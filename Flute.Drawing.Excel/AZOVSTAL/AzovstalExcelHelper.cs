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

namespace Flute.Drawing.Excel
{
    public class AzovstalExcelHelper
    {
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);

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
                // 如果序号列的值为空，说明该行有可能是子项的名称
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
                    // 如果序号列的下一列不为空,说明专业作业计划还没有结束,暂且将其看作子项
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
                string currentCellContent = "";

                DrawingKeyword foundKeyword = new DrawingKeyword();

                string englishTrans = "";
                string russianTrans = "";

                for (int i = 1; i < workSheetCount; i++) {
                    xlsWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlsApp.Worksheets.get_Item(i);
                    xlsWorkSheet.Activate();

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

    }
}
