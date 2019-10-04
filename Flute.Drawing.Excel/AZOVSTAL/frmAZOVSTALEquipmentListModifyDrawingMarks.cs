using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
// using System.Linq;
using System.Text;
using System.Windows.Forms;

using Flute.UI.WinForms;

using Flute.DataStruct.IDS;

namespace Flute.Drawing.Excel
{
    public partial class frmAZOVSTALEquipmentListModifyDrawingMarks : Flute.UI.WinForms.frmDialog
    {
        #region .UI Elements.
        /*
        private System.Windows.Forms.CheckBox chkBoxLoopNo;
        private System.Windows.Forms.CheckBox chkBoxTagNo;
        private System.Windows.Forms.CheckBox chkBoxItems;
        private System.Windows.Forms.CheckBox chkBoxEqpName;
        private System.Windows.Forms.CheckBox chkBoxEqpType;
        private System.Windows.Forms.CheckBox chkBoxSupplier;
        private System.Windows.Forms.CheckBox chkBoxMeasuringRangeMin;
        private System.Windows.Forms.CheckBox chkBoxMeasuringRangeMax;
        private System.Windows.Forms.CheckBox chkBoxMeasuringRangeUnit;
        private System.Windows.Forms.CheckBox chkBoxInputSignal;
        private System.Windows.Forms.CheckBox chkBoxOutputSignal;
        private System.Windows.Forms.CheckBox chkBoxPowerSupply;
        private System.Windows.Forms.CheckBox chkBoxSpec;
        private System.Windows.Forms.CheckBox chkBoxQuantity;
        private System.Windows.Forms.CheckBox chkBoxLocation;
        private System.Windows.Forms.CheckBox chkBoxOperationRangeMin;
        private System.Windows.Forms.CheckBox chkBoxOperationRangeMax;
        private System.Windows.Forms.CheckBox chkBoxOperationRangeUnit;
        private System.Windows.Forms.CheckBox chkBoxRemark;
        */

        private System.Windows.Forms.CheckBox chkBoxModifyApprovedBy;
        private System.Windows.Forms.CheckBox chkBoxModifyCheckedBy;
        private System.Windows.Forms.CheckBox chkBoxModifyDesignedBy;
        private System.Windows.Forms.CheckBox chkBoxModifyMadeBy;
        private System.Windows.Forms.CheckBox chkBoxModifyProjectID;
        private System.Windows.Forms.CheckBox chkBoxModifyDrawingID;
        private System.Windows.Forms.CheckBox chkBoxModifySpeciality;
        private System.Windows.Forms.CheckBox chkBoxModifyStage;
        private System.Windows.Forms.CheckBox chkBoxModifyDate;
        private System.Windows.Forms.CheckBox chkBoxModifyContractNo;
        private System.Windows.Forms.CheckBox chkBoxModifyRevision;
        private System.Windows.Forms.CheckBox chkBoxModifyTopLevelNo;

        #endregion // UI Elements

        #region .Parameters.

        /*
        private DrawingLanguage _language = DrawingLanguage.SimplifiedChinese;

        private bool _hasLoopNo = true;
        private bool _hasTagNo = true;
        private bool _hasItems = true;
        private bool _hasEqpType = true;
        private bool _hasSupplier = true;
        private bool _hasEqpName = true;
        private bool _hasMeasuringRangeMin = true;
        private bool _hasMeasuringRangeMax = true;
        private bool _hasMeasuringRangeUnit = true;
        private bool _hasInputSignal = true;
        private bool _hasOutputSignal = true;
        private bool _hasPowerSupply = true;
        private bool _hasSpec = true;
        private bool _hasQuantity = true;
        private bool _hasLocation = true;
        private bool _hasOperationRangeMin = true;
        private bool _hasOperationRangeMax = true;
        private bool _hasOperationRangeUnit = true;
        private bool _hasRemark = true;
        */

        private bool _modifyApprovedBy = false;
        private bool _modifyCheckedBy = false;
        private bool _modifyDesignedBy = false;
        private bool _modifyMadeBy = false;
        private bool _modifyProjectID = false;
        private bool _modifyDrawingID = false;
        private bool _modifySpeciality = false;
        private bool _modifyStage = false;
        private bool _modifyDate = false;
        private bool _modifyContractNo = false;
        private bool _modifyRevision = false;
        private bool _modifyTopLevelNo = false;

        /*
        public DrawingLanguage Language { get { return _language; } }

        public bool HasLoopNo { get { return _hasLoopNo; } }
        public bool HasTagNo { get { return _hasTagNo; } }
        public bool HasItems { get { return _hasItems; } }
        public bool HasEqpType { get { return _hasEqpType; } }
        public bool HasSupplier { get { return _hasSupplier; } }
        public bool HasEqpName { get { return _hasEqpName; } }
        public bool HasMeasuringRangeMin { get { return _hasMeasuringRangeMin; } }
        public bool HasMeasuringRangeMax { get { return _hasMeasuringRangeMax; } }
        public bool HasMeasuringRangeUnit { get { return _hasMeasuringRangeUnit; } }
        public bool HasInputSignal { get { return _hasInputSignal; } }
        public bool HasOutputSignal { get { return _hasOutputSignal; } }
        public bool HasPowerSupply { get { return _hasPowerSupply; } }
        public bool HasSpec { get { return _hasSpec; } }
        public bool HasQuantity { get { return _hasQuantity; } }
        public bool HasLocation { get { return _hasLocation; } }
        public bool HasOperationRangeMin { get { return _hasOperationRangeMin; } }
        public bool HasOperationRangeMax { get { return _hasOperationRangeMax; } }
        public bool HasOperationRangeUnit { get { return _hasOperationRangeUnit; } }
        public bool HasRemark { get { return _hasRemark; } }
        */

        public bool ModifyApprovedBy { get { return _modifyApprovedBy; } }
        public bool ModifyCheckedBy { get { return _modifyCheckedBy; } }
        public bool ModifyDesignedBy { get { return _modifyDesignedBy; } }
        public bool ModifyMadeBy { get { return _modifyMadeBy; } }
        public bool ModifyProjectID { get { return _modifyProjectID; } }
        public bool ModifyDrawingID { get { return _modifyDrawingID; } }
        public bool ModifySpeciality { get { return _modifySpeciality; } }
        public bool ModifyStage { get { return _modifyStage; } }
        public bool ModifyDate { get { return _modifyDate; } }
        public bool ModifyContractNo { get { return _modifyContractNo; } }
        public bool ModifyRevision { get { return _modifyRevision; } }
        public bool ModifyTopLevelNo { get { return _modifyTopLevelNo; } }


        public string ApprovedBy { get { return this.tbApprovedBy.Text; } }
        public string CheckedBy { get { return this.tbCheckedBy.Text; } }
        public string DesignedBy { get { return this.tbDesignedBy.Text; } }
        public string MadeBy { get { return this.tbMadeBy.Text; } }
        public string ProjectID { get { return this.tbProjectID.Text; } }
        public string DrawingID { get { return this.tbDrawingID.Text; } }
        public string Speciality { get { return this.tbSpeciality.Text; } }
        public string Stage { get { return this.tbStage.Text; } }
        public string Date { get { return this.tbDate.Text; } }
        public string ContractNo { get { return this.tbContractNo.Text; } }
        public string Revision { get { return this.tbRevision.Text; } }
        public string TopLevelNo { get { return this.tbTopLevelNo.Text; } }

        public string TemplatePath { get { return this.tbTemplatePath.Text; } }
        public string DestPath { get { return this.tbDestPath.Text; } }

        #endregion

        public frmAZOVSTALEquipmentListModifyDrawingMarks(IDSDesignInfo designInfo)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "AZOVSTAL高炉项目设备表导出";

            // 按钮位置
            btnApply.Location = new Point(186, 16);
            btnOK.Location = new Point(267, 16);
            btnCancel.Location = new Point(348, 16);

            //
            // 图框须修改内容
            //
            chkBoxModifyApprovedBy = new CheckBox();
            chkBoxModifyApprovedBy.Text = "室审";
            chkBoxModifyApprovedBy.Checked = false;

            chkBoxModifyCheckedBy = new CheckBox();
            chkBoxModifyCheckedBy.Text = "审核";
            chkBoxModifyCheckedBy.Checked = false;

            chkBoxModifyDesignedBy = new CheckBox();
            chkBoxModifyDesignedBy.Text = "设计";
            chkBoxModifyDesignedBy.Checked = false;

            chkBoxModifyMadeBy = new CheckBox();
            chkBoxModifyMadeBy.Text = "制图";
            chkBoxModifyMadeBy.Checked = false;

            chkBoxModifyProjectID = new CheckBox();
            chkBoxModifyProjectID.Text = "项目编码";
            chkBoxModifyProjectID.Checked = false;

            chkBoxModifyDrawingID = new CheckBox();
            chkBoxModifyDrawingID.Text = "图号";
            chkBoxModifyDrawingID.Checked = false;

            chkBoxModifySpeciality = new CheckBox();
            chkBoxModifySpeciality.Text = "专业";
            chkBoxModifySpeciality.Checked = false;

            chkBoxModifyStage = new CheckBox();
            chkBoxModifyStage.Text = "设计阶段";
            chkBoxModifyStage.Checked = false;

            chkBoxModifyDate = new CheckBox();
            chkBoxModifyDate.Text = "日期";
            chkBoxModifyDate.Checked = false;

            chkBoxModifyContractNo = new CheckBox();
            chkBoxModifyContractNo.Text = "合同编号";
            chkBoxModifyContractNo.Checked = false;

            chkBoxModifyRevision = new CheckBox();
            chkBoxModifyRevision.Text = "修改版次";
            chkBoxModifyRevision.Checked = false;

            chkBoxModifyTopLevelNo = new CheckBox();
            chkBoxModifyTopLevelNo.Text = "高层代号";
            chkBoxModifyTopLevelNo.Checked = false;

            /*
            chkBoxLoopNo = new CheckBox();
            chkBoxLoopNo.Text = "回路号";
            chkBoxLoopNo.Checked = true;
            chkBoxTagNo = new CheckBox();
            chkBoxTagNo.Text = "位号";
            chkBoxTagNo.Checked = true;
            chkBoxItems = new CheckBox();
            chkBoxItems.Text = "检测与控制项目";
            chkBoxItems.Checked = true;
            chkBoxEqpType = new CheckBox();
            chkBoxEqpType.Text = "型号";
            chkBoxEqpType.Checked = true;
            chkBoxSupplier = new CheckBox();
            chkBoxSupplier.Text = "厂家";
            chkBoxSupplier.Checked = true;
            chkBoxEqpName = new CheckBox();
            chkBoxEqpName.Text = "设备名称";
            chkBoxEqpName.Checked = true;
            chkBoxMeasuringRangeMin = new CheckBox();
            chkBoxMeasuringRangeMin.Text = "测量范围最小值";
            chkBoxMeasuringRangeMin.Checked = true;
            chkBoxMeasuringRangeMax = new CheckBox();
            chkBoxMeasuringRangeMax.Text = "测量范围最大值";
            chkBoxMeasuringRangeMax.Checked = true;
            chkBoxMeasuringRangeUnit = new CheckBox();
            chkBoxMeasuringRangeUnit.Text = "测量单位";
            chkBoxMeasuringRangeUnit.Checked = true;
            chkBoxInputSignal = new CheckBox();
            chkBoxInputSignal.Text = "输入信号";
            chkBoxInputSignal.Checked = true;
            chkBoxOutputSignal = new CheckBox();
            chkBoxOutputSignal.Text = "输出信号";
            chkBoxOutputSignal.Checked = true;
            chkBoxPowerSupply = new CheckBox();
            chkBoxPowerSupply.Text = "供电";
            chkBoxPowerSupply.Checked = true;
            chkBoxSpec = new CheckBox();
            chkBoxSpec.Text = "规格";
            chkBoxSpec.Checked = true;
            chkBoxQuantity = new CheckBox();
            chkBoxQuantity.Text = "数量";
            chkBoxQuantity.Checked = true;
            chkBoxLocation = new CheckBox();
            chkBoxLocation.Text = "安装地点";
            chkBoxLocation.Checked = true;
            chkBoxOperationRangeMin = new CheckBox();
            chkBoxOperationRangeMin.Text = "操作数据最小值";
            chkBoxOperationRangeMin.Checked = true;
            chkBoxOperationRangeMax = new CheckBox();
            chkBoxOperationRangeMax.Text = "操作数据最大值";
            chkBoxOperationRangeMax.Checked = true;
            chkBoxOperationRangeUnit = new CheckBox();
            chkBoxOperationRangeUnit.Text = "操作数据单位";
            chkBoxOperationRangeUnit.Checked = true;
            chkBoxRemark = new CheckBox();
            chkBoxRemark.Text = "备注";
            chkBoxRemark.Checked = true;
            */

            flowLayoutPanelElement.Controls.Add(chkBoxModifyApprovedBy);
            flowLayoutPanelElement.Controls.Add(chkBoxModifyCheckedBy);
            flowLayoutPanelElement.Controls.Add(chkBoxModifyDesignedBy);
            flowLayoutPanelElement.Controls.Add(chkBoxModifyMadeBy);
            flowLayoutPanelElement.Controls.Add(chkBoxModifyProjectID);
            flowLayoutPanelElement.Controls.Add(chkBoxModifyDrawingID);
            flowLayoutPanelElement.Controls.Add(chkBoxModifySpeciality);
            flowLayoutPanelElement.Controls.Add(chkBoxModifyStage);
            flowLayoutPanelElement.Controls.Add(chkBoxModifyDate);
            flowLayoutPanelElement.Controls.Add(chkBoxModifyContractNo);
            flowLayoutPanelElement.Controls.Add(chkBoxModifyRevision);
            flowLayoutPanelElement.Controls.Add(chkBoxModifyTopLevelNo);

            /*
            flowLayoutPanelElement.Controls.Add(chkBoxEqpType);
            flowLayoutPanelElement.Controls.Add(chkBoxSupplier);
             * 
            flowLayoutPanelElement.Controls.Add(chkBoxLoopNo);
            flowLayoutPanelElement.Controls.Add(chkBoxTagNo);
            flowLayoutPanelElement.Controls.Add(chkBoxItems);            
            flowLayoutPanelElement.Controls.Add(chkBoxEqpName);
            flowLayoutPanelElement.Controls.Add(chkBoxMeasuringRangeMin);
            flowLayoutPanelElement.Controls.Add(chkBoxMeasuringRangeMax);
            flowLayoutPanelElement.Controls.Add(chkBoxMeasuringRangeUnit);
            flowLayoutPanelElement.Controls.Add(chkBoxInputSignal);
            flowLayoutPanelElement.Controls.Add(chkBoxOutputSignal);
            flowLayoutPanelElement.Controls.Add(chkBoxPowerSupply);
            flowLayoutPanelElement.Controls.Add(chkBoxSpec);
            flowLayoutPanelElement.Controls.Add(chkBoxQuantity);
            flowLayoutPanelElement.Controls.Add(chkBoxLocation);
            flowLayoutPanelElement.Controls.Add(chkBoxOperationRangeMin);
            flowLayoutPanelElement.Controls.Add(chkBoxOperationRangeMax);
            flowLayoutPanelElement.Controls.Add(chkBoxOperationRangeUnit);
            flowLayoutPanelElement.Controls.Add(chkBoxRemark);
             */

            flowLayoutPanelElement.Visible = true;
            this.groupBoxPorpertySelection.Visible = true;

            //
            // 图框
            //
            tbApprovedBy.Text = designInfo.ApprovedBy;
            tbCheckedBy.Text = designInfo.CheckedBy;
            tbDesignedBy.Text = designInfo.DesignedBy;
            tbMadeBy.Text = "";
            tbProjectID.Text = designInfo.ProjectID;
            tbDrawingID.Text = designInfo.DrawingID;
            tbSpeciality.Text = designInfo.Speciality;
            tbStage.Text = designInfo.DesignPhase;
            tbDate.Text = DateTime.Now.Year.ToString() + "." + DateTime.Now.Month.ToString();
            tbContractNo.Text = "";
            tbRevision.Text = designInfo.RevisionVersion;
            tbTopLevelNo.Text = "";
            //
            // 文件路径
            //
            tbTemplatePath.Enabled = true;
            tbTemplatePath.Text = Application.StartupPath + @"\Template\AZOVSTAL_enu.xlt";
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
            /*
            _language = radioBtnLangSimpChinese.Checked ? DrawingLanguage.SimplifiedChinese : DrawingLanguage.English;
            _hasLoopNo = chkBoxLoopNo.Checked;
            _hasTagNo = chkBoxTagNo.Checked;
            _hasItems = chkBoxItems.Checked;
            _hasEqpType = chkBoxEqpType.Checked;
            _hasSupplier = chkBoxSupplier.Checked;
            _hasEqpName = chkBoxEqpName.Checked;
            _hasMeasuringRangeMin = chkBoxMeasuringRangeMin.Checked;
            _hasMeasuringRangeMax = chkBoxMeasuringRangeMax.Checked;
            _hasMeasuringRangeUnit = chkBoxMeasuringRangeUnit.Checked;
            _hasInputSignal = chkBoxInputSignal.Checked;
            _hasOutputSignal = chkBoxOutputSignal.Checked;
            _hasPowerSupply = chkBoxPowerSupply.Checked;
            _hasSpec = chkBoxSpec.Checked;
            _hasQuantity = chkBoxQuantity.Checked;
            _hasLocation = chkBoxLocation.Checked;
            _hasOperationRangeMin = chkBoxOperationRangeMin.Checked;
            _hasOperationRangeMax = chkBoxOperationRangeMax.Checked;
            _hasOperationRangeUnit = chkBoxOperationRangeUnit.Checked;
            _hasRemark = chkBoxRemark.Checked;
            */

            _modifyApprovedBy = chkBoxModifyApprovedBy.Checked;
            _modifyCheckedBy = chkBoxModifyCheckedBy.Checked;
            _modifyDesignedBy = chkBoxModifyDesignedBy.Checked;
            _modifyMadeBy = chkBoxModifyMadeBy.Checked;
            _modifyProjectID = chkBoxModifyProjectID.Checked;
            _modifyDrawingID = chkBoxModifyDrawingID.Checked;
            _modifySpeciality = chkBoxModifySpeciality.Checked;
            _modifyStage = chkBoxModifyStage.Checked;
            _modifyDate = chkBoxModifyDate.Checked;
            _modifyContractNo = chkBoxModifyContractNo.Checked;
            _modifyRevision = chkBoxModifyRevision.Checked;
            _modifyTopLevelNo = chkBoxModifyTopLevelNo.Checked;

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
