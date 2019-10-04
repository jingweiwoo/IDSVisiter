using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Drawing;
using System.IO;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

using Flute.Drawing;
using Flute.Service;

using Flute.DataStruct.IDS;

namespace Flute.Drawing.Excel
{
    public class AzovstalExcelHelper
    {
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);

        #region .Function - Modify Drawing Marks.

        public static void ModifyEquipmentListDrawingMarks(string fileName)
        {
            Console.WriteLine("calling Flute.Drawing.Excel.AzovstalExcelHelper.ModifyEquipmentListDrawingMarks");

            frmAZOVSTALEquipmentListModifyDrawingMarks FrmAZOVSTALEquipmentListModifyDrawingMarks = new frmAZOVSTALEquipmentListModifyDrawingMarks(new IDSDesignInfo());
            System.Windows.Forms.DialogResult dlgResult = FrmAZOVSTALEquipmentListModifyDrawingMarks.ShowDialog();

            if (dlgResult == System.Windows.Forms.DialogResult.Cancel)
                return;

            bool _modifyApprovedBy = FrmAZOVSTALEquipmentListModifyDrawingMarks.ModifyApprovedBy;
            bool _modifyCheckedBy = FrmAZOVSTALEquipmentListModifyDrawingMarks.ModifyCheckedBy;
            bool _modifyDesignedBy = FrmAZOVSTALEquipmentListModifyDrawingMarks.ModifyDesignedBy;
            bool _modifyMadeBy = FrmAZOVSTALEquipmentListModifyDrawingMarks.ModifyMadeBy;
            bool _modifyProjectID = FrmAZOVSTALEquipmentListModifyDrawingMarks.ModifyProjectID;
            bool _modifyDrawingID = FrmAZOVSTALEquipmentListModifyDrawingMarks.ModifyDrawingID;
            bool _modifySpeciality = FrmAZOVSTALEquipmentListModifyDrawingMarks.ModifySpeciality;
            bool _modifyStage = FrmAZOVSTALEquipmentListModifyDrawingMarks.ModifyStage;
            bool _modifyDate = FrmAZOVSTALEquipmentListModifyDrawingMarks.ModifyDate;
            bool _modifyContractNo = FrmAZOVSTALEquipmentListModifyDrawingMarks.ModifyContractNo;
            bool _modifyRevision = FrmAZOVSTALEquipmentListModifyDrawingMarks.ModifyRevision;
            bool _modifyTopLevelNo = FrmAZOVSTALEquipmentListModifyDrawingMarks.ModifyTopLevelNo;

            string _stringApprovedBy = FrmAZOVSTALEquipmentListModifyDrawingMarks.ApprovedBy;
            string _stringCheckedBy = FrmAZOVSTALEquipmentListModifyDrawingMarks.CheckedBy;
            string _stringDesignedBy = FrmAZOVSTALEquipmentListModifyDrawingMarks.DesignedBy;
            string _stringMadeBy = FrmAZOVSTALEquipmentListModifyDrawingMarks.MadeBy;
            string _stringProjectID = FrmAZOVSTALEquipmentListModifyDrawingMarks.ProjectID;
            string _stringDrawingID = FrmAZOVSTALEquipmentListModifyDrawingMarks.DrawingID;
            string _stringSpeciality = FrmAZOVSTALEquipmentListModifyDrawingMarks.Speciality;
            string _stringStage = FrmAZOVSTALEquipmentListModifyDrawingMarks.Stage;
            string _stringDate = FrmAZOVSTALEquipmentListModifyDrawingMarks.Date;
            string _stringContractNo = FrmAZOVSTALEquipmentListModifyDrawingMarks.ContractNo;
            string _stringRevision = FrmAZOVSTALEquipmentListModifyDrawingMarks.Revision;
            string _stringTopLevelNo = FrmAZOVSTALEquipmentListModifyDrawingMarks.TopLevelNo;

            FrmAZOVSTALEquipmentListModifyDrawingMarks.Close();

            Microsoft.Office.Interop.Excel.ApplicationClass xlsApp = new ApplicationClass();

            // 打开文件
            xlsApp.Workbooks.Open(fileName, Missing.Value,
                                     XlFileAccess.xlReadOnly, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                                        Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                                            Missing.Value, Missing.Value);

            xlsApp.Visible = true;

            int workSheetCount = xlsApp.Worksheets.Count;

            Microsoft.Office.Interop.Excel.Workbook xlsWorkBook
                                = xlsApp.Workbooks.get_Item(1);

            Microsoft.Office.Interop.Excel.Worksheet xlsWorkSheet;

            if (workSheetCount > 0) {
                for (int i = 1; i < workSheetCount; i++) {
                    xlsWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlsApp.Worksheets.get_Item(i);
                    xlsWorkSheet.Activate();

                    //
                    // 图框内容

                    // 专业
                    if (_modifySpeciality)
                        try {
                            xlsWorkSheet.Shapes.Item("DWG_SPECIALITY").TextFrame.Characters(Missing.Value, Missing.Value).Text = _stringSpeciality;
                        } catch {
                            // Do Nothing
                        }

                    // 设计阶段
                    if (_modifyStage)
                        try {
                            xlsWorkSheet.Shapes.Item("DESIGN_STAGE").TextFrame.Characters(Missing.Value, Missing.Value).Text = _stringStage;
                        } catch {
                            // Do Nothing
                        }

                    // 日期
                    if (_modifyDate)
                        try {
                            xlsWorkSheet.Shapes.Item("PRINT_DATE").TextFrame.Characters(Missing.Value, Missing.Value).Text = _stringDate;
                        } catch {
                            // Do Nothing
                        }

                    // 室审
                    if (_modifyApprovedBy)
                        try {
                            xlsWorkSheet.Shapes.Item("DEPT_CHECKER").TextFrame.Characters(Missing.Value, Missing.Value).Text = _stringApprovedBy;
                        } catch {
                            // Do Nothing
                        }

                    // 审核
                    if (_modifyCheckedBy)
                        try {
                            xlsWorkSheet.Shapes.Item("DWG_CHECKER").TextFrame.Characters(Missing.Value, Missing.Value).Text = _stringCheckedBy;
                        } catch {
                            // Do Nothing
                        }

                    // 设计
                    if (_modifyDesignedBy)
                        try {
                            xlsWorkSheet.Shapes.Item("DWG_DESIGNER").TextFrame.Characters(Missing.Value, Missing.Value).Text = _stringDesignedBy;
                        } catch {
                            // Do Nothing
                        }

                    // 制图
                    if (_modifyMadeBy)
                        try {
                            xlsWorkSheet.Shapes.Item("DWG_DRAW").TextFrame.Characters(Missing.Value, Missing.Value).Text = _stringMadeBy;
                        } catch {
                            // Do Nothing
                        }

                    //// 合同号
                    //xlsWorkSheet.Shapes.Item("CONTRACT").TextFrame.Characters(Missing.Value, Missing.Value).Text = _contractNo;
                    //项目编码
                    if (_modifyProjectID)
                        try {
                            xlsWorkSheet.Shapes.Item("PROJECT_NO").TextFrame.Characters(Missing.Value, Missing.Value).Text = _stringProjectID;
                        } catch {
                            // Do Nothing
                        }

                    // 图号
                    if (_modifyDrawingID)
                        try {
                            xlsWorkSheet.Shapes.Item("DRAWING_NO").TextFrame.Characters(Missing.Value, Missing.Value).Text = _stringDrawingID;
                        } catch {
                            // Do Nothing
                        }

                    //// 高层代号
                    //xlsWorkSheet.Shapes.Item("=").TextFrame.Characters(Missing.Value, Missing.Value).Text = "=" + _topLevelNo;
                    // 修改号
                    if (_modifyRevision)
                        try {
                            xlsWorkSheet.Shapes.Item("REVISE_NO").TextFrame.Characters(Missing.Value, Missing.Value).Text = _stringRevision;
                        } catch {
                            // Do Nothing
                        }
                }
            }

            Flute.Service.MessageBoxWinForm.Info("成功", "成功修改设备表图框内容", "");
        }

        #endregion // Function - Modify Drawing Marks

        #region .Function - ReadKeywordList.
        public static DrawingKeywordCollection ReadKeywordList(string fileName)
        {
            DrawingKeywordCollection drawingKeywords = new DrawingKeywordCollection();

            Microsoft.Office.Interop.Excel.ApplicationClass xlsApp = new ApplicationClass();

            // 打开文件
            xlsApp.Workbooks.Open(fileName, Missing.Value,
                                     XlFileAccess.xlReadOnly, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                                        Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                                            Missing.Value, Missing.Value);

            xlsApp.Visible = true;

            Microsoft.Office.Interop.Excel.Workbook xlsWorkBook
                                = xlsApp.Workbooks.get_Item(1);
            Microsoft.Office.Interop.Excel.Worksheet xlsWorkSheet
                                = (Microsoft.Office.Interop.Excel.Worksheet)xlsApp.Worksheets.get_Item(xlsApp.Worksheets.Count);

            xlsWorkSheet.Activate();

            return drawingKeywords;
        }

        #endregion // Function - ReadKeywordList

        #region .Function - ReplaceEquipmentListKeywords.

        public static DrawingKeywordCollection ReplaceEquipmentListKeywords(string fileName, 
                                                                            DrawingKeywordCollection keywords)
        {
            Console.WriteLine("calling Flute.Drawing.Excel.AzovstalExcelHelper.ReplaceEquipmentListKeywords");

            DrawingKeywordCollection drawingKeywords = new DrawingKeywordCollection();

            frmAZOVSTALReplaceTrans FrmAZOVSTALReplaceTrans = new frmAZOVSTALReplaceTrans();
            System.Windows.Forms.DialogResult dlgResult = FrmAZOVSTALReplaceTrans.ShowDialog();

            if (dlgResult == System.Windows.Forms.DialogResult.Cancel)
                return drawingKeywords;

            bool replaceEnglishTrans = FrmAZOVSTALReplaceTrans.SelectedEnglishTrans;
            bool replaceRussianTrans = FrmAZOVSTALReplaceTrans.SelectedRussianTrans;

            FrmAZOVSTALReplaceTrans.Close();

            Microsoft.Office.Interop.Excel.ApplicationClass xlsApp = new ApplicationClass();

            // 打开文件
            xlsApp.Workbooks.Open(fileName, Missing.Value,
                                     XlFileAccess.xlReadOnly, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                                        Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                                            Missing.Value, Missing.Value);

            xlsApp.Visible = true;

            int workSheetCount = xlsApp.Worksheets.Count;

            Microsoft.Office.Interop.Excel.Workbook xlsWorkBook
                                = xlsApp.Workbooks.get_Item(1);
            Microsoft.Office.Interop.Excel.Worksheet xlsWorkSheet
                                = (Microsoft.Office.Interop.Excel.Worksheet)xlsApp.Worksheets.get_Item(workSheetCount);

            xlsWorkSheet.Activate();

            int nullCellNumber = 0;
            int currentCellNumber = 2;

            string keyword = "";
            string keywordInEnglish = "";
            string keywordInRussian = "";

            for (int i = 2; i < 65536; i++) {
                if (Convert.ToString(xlsWorkSheet.get_Range("A" + i.ToString(), Missing.Value).Value2) == String.Empty) {
                    keyword = Convert.ToString(xlsWorkSheet.get_Range("B" + i.ToString(), Missing.Value).Value2);
                    // 如果序号列的下一列也为空，没有Keyword
                    if (keyword == String.Empty) {
                        nullCellNumber++;

                        // 如果10行都是这样，那就是完了
                        if (nullCellNumber >= 10)
                            break;
                        else
                            continue;
                    }
                }

                    else {
                    nullCellNumber = 0;
                    currentCellNumber = i;

                    keyword = Convert.ToString(xlsWorkSheet.get_Range("B" + i.ToString(), Missing.Value).Value2);
                    keywordInEnglish = Convert.ToString(xlsWorkSheet.get_Range("C" + i.ToString(), Missing.Value).Value2);
                    keywordInRussian = Convert.ToString(xlsWorkSheet.get_Range("D" + i.ToString(), Missing.Value).Value2);

                    KeywordInOtherLanguageCollection translated = new KeywordInOtherLanguageCollection();
                    translated.Add(new KeywordInOtherLanguage(DrawingLanguage.English, keywordInEnglish));
                    translated.Add(new KeywordInOtherLanguage(DrawingLanguage.Russian, keywordInRussian));

                    DrawingKeyword KEYWORD = new DrawingKeyword(keyword, translated, new KeywordLocationCollection());

                    drawingKeywords.AddKeyword(KEYWORD);
                }
            }

            if (drawingKeywords.Count > 0) {
                int currentLine = 9;
                string currentSubSystem = "";
                string currentCellContent = "";

                DrawingKeyword foundKeyword = new DrawingKeyword();

                string englishTrans = "";
                string russianTrans = "";

                for (int i = 1; i < workSheetCount; i++) {
                    xlsWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlsApp.Worksheets.get_Item(i);
                    xlsWorkSheet.Activate();

                    // SubSystem
                    currentSubSystem = Convert.ToString(xlsWorkSheet.get_Range("B3", Missing.Value).Value2);

                    if (drawingKeywords.ContainsKeyword(currentSubSystem)) {
                        foundKeyword = drawingKeywords[currentSubSystem];
                        englishTrans = foundKeyword.KeywordsInOtherLanguage[DrawingLanguage.English].Translated;
                        // russianTrans = foundKeyword.KeywordsInOtherLanguage[DrawingLanguage.Russian].Translated;

                        xlsWorkSheet.get_Range("B3", Missing.Value).Value2 = englishTrans;
                    }

                    for (int j = 9; j < 15; j = j + 2) {
                        // Monitoring and control items
                        currentCellContent = Convert.ToString(xlsWorkSheet.get_Range("D" + j.ToString(), Missing.Value).Value2);
                        
                        if (drawingKeywords.ContainsKeyword(currentCellContent)) {
                            foundKeyword = drawingKeywords[currentCellContent];
                            englishTrans = foundKeyword.KeywordsInOtherLanguage[DrawingLanguage.English].Translated;
                            russianTrans = foundKeyword.KeywordsInOtherLanguage[DrawingLanguage.Russian].Translated;

                            if (replaceEnglishTrans == true && englishTrans != "")
                                xlsWorkSheet.get_Range("D" + j.ToString(), Missing.Value).Value2 = englishTrans;
                            if (replaceRussianTrans == true && russianTrans != "")
                                xlsWorkSheet.get_Range("D" + (j + 1).ToString(), Missing.Value).Value2 = russianTrans;
                        }

                        // Medium
                        currentCellContent = Convert.ToString(xlsWorkSheet.get_Range("E" + j.ToString(), Missing.Value).Value2);

                        if (drawingKeywords.ContainsKeyword(currentCellContent)) {
                            foundKeyword = drawingKeywords[currentCellContent];
                            englishTrans = foundKeyword.KeywordsInOtherLanguage[DrawingLanguage.English].Translated;
                            russianTrans = foundKeyword.KeywordsInOtherLanguage[DrawingLanguage.Russian].Translated;

                            if (replaceEnglishTrans == true && englishTrans != "")
                                xlsWorkSheet.get_Range("E" + j.ToString(), Missing.Value).Value2 = englishTrans;
                            if (replaceRussianTrans == true && russianTrans != "")
                                xlsWorkSheet.get_Range("E" + (j + 1).ToString(), Missing.Value).Value2 = russianTrans;
                        }

                        // Equipment Name
                        currentCellContent = Convert.ToString(xlsWorkSheet.get_Range("F" + j.ToString(), Missing.Value).Value2);

                        if (drawingKeywords.ContainsKeyword(currentCellContent)) {
                            foundKeyword = drawingKeywords[currentCellContent];
                            englishTrans = foundKeyword.KeywordsInOtherLanguage[DrawingLanguage.English].Translated;
                            russianTrans = foundKeyword.KeywordsInOtherLanguage[DrawingLanguage.Russian].Translated;

                            if (replaceEnglishTrans == true && englishTrans != "")
                                xlsWorkSheet.get_Range("F" + j.ToString(), Missing.Value).Value2 = englishTrans;
                            if (replaceRussianTrans == true && russianTrans != "")
                                xlsWorkSheet.get_Range("F" + (j + 1).ToString(), Missing.Value).Value2 = russianTrans;
                        }

                        // Supplier
                        currentCellContent = Convert.ToString(xlsWorkSheet.get_Range("K" + j.ToString(), Missing.Value).Value2);

                        if (drawingKeywords.ContainsKeyword(currentCellContent)) {
                            foundKeyword = drawingKeywords[currentCellContent];
                            englishTrans = foundKeyword.KeywordsInOtherLanguage[DrawingLanguage.English].Translated;
                            russianTrans = foundKeyword.KeywordsInOtherLanguage[DrawingLanguage.Russian].Translated;

                            if (replaceEnglishTrans == true && englishTrans != "")
                                xlsWorkSheet.get_Range("K" + j.ToString(), Missing.Value).Value2 = englishTrans;
                            if (replaceRussianTrans == true && russianTrans != "")
                                xlsWorkSheet.get_Range("K" + (j + 1).ToString(), Missing.Value).Value2 = russianTrans;
                        }

                        // Specification
                        currentCellContent = Convert.ToString(xlsWorkSheet.get_Range("L" + j.ToString(), Missing.Value).Value2);

                        if (drawingKeywords.ContainsKeyword(currentCellContent)) {
                            foundKeyword = drawingKeywords[currentCellContent];
                            englishTrans = foundKeyword.KeywordsInOtherLanguage[DrawingLanguage.English].Translated;
                            russianTrans = foundKeyword.KeywordsInOtherLanguage[DrawingLanguage.Russian].Translated;

                            if (replaceEnglishTrans == true && englishTrans != "")
                                xlsWorkSheet.get_Range("L" + j.ToString(), Missing.Value).Value2 = englishTrans;
                            if (replaceRussianTrans == true && russianTrans != "")
                                xlsWorkSheet.get_Range("L" + (j + 1).ToString(), Missing.Value).Value2 = russianTrans;
                        }

                        // Ins. Location
                        currentCellContent = Convert.ToString(xlsWorkSheet.get_Range("N" + j.ToString(), Missing.Value).Value2);

                        if (drawingKeywords.ContainsKeyword(currentCellContent)) {
                            foundKeyword = drawingKeywords[currentCellContent];
                            englishTrans = foundKeyword.KeywordsInOtherLanguage[DrawingLanguage.English].Translated;
                            russianTrans = foundKeyword.KeywordsInOtherLanguage[DrawingLanguage.Russian].Translated;

                            if (replaceEnglishTrans == true && englishTrans != "")
                                xlsWorkSheet.get_Range("N" + j.ToString(), Missing.Value).Value2 = englishTrans;
                            if (replaceRussianTrans == true && russianTrans != "")
                                xlsWorkSheet.get_Range("N" + (j + 1).ToString(), Missing.Value).Value2 = russianTrans;
                        }

                        // Remark
                        currentCellContent = Convert.ToString(xlsWorkSheet.get_Range("O" + j.ToString(), Missing.Value).Value2);

                        if (drawingKeywords.ContainsKeyword(currentCellContent)) {
                            foundKeyword = drawingKeywords[currentCellContent];
                            englishTrans = foundKeyword.KeywordsInOtherLanguage[DrawingLanguage.English].Translated;
                            russianTrans = foundKeyword.KeywordsInOtherLanguage[DrawingLanguage.Russian].Translated;

                            if (replaceEnglishTrans == true && englishTrans != "")
                                xlsWorkSheet.get_Range("O" + j.ToString(), Missing.Value).Value2 = englishTrans;
                            if (replaceRussianTrans == true && russianTrans != "")
                                xlsWorkSheet.get_Range("O" + (j + 1).ToString(), Missing.Value).Value2 = russianTrans;
                        }
                    }
                }
            }

            Flute.Service.MessageBoxWinForm.Info("成功", "成功替换设备表翻译项", "");

            return drawingKeywords;
        }

        #endregion .Function - ReplaceEquipmentListKeywords.
    }
}
