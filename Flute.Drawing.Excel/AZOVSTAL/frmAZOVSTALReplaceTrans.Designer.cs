namespace Flute.Drawing.Excel
{
    partial class frmAZOVSTALReplaceTrans
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelLanguage = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.None;
            this.panel2.Location = new System.Drawing.Point(0, -1);
            this.panel2.Size = new System.Drawing.Size(425, 215);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(163, 15);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(244, 15);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(325, 15);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanelLanguage);
            this.groupBox1.Location = new System.Drawing.Point(8, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 55);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "语言";
            // 
            // flowLayoutPanelLanguage
            // 
            this.flowLayoutPanelLanguage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelLanguage.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanelLanguage.Name = "flowLayoutPanelLanguage";
            this.flowLayoutPanelLanguage.Size = new System.Drawing.Size(407, 35);
            this.flowLayoutPanelLanguage.TabIndex = 0;
            // 
            // frmAZOVSTALReplaceTrans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 262);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmAZOVSTALReplaceTrans";
            this.Text = "frmAZOVSTALReplaceTrans";
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelLanguage;
    }
}