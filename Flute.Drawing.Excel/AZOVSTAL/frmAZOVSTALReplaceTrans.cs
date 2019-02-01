using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Flute.UI.WinForms;

namespace Flute.Drawing.Excel
{
    public partial class frmAZOVSTALReplaceTrans : Flute.UI.WinForms.frmDialog
    {
        public bool SelectedEnglishTrans { get; set; }
        public bool SelectedRussianTrans { get; set; }

        public frmAZOVSTALReplaceTrans()
        {
            InitializeComponent();

            this.Text = "替换英俄语翻译";

            CheckBox cbSelectedEnglish = new CheckBox();
            CheckBox cbSelectedRussian = new CheckBox();

            cbSelectedEnglish.Text = "英语";
            cbSelectedEnglish.Checked = true;

            cbSelectedRussian.Text = "俄语";
            cbSelectedRussian.Checked = true;

            flowLayoutPanelLanguage.Controls.Add(cbSelectedEnglish);
            flowLayoutPanelLanguage.Controls.Add(cbSelectedRussian);

            this.btnApply.Visible = false;

            this.btnOK.Visible = true;
            this.btnOK.Text = "确定(&O)";

            this.btnCancel.Visible = true;
            this.btnCancel.Text = "取消(&C)";
  
            btnOK.Click += (sender, e) => {
                SelectedEnglishTrans = cbSelectedEnglish.Checked;
                SelectedRussianTrans = cbSelectedRussian.Checked;

                this.DialogResult = DialogResult.OK;
                this.Hide();
            };

            btnCancel.Click += (sendr, e) => {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };
           

            //// 按钮位置
            //btnApply.Location = new Point(86, 16);
            btnCancel.Location = new Point(325, 15);
        }

    }
}
