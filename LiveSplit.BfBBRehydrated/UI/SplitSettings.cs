using System;
using System.ComponentModel;
using System.Windows.Forms;
using LiveSplit.BfBBRehydrated.Logic;

namespace LiveSplit.BfBBRehydrated.UI
{
    public partial class SplitSettings : UserControl
    {
        private Split _split;
        
        public SplitSettings(Split split)
        {
            InitializeComponent();
            SetSplit(split);
        }

        public void SetSplit(Split split)
        {
            _split = split;
            UpdateControl();
        }

        private void UpdateControl()
        {
            cboType.SelectedIndexChanged -= cboType_SelectedIndexChanged;
            
            splitLabel.Text = _split.Name;
            cboType.DataSource = Enum.GetValues(typeof(SplitType));
            cboType.SelectedIndex = (int) _split.Type;

            cboType.SelectedIndexChanged += cboType_SelectedIndexChanged;
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _split.Type = (SplitType) cboType.SelectedIndex;
        }

        private void cboType_Validating(object sender, CancelEventArgs e)
        {
            if (cboType.SelectedIndex < 0)
            {
                cboType.SelectedIndex = (int) SplitType.Manual;
            }
        }
    }
}