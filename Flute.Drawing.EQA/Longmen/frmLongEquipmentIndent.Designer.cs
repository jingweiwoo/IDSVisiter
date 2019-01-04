namespace Flute.Drawing
{
    partial class frmLongEquipmentIndent
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDestPath = new System.Windows.Forms.Button();
            this.btnTemplatePath = new System.Windows.Forms.Button();
            this.tbDestPath = new System.Windows.Forms.TextBox();
            this.tbTemplatePath = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Size = new System.Drawing.Size(548, 159);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(303, 15);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(384, 15);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(465, 15);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox3.Controls.Add(this.btnDestPath);
            this.groupBox3.Controls.Add(this.btnTemplatePath);
            this.groupBox3.Controls.Add(this.tbDestPath);
            this.groupBox3.Controls.Add(this.tbTemplatePath);
            this.groupBox3.Location = new System.Drawing.Point(15, 71);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(523, 78);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "文件路径";
            // 
            // btnDestPath
            // 
            this.btnDestPath.Location = new System.Drawing.Point(426, 47);
            this.btnDestPath.Name = "btnDestPath";
            this.btnDestPath.Size = new System.Drawing.Size(92, 21);
            this.btnDestPath.TabIndex = 3;
            this.btnDestPath.Text = "button2";
            this.btnDestPath.UseVisualStyleBackColor = true;
            // 
            // btnTemplatePath
            // 
            this.btnTemplatePath.Location = new System.Drawing.Point(426, 20);
            this.btnTemplatePath.Name = "btnTemplatePath";
            this.btnTemplatePath.Size = new System.Drawing.Size(92, 21);
            this.btnTemplatePath.TabIndex = 2;
            this.btnTemplatePath.Text = "button1";
            this.btnTemplatePath.UseVisualStyleBackColor = true;
            // 
            // tbDestPath
            // 
            this.tbDestPath.Location = new System.Drawing.Point(6, 47);
            this.tbDestPath.Name = "tbDestPath";
            this.tbDestPath.Size = new System.Drawing.Size(414, 21);
            this.tbDestPath.TabIndex = 1;
            // 
            // tbTemplatePath
            // 
            this.tbTemplatePath.Location = new System.Drawing.Point(6, 20);
            this.tbTemplatePath.Name = "tbTemplatePath";
            this.tbTemplatePath.Size = new System.Drawing.Size(414, 21);
            this.tbTemplatePath.TabIndex = 0;
            // 
            // frmLongEquipmentIndent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(548, 206);
            this.Name = "frmLongEquipmentIndent";
            this.panel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnDestPath;
        private System.Windows.Forms.Button btnTemplatePath;
        private System.Windows.Forms.TextBox tbDestPath;
        private System.Windows.Forms.TextBox tbTemplatePath;
    }
}
