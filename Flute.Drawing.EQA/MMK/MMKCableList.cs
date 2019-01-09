using System;
using System.Collections.Generic;
// using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using Microsoft.Office;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

using Flute.DataStruct.EQA;
using Flute.Drawing;

namespace Flute.Drawing.EQA
{
    public class MMKCableList : EQACableList
    {
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);

        enum CableListType { Excel = 0, }

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

        public MMKCableList(object drawingData)
        {
            DrawingData = drawingData;
        }

        public bool Export(string templatePath)
        {
            EQASubSystemCollectin subSystems = DrawingData as EQASubSystemCollectin;

            if (subSystems.Count == 0)
                return true;

            subSystems.Sort();

            frmMMKCableList FrmMMKCableList = new frmMMKCableList();
            System.Windows.Forms.DialogResult dlgResult = FrmMMKCableList.ShowDialog();

            if (dlgResult == System.Windows.Forms.DialogResult.Cancel)
                return true;

            _drawingLanguage = FrmMMKCableList.Language;

            _contractNo = FrmMMKCableList.ContractNo;
            _drawingNo = FrmMMKCableList.DrawingNo;
            _revision = FrmMMKCableList.Revision;
            _topLevelNo = FrmMMKCableList.TopLevelNo;
            _speciality = FrmMMKCableList.Speciality;
            _stage = FrmMMKCableList.Stage;
            _date = FrmMMKCableList.Date;
            _madeBy = FrmMMKCableList.MadeBy;
            _designBy = FrmMMKCableList.DesignBy;
            _checkedBy = FrmMMKCableList.CheckedBy;
            _reviewedBy = FrmMMKCableList.ApprovedBy;

            Microsoft.Office.Interop.Excel.ApplicationClass xlsApp = new ApplicationClass();
            // 打开文件  
            xlsApp.Workbooks.Add(FrmMMKCableList.TemplatePath);

            Microsoft.Office.Interop.Excel.Workbook xlsWorkBook
                                = xlsApp.Workbooks[1];
            xlsApp.Visible = true;

            try {
                int pageCount;
                int currentPageNumber;
                int cableNumberInPages;

                int currentCableNumber;

                Microsoft.Office.Interop.Excel.Worksheet xlsWorkSheet;

                switch (_drawingLanguage) {
                    case DrawingLanguage.SimpleChinese:
                        break;

                    case DrawingLanguage.English:
                        pageCount = 0;

                        foreach (EQASubSystem subSystem in subSystems) {
                            pageCount +=subSystem.CablesCount;
                        }

                        if ((pageCount % 5 == 0))
                            pageCount = pageCount / 5;
                        else
                            pageCount = Convert.ToInt32(Math.Ceiling(pageCount / 5.0f));

                        (xlsApp.Worksheets[1] as Microsoft.Office.Interop.Excel.Worksheet).Shapes.Item("BTL").Ungroup();

                        // 图纸格式
                        // 字体
                        //(xlsApp.Worksheets[1] as Microsoft.Office.Interop.Excel.Worksheet).get_Range("B9", "S14").Font.Name = "Times New Roman";
                        //(xlsApp.Worksheets[1] as Microsoft.Office.Interop.Excel.Worksheet).get_Range("B9", "S14").Font.Size = 11f;

                        //// 格式
                        //(xlsApp.Worksheets[1] as Microsoft.Office.Interop.Excel.Worksheet).get_Range("B9", "S14").HorizontalAlignment = Constants.xlCenter;
                        //(xlsApp.Worksheets[1] as Microsoft.Office.Interop.Excel.Worksheet).get_Range("B9", "S14").VerticalAlignment = Constants.xlCenter;
                        //(xlsApp.Worksheets[1] as Microsoft.Office.Interop.Excel.Worksheet).get_Range("M9", "M14").HorizontalAlignment = Constants.xlGeneral;
                        //(xlsApp.Worksheets[1] as Microsoft.Office.Interop.Excel.Worksheet).get_Range("B9", "S14").WrapText = true;

                        for (int i = 0; i < pageCount - 1; i++) {
                            (xlsApp.Worksheets[1] as Microsoft.Office.Interop.Excel.Worksheet).Copy(Missing.Value, xlsApp.Worksheets[1 + i]);
                        }

                        currentPageNumber = 1;
                        cableNumberInPages = 4;
                        currentCableNumber = 1;

                        lock (subSystems) {
                            if (subSystems.Count > 0) {
                                for (int i = 0; i < subSystems.Count; i++) {
                                    EQASubSystem subSystem = subSystems[i];
                                    
                                    xlsWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlsApp.Worksheets[currentPageNumber];
                                    xlsWorkSheet.Name = (currentPageNumber).ToString();
                                    xlsWorkSheet.Activate();

                                    if (xlsWorkSheet.Index == 1) {
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
                                    }

                                    //
                                    // 图纸内容
                                    //                                    

                                    if (subSystem.Cables.Count > 0) {
                                        for (int j = 0; j < subSystem.Cables.Count; j++) {
                                            EQACable cable = subSystem.Cables[j];

                                            // 电缆内容
                                            string[] cableSpec = cable.CableSpec.Split(' ');

                                            xlsWorkSheet.get_Range("B" + cableNumberInPages.ToString(), "O" + cableNumberInPages.ToString()).Value2
                                                = new object[] { (currentCableNumber++).ToString(),
                                                                     cable.CableNo,
                                                                     cable.StartPosition,
                                                                     subSystems.EquipmentInSubSystems(cable.StartPosition) != null ?
                                                                            subSystems.EquipmentInSubSystems(cable.StartPosition).Area:"",
                                                                     cable.EndPosition,
                                                                     subSystems.EquipmentInSubSystems(cable.EndPosition) != null ?
                                                                            subSystems.EquipmentInSubSystems(cable.EndPosition).Area:"",
                                                                     cableSpec[0],
                                                                     cableSpec[cableSpec.Length-1],
                                                                     cable.CableLength,
                                                                     cable.Route,
                                                                     cable.ConductSpec,
                                                                     cable.ConductLength,
                                                                     "",
                                                                     cable.Remark,
                                                    };

                                            xlsWorkSheet.get_Range("B" + (cableNumberInPages + 1).ToString(), "O" + (cableNumberInPages + 1).ToString()).Value2
                                                = xlsWorkSheet.get_Range("B" + cableNumberInPages.ToString(), "O" + cableNumberInPages.ToString()).Value2;

                                            cableNumberInPages += 2;

                                            if (cableNumberInPages >= 14) {
                                                currentPageNumber++;
                                                xlsWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlsApp.Worksheets[currentPageNumber];
                                                xlsWorkSheet.Name = (currentPageNumber).ToString();
                                                xlsWorkSheet.Activate();

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

                                                cableNumberInPages = 4;
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
        }
    }
}
