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

            if (_split.Type == SplitType.SpatCount)
            {
                txtValue.Visible = true;
                txtValue.Text = _split.SubType.ToString();
            }

            cboType.SelectedIndexChanged += cboType_SelectedIndexChanged;
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _split.Type = (SplitType) cboType.SelectedIndex;

            if (_split.Type == SplitType.SpatCount)
            {
                txtValue.Visible = true;
                txtValue.Text = _split.SubType.ToString();
            }
            else
            {
                txtValue.Visible = false;
                _split.SubType = 0;
            }
        }

        private void cboType_Validating(object sender, CancelEventArgs e)
        {
            if (cboType.SelectedIndex < 0)
            {
                cboType.SelectedIndex = (int) SplitType.Manual;
            }
        }

        private void txtValue_Validating(object sender, CancelEventArgs e)
        {
            if (int.TryParse(txtValue.Text, out var newNum))
            {
                _split.SubType = newNum;
            }
            else
            {
                txtValue.Text = _split.SubType.ToString();
            }
        }
    }
}