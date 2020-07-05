using System;
using System.Windows.Forms;
using LiveSplit.BfBBRehydrated.Logic;

namespace LiveSplit.BfBBRehydrated.UI
{
    public partial class SplitSettings : UserControl
    {
        public SplitSettings(string segmentName)
        {
            InitializeComponent();
            splitLabel.Text = segmentName;
            comboBox1.DataSource = Enum.GetNames(typeof(SplitType));
            Dock = DockStyle.Right;
        }
    }
}