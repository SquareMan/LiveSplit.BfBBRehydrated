using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.BfBBRehydrated.Logic;
using LiveSplit.Model;
using LiveSplit.Options;
using LiveSplit.UI;

namespace LiveSplit.BfBBRehydrated.UI
{
    public partial class RehydratedSettings : UserControl
    {
        private LiveSplitState _state;
        
        public RehydratedSettings(LiveSplitState state)
        {
            InitializeComponent();

            _state = state;
            
            // Cause this form to fill it's container in the settings menu
            Dock = DockStyle.Fill;
        }
        
        public XmlNode GetSettings(XmlDocument document)
        {
            XmlElement xmlSettings = document.CreateElement("Settings");

            SettingsHelper.CreateSetting(document, xmlSettings, "ResetPreference",
                AutosplitterSettings.ResetPreference);

            XmlElement xmlSplits = document.CreateElement("Splits");
            xmlSettings.AppendChild(xmlSplits);

            // Create an XML node for each of the user's splits
            foreach(Split split in AutosplitterSettings.Autosplits)
            {
                XmlElement xmlSplit = document.CreateElement("Split");
                xmlSplits.AppendChild(xmlSplit);
                
                SettingsHelper.CreateSetting(document, xmlSplit, "Name", split.Name);
                SettingsHelper.CreateSetting(document, xmlSplit, "SplitType", split.Type);
                SettingsHelper.CreateSetting(document, xmlSplit, "SubType", split.SubType);
            }

            return xmlSettings;
        }

        public void SetSettings(XmlNode node)
        {
            AutosplitterSettings.ResetPreference = SettingsHelper.ParseEnum<ResetPreference>(node["ResetPreference"]);
            
            XmlReadSplits(node.SelectNodes(".//Splits/Split"));
            UpdateSplitControls();
        }

        /// <summary>
        /// Reads XML serialized by ASL script and ports the settings over to our format
        /// </summary>
        /// <param name="node"></param>
        public bool PortSettings(XmlNode node)
        {
            XmlNodeList settings = node.SelectNodes(".//CustomSettings/Setting");

            if (settings == null)
            {
                return false;
            }

            bool reset = false;
            bool misc = false;
            bool spatSplit = false;
            List<Split> convertedSplits = new List<Split>();
            
            // Extract information from XML
            foreach (XmlNode setting in settings)
            {
                if (setting.Attributes == null) continue;
                
                var id = setting.Attributes["id"];
                
                // Parse the non spatCount settings
                switch (id.InnerText)
                {
                    case "reset" when setting.InnerText == "False":
                        AutosplitterSettings.ResetPreference = ResetPreference.Never;
                        break;
                    case "reset":
                        reset = true;
                        break;
                    case "mainMenuReset" when reset && setting.InnerText == "True":
                        AutosplitterSettings.ResetPreference = ResetPreference.MainMenu;
                        break;
                    case "newGameReset" when reset && setting.InnerText == "True":
                        AutosplitterSettings.ResetPreference = ResetPreference.NewGame;
                        break;
                    case "misc" when setting.InnerText == "True":
                        misc = true;
                        break;
                    case "warpSplit" when misc && setting.InnerText == "True":
                        convertedSplits.Add(new Split{Type = SplitType.LevelTransition, SubType = (int)Level.ChumBucketLab});
                        break;
                    case "spatSplit" when setting.InnerText == "True":
                        spatSplit = true;
                        break;
                }

                // Parse the spat count settings, adding new splits for each ticked box.
                if (spatSplit && id.InnerText.Contains("spat") && setting.InnerText == "True")
                {
                    if(int.TryParse(id.InnerText.Substring("spat".Length), out int spatNumber))
                    {
                        convertedSplits.Add(new Split {Type = SplitType.SpatCount, SubType = spatNumber});
                    }
                }
            }
            
            // Add splits that were able to be extracted from the old settings
            
            if (convertedSplits.Count > 0)
            {
                for (int i = 0; i < convertedSplits.Count; i++)
                {
                    if (i >= AutosplitterSettings.Autosplits.Count)
                    {
                        AutosplitterSettings.Autosplits.Add(convertedSplits[i]);
                    }
                    else
                    {
                        AutosplitterSettings.Autosplits[i] = convertedSplits[i];
                    } 
                }
            }

            // If the user was using any manual splits we won't have an autosplit for each split.
            // To ensure that the GameEnd split as at the end, add autosplits until we match the number of splits the user has.
            while (AutosplitterSettings.Autosplits.Count < _state.Run.Count)
            {
                AutosplitterSettings.Autosplits.Add(new Split {Type = SplitType.Manual, SubType = 0});
            }
            
            // Set final split to game end.
            AutosplitterSettings.Autosplits[_state.Run.Count - 1] = new Split {Type = SplitType.GameEnd, SubType = 0}; 

            return true;
        }

        private void XmlReadSplits(XmlNodeList splitNodes)
        {
            if (splitNodes == null) return;

            for (int i = 0; i < splitNodes.Count; i++)
            {
                Split currentSplit;
                if (i >= AutosplitterSettings.Autosplits.Count)
                {
                    currentSplit = new Split();
                    AutosplitterSettings.Autosplits.Add(currentSplit);
                }
                else
                {
                    currentSplit = AutosplitterSettings.Autosplits[i];
                } 

                // Assign saved split options
                Enum.TryParse(SettingsHelper.ParseString(splitNodes[i]["SplitType"], SplitType.Manual.ToString()), out currentSplit.Type);
                currentSplit.SubType = SettingsHelper.ParseInt(splitNodes[i]["SubType"]);
            }
            
            
        }

        private void UpdateSplitControls()
        {
            // Ensure Autosplits are up to date
            bool changed = false;
            for (var i = 0; i < _state.Run.Count; i++)
            {
                ISegment segment = _state.Run[i];

                if (i >= AutosplitterSettings.Autosplits.Count)
                {
                    AutosplitterSettings.Autosplits.Add(new Split());
                    changed = true;
                }
                
                Split autosplit = AutosplitterSettings.Autosplits[i];
                
                if (segment.Name != autosplit.Name)
                {
                    autosplit.Name = segment.Name;
                    changed = true;
                }
            }
            
            //Remove any extra splits
            while (AutosplitterSettings.Autosplits.Count > _state.Run.Count)
            {
                AutosplitterSettings.Autosplits.RemoveAt(AutosplitterSettings.Autosplits.Count - 1);
                changed = true;
            }

            if (changed)
            {
                flowLayoutSplits.SuspendLayout();
                flowLayoutSplits.Controls.Clear();
            
                foreach (Split split in AutosplitterSettings.Autosplits)
                {
                    SplitSettings splitBox = new SplitSettings(split);
                    flowLayoutSplits.Controls.Add(splitBox);
                }
            
                flowLayoutSplits.ResumeLayout(true);
            }
        }

        private void RehydratedSettings_Load(object sender, EventArgs e)
        {
            UpdateSplitControls();

            // Update radio controls for reset preference
            rdoNewGame.CheckedChanged -= rdoNewGame_CheckedChanged;
            rdoMainMenu.CheckedChanged -= rdoMainMenu_CheckedChanged;
            rdoNever.CheckedChanged -= rdoNever_CheckedChanged;
            
            switch (AutosplitterSettings.ResetPreference)
            {
                case ResetPreference.NewGame:
                    rdoNewGame.Checked = true;
                    break;
                case ResetPreference.MainMenu:
                    rdoMainMenu.Checked = true;
                    break;
                case ResetPreference.Never:
                    rdoNever.Checked = true;
                    break;
            }
            
            rdoNewGame.CheckedChanged += rdoNewGame_CheckedChanged;
            rdoMainMenu.CheckedChanged += rdoMainMenu_CheckedChanged;
            rdoNever.CheckedChanged += rdoNever_CheckedChanged;
        }

        private void rdoNewGame_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNewGame.Checked)
            {
                AutosplitterSettings.ResetPreference = ResetPreference.NewGame;
            }
        }

        private void rdoMainMenu_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoMainMenu.Checked)
            {
                AutosplitterSettings.ResetPreference = ResetPreference.MainMenu;
            }
        }

        private void rdoNever_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNever.Checked)
            {
                AutosplitterSettings.ResetPreference = ResetPreference.Never;
            }
        }

        /// <summary>
        /// Swap splits when a split is dragged.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flowLayoutSplits_DragOver(object sender, DragEventArgs e)
        {
            SplitSettings draggedControl = (SplitSettings)e.Data.GetData(typeof(SplitSettings));
            SplitSettings coveredControl = flowLayoutSplits.GetChildAtPoint(flowLayoutSplits.PointToClient(new Point(e.X, e.Y))) as SplitSettings;
            
            if (draggedControl != coveredControl && coveredControl != null) {
                int draggedIndex = flowLayoutSplits.Controls.GetChildIndex(draggedControl);
                int coveredIndex = flowLayoutSplits.Controls.GetChildIndex(coveredControl, false);

                if (Math.Abs(draggedIndex - coveredIndex) > 1)
                {
                    coveredIndex = coveredIndex > draggedIndex ? draggedIndex + 1 : draggedIndex - 1;
                    coveredControl = (SplitSettings)flowLayoutSplits.Controls[coveredIndex];
                }

                Split draggedSplit = AutosplitterSettings.Autosplits[draggedIndex];
                Split coveredSplit = AutosplitterSettings.Autosplits[coveredIndex];
                
                string tmpName = draggedSplit.Name;
                draggedSplit.Name = coveredSplit.Name;
                coveredSplit.Name = tmpName;
                
                AutosplitterSettings.Autosplits[draggedIndex] = coveredSplit;
                AutosplitterSettings.Autosplits[coveredIndex] = draggedSplit;
                
                draggedControl.UpdateControl();
                coveredControl.UpdateControl();
                flowLayoutSplits.Controls.SetChildIndex(draggedControl, coveredIndex);
                flowLayoutSplits.Invalidate();
            }
        }
    }
}