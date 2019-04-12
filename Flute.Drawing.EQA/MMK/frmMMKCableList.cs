using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
// using System.Linq;
using System.Text;
using System.Windows.Forms;

using Flute.UI.WinForms;

namespace Flute.Drawing.EQA
{
    public partial class frmMMKCableList : Flute.UI.WinForms.frmDialog
    {
        #region .UI Elements.

        private System.Windows.Forms.RadioButton radioBtnLangSimpChinese;
        private System.Windows.Forms.RadioButton radioBtnLangEnglish;

        #endregion // UI Elements

        #region .Parameters.

        private DrawingLanguage _language = DrawingLanguage.English;
        public DrawingLanguage Language { get { return _language; } }

        public string ApprovedBy { get { return this.tbApprovedBy.Text; } }
        public string CheckedBy { get { return this.tbCheckedBy.Text; } }
        public string DesignBy { get { return this.tbDesignedBy.Text; } }
        public string MadeBy { get { return this.tbMadeBy.Text; } }
        public string DrawingNo { get { return this.tbDrawingNo.Text; } }
        public string Speciality { get { return this.tbSpeciality.Text; } }
        public string Stage { get { return this.tbStage.Text; } }
        public string Date { get { return this.tbDate.Text; } }
        public string ContractNo { get { return this.tbContractNo.Text; } }
        public string Revision { get { return this.tbRevision.Text; } }
        public string TopLevelNo { get { return this.tbTopLevelNo.Text; } }

        public string TemplatePath { get { return this.tbTemplatePath.Text; } }
        public string DestPath { get { return this.tbDestPath.Text; } }
        
        #endregion

        public frmMMKCableList()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "MMK冷轧公辅设备表导出";
            
            // 按钮位置
            btnApply.Location = new Point(186, 16);
            btnOK.Location = new Point(267, 16);
            btnCancel.Location = new Point(348, 16);

            //
            // 版本
            //
            radioBtnLangSimpChinese = new RadioButton();
            radioBtnLangSimpChinese.Checked = false;
            radioBtnLangSimpChinese.Text = "中文版";
            radioBtnLangEnglish = new RadioButton();
            radioBtnLangEnglish.Checked = true;
            radioBtnLangEnglish.Text = "英俄文版";
            radioBtnLangSimpChinese.Click += radioBtnLang_Click;
            radioBtnLangEnglish.Click += radioBtnLang_Click;

            flowLayoutPanelLanguage.Controls.Add(radioBtnLangSimpChinese);
            flowLayoutPanelLanguage.Controls.Add(radioBtnLangEnglish);            
            
            //
            // 图框
            //
            tbApprovedBy.Text = "邓志刚";
            tbCheckedBy.Text = "姚秀元";
            tbDesignedBy.Text = "吴经纬";
            tbMadeBy.Text = "";
            tbDrawingNo.Text = "";
            tbSpeciality.Text = "Instrument";
            tbStage.Text = "DE";
            tbDate.Text = DateTime.Now.Year.ToString() + "." + DateTime.Now.Month.ToString();
            tbContractNo.Text = "E152821";
            tbRevision.Text = "";
            tbTopLevelNo.Text = "";
            //
            // 文件路径
            //
            tbTemplatePath.Enabled = true;
            tbTemplatePath.Text = Application.StartupPath + @"\Template\MMK_Cable_en.xlt";
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

        private void radioBtnLang_Click(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Text == radioBtnLangSimpChinese.Text) {
                if ((sender as RadioButton).Checked) {
                    _language = DrawingLanguage.SimplifiedChinese;
                    tbTemplatePath.Text = Application.StartupPath + @"\Template\MMK_chs.xlt";
                }
            } else if ((sender as RadioButton).Text == radioBtnLangEnglish.Text) {
                if ((sender as RadioButton).Checked) {
                    _language = DrawingLanguage.English;
                    tbTemplatePath.Text = Application.StartupPath + @"\Template\MMK_Cable_en.xlt";
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {            
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void btnCancel_Click(object sender , EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
