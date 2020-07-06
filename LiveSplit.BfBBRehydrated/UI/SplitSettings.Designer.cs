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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
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
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(244, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(203, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // SplitSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.splitLabel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SplitSettings";
            this.Size = new System.Drawing.Size(450, 27);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label splitLabel;

        #endregion
    }
}