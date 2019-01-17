using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

using System.IO;
using Microsoft.Office;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

using Flute.DataStruct.IDS;
using Flute.Drawing;

using Flute.Service;

namespace Flute.Drawing.IDS
{
    public class AZOVSTALEquipmentList : IDSEquipmentList
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

        DrawingKeywordCollection DrawingKeywords { get; set; }

        DrawingLanguage _drawingLanguage = DrawingLanguage.English;

        public AZOVSTALEquipmentList(object drawingData)
        {
            DrawingData = drawingData;
            DrawingKeywords = new DrawingKeywordCollection();
        }

        public override bool Export(string templatePath, string destPath)
        {
            Console.WriteLine("calling Flute.Drawing.IDS.AZOVSTALEquipmentList.Export");
            IDSSystemCollection systems = DrawingData as IDSSystemCollection;

            if (systems.Count <= 0)
                return true;

            systems.Sort();

            frmAZOVSTALEquipmentList FrmAZOVSTALEquipmentList = new frmAZOVSTALEquipmentList();
            System.Windows.Forms.DialogResult dlgResult = FrmAZOVSTALEquipmentList.ShowDialog();

            if (dlgResult == System.Windows.Forms.DialogResult.Cancel)
                return true;

            _drawingLanguage = FrmAZOVSTALEquipmentList.Language;

            _contractNo = FrmAZOVSTALEquipmentList.ContractNo;
            _drawingNo = FrmAZOVSTALEquipmentList.DrawingNo;
            _revision = FrmAZOVSTALEquipmentList.Revision;
            _topLevelNo = FrmAZOVSTALEquipmentList.TopLevelNo;
            _speciality = FrmAZOVSTALEquipmentList.Speciality;
            _stage = FrmAZOVSTALEquipmentList.Stage;
            _date = FrmAZOVSTALEquipmentList.Date;
            _madeBy = FrmAZOVSTALEquipmentList.MadeBy;
            _designBy = FrmAZOVSTALEquipmentList.DesignBy;
            _checkedBy = FrmAZOVSTALEquipmentList.CheckedBy;
            _reviewedBy = FrmAZOVSTALEquipmentList.ApprovedBy;

            //if (!FrmAZOVSTALEquipmentList.KeepETNo) {
            //    int startNo = 0;
            //    for (int i = 0; i < subSystems.Count; i++) {
            //        for (int j = 0; j < subSystems[i].Loops.Count; j++) {
            //            for (int k = 0; k < subSystems[i].Loops[j].Equipments.Count; k++) {
            //                startNo = subSystems[i].Loops[j].Equipments[k].TagNo.IndexOf("-", 0);
            //                subSystems[i].Loops[j].Equipments[k].TagNo =
            //                    subSystems[i].Loops[j].Equipments[k].TagNo.Substring(startNo);
            //            }
            //        }
            //    }
            //}

            Microsoft.Office.Interop.Excel.ApplicationClass xlsApp = new ApplicationClass();
            // 打开文件  
            xlsApp.Workbooks.Add(FrmAZOVSTALEquipmentList.TemplatePath);

            Microsoft.Office.Interop.Excel.Workbook xlsWorkBook
                                = xlsApp.Workbooks[1];
            xlsApp.Visible = true;

            try {
                Int32 pageCount;
                Int32 currentPageNumber;
                Int32 eqpNumberInPages;

                Microsoft.Office.Interop.Excel.Worksheet xlsWorkSheet;

                switch (_drawingLanguage) {
                    #region .Case SimpleChinese.
                    case DrawingLanguage.SimpleChinese:

                        pageCount = 0;

                        foreach (IDSSystem system in systems)
                            if ((system.EquipmentsCount % 7) == 0)
                                pageCount += system.EquipmentsCount / 7;
                            else
                                pageCount += Convert.ToInt32(Math.Ceiling(system.EquipmentsCount / 7.0f));

                        for (int i = 0; i < pageCount - 1; i++) {
                            (xlsApp.Worksheets[1] as Microsoft.Office.Interop.Excel.Worksheet).Copy(Missing.Value, xlsApp.Worksheets[1 + i]);
                        }

                        currentPageNumber = 0;
                        eqpNumberInPages = 7;

                        lock (systems) {
                            if (systems.Count > 0) {
                                for (int i = 0; i < systems.Count; i++) {
                                    IDSSystem system = systems[i];
                                    currentPageNumber++;
                                    if (i > 0 && (systems[i - 1].EquipmentsCount % 7 == 0))
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
                                                        += "AZOVSTAL 6#高炉项目";
                                    // 系统                  
                                    xlsWorkSheet.get_Range("B3", Missing.Value).Value2
                                                        += system.Name;

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

                                    // --
                                    if (system.SubSystems.Count > 0) {
                                        for (int j = 0; j < system.SubSystems.Count; j++) {
                                            IDSSubSystem subSystem = system.SubSystems[j];

                                            for (int k = 0; k < subSystem.Loops.Count; k++) {
                                                IDSLoop loop = subSystem.Loops[k];

                                                if (loop.EquipmentsCount > 0) {
                                                    // 回路号                  
                                                    xlsWorkSheet.get_Range("B" + eqpNumberInPages.ToString(), Missing.Value).Value2
                                                        = FrmAZOVSTALEquipmentList.HasLoopNo ? loop.Tag : "";
                                                    xlsWorkSheet.get_Range("D" + eqpNumberInPages.ToString(), Missing.Value).Value2
                                                        = FrmAZOVSTALEquipmentList.HasItems ? loop.Location : "";

                                                    for (int m = 0; m < loop.SubLoops.Count; m++) {
                                                        IDSSubLoop subLoop = loop.SubLoops[m];

                                                        if (subLoop.Equipments.Count > 0)
                                                            for (int n = 0; n < subLoop.Equipments.Count; n++) {
                                                                IDSEquipment equipment = subLoop.Equipments[n];

                                                                // 位号
                                                                xlsWorkSheet.get_Range("C" + eqpNumberInPages.ToString(), Missing.Value).Value2
                                                                    = FrmAZOVSTALEquipmentList.HasTagNo ? equipment.Tag : "";

                                                                // 其他项目
                                                                xlsWorkSheet.get_Range("E" + eqpNumberInPages.ToString(), "S" + eqpNumberInPages.ToString()).Value2
                                                                    = new object[] { FrmAZOVSTALEquipmentList.HasEqpName?equipment.EquipmentRepository.Name:"",
                                                                                    //FrmAZOVSTALEquipmentList.HasEqpType?eqp.EqpType:"",
                                                                                    //FrmAZOVSTALEquipmentList.HasMeasuringRangeMin?eqp.LowerLimit:"",
                                                                                    //FrmAZOVSTALEquipmentList.HasMeasuringRangeMax?eqp.UpperLimit:"",
                                                                                    //FrmAZOVSTALEquipmentList.HasMeasuringRangeUnit?eqp.Unit:"",
                                                                                    //FrmAZOVSTALEquipmentList.HasInputSignal?eqp.InputSignal:"",
                                                                                    //FrmAZOVSTALEquipmentList.HasOutputSignal?eqp.OutputSignal:"",
                                                                                    //FrmAZOVSTALEquipmentList.HasPowerSupply?eqp.PowerSupply:"",
                                                                                    //FrmAZOVSTALEquipmentList.HasSpec?eqp.Spec1+",\n"+eqp.Spec2+",\n"+eqp.Spec3:"",
                                                                                    //FrmAZOVSTALEquipmentList.HasQuantity?eqp.Quantity.ToString():"",
                                                                                    //FrmAZOVSTALEquipmentList.HasLocation?eqp.FixedPlace:"",
                                                                                    //FrmAZOVSTALEquipmentList.HasOperationRangeMin?loop.LowerLimit:"",
                                                                                    //FrmAZOVSTALEquipmentList.HasOperationRangeMax?loop.UpperLimit:"",
                                                                                    //FrmAZOVSTALEquipmentList.HasOperationRangeUnit?loop.Unit:"",
                                                                                    //FrmAZOVSTALEquipmentList.HasRemark?eqp.Remark:"" 
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
                                                                                        = "项目名称：乌克兰亚速6#高炉项目";
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
                                }
                            }
                        }

                        break;
                    #endregion

                    #region .Case English.
                    case DrawingLanguage.English:

                        pageCount = 0;

                        foreach (IDSSystem system in systems) {
                            if ((system.EquipmentsCount % 3) == 0)
                                pageCount += system.EquipmentsCount / 3;
                            else
                                pageCount += Convert.ToInt32(Math.Ceiling(system.EquipmentsCount / 3.0f));
                        }

                        xlsWorkSheet = xlsApp.Worksheets[1] as Microsoft.Office.Interop.Excel.Worksheet;

                        // (xlsApp.Worksheets[1] as Microsoft.Office.Interop.Excel.Worksheet).Shapes.Item("BTL").Ungroup();

                        // 图纸格式
                        // 字体
                        xlsWorkSheet.get_Range("B9", "O14").Font.Name = "Times New Roman";
                        xlsWorkSheet.get_Range("B9", "O14").Font.Size = 11f;

                        // 格式
                        xlsWorkSheet.get_Range("B9", "O14").HorizontalAlignment = Constants.xlCenter;
                        xlsWorkSheet.get_Range("B9", "O14").VerticalAlignment = Constants.xlCenter;
                        xlsWorkSheet.get_Range("L9", "L14").HorizontalAlignment = Constants.xlGeneral;
                        xlsWorkSheet.get_Range("B9", "O14").WrapText = true;

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
                        xlsWorkSheet.Shapes.Item("DWG_DESIGNER").TextFrame.Characters(Missing.Value, Missing.Value).Text = _designBy;
                        // 制图
                        xlsWorkSheet.Shapes.Item("DWG_DRAW").TextFrame.Characters(Missing.Value, Missing.Value).Text = _madeBy;
                        //// 合同号
                        //xlsWorkSheet.Shapes.Item("CONTRACT").TextFrame.Characters(Missing.Value, Missing.Value).Text = _contractNo;
                        //项目编码
                        xlsWorkSheet.Shapes.Item("PROJECT_NO").TextFrame.Characters(Missing.Value, Missing.Value).Text = "";
                        // 图号
                        xlsWorkSheet.Shapes.Item("DRAWING_NO").TextFrame.Characters(Missing.Value, Missing.Value).Text = _drawingNo;
                        //// 高层代号
                        //xlsWorkSheet.Shapes.Item("=").TextFrame.Characters(Missing.Value, Missing.Value).Text = "=" + _topLevelNo;
                        // 修改号
                        xlsWorkSheet.Shapes.Item("REVISE_NO").TextFrame.Characters(Missing.Value, Missing.Value).Text = _revision;

                        for (int i = 0; i < pageCount - 1; i++) {
                            (xlsApp.Worksheets[1] as Microsoft.Office.Interop.Excel.Worksheet).Copy(Missing.Value, xlsApp.Worksheets[1 + i]);
                        }

                        currentPageNumber = 0;
                        eqpNumberInPages = 9;

                        lock (systems) {
                            if (systems.Count > 0) {
                                for (int i = 0; i < systems.Count; i++) {
                                    IDSSystem system = systems[i];
                                    currentPageNumber++;
                                    if (i > 0 && (systems[i - 1].EquipmentsCount % 3 == 0))
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
                                                        = "Sub-system/Подсистема: " + system.SubSystems[0].Name;

                                    // ++== 增加子系统关键字
                                    DrawingKeyword keyword = new DrawingKeyword("Sub-system/Подсистема: " + system.SubSystems[0].Name,
                                                                                new KeywordInOtherLanguageCollection(),
                                                                                new KeywordLocation(currentPageNumber, "B3"));
                                    DrawingKeywords.AddKeyword(keyword);


                                    // 页次
                                    if (xlsWorkSheet.Index < pageCount)
                                        xlsWorkSheet.Shapes.Item("PAGE").TextFrame.Characters(Missing.Value, Missing.Value).Text = xlsWorkSheet.Index.ToString() + "+";
                                    else
                                        xlsWorkSheet.Shapes.Item("PAGE").TextFrame.Characters(Missing.Value, Missing.Value).Text = (xlsWorkSheet.Index).ToString();

                                    // --
                                    if (system.SubSystems.Count > 0) {
                                        for (int j = 0; j < system.SubSystems.Count; j++) {
                                            IDSSubSystem subSystem = system.SubSystems[j];

                                            for (int k = 0; k < subSystem.Loops.Count; k++) {
                                                IDSLoop loop = subSystem.Loops[k];

                                                if (loop.EquipmentsCount > 0) {
                                                    // 回路号
                                                    string loopTag = loop.Tag;
                                                    string loopTagCell = "B" + eqpNumberInPages.ToString();
                                                    // 回路检测与控制内容
                                                    string loopFunction = loop.Location + loop.Parameter;
                                                    string loopFunctionCell = "D" + eqpNumberInPages.ToString();
                                                    // 回路测量介质
                                                    string loopMedium = loop.Medium;
                                                    string loopMediumCell = "E" + eqpNumberInPages.ToString();

                                                    // 回路号                  
                                                    xlsWorkSheet.get_Range(loopTagCell, Missing.Value).Value2 = loopTag;
                                                    // 回路检测与控制内容
                                                    xlsWorkSheet.get_Range(loopFunctionCell, Missing.Value).Value2 = loopFunction;
                                                    // 回路测量介质
                                                    xlsWorkSheet.get_Range(loopMediumCell, Missing.Value).Value2 = loopMedium;

                                                    // ++== 增加回路部分关键字
                                                    //DrawingKeywords.AddKeyword(new DrawingKeyword(loopTag,
                                                    //                                            new KeywordInOtherLanguageCollection(),
                                                    //                                            new KeywordLocation(currentPageNumber, loopTagCell)));
                                                    DrawingKeywords.AddKeyword(new DrawingKeyword(loopFunction,
                                                                                                new KeywordInOtherLanguageCollection(),
                                                                                                new KeywordLocation(currentPageNumber, loopFunctionCell)));
                                                    DrawingKeywords.AddKeyword(new DrawingKeyword(loopMedium,
                                                                                                new KeywordInOtherLanguageCollection(),
                                                                                                new KeywordLocation(currentPageNumber, loopMediumCell)));

                                                    for (int m = 0; m < loop.SubLoops.Count; m++) {
                                                        IDSSubLoop subLoop = loop.SubLoops[m];

                                                        if (subLoop.Equipments.Count > 0) {
                                                            for (int n = 0; n < subLoop.Equipments.Count; n++) {
                                                                IDSEquipment equipment = subLoop.Equipments[n];

                                                                // 位号
                                                                string equipmentTag = equipment.Tag;
                                                                string equipmentTagCell = "C" + eqpNumberInPages.ToString();

                                                                // 位号
                                                                xlsWorkSheet.get_Range(equipmentTagCell, Missing.Value).Value2 = equipmentTag;

                                                                // ++== 增加位号关键字
                                                                //DrawingKeywords.AddKeyword(new DrawingKeyword(loopTag,
                                                                //                                            new KeywordInOtherLanguageCollection(),
                                                                //                                            new KeywordLocation(currentPageNumber, loopTagCell)));

                                                                // 其他项目 --
                                                                // 设备名称
                                                                string equipmentRepository = FrmAZOVSTALEquipmentList.HasEqpName ? equipment.EquipmentRepository.Name : "";
                                                                string equipmentRepositoryCell = "F" + eqpNumberInPages.ToString();
                                                                // 设备型号
                                                                string equipmentModelNumber = FrmAZOVSTALEquipmentList.HasEqpType ? equipment.EquipmentRepository.ModelNumber : "";
                                                                string equipmentModelNumberCell = "G" + eqpNumberInPages.ToString();
                                                                // 测量范围
                                                                string loopMeasurementRange = loop.MeasurementRange;
                                                                string loopMeasurementRangeCell = "H" + eqpNumberInPages.ToString();
                                                                // 测量单位
                                                                string unit = loop.Unit;
                                                                string unitCell = "I" + eqpNumberInPages.ToString();
                                                                // 供电
                                                                string powerSupply = equipment.Remark;
                                                                string powerSupplyCell = "J" + eqpNumberInPages.ToString();
                                                                // 供应商
                                                                string supplier = "";
                                                                string supplierCell = "K" + eqpNumberInPages.ToString();
                                                                // 规格
                                                                string equipmentSpecification = equipment.EquipmentRepository.Remark01
                                                                                                    + equipment.EquipmentRepository.Remark02
                                                                                                        + equipment.EquipmentRepository.Remark03;
                                                                string equipmentSpecificationCell = "L" + eqpNumberInPages.ToString();
                                                                // 数量
                                                                Int32 equipmentQuantity = equipment.Quantity;
                                                                string equipmentQuantityCell = "M" + eqpNumberInPages.ToString();
                                                                // 安装位置
                                                                string mountingType = equipment.SubEquipments[0].MountingType;
                                                                string mountingTypeCell = "N" + eqpNumberInPages.ToString();

                                                                xlsWorkSheet.get_Range("F" + eqpNumberInPages.ToString(), "N" + eqpNumberInPages.ToString()).Value2
                                                                    = new object[] {equipmentRepository,
                                                                                    equipmentModelNumber,
                                                                                    loopMeasurementRange,
                                                                                    unit,
                                                                                    equipment.Remark,
                                                                                    supplier,
                                                                                    equipmentSpecification,
                                                                                    equipmentQuantity,
                                                                                    mountingType,
                                                                    };

                                                                // ++== 增加其他项目关键字
                                                                DrawingKeywords.AddKeyword(new DrawingKeyword(equipmentRepository,
                                                                                                            new KeywordInOtherLanguageCollection(),
                                                                                                            new KeywordLocation(currentPageNumber, equipmentRepositoryCell)));
                                                                //DrawingKeywords.AddKeyword(new DrawingKeyword(equipmentModelNumber,
                                                                //                                            new KeywordInOtherLanguageCollection(),
                                                                //                                            new KeywordLocation(currentPageNumber, equipmentModelNumberCell)));
                                                                DrawingKeywords.AddKeyword(new DrawingKeyword(supplier,
                                                                                                            new KeywordInOtherLanguageCollection(),
                                                                                                            new KeywordLocation(currentPageNumber, supplierCell)));
                                                                DrawingKeywords.AddKeyword(new DrawingKeyword(equipmentSpecification,
                                                                                                            new KeywordInOtherLanguageCollection(),
                                                                                                            new KeywordLocation(currentPageNumber, equipmentSpecificationCell)));
                                                                DrawingKeywords.AddKeyword(new DrawingKeyword(mountingType,
                                                                                                            new KeywordInOtherLanguageCollection(),
                                                                                                            new KeywordLocation(currentPageNumber, mountingTypeCell)));


                                                                xlsWorkSheet.get_Range("B" + (eqpNumberInPages + 1).ToString(), "O" + (eqpNumberInPages + 1).ToString()).Value2
                                                                    = xlsWorkSheet.get_Range("B" + eqpNumberInPages.ToString(), "O" + eqpNumberInPages.ToString()).Value2;

                                                                eqpNumberInPages += 2;

                                                                if (eqpNumberInPages >= 15 && currentPageNumber < pageCount) {
                                                                    currentPageNumber++;
                                                                    Console.WriteLine("当前页号: " + currentPageNumber.ToString());

                                                                    xlsWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlsApp.Worksheets[currentPageNumber];
                                                                    xlsWorkSheet.Name = (currentPageNumber).ToString();
                                                                    xlsWorkSheet.Activate();

                                                                    //
                                                                    // 图纸内容
                                                                    //
                                                                    // 子系统                  
                                                                    xlsWorkSheet.get_Range("B3", Missing.Value).Value2
                                                                                        = "Sub-system/Подсистема: " + subSystem.Name;

                                                                    // ++== 增加子系统关键字
                                                                    DrawingKeywords.AddKeyword(new DrawingKeyword("Sub-system/Подсистема: " + subSystem.Name,
                                                                                                            new KeywordInOtherLanguageCollection(),
                                                                                                            new KeywordLocation(currentPageNumber, "B3")));

                                                                    // 页次
                                                                    if (xlsWorkSheet.Index < pageCount)
                                                                        xlsWorkSheet.Shapes.Item("PAGE").TextFrame.Characters(Missing.Value, Missing.Value).Text = xlsWorkSheet.Index.ToString() + "+";
                                                                    else
                                                                        xlsWorkSheet.Shapes.Item("PAGE").TextFrame.Characters(Missing.Value, Missing.Value).Text = (xlsWorkSheet.Index).ToString();

                                                                    eqpNumberInPages = 9;
                                                                }
                                                                else {
                                                                    continue;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        if (DrawingKeywords != null && DrawingKeywords.Count > 0) {
                            //
                            int lastEquipmentListPageNumber = currentPageNumber;
                            int ExtractedInfoPageNumber = currentPageNumber + 1;

                            xlsApp.Worksheets.Add(Type.Missing, xlsApp.Worksheets[currentPageNumber], Type.Missing, Type.Missing);

                            // 提取信息的WorkSheet
                            Microsoft.Office.Interop.Excel.Worksheet
                                xlsWorkSheetExtracted = xlsApp.Worksheets[ExtractedInfoPageNumber] as Microsoft.Office.Interop.Excel.Worksheet;

                            xlsWorkSheetExtracted.Name = (ExtractedInfoPageNumber).ToString() + " - " + "提取内容";
                            xlsWorkSheetExtracted.Activate();


                            // 图纸格式 -- 标题
                            // 字体
                            xlsWorkSheetExtracted.get_Range("A1", "D1").Font.Name = "Times New Roman";
                            xlsWorkSheetExtracted.get_Range("A1", "D1").Font.Size = 13f;
                            xlsWorkSheetExtracted.get_Range("A1", "D1").Font.Bold = true;

                            xlsWorkSheetExtracted.get_Range("A1", Type.Missing).ColumnWidth = 6f;
                            xlsWorkSheetExtracted.get_Range("B1", "D1").ColumnWidth = 45f;
                            xlsWorkSheetExtracted.get_Range("A1", "D1").RowHeight = 35f;
                            xlsWorkSheetExtracted.get_Range("A1", "D1").HorizontalAlignment = Constants.xlCenter;
                            xlsWorkSheetExtracted.get_Range("A1", "D1").VerticalAlignment = Constants.xlCenter;
                            xlsWorkSheetExtracted.get_Range("A1", "D1").WrapText = true;

                            xlsWorkSheetExtracted.get_Range("A1", "D1").Value2 = new object[] { "编号", "提取的信息", "英语", "俄语", };

                            string lastCell = "D" + (DrawingKeywords.Count + 1).ToString();
                            string lastNumberCell = "B" + (DrawingKeywords.Count + 1).ToString();

                            // 图纸格式 -- 内容
                            // 字体
                            xlsWorkSheetExtracted.get_Range("A2", lastCell).Font.Name = "Times New Roman";
                            xlsWorkSheetExtracted.get_Range("A2", lastCell).Font.Size = 11f;
                            xlsWorkSheetExtracted.get_Range("A2", lastCell).Font.Bold = false;

                            xlsWorkSheetExtracted.get_Range("A2", lastCell).RowHeight = 30f;

                            xlsWorkSheetExtracted.get_Range("A2", lastNumberCell).HorizontalAlignment = Constants.xlCenter;
                            xlsWorkSheetExtracted.get_Range("A2", lastNumberCell).VerticalAlignment = Constants.xlCenter;

                            xlsWorkSheetExtracted.get_Range("B2", lastCell).HorizontalAlignment = Constants.xlLeft;
                            xlsWorkSheetExtracted.get_Range("B2", lastCell).VerticalAlignment = Constants.xlCenter;

                            xlsWorkSheetExtracted.get_Range("A2", lastCell).WrapText = true;



                            for (int i = 1; i < DrawingKeywords.Count + 1; i++) {
                                xlsWorkSheetExtracted.get_Range("A" + (i + 1).ToString(), "D" + (i + 1).ToString()).Value2
                                    = new object[] { i.ToString(), DrawingKeywords[i - 1].Keyword, "", "", };
                            }
                        }

                        Flute.Service.MessageBoxWinForm.Info("成功", "成功导出设备表", "");

                        break;
                    #endregion

                    default:
                        break;
                }

                return true;

            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
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


                                    // ====================================
                    //                if (subSystem.Loops.Count > 0) {
                    //                    for (int j = 0; j < subSystem.Loops.Count; j++) {
                    //                        EQALoop loop = subSystem.Loops[j];
                    //                        if (loop.Equipments.Count > 0) {
                    //                            // 回路号                  
                    //                            xlsWorkSheet.get_Range("B" + eqpNumberInPages.ToString(), Missing.Value).Value2
                    //                                = FrmAZOVSTALEquipmentList.HasLoopNo ? loop.LoopNo : "";

                    //                            //检测与控制项目
                    //                            string item = loop.Location + loop.ProcParameter +
                    //                                (loop.HasLocalIndication ? @"/就地显示" : "") +
                    //                                (loop.HasLocalOperating ? @"/就地操作" : "") +
                    //                                (loop.HasComputerIndication ? @"/显示" : "") +
                    //                                (loop.HasComputerOperating ? @"/操作" : "") +
                    //                                (loop.HasRecording ? @"/记录" : "") +
                    //                                (loop.HasAlarm ? @"/报警" : "") +
                    //                                (loop.HasControlling ? @"/调节" : "") +
                    //                                (loop.HasInterlock ? @"/联锁" : "");

                    //                            xlsWorkSheet.get_Range("D" + eqpNumberInPages.ToString(), Missing.Value).Value2
                    //                                = FrmAZOVSTALEquipmentList.HasItems ? item : "";
                    //                        }

                    //                        for (int m = 0; m < loop.Equipments.Count; m++) {
                    //                            EQAEquipment eqp = loop.Equipments[m];
                    //                            if (!eqp.IsEquipment)
                    //                                continue;

                    //                            // 位号
                    //                            xlsWorkSheet.get_Range("C" + eqpNumberInPages.ToString(), Missing.Value).Value2
                    //                                = FrmAZOVSTALEquipmentList.HasTagNo ? eqp.TagNo : "";

                    //                            // 其他项目
                    //                            xlsWorkSheet.get_Range("E" + eqpNumberInPages.ToString(), "S" + eqpNumberInPages.ToString()).Value2
                    //                                = new object[] { FrmAZOVSTALEquipmentList.HasEqpName?eqp.Name:"",
                    //                                                 FrmAZOVSTALEquipmentList.HasEqpType?eqp.EqpType:"",
                    //                                                 FrmAZOVSTALEquipmentList.HasMeasuringRangeMin?eqp.LowerLimit:"",
                    //                                                 FrmAZOVSTALEquipmentList.HasMeasuringRangeMax?eqp.UpperLimit:"",
                    //                                                 FrmAZOVSTALEquipmentList.HasMeasuringRangeUnit?eqp.Unit:"",
                    //                                                 FrmAZOVSTALEquipmentList.HasInputSignal?eqp.InputSignal:"",
                    //                                                 FrmAZOVSTALEquipmentList.HasOutputSignal?eqp.OutputSignal:"",
                    //                                                 FrmAZOVSTALEquipmentList.HasPowerSupply?eqp.PowerSupply:"",
                    //                                                 FrmAZOVSTALEquipmentList.HasSpec?eqp.Spec1+",\n"+eqp.Spec2+",\n"+eqp.Spec3:"",
                    //                                                 FrmAZOVSTALEquipmentList.HasQuantity?eqp.Quantity.ToString():"",
                    //                                                 FrmAZOVSTALEquipmentList.HasLocation?eqp.FixedPlace:"",
                    //                                                 FrmAZOVSTALEquipmentList.HasOperationRangeMin?loop.LowerLimit:"",
                    //                                                 FrmAZOVSTALEquipmentList.HasOperationRangeMax?loop.UpperLimit:"",
                    //                                                 FrmAZOVSTALEquipmentList.HasOperationRangeUnit?loop.Unit:"",
                    //                                                 FrmAZOVSTALEquipmentList.HasRemark?eqp.Remark:""
                    //                                };

                    //                            eqpNumberInPages++;


                    //                            if (eqpNumberInPages >= 14) {
                    //                                currentPageNumber++;
                    //                                xlsWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlsApp.Worksheets[currentPageNumber];
                    //                                xlsWorkSheet.Name = (currentPageNumber).ToString();
                    //                                xlsWorkSheet.Activate();

                    //                                // 图纸格式
                    //                                // 字体
                    //                                xlsWorkSheet.get_Range("B7", "S13").Font.Name = "Times New Roman";
                    //                                xlsWorkSheet.get_Range("B7", "S13").Font.Size = 11f;

                    //                                // 格式
                    //                                xlsWorkSheet.get_Range("B7", "S13").HorizontalAlignment = Constants.xlCenter;
                    //                                xlsWorkSheet.get_Range("B7", "S13").VerticalAlignment = Constants.xlCenter;
                    //                                xlsWorkSheet.get_Range("M7", "M13").HorizontalAlignment = Constants.xlGeneral;
                    //                                xlsWorkSheet.get_Range("M7", "M13").VerticalAlignment = Constants.xlGeneral;
                    //                                xlsWorkSheet.get_Range("B7", "S13").WrapText = true;

                    //                                //
                    //                                // 图纸内容
                    //                                //
                    //                                // 项目名称
                    //                                xlsWorkSheet.get_Range("B2", Missing.Value).Value2
                    //                                                    = "项目名称：俄罗斯MMK冷轧公辅EP项目";
                    //                                // 子系统                  
                    //                                xlsWorkSheet.get_Range("B3", Missing.Value).Value2
                    //                                                    = "子系统：" + subSystem.Name;

                    //                                //
                    //                                // 图框内容
                    //                                xlsWorkSheet.Shapes.Item("BTL").Ungroup();
                    //                                // 专业
                    //                                xlsWorkSheet.Shapes.Item("DWG_SPECIALITY").TextFrame.Characters(Missing.Value, Missing.Value).Text = _speciality;
                    //                                // 设计阶段
                    //                                xlsWorkSheet.Shapes.Item("DESIGN_STAGE").TextFrame.Characters(Missing.Value, Missing.Value).Text = _stage;
                    //                                // 日期
                    //                                xlsWorkSheet.Shapes.Item("PRINT_DATE").TextFrame.Characters(Missing.Value, Missing.Value).Text = _date;
                    //                                // 室审
                    //                                xlsWorkSheet.Shapes.Item("DEPT_CHECKER").TextFrame.Characters(Missing.Value, Missing.Value).Text = _reviewedBy;
                    //                                // 审核
                    //                                xlsWorkSheet.Shapes.Item("DWG_CHECKER").TextFrame.Characters(Missing.Value, Missing.Value).Text = _checkedBy;
                    //                                // 设计
                    //                                xlsWorkSheet.Shapes.Item("DWG_DESIGN").TextFrame.Characters(Missing.Value, Missing.Value).Text = _designBy;
                    //                                // 制图
                    //                                xlsWorkSheet.Shapes.Item("DWG_DRAW").TextFrame.Characters(Missing.Value, Missing.Value).Text = _madeBy;
                    //                                // 合同号
                    //                                xlsWorkSheet.Shapes.Item("CONTRACT").TextFrame.Characters(Missing.Value, Missing.Value).Text = _contractNo;
                    //                                // 图号
                    //                                xlsWorkSheet.Shapes.Item("DRAWING_NO").TextFrame.Characters(Missing.Value, Missing.Value).Text = _drawingNo;
                    //                                // 高层代号
                    //                                xlsWorkSheet.Shapes.Item("=").TextFrame.Characters(Missing.Value, Missing.Value).Text = "=" + _topLevelNo;
                    //                                // 修改号
                    //                                xlsWorkSheet.Shapes.Item("REVISE_NO").TextFrame.Characters(Missing.Value, Missing.Value).Text = _revision;
                    //                                // 页次
                    //                                if (xlsWorkSheet.Index < pageCount)
                    //                                    xlsWorkSheet.Shapes.Item("PAGE").TextFrame.Characters(Missing.Value, Missing.Value).Text = xlsWorkSheet.Index.ToString() + "+";
                    //                                else
                    //                                    xlsWorkSheet.Shapes.Item("PAGE").TextFrame.Characters(Missing.Value, Missing.Value).Text = (xlsWorkSheet.Index).ToString();

                    //                                eqpNumberInPages = 7;
                    //                            }
                    //                        }
                    //                    }
                    //                }
                    //            }
                    //        }
                    //    }

                    //    break;

                    //case DrawingLanguage.English:

                    //    pageCount = 0;

                    //    foreach (EQASubSystem subSystem in subSystems) {
                    //        if ((subSystem.EquipmentsCount % 3 == 0))
                    //            pageCount += subSystem.EquipmentsCount / 3;
                    //        else
                    //            pageCount += Convert.ToInt32(Math.Ceiling(subSystem.EquipmentsCount / 3.0f));
                    //    }

                    //    (xlsApp.Worksheets[1] as Microsoft.Office.Interop.Excel.Worksheet).Shapes.Item("BTL").Ungroup();

                    //    // 图纸格式
                    //    // 字体
                    //    (xlsApp.Worksheets[1] as Microsoft.Office.Interop.Excel.Worksheet).get_Range("B9", "S14").Font.Name = "Times New Roman";
                    //    (xlsApp.Worksheets[1] as Microsoft.Office.Interop.Excel.Worksheet).get_Range("B9", "S14").Font.Size = 11f;

                    //    // 格式
                    //    (xlsApp.Worksheets[1] as Microsoft.Office.Interop.Excel.Worksheet).get_Range("B9", "S14").HorizontalAlignment = Constants.xlCenter;
                    //    (xlsApp.Worksheets[1] as Microsoft.Office.Interop.Excel.Worksheet).get_Range("B9", "S14").VerticalAlignment = Constants.xlCenter;
                    //    (xlsApp.Worksheets[1] as Microsoft.Office.Interop.Excel.Worksheet).get_Range("M9", "M14").HorizontalAlignment = Constants.xlGeneral;
                    //    (xlsApp.Worksheets[1] as Microsoft.Office.Interop.Excel.Worksheet).get_Range("B9", "S14").WrapText = true;

                    //    for (int i = 0; i < pageCount - 1; i++) {
                    //        (xlsApp.Worksheets[1] as Microsoft.Office.Interop.Excel.Worksheet).Copy(Missing.Value, xlsApp.Worksheets[1 + i]);
                    //    }

                    //    currentPageNumber = 0;
                    //    eqpNumberInPages = 9;

                    //    lock (subSystems) {
                    //        if (subSystems.Count > 0) {
                    //            for (int i = 0; i < subSystems.Count; i++) {
                    //                EQASubSystem subSystem = subSystems[i];
                    //                currentPageNumber++;
                    //                if (i > 0 && (subSystems[i - 1].EquipmentsCount % 3 == 0))
                    //                    currentPageNumber--;

                    //                eqpNumberInPages = 9;
                    //                xlsWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlsApp.Worksheets[currentPageNumber];
                    //                xlsWorkSheet.Name = (currentPageNumber).ToString();
                    //                xlsWorkSheet.Activate();                                    

                    //                //
                    //                // 图纸内容
                    //                //

                    //                // 子系统                  
                    //                xlsWorkSheet.get_Range("B3", Missing.Value).Value2
                    //                                    = "Sub-system/Подсистема: " + subSystem.Name;

                    //                //
                    //                // 图框内容

                    //                // 专业
                    //                xlsWorkSheet.Shapes.Item("DWG_SPECIALITY").TextFrame.Characters(Missing.Value, Missing.Value).Text = _speciality;
                    //                // 设计阶段
                    //                xlsWorkSheet.Shapes.Item("DESIGN_STAGE").TextFrame.Characters(Missing.Value, Missing.Value).Text = _stage;
                    //                // 日期
                    //                xlsWorkSheet.Shapes.Item("PRINT_DATE").TextFrame.Characters(Missing.Value, Missing.Value).Text = _date;
                    //                // 室审
                    //                xlsWorkSheet.Shapes.Item("DEPT_CHECKER").TextFrame.Characters(Missing.Value, Missing.Value).Text = _reviewedBy;
                    //                // 审核
                    //                xlsWorkSheet.Shapes.Item("DWG_CHECKER").TextFrame.Characters(Missing.Value, Missing.Value).Text = _checkedBy;
                    //                // 设计
                    //                xlsWorkSheet.Shapes.Item("DWG_DESIGN").TextFrame.Characters(Missing.Value, Missing.Value).Text = _designBy;
                    //                // 制图
                    //                xlsWorkSheet.Shapes.Item("DWG_DRAW").TextFrame.Characters(Missing.Value, Missing.Value).Text = _madeBy;
                    //                // 合同号
                    //                xlsWorkSheet.Shapes.Item("CONTRACT").TextFrame.Characters(Missing.Value, Missing.Value).Text = _contractNo;
                    //                // 图号
                    //                xlsWorkSheet.Shapes.Item("DRAWING_NO").TextFrame.Characters(Missing.Value, Missing.Value).Text = _drawingNo;
                    //                // 高层代号
                    //                xlsWorkSheet.Shapes.Item("=").TextFrame.Characters(Missing.Value, Missing.Value).Text = "="+_topLevelNo;
                    //                // 修改号
                    //                xlsWorkSheet.Shapes.Item("REVISE_NO").TextFrame.Characters(Missing.Value, Missing.Value).Text = _revision;
                    //                // 页次
                    //                if (xlsWorkSheet.Index < pageCount)
                    //                    xlsWorkSheet.Shapes.Item("PAGE").TextFrame.Characters(Missing.Value, Missing.Value).Text = xlsWorkSheet.Index.ToString() + "+";
                    //                else
                    //                    xlsWorkSheet.Shapes.Item("PAGE").TextFrame.Characters(Missing.Value, Missing.Value).Text = (xlsWorkSheet.Index).ToString();


                    //                if (subSystem.Loops.Count > 0) {
                    //                    for (int j = 0; j < subSystem.Loops.Count; j++) {
                    //                        EQALoop loop = subSystem.Loops[j];
                    //                        if (loop.Equipments.Count > 0) {
                    //                            // 回路号                  
                    //                            xlsWorkSheet.get_Range("B" + eqpNumberInPages.ToString(), Missing.Value).Value2
                    //                                = FrmAZOVSTALEquipmentList.HasLoopNo ? loop.LoopNo : "";

                    //                            //检测与控制项目
                    //                            string item = loop.Location + loop.ProcParameter +
                    //                                (loop.HasLocalIndication ? @"/就地显示" : "") +
                    //                                (loop.HasLocalOperating ? @"/就地操作" : "") +
                    //                                (loop.HasComputerIndication ? @"/显示" : "") +
                    //                                (loop.HasComputerOperating ? @"/操作" : "") +
                    //                                (loop.HasRecording ? @"/记录" : "") +
                    //                                (loop.HasAlarm ? @"/报警" : "") +
                    //                                (loop.HasControlling ? @"/调节" : "") +
                    //                                (loop.HasInterlock ? @"/联锁" : "");

                    //                            xlsWorkSheet.get_Range("D" + eqpNumberInPages.ToString(), Missing.Value).Value2
                    //                                = FrmAZOVSTALEquipmentList.HasItems ? item : "";
                    //                        }

                    //                        for (int m = 0; m < loop.Equipments.Count; m++) {
                    //                            EQAEquipment eqp = loop.Equipments[m];
                    //                            if (!eqp.IsEquipment)
                    //                                continue;

                    //                            // 位号
                    //                            xlsWorkSheet.get_Range("C" + eqpNumberInPages.ToString(), Missing.Value).Value2
                    //                                = FrmAZOVSTALEquipmentList.HasTagNo ? eqp.TagNo : "";

                    //                            // 其他项目
                    //                            xlsWorkSheet.get_Range("E" + eqpNumberInPages.ToString(), "S" + eqpNumberInPages.ToString()).Value2
                    //                                = new object[] { FrmAZOVSTALEquipmentList.HasEqpName?eqp.Name:"",
                    //                                                 FrmAZOVSTALEquipmentList.HasEqpType?eqp.EqpType:"",
                    //                                                 FrmAZOVSTALEquipmentList.HasMeasuringRangeMin?eqp.LowerLimit:"",
                    //                                                 FrmAZOVSTALEquipmentList.HasMeasuringRangeMax?eqp.UpperLimit:"",
                    //                                                 FrmAZOVSTALEquipmentList.HasMeasuringRangeUnit?eqp.Unit:"",
                    //                                                 FrmAZOVSTALEquipmentList.HasInputSignal?eqp.InputSignal:"",
                    //                                                 FrmAZOVSTALEquipmentList.HasOutputSignal?eqp.OutputSignal:"",
                    //                                                 FrmAZOVSTALEquipmentList.HasPowerSupply?eqp.PowerSupply:"",
                    //                                                 FrmAZOVSTALEquipmentList.HasSpec?eqp.Spec1+",\n"+eqp.Spec2:"",
                    //                                                 FrmAZOVSTALEquipmentList.HasQuantity?eqp.Quantity.ToString():"",
                    //                                                 FrmAZOVSTALEquipmentList.HasLocation?eqp.FixedPlace:"",
                    //                                                 FrmAZOVSTALEquipmentList.HasOperationRangeMin?loop.LowerLimit:"",
                    //                                                 FrmAZOVSTALEquipmentList.HasOperationRangeMax?loop.UpperLimit:"",
                    //                                                 FrmAZOVSTALEquipmentList.HasOperationRangeUnit?loop.Unit:"",
                    //                                                 FrmAZOVSTALEquipmentList.HasRemark?eqp.Remark:""
                    //                                };

                    //                            xlsWorkSheet.get_Range("B" + (eqpNumberInPages + 1).ToString(), "S" + (eqpNumberInPages + 1).ToString()).Value2
                    //                                = xlsWorkSheet.get_Range("B" + eqpNumberInPages.ToString(), "S" + eqpNumberInPages.ToString()).Value2;

                    //                            eqpNumberInPages += 2;

                    //                            if (eqpNumberInPages >= 15) {
                    //                                currentPageNumber++;
                    //                                xlsWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlsApp.Worksheets[currentPageNumber];
                    //                                xlsWorkSheet.Name = (currentPageNumber).ToString();
                    //                                xlsWorkSheet.Activate();
                                                    
                    //                                //
                    //                                // 图纸内容
                    //                                //
                    //                                // 子系统                  
                    //                                xlsWorkSheet.get_Range("B3", Missing.Value).Value2
                    //                                                    = "Sub-system/Подсистема: " + subSystem.Name;

                    //                                //
                    //                                // 图框内容
                                                    
                    //                                // 专业
                    //                                xlsWorkSheet.Shapes.Item("DWG_SPECIALITY").TextFrame.Characters(Missing.Value, Missing.Value).Text = _speciality;
                    //                                // 设计阶段
                    //                                xlsWorkSheet.Shapes.Item("DESIGN_STAGE").TextFrame.Characters(Missing.Value, Missing.Value).Text = _stage;
                    //                                // 日期
                    //                                xlsWorkSheet.Shapes.Item("PRINT_DATE").TextFrame.Characters(Missing.Value, Missing.Value).Text = _date;
                    //                                // 室审
                    //                                xlsWorkSheet.Shapes.Item("DEPT_CHECKER").TextFrame.Characters(Missing.Value, Missing.Value).Text = _reviewedBy;
                    //                                // 审核
                    //                                xlsWorkSheet.Shapes.Item("DWG_CHECKER").TextFrame.Characters(Missing.Value, Missing.Value).Text = _checkedBy;
                    //                                // 设计
                    //                                xlsWorkSheet.Shapes.Item("DWG_DESIGN").TextFrame.Characters(Missing.Value, Missing.Value).Text = _designBy;
                    //                                // 制图
                    //                                xlsWorkSheet.Shapes.Item("DWG_DRAW").TextFrame.Characters(Missing.Value, Missing.Value).Text = _madeBy;
                    //                                // 合同号
                    //                                xlsWorkSheet.Shapes.Item("CONTRACT").TextFrame.Characters(Missing.Value, Missing.Value).Text = _contractNo;
                    //                                // 图号
                    //                                xlsWorkSheet.Shapes.Item("DRAWING_NO").TextFrame.Characters(Missing.Value, Missing.Value).Text = _drawingNo;
                    //                                // 高层代号
                    //                                xlsWorkSheet.Shapes.Item("=").TextFrame.Characters(Missing.Value, Missing.Value).Text = "=" + _topLevelNo;
                    //                                // 修改号
                    //                                xlsWorkSheet.Shapes.Item("REVISE_NO").TextFrame.Characters(Missing.Value, Missing.Value).Text = _revision;
                    //                                // 页次
                    //                                if (xlsWorkSheet.Index < pageCount)
                    //                                    xlsWorkSheet.Shapes.Item("PAGE").TextFrame.Characters(Missing.Value, Missing.Value).Text = xlsWorkSheet.Index.ToString() + "+";
                    //                                else
                    //                                    xlsWorkSheet.Shapes.Item("PAGE").TextFrame.Characters(Missing.Value, Missing.Value).Text = (xlsWorkSheet.Index).ToString();

                    //                                eqpNumberInPages = 9;
                    //                            }
                    //                        }
                    //                    }
                    //                }
                    //            }
                    //        }
                    //    }


