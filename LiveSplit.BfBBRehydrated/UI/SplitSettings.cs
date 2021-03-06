﻿using System;
using System.ComponentModel;
using System.Drawing;
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

        public void UpdateControl()
        {
            splitLabel.Text = _split.Name;
            cboType.DataSource = Enum.GetValues(typeof(SplitType));
            cboType.SelectedIndex = (int) _split.Type;
            UpdateVisibilities();
        }

        private void UpdateVisibilities()
        {
            switch (_split.Type)
            {
                case SplitType.IndividualLevelComplete:
                    txtValue.Visible = false;
                    cboSubType.Visible = true;
                    cboSubType.DataSource = Enum.GetValues(typeof(IndividualLevelCompletion));
                    cboSubType.SelectedIndex = _split.SubType;
                    break;
                case SplitType.SpatCount:
                    txtValue.Visible = true;
                    cboSubType.Visible = false;
                    txtValue.Text = _split.SubType.ToString();
                    break;
                case SplitType.LevelTransition:
                    txtValue.Visible = false;
                    cboSubType.Visible = true;
                    cboSubType.DataSource = Enum.GetValues(typeof(Level));
                    cboSubType.SelectedIndex = _split.SubType;
                    break;
                case SplitType.CutsceneStart:
                    txtValue.Visible = false;
                    cboSubType.Visible = true;
                    cboSubType.DataSource = Enum.GetValues(typeof(Sequence));
                    cboSubType.SelectedIndex = _split.SubType;
                    break;
                default:
                    txtValue.Visible = false;
                    cboSubType.Visible = false;
                    _split.SubType = 0;
                    break;
            }
        }

        private void cboType_Validating(object sender, CancelEventArgs e)
        {
            if (cboType.SelectedIndex < 0)
            {
                cboType.SelectedIndex = (int)_split.Type;
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

        private void cboSubType_Validating(object sender, CancelEventArgs e)
        {
            if (cboSubType.SelectedIndex < 0)
            {
                cboSubType.SelectedIndex = _split.SubType;
            }
        }

        private void splitLabel_MouseDown(object sender, MouseEventArgs e)
        {
            DoDragDrop(this,DragDropEffects.All);
        }

        private void cboType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Check if the user re-selected the same type
            if (cboType.SelectedIndex == (int) _split.Type)
            {
                return;
            }
            
            _split.Type = (SplitType) cboType.SelectedIndex;
            _split.SubType = 0;

            //Toggle visibilities as necessary
            UpdateVisibilities();
        }

        private void cboSubType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _split.SubType = cboSubType.SelectedIndex;
        }
    }
}