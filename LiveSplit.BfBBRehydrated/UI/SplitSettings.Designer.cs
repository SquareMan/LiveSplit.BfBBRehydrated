using System.ComponentModel;

namespace LiveSplit.BfBBRehydrated.UI
{
    partial class SplitSettings
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
            this.splitLabel = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // splitLabel
            // 
            this.splitLabel.AutoEllipsis = true;
            this.splitLabel.Location = new System.Drawing.Point(3, 3);
            this.splitLabel.Name = "splitLabel";
            this.splitLabel.Size = new System.Drawing.Size(108, 21);
            this.splitLabel.TabIndex = 0;
            this.splitLabel.Text = "The cool split thing that happens here. Gaming Time ye";
            this.splitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboType
            // 
            this.cboType.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(244, 3);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(203, 21);
            this.cboType.TabIndex = 1;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            this.cboType.Validating += new System.ComponentModel.CancelEventHandler(this.cboType_Validating);
            // 
            // SplitSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.splitLabel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SplitSettings";
            this.Size = new System.Drawing.Size(450, 27);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label splitLabel;

        #endregion
    }
}