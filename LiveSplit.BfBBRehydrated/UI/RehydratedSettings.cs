using System.Windows.Forms;
using System.Xml;
using LiveSplit.Model;

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

        public void AddXmlItem<T>(XmlDocument document, XmlElement xmlSettings, string name, T value) {
            XmlElement xmlItem = document.CreateElement(name);
            xmlItem.InnerText = value.ToString();
            xmlSettings.AppendChild(xmlItem);
        }
        
        public bool GetXmlBoolItem(XmlNode node, string path, bool defaultValue) {
            XmlNode item = node.SelectSingleNode(path);
            bool value = defaultValue;
            if (item != null) {
                bool.TryParse(item.InnerText, out value);
            }
            return value;
        }
        
        public XmlNode UpdateSettings(XmlDocument document)
        {
            XmlElement xmlSettings = document.CreateElement("Settings");

            AddXmlItem(document,xmlSettings,"CheckTest", doThing.Checked);

            XmlElement xmlSplits = document.CreateElement("Splits");
            xmlSettings.AppendChild(xmlSplits);

            // Create an XML node for each of the user's splits
            // TODO: Store splitting logic settings here instead of split name
            foreach(ISegment segment in _state.Run)
            {
                XmlElement xmlSplit = document.CreateElement("Split");
                xmlSplits.AppendChild(xmlSplit);
                xmlSplit.InnerText = segment.Name;
            }

            return xmlSettings;
        }

        public void InitializeSettings(XmlNode node)
        {
            var doThingChecked = GetXmlBoolItem(node, ".//CheckTest", false);
            doThing.Checked = doThingChecked;

            flowLayoutSplits.SuspendLayout();
            flowLayoutSplits.Controls.Clear();
            XmlNodeList splitNodes = node.SelectNodes(".//Splits/Split");
            foreach (XmlNode splitNode in splitNodes)
            {
                TextBox splitBox = new TextBox();
                splitBox.Text = splitNode.InnerText;
                flowLayoutSplits.Controls.Add(splitBox);
            }
            flowLayoutSplits.ResumeLayout(true);
        }
    }
}