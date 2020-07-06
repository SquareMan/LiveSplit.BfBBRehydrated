using System;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.BfBBRehydrated.Logic;
using LiveSplit.Model;
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
            }

            return xmlSettings;
        }

        public void SetSettings(XmlNode node)
        {
            AutosplitterSettings.ResetPreference = SettingsHelper.ParseEnum<ResetPreference>(node["ResetPreference"]);
            
            XmlReadSplits(node.SelectNodes(".//Splits/Split"));
            UpdateSplitControls();
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
    }
}