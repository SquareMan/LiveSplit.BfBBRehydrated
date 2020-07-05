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
            this.doThing = new System.Windows.Forms.CheckBox();
            this.flowLayoutSplits = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // doThing
            // 
            this.doThing.AutoSize = true;
            this.doThing.Location = new System.Drawing.Point(3, 3);
            this.doThing.Name = "doThing";
            this.doThing.Size = new System.Drawing.Size(92, 17);
            this.doThing.TabIndex = 0;
            this.doThing.Text = "Do The Thing\r\n";
            this.doThing.UseVisualStyleBackColor = true;
            // 
            // flowLayoutSplits
            // 
            this.flowLayoutSplits.AllowDrop = true;
            this.flowLayoutSplits.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutSplits.AutoScroll = true;
            this.flowLayoutSplits.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutSplits.Location = new System.Drawing.Point(0, 26);
            this.flowLayoutSplits.Name = "flowLayoutSplits";
            this.flowLayoutSplits.Size = new System.Drawing.Size(233, 200);
            this.flowLayoutSplits.TabIndex = 0;
            this.flowLayoutSplits.WrapContents = false;
            // 
            // RehydratedSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutSplits);
            this.Controls.Add(this.doThing);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "RehydratedSettings";
            this.Size = new System.Drawing.Size(233, 226);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.CheckBox doThing;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutSplits;

        #endregion
    }
}