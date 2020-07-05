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

            SettingsHelper.CreateSetting(document, xmlSettings, "CheckTest", doThing.Checked);

            XmlElement xmlSplits = document.CreateElement("Splits");
            xmlSettings.AppendChild(xmlSplits);

            // Create an XML node for each of the user's splits
            // TODO: Store splitting logic settings here instead of split name
            foreach(ISegment segment in _state.Run)
            {
                XmlElement xmlSplit = document.CreateElement("Split");
                xmlSplits.AppendChild(xmlSplit);
                
                SettingsHelper.CreateSetting(document, xmlSplit, "Name", segment.Name);
                SettingsHelper.CreateSetting(document, xmlSplit, "SplitType", SplitType.Manual);
            }

            return xmlSettings;
        }

        public void SetSettings(XmlNode node)
        {
            var doThingChecked = SettingsHelper.ParseBool(node["CheckTest"]);
            doThing.Checked = doThingChecked;

            XmlNodeList splitNodes = node.SelectNodes(".//Splits/Split");
            if (splitNodes != null)
            {
                foreach (XmlElement splitNode in splitNodes)
                {
                    //TODO: Deserialize split logic once implemented
                }
            }
            
            UpdateSplitControls();
        }

        private void UpdateSplitControls()
        {
            flowLayoutSplits.SuspendLayout();
            flowLayoutSplits.Controls.Clear();
            
            foreach (ISegment segment in _state.Run)
            {
                SplitSettings splitBox = new SplitSettings(segment.Name);
                flowLayoutSplits.Controls.Add(splitBox);
            }
            
            flowLayoutSplits.ResumeLayout(true);
        }

        private void RehydratedSettings_Load(object sender, EventArgs e)
        {
            UpdateSplitControls();
        }
    }
}