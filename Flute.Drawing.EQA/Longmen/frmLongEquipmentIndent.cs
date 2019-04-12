using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Flute.Drawing
{
    public partial class frmLongEquipmentIndent : Flute.UI.WinForms.frmDialog
    {
        #region .Parameters.

        private DrawingLanguage _language = DrawingLanguage.SimplifiedChinese;
        public DrawingLanguage Language { get { return _language; } }

        public string TemplatePath { get { return this.tbTemplatePath.Text; } }
        public string DestPath { get { return this.tbDestPath.Text; } }

        #endregion

        public frmLongEquipmentIndent()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "MMK冷轧公辅设备表导出";

            // 按钮位置
            btnApply.Location = new Point(186, 16);
            btnOK.Location = new Point(267, 16);
            btnCancel.Location = new Point(348, 16);

            //
            // 文件路径
            //
            tbTemplatePath.Enabled = true;
            tbTemplatePath.Text = Application.StartupPath + @"\Template\Long_EquipmentIndent_chs.xlt";
            btnTemplatePath.Visible = false;

            tbDestPath.Enabled = false;
            tbDestPath.Text = "";
            btnDestPath.Visible = false;
            //
            // Command Buttons
            //
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Click += btnCancel_Click;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.Click += btnOK_Click;
            this.btnApply.Visible = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
