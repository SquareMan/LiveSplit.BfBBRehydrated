using System.ComponentModel;

namespace LiveSplit.BfBBRehydrated.UI
{
    partial class RehydratedSettings
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutSplits = new System.Windows.Forms.FlowLayoutPanel();
            this.rdoNever = new System.Windows.Forms.RadioButton();
            this.rdoMainMenu = new System.Windows.Forms.RadioButton();
            this.rdoNewGame = new System.Windows.Forms.RadioButton();
            this.grpReset = new System.Windows.Forms.GroupBox();
            this.lblRevision = new System.Windows.Forms.Label();
            this.lblStartCondition = new System.Windows.Forms.Label();
            this.cboStartType = new System.Windows.Forms.ComboBox();
            this.cboStartSubType = new System.Windows.Forms.ComboBox();
            this.grpReset.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutSplits
            // 
            this.flowLayoutSplits.AllowDrop = true;
            this.flowLayoutSplits.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutSplits.AutoScroll = true;
            this.flowLayoutSplits.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutSplits.Location = new System.Drawing.Point(0, 92);
            this.flowLayoutSplits.Name = "flowLayoutSplits";
            this.flowLayoutSplits.Size = new System.Drawing.Size(450, 134);
            this.flowLayoutSplits.TabIndex = 10;
            this.flowLayoutSplits.WrapContents = false;
            this.flowLayoutSplits.DragOver += new System.Windows.Forms.DragEventHandler(this.flowLayoutSplits_DragOver);
            // 
            // rdoNever
            // 
            this.rdoNever.Location = new System.Drawing.Point(183, 19);
            this.rdoNever.Name = "rdoNever";
            this.rdoNever.Size = new System.Drawing.Size(57, 17);
            this.rdoNever.TabIndex = 3;
            this.rdoNever.Text = "Never";
            this.rdoNever.UseVisualStyleBackColor = true;
            this.rdoNever.CheckedChanged += new System.EventHandler(this.rdoNever_CheckedChanged);
            // 
            // rdoMainMenu
            // 
            this.rdoMainMenu.Location = new System.Drawing.Point(92, 19);
            this.rdoMainMenu.Name = "rdoMainMenu";
            this.rdoMainMenu.Size = new System.Drawing.Size(85, 17);
            this.rdoMainMenu.TabIndex = 2;
            this.rdoMainMenu.Text = "Main Menu";
            this.rdoMainMenu.UseVisualStyleBackColor = true;
            this.rdoMainMenu.CheckedChanged += new System.EventHandler(this.rdoMainMenu_CheckedChanged);
            // 
            // rdoNewGame
            // 
            this.rdoNewGame.Location = new System.Drawing.Point(6, 19);
            this.rdoNewGame.Name = "rdoNewGame";
            this.rdoNewGame.Size = new System.Drawing.Size(80, 17);
            this.rdoNewGame.TabIndex = 1;
            this.rdoNewGame.Text = "New Game";
            this.rdoNewGame.UseVisualStyleBackColor = true;
            this.rdoNewGame.CheckedChanged += new System.EventHandler(this.rdoNewGame_CheckedChanged);
            // 
            // grpReset
            // 
            this.grpReset.Controls.Add(this.rdoNewGame);
            this.grpReset.Controls.Add(this.rdoMainMenu);
            this.grpReset.Controls.Add(this.rdoNever);
            this.grpReset.Location = new System.Drawing.Point(10, 10);
            this.grpReset.Margin = new System.Windows.Forms.Padding(10);
            this.grpReset.Name = "grpReset";
            this.grpReset.Size = new System.Drawing.Size(246, 42);
            this.grpReset.TabIndex = 5;
            this.grpReset.TabStop = false;
            this.grpReset.Text = "Auto Reset Preference";
            // 
            // lblRevision
            // 
            this.lblRevision.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblRevision.Location = new System.Drawing.Point(269, 26);
            this.lblRevision.Name = "lblRevision";
            this.lblRevision.Size = new System.Drawing.Size(178, 23);
            this.lblRevision.TabIndex = 6;
            this.lblRevision.Text = "Game Revision: 000000";
            this.lblRevision.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStartCondition
            // 
            this.lblStartCondition.AutoEllipsis = true;
            this.lblStartCondition.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.lblStartCondition.Location = new System.Drawing.Point(3, 65);
            this.lblStartCondition.Margin = new System.Windows.Forms.Padding(3);
            this.lblStartCondition.Name = "lblStartCondition";
            this.lblStartCondition.Size = new System.Drawing.Size(160, 21);
            this.lblStartCondition.TabIndex = 7;
            this.lblStartCondition.Text = "Timer Start";
            this.lblStartCondition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboStartType
            // 
            this.cboStartType.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboStartType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboStartType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStartType.FormattingEnabled = true;
            this.cboStartType.Location = new System.Drawing.Point(169, 65);
            this.cboStartType.Name = "cboStartType";
            this.cboStartType.Size = new System.Drawing.Size(136, 21);
            this.cboStartType.TabIndex = 8;
            this.cboStartType.SelectionChangeCommitted += new System.EventHandler(this.cboStartType_SelectionChangeCommitted);
            // 
            // cboStartSubType
            // 
            this.cboStartSubType.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboStartSubType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboStartSubType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStartSubType.FormattingEnabled = true;
            this.cboStartSubType.Location = new System.Drawing.Point(311, 65);
            this.cboStartSubType.Name = "cboStartSubType";
            this.cboStartSubType.Size = new System.Drawing.Size(136, 21);
            this.cboStartSubType.TabIndex = 9;
            this.cboStartSubType.Visible = false;
            this.cboStartSubType.SelectionChangeCommitted += new System.EventHandler(this.cboStartSubType_SelectionChangeCommitted);
            // 
            // RehydratedSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblStartCondition);
            this.Controls.Add(this.cboStartType);
            this.Controls.Add(this.cboStartSubType);
            this.Controls.Add(this.lblRevision);
            this.Controls.Add(this.grpReset);
            this.Controls.Add(this.flowLayoutSplits);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "RehydratedSettings";
            this.Size = new System.Drawing.Size(450, 226);
            this.Load += new System.EventHandler(this.RehydratedSettings_Load);
            this.grpReset.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ComboBox cboStartSubType;
        private System.Windows.Forms.ComboBox cboStartType;
        private System.Windows.Forms.Label lblStartCondition;

        private System.Windows.Forms.FlowLayoutPanel flowLayoutSplits;
        private System.Windows.Forms.GroupBox grpReset;
        private System.Windows.Forms.Label lblRevision;
        private System.Windows.Forms.RadioButton rdoMainMenu;
        private System.Windows.Forms.RadioButton rdoNever;
        private System.Windows.Forms.RadioButton rdoNewGame;

        #endregion
    }
}