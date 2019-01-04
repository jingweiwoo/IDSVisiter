using System;
using System.Reflection;
using System.Collections.Generic;
// using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Office;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

using Flute.DataStruct.EQA;
using Flute.Drawing;

namespace Flute.Drawing.EQA
{
    public class MMKEquipmentList : EquipmentList
    {
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);

        enum EquipmentListType { Excel = 0, }

        string _contractNo = "";    // 合同号
        string _drawingNo = "";     // 图号
        string _revision = "";      // 修改号
        string _topLevelNo = "";    // 高层代号
        string _speciality = "";    // 专业
        string _stage = "";         // 设计阶段
        string _date = "";          // 日期
        string _madeBy = "";        // 制图
        string _designBy = "";      // 设计
        string _checkedBy = "";     // 审核
        string _reviewedBy = "";    // 室审

        DrawingLanguage _drawingLanguage = DrawingLanguage.English;

        public MMKEquipmentList(object drawingData)
        {
            DrawingData = drawingData;
        }

        public bool Export(string templatePath)
        {
            SubSystemCollectin subSystems = DrawingData as SubSystemCollectin;

            if (subSystems.Count == 0)
                return true;

            subSystems.Sort();            

            frmMMKEquipmentList FrmMMKEquipmentList = new frmMMKEquipmentList();
            System.Windows.Forms.DialogResult dlgResult = FrmMMKEquipmentList.ShowDialog();

            if (dlgResult == System.Windows.Forms.DialogResult.Cancel)
                return true;

            _drawingLanguage = FrmMMKEquipmentList.Language;

            _contractNo = FrmMMKEquipmentList.ContractNo;
            _drawingNo = FrmMMKEquipmentList.DrawingNo;
            _revision = FrmMMKEquipmentList.Revision;
            _topLevelNo = FrmMMKEquipmentList.TopLevelNo;
            _speciality = FrmMMKEquipmentList.Speciality;
            _stage = FrmMMKEquipmentList.Stage;
            _date = FrmMMKEquipmentList.Date;
            _madeBy = FrmMMKEquipmentList.MadeBy;
            _designBy = FrmMMKEquipmentList.DesignBy;
            _checkedBy = FrmMMKEquipmentList.CheckedBy;
            _reviewedBy = FrmMMKEquipmentList.ApprovedBy;

            if (!FrmMMKEquipmentList.KeepETNo) {
                int startNo = 0;
                for (int i = 0; i < subSystems.Count; i++) {
                    for (int j = 0; j < subSystems[i].Loops.Count; j++) {
                        for (int k = 0; k < subSystems[i].Loops[j].Equipments.Count; k++) {
                            startNo = subSystems[i].Loops[j].Equipments[k].TagNo.IndexOf("-", 0);
                            subSystems[i].Loops[j].Equipments[k].TagNo =
                                subSystems[i].Loops[j].Equipments[k].TagNo.Substring(startNo);
                        }
                    }
                }
            }

            Microsoft.Office.Interop.Excel.ApplicationClass xlsApp = new ApplicationClass();
            // 打开文件  
            xlsApp.Workbooks.Add(FrmMMKEquipmentList.TemplatePath);

            Microsoft.Office.Interop.Excel.Workbook xlsWorkBook
                                = xlsApp.Workbooks[1];
            xlsApp.Visible = true;

            try {
                int pageCount;
                int currentPageNumber;
                int eqpNumberInPages;

                Microsoft.Office.Interop.Excel.Worksheet xlsWorkSheet;

                switch (_drawingLanguage) {
                    case DrawingLanguage.SimpleChinese:

                        pageCount = 0;

                        foreach (SubSystem subSystem in subSystems)
                            if ((subSystem.EquipmentsCount % 7) == 0)
                                pageCount += subSystem.EquipmentsCount / 7;
                            else
                                pageCount += Convert.ToInt32(Math.Ceiling(subSystem.EquipmentsCount / 7.0f));

                        for (int i = 0; i < pageCount - 1; i++) {
                            (xlsApp.Worksheets[1] as Microsoft.Office.Interop.Excel.Worksheet).Copy(Missing.Value, xlsApp.Worksheets[1 + i]);
                        }

                        currentPageNumber = 0;
                        eqpNumberInPages = 7;

                        lock (subSystems) {
                            if (subSystems.Count > 0) {
                                for (int i = 0; i < subSystems.Count; i++) {
                                    SubSystem subSystem = subSystems[i];
                                    currentPageNumber++;
                                    if (i > 0 && (subSystems[i - 1].EquipmentsCount % 7 == 0))
                                        currentPageNumber--;
                                    eqpNumberInPages = 7;
                                    xlsWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlsApp.Worksheets[currentPageNumber];
                                    xlsWorkSheet.Name = (currentPageNumber).ToString();
                                    xlsWorkSheet.Activate();

                                    // 图纸格式
                                    // 字体
                                    xlsWorkSheet.get_Range("B7", "S13").Font.Name = "Times New Roman";
                                    xlsWorkSheet.get_Range("B7", "S13").Font.Size = 11f;

                                    // 格式
                                    xlsWorkSheet.get_Range("B7", "S13").HorizontalAlignment = Constants.xlCenter;
                                    xlsWorkSheet.get_Range("B7", "S13").VerticalAlignment = Constants.xlCenter;
                                    xlsWorkSheet.get_Range("M7", "M13").HorizontalAlignment = Constants.xlGeneral;
                                    xlsWorkSheet.get_Range("M7", "M13").VerticalAlignment = Constants.xlGeneral;
                                    xlsWorkSheet.get_Range("B7", "S13").WrapText = true;

                                    //
                                    // 图纸内容
                                    //
                                    // 项目名称
                                    xlsWorkSheet.get_Range("B2", Missing.Value).Value2
                                                        += "俄罗斯MMK冷轧公辅EP项目";
                                    // 子系统                  
                                    xlsWorkSheet.get_Range("B3", Missing.Value).Value2
                                                        += subSystem.Name;

                                    //
                                    // 图框内容
                                    xlsWorkSheet.Shapes.Item("BTL").Ungroup();
                                    // 专业
                                    xlsWorkSheet.Shapes.Item("DWG_SPECIALITY").TextFrame.Characters(Missing.Value, Missing.Value).Text = _speciality;
                                    // 设计阶段
                                    xlsWorkSheet.Shapes.Item("DESIGN_STAGE").TextFrame.Characters(Missing.Value, Missing.Value).Text = _stage;
                                    // 日期
                                    xlsWorkSheet.Shapes.Item("PRINT_DATE").TextFrame.Characters(Missing.Value, Missing.Value).Text = _date;
                                    // 室审
                                    xlsWorkSheet.Shapes.Item("DEPT_CHECKER").TextFrame.Characters(Missing.Value, Missing.Value).Text = _reviewedBy;
                                    // 审核
                                    xlsWorkSheet.Shapes.Item("DWG_CHECKER").TextFrame.Characters(Missing.Value, Missing.Value).Text = _checkedBy;
                                    // 设计
                                    xlsWorkSheet.Shapes.Item("DWG_DESIGN").TextFrame.Characters(Missing.Value, Missing.Value).Text = _designBy;
                                    // 制图
                                    xlsWorkSheet.Shapes.Item("DWG_DRAW").TextFrame.Characters(Missing.Value, Missing.Value).Text = _madeBy;
                                    // 合同号
                                    xlsWorkSheet.Shapes.Item("CONTRACT").TextFrame.Characters(Missing.Value, Missing.Value).Text = _contractNo;
                                    // 图号
                                    xlsWorkSheet.Shapes.Item("DRAWING_NO").TextFrame.Characters(Missing.Value, Missing.Value).Text = _drawingNo;
                                    // 高层代号
                                    xlsWorkSheet.Shapes.Item("=").TextFrame.Characters(Missing.Value, Missing.Value).Text = "=" + _topLevelNo;
                                    // 修改号
                                    xlsWorkSheet.Shapes.Item("REVISE_NO").TextFrame.Characters(Missing.Value, Missing.Value).Text = _revision;
                                    // 页次
                                    if (xlsWorkSheet.Index < pageCount)
                                        xlsWorkSheet.Shapes.Item("PAGE").TextFrame.Characters(Missing.Value, Missing.Value).Text = xlsWorkSheet.Index.ToString() + "+";
                                    else
                                        xlsWorkSheet.Shapes.Item("PAGE").TextFrame.Characters(Missing.Value, Missing.Value).Text = (xlsWorkSheet.Index).ToString();

                                    if (subSystem.Loops.Count > 0) {
                                        for (int j = 0; j < subSystem.Loops.Count; j++) {
                                            Loop loop = subSystem.Loops[j];
                                            if (loop.Equipments.Count > 0) {
                                                // 回路号                  
                                                xlsWorkSheet.get_Range("B" + eqpNumberInPages.ToString(), Missing.Value).Value2
                                                    = FrmMMKEquipmentList.HasLoopNo ? loop.LoopNo : "";

                                                //检测与控制项目
                                                string item = loop.Location + loop.ProcParameter +
                                                    (loop.HasLocalIndication ? @"/就地显示" : "") +
                                                    (loop.HasLocalOperating ? @"/就地操作" : "") +
                                                    (loop.HasComputerIndication ? @"/显示" : "") +
                                                    (loop.HasComputerOperating ? @"/操作" : "") +
                                                    (loop.HasRecording ? @"/记录" : "") +
                                                    (loop.HasAlarm ? @"/报警" : "") +
                                                    (loop.HasControlling ? @"/调节" : "") +
                                                    (loop.HasInterlock ? @"/联锁" : "");

                                                xlsWorkSheet.get_Range("D" + eqpNumberInPages.ToString(), Missing.Value).Value2
                                                    = FrmMMKEquipmentList.HasItems ? item : "";
                                            }

                                            for (int m = 0; m < loop.Equipments.Count; m++) {
                                                Equipment eqp = loop.Equipments[m];
                                                if (!eqp.IsEquipment)
                                                    continue;

                                                // 位号
                                                xlsWorkSheet.get_Range("C" + eqpNumberInPages.ToString(), Missing.Value).Value2
                                                    = FrmMMKEquipmentList.HasTagNo ? eqp.TagNo : "";

                                                // 其他项目
                                                xlsWorkSheet.get_Range("E" + eqpNumberInPages.ToString(), "S" + eqpNumberInPages.ToString()).Value2
                                                    = new object[] { FrmMMKEquipmentList.HasEqpName?eqp.Name:"",
                                                                     FrmMMKEquipmentList.HasEqpType?eqp.EqpType:"",
                                                                     FrmMMKEquipmentList.HasMeasuringRangeMin?eqp.LowerLimit:"",
                                                                     FrmMMKEquipmentList.HasMeasuringRangeMax?eqp.UpperLimit:"",
                                                                     FrmMMKEquipmentList.HasMeasuringRangeUnit?eqp.Unit:"",
                                                                     FrmMMKEquipmentList.HasInputSignal?eqp.InputSignal:"",
                                                                     FrmMMKEquipmentList.HasOutputSignal?eqp.OutputSignal:"",
                                                                     FrmMMKEquipmentList.HasPowerSupply?eqp.PowerSupply:"",
                                                                     FrmMMKEquipmentList.HasSpec?eqp.Spec1+",\n"+eqp.Spec2+",\n"+eqp.Spec3:"",
                                                                     FrmMMKEquipmentList.HasQuantity?eqp.Quantity.ToString():"",
                                                                     FrmMMKEquipmentList.HasLocation?eqp.FixedPlace:"",
                                                                     FrmMMKEquipmentList.HasOperationRangeMin?loop.LowerLimit:"",
                                                                     FrmMMKEquipmentList.HasOperationRangeMax?loop.UpperLimit:"",
                                                                     FrmMMKEquipmentList.HasOperationRangeUnit?loop.Unit:"",
                                                                     FrmMMKEquipmentList.HasRemark?eqp.Remark:""
                                                    };

                                                eqpNumberInPages++;


                                                if (eqpNumberInPages >= 14) {
                                                    currentPageNumber++;
                                                    xlsWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlsApp.Worksheets[currentPageNumber];
                                                    xlsWorkSheet.Name = (currentPageNumber).ToString();
                                                    xlsWorkSheet.Activate();

                                                    // 图纸格式
                                                    // 字体
                                                    xlsWorkSheet.get_Range("B7", "S13").Font.Name = "Times New Roman";
                                                    xlsWorkSheet.get_Range("B7", "S13").Font.Size = 11f;

                                                    // 格式
                                                    xlsWorkSheet.get_Range("B7", "S13").HorizontalAlignment = Constants.xlCenter;
                                                    xlsWorkSheet.get_Range("B7", "S13").VerticalAlignment = Constants.xlCenter;
                                                    xlsWorkSheet.get_Range("M7", "M13").HorizontalAlignment = Constants.xlGeneral;
                                                    xlsWorkSheet.get_Range("M7", "M13").VerticalAlignment = Constants.xlGeneral;
                                                    xlsWorkSheet.get_Range("B7", "S13").WrapText = true;

                                                    //
                                                    // 图纸内容
                                                    //
                                                    // 项目名称
                                                    xlsWorkSheet.get_Range("B2", Missing.Value).Value2
                                                                        = "项目名称：俄罗斯MMK冷轧公辅EP项目";
                                                    // 子系统                  
                                                    xlsWorkSheet.get_Range("B3", Missing.Value).Value2
                                                                        = "子系统：" + subSystem.Name;

                                                    //
                                                    // 图框内容
                                                    xlsWorkSheet.Shapes.Item("BTL").Ungroup();
                                                    // 专业
                                                    xlsWorkSheet.Shapes.Item("DWG_SPECIALITY").TextFrame.Characters(Missing.Value, Missing.Value).Text = _speciality;
                                                    // 设计阶段
                                                    xlsWorkSheet.Shapes.Item("DESIGN_STAGE").TextFrame.Characters(Missing.Value, Missing.Value).Text = _stage;
                                                    // 日期
                                                    xlsWorkSheet.Shapes.Item("PRINT_DATE").TextFrame.Characters(Missing.Value, Missing.Value).Text = _date;
                                                    // 室审
                                                    xlsWorkSheet.Shapes.Item("DEPT_CHECKER").TextFrame.Characters(Missing.Value, Missing.Value).Text = _reviewedBy;
                                                    // 审核
                                                    xlsWorkSheet.Shapes.Item("DWG_CHECKER").TextFrame.Characters(Missing.Value, Missing.Value).Text = _checkedBy;
                                                    // 设计
                                                    xlsWorkSheet.Shapes.Item("DWG_DESIGN").TextFrame.Characters(Missing.Value, Missing.Value).Text = _designBy;
                                                    // 制图
                                                    xlsWorkSheet.Shapes.Item("DWG_DRAW").TextFrame.Characters(Missing.Value, Missing.Value).Text = _madeBy;
                                                    // 合同号
                                                    xlsWorkSheet.Shapes.Item("CONTRACT").TextFrame.Characters(Missing.Value, Missing.Value).Text = _contractNo;
                                                    // 图号
                                                    xlsWorkSheet.Shapes.Item("DRAWING_NO").TextFrame.Characters(Missing.Value, Missing.Value).Text = _drawingNo;
                                                    // 高层代号
                                                    xlsWorkSheet.Shapes.Item("=").TextFrame.Characters(Missing.Value, Missing.Value).Text = "=" + _topLevelNo;
                                                    // 修改号
                                                    xlsWorkSheet.Shapes.Item("REVISE_NO").TextFrame.Characters(Missing.Value, Missing.Value).Text = _revision;
                                                    // 页次
                                                    if (xlsWorkSheet.Index < pageCount)
                                                        xlsWorkSheet.Shapes.Item("PAGE").TextFrame.Characters(Missing.Value, Missing.Value).Text = xlsWorkSheet.Index.ToString() + "+";
                                                    else
                                                        xlsWorkSheet.Shapes.Item("PAGE").TextFrame.Characters(Missing.Value, Missing.Value).Text = (xlsWorkSheet.Index).ToString();

                                                    eqpNumberInPages = 7;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        break;

                    case DrawingLanguage.English:

                        pageCount = 0;

                        foreach (SubSystem subSystem in subSystems) {
                            if ((subSystem.EquipmentsCount % 3 == 0))
                                pageCount += subSystem.EquipmentsCount / 3;
                            else
                                pageCount += Convert.ToInt32(Math.Ceiling(subSystem.EquipmentsCount / 3.0f));
                        }

                        (xlsApp.Worksheets[1] as Microsoft.Office.Interop.Excel.Worksheet).Shapes.Item("BTL").Ungroup();

                        // 图纸格式
                        // 字体
                        (xlsApp.Worksheets[1] as Microsoft.Office.Interop.Excel.Worksheet).get_Range("B9", "S14").Font.Name = "Times New Roman";
                        (xlsApp.Worksheets[1] as Microsoft.Office.Interop.Excel.Worksheet).get_Range("B9", "S14").Font.Size = 11f;

                        // 格式
                        (xlsApp.Worksheets[1] as Microsoft.Office.Interop.Excel.Worksheet).get_Range("B9", "S14").HorizontalAlignment = Constants.xlCenter;
                        (xlsApp.Worksheets[1] as Microsoft.Office.Interop.Excel.Worksheet).get_Range("B9", "S14").VerticalAlignment = Constants.xlCenter;
                        (xlsApp.Worksheets[1] as Microsoft.Office.Interop.Excel.Worksheet).get_Range("M9", "M14").HorizontalAlignment = Constants.xlGeneral;
                        (xlsApp.Worksheets[1] as Microsoft.Office.Interop.Excel.Worksheet).get_Range("B9", "S14").WrapText = true;

                        for (int i = 0; i < pageCount - 1; i++) {
                            (xlsApp.Worksheets[1] as Microsoft.Office.Interop.Excel.Worksheet).Copy(Missing.Value, xlsApp.Worksheets[1 + i]);
                        }

                        currentPageNumber = 0;
                        eqpNumberInPages = 9;

                        lock (subSystems) {
                            if (subSystems.Count > 0) {
                                for (int i = 0; i < subSystems.Count; i++) {
                                    SubSystem subSystem = subSystems[i];
                                    currentPageNumber++;
                                    if (i > 0 && (subSystems[i - 1].EquipmentsCount % 3 == 0))
                                        currentPageNumber--;

                                    eqpNumberInPages = 9;
                                    xlsWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlsApp.Worksheets[currentPageNumber];
                                    xlsWorkSheet.Name = (currentPageNumber).ToString();
                                    xlsWorkSheet.Activate();                                    

                                    //
                                    // 图纸内容
                                    //

                                    // 子系统                  
                                    xlsWorkSheet.get_Range("B3", Missing.Value).Value2
                                                        = "Sub-system/Подсистема: " + subSystem.Name;

                                    //
                                    // 图框内容

                                    // 专业
                                    xlsWorkSheet.Shapes.Item("DWG_SPECIALITY").TextFrame.Characters(Missing.Value, Missing.Value).Text = _speciality;
                                    // 设计阶段
                                    xlsWorkSheet.Shapes.Item("DESIGN_STAGE").TextFrame.Characters(Missing.Value, Missing.Value).Text = _stage;
                                    // 日期
                                    xlsWorkSheet.Shapes.Item("PRINT_DATE").TextFrame.Characters(Missing.Value, Missing.Value).Text = _date;
                                    // 室审
                                    xlsWorkSheet.Shapes.Item("DEPT_CHECKER").TextFrame.Characters(Missing.Value, Missing.Value).Text = _reviewedBy;
                                    // 审核
                                    xlsWorkSheet.Shapes.Item("DWG_CHECKER").TextFrame.Characters(Missing.Value, Missing.Value).Text = _checkedBy;
                                    // 设计
                                    xlsWorkSheet.Shapes.Item("DWG_DESIGN").TextFrame.Characters(Missing.Value, Missing.Value).Text = _designBy;
                                    // 制图
                                    xlsWorkSheet.Shapes.Item("DWG_DRAW").TextFrame.Characters(Missing.Value, Missing.Value).Text = _madeBy;
                                    // 合同号
                                    xlsWorkSheet.Shapes.Item("CONTRACT").TextFrame.Characters(Missing.Value, Missing.Value).Text = _contractNo;
                                    // 图号
                                    xlsWorkSheet.Shapes.Item("DRAWING_NO").TextFrame.Characters(Missing.Value, Missing.Value).Text = _drawingNo;
                                    // 高层代号
                                    xlsWorkSheet.Shapes.Item("=").TextFrame.Characters(Missing.Value, Missing.Value).Text = "="+_topLevelNo;
                                    // 修改号
                                    xlsWorkSheet.Shapes.Item("REVISE_NO").TextFrame.Characters(Missing.Value, Missing.Value).Text = _revision;
                                    // 页次
                                    if (xlsWorkSheet.Index < pageCount)
                                        xlsWorkSheet.Shapes.Item("PAGE").TextFrame.Characters(Missing.Value, Missing.Value).Text = xlsWorkSheet.Index.ToString() + "+";
                                    else
                                        xlsWorkSheet.Shapes.Item("PAGE").TextFrame.Characters(Missing.Value, Missing.Value).Text = (xlsWorkSheet.Index).ToString();


                                    if (subSystem.Loops.Count > 0) {
                                        for (int j = 0; j < subSystem.Loops.Count; j++) {
                                            Loop loop = subSystem.Loops[j];
                                            if (loop.Equipments.Count > 0) {
                                                // 回路号                  
                                                xlsWorkSheet.get_Range("B" + eqpNumberInPages.ToString(), Missing.Value).Value2
                                                    = FrmMMKEquipmentList.HasLoopNo ? loop.LoopNo : "";

                                                //检测与控制项目
                                                string item = loop.Location + loop.ProcParameter +
                                                    (loop.HasLocalIndication ? @"/就地显示" : "") +
                                                    (loop.HasLocalOperating ? @"/就地操作" : "") +
                                                    (loop.HasComputerIndication ? @"/显示" : "") +
                                                    (loop.HasComputerOperating ? @"/操作" : "") +
                                                    (loop.HasRecording ? @"/记录" : "") +
                                                    (loop.HasAlarm ? @"/报警" : "") +
                                                    (loop.HasControlling ? @"/调节" : "") +
                                                    (loop.HasInterlock ? @"/联锁" : "");

                                                xlsWorkSheet.get_Range("D" + eqpNumberInPages.ToString(), Missing.Value).Value2
                                                    = FrmMMKEquipmentList.HasItems ? item : "";
                                            }

                                            for (int m = 0; m < loop.Equipments.Count; m++) {
                                                Equipment eqp = loop.Equipments[m];
                                                if (!eqp.IsEquipment)
                                                    continue;

                                                // 位号
                                                xlsWorkSheet.get_Range("C" + eqpNumberInPages.ToString(), Missing.Value).Value2
                                                    = FrmMMKEquipmentList.HasTagNo ? eqp.TagNo : "";

                                                // 其他项目
                                                xlsWorkSheet.get_Range("E" + eqpNumberInPages.ToString(), "S" + eqpNumberInPages.ToString()).Value2
                                                    = new object[] { FrmMMKEquipmentList.HasEqpName?eqp.Name:"",
                                                                     FrmMMKEquipmentList.HasEqpType?eqp.EqpType:"",
                                                                     FrmMMKEquipmentList.HasMeasuringRangeMin?eqp.LowerLimit:"",
                                                                     FrmMMKEquipmentList.HasMeasuringRangeMax?eqp.UpperLimit:"",
                                                                     FrmMMKEquipmentList.HasMeasuringRangeUnit?eqp.Unit:"",
                                                                     FrmMMKEquipmentList.HasInputSignal?eqp.InputSignal:"",
                                                                     FrmMMKEquipmentList.HasOutputSignal?eqp.OutputSignal:"",
                                                                     FrmMMKEquipmentList.HasPowerSupply?eqp.PowerSupply:"",
                                                                     FrmMMKEquipmentList.HasSpec?eqp.Spec1+",\n"+eqp.Spec2:"",
                                                                     FrmMMKEquipmentList.HasQuantity?eqp.Quantity.ToString():"",
                                                                     FrmMMKEquipmentList.HasLocation?eqp.FixedPlace:"",
                                                                     FrmMMKEquipmentList.HasOperationRangeMin?loop.LowerLimit:"",
                                                                     FrmMMKEquipmentList.HasOperationRangeMax?loop.UpperLimit:"",
                                                                     FrmMMKEquipmentList.HasOperationRangeUnit?loop.Unit:"",
                                                                     FrmMMKEquipmentList.HasRemark?eqp.Remark:""
                                                    };

                                                xlsWorkSheet.get_Range("B" + (eqpNumberInPages + 1).ToString(), "S" + (eqpNumberInPages + 1).ToString()).Value2
                                                    = xlsWorkSheet.get_Range("B" + eqpNumberInPages.ToString(), "S" + eqpNumberInPages.ToString()).Value2;

                                                eqpNumberInPages += 2;

                                                if (eqpNumberInPages >= 15) {
                                                    currentPageNumber++;
                                                    xlsWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlsApp.Worksheets[currentPageNumber];
                                                    xlsWorkSheet.Name = (currentPageNumber).ToString();
                                                    xlsWorkSheet.Activate();
                                                    
                                                    //
                                                    // 图纸内容
                                                    //
                                                    // 子系统                  
                                                    xlsWorkSheet.get_Range("B3", Missing.Value).Value2
                                                                        = "Sub-system/Подсистема: " + subSystem.Name;

                                                    //
                                                    // 图框内容
                                                    
                                                    // 专业
                                                    xlsWorkSheet.Shapes.Item("DWG_SPECIALITY").TextFrame.Characters(Missing.Value, Missing.Value).Text = _speciality;
                                                    // 设计阶段
                                                    xlsWorkSheet.Shapes.Item("DESIGN_STAGE").TextFrame.Characters(Missing.Value, Missing.Value).Text = _stage;
                                                    // 日期
                                                    xlsWorkSheet.Shapes.Item("PRINT_DATE").TextFrame.Characters(Missing.Value, Missing.Value).Text = _date;
                                                    // 室审
                                                    xlsWorkSheet.Shapes.Item("DEPT_CHECKER").TextFrame.Characters(Missing.Value, Missing.Value).Text = _reviewedBy;
                                                    // 审核
                                                    xlsWorkSheet.Shapes.Item("DWG_CHECKER").TextFrame.Characters(Missing.Value, Missing.Value).Text = _checkedBy;
                                                    // 设计
                                                    xlsWorkSheet.Shapes.Item("DWG_DESIGN").TextFrame.Characters(Missing.Value, Missing.Value).Text = _designBy;
                                                    // 制图
                                                    xlsWorkSheet.Shapes.Item("DWG_DRAW").TextFrame.Characters(Missing.Value, Missing.Value).Text = _madeBy;
                                                    // 合同号
                                                    xlsWorkSheet.Shapes.Item("CONTRACT").TextFrame.Characters(Missing.Value, Missing.Value).Text = _contractNo;
                                                    // 图号
                                                    xlsWorkSheet.Shapes.Item("DRAWING_NO").TextFrame.Characters(Missing.Value, Missing.Value).Text = _drawingNo;
                                                    // 高层代号
                                                    xlsWorkSheet.Shapes.Item("=").TextFrame.Characters(Missing.Value, Missing.Value).Text = "=" + _topLevelNo;
                                                    // 修改号
                                                    xlsWorkSheet.Shapes.Item("REVISE_NO").TextFrame.Characters(Missing.Value, Missing.Value).Text = _revision;
                                                    // 页次
                                                    if (xlsWorkSheet.Index < pageCount)
                                                        xlsWorkSheet.Shapes.Item("PAGE").TextFrame.Characters(Missing.Value, Missing.Value).Text = xlsWorkSheet.Index.ToString() + "+";
                                                    else
                                                        xlsWorkSheet.Shapes.Item("PAGE").TextFrame.Characters(Missing.Value, Missing.Value).Text = (xlsWorkSheet.Index).ToString();

                                                    eqpNumberInPages = 9;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        break;

                    default:
                        break;
                }

                return true;

            } catch (Exception ex) {
                return false;
            }


            //} finally {
            //    IntPtr t = new IntPtr(xlsApp.Hwnd);

            //    int k = 0;
            //    GetWindowThreadProcessId(t, out k);
            //    System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(k);
            //    p.Kill();
            //}

            
        }
    }
}
