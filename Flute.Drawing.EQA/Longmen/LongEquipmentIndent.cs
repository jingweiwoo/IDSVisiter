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
    public class LongEquipmentIndent : EQAEquipmentIndent
    {
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);

        enum EquipmentIndentType { Excel = 0, }

        DrawingLanguage _drawingLanguage = DrawingLanguage.SimpleChinese;
        IDictionary<string, string> subSystemIDprefixs = new Dictionary<string, string>();

        public LongEquipmentIndent(object drawingData)
        {
            DrawingData = drawingData;

            subSystemIDprefixs.Add(new KeyValuePair<string, string>("01", "槽上供料系统"));
            subSystemIDprefixs.Add(new KeyValuePair<string, string>("02", "槽下供料系统"));
            subSystemIDprefixs.Add(new KeyValuePair<string, string>("04", "炉顶系统"));
            subSystemIDprefixs.Add(new KeyValuePair<string, string>("05", "粗煤气系统"));
            subSystemIDprefixs.Add(new KeyValuePair<string, string>("06", "高炉本体"));
            subSystemIDprefixs.Add(new KeyValuePair<string, string>("07", "出铁场系统"));
            subSystemIDprefixs.Add(new KeyValuePair<string, string>("08", "渣处理系统"));
            subSystemIDprefixs.Add(new KeyValuePair<string, string>("09", "热风炉系统"));
            subSystemIDprefixs.Add(new KeyValuePair<string, string>("10", "煤粉制备喷吹系统"));
            subSystemIDprefixs.Add(new KeyValuePair<string, string>("11", "高炉主控楼"));
            subSystemIDprefixs.Add(new KeyValuePair<string, string>("12", "高炉煤气净化系统"));
            subSystemIDprefixs.Add(new KeyValuePair<string, string>("13", "TRT"));
            subSystemIDprefixs.Add(new KeyValuePair<string, string>("14", "鼓风机站"));
            subSystemIDprefixs.Add(new KeyValuePair<string, string>("15", "主循环水泵站"));
            subSystemIDprefixs.Add(new KeyValuePair<string, string>("16", "原煤储运设施"));
            subSystemIDprefixs.Add(new KeyValuePair<string, string>("18", "机修设施"));
            subSystemIDprefixs.Add(new KeyValuePair<string, string>("19", "总图及综合管网"));
            subSystemIDprefixs.Add(new KeyValuePair<string, string>("20", "原料除尘系统"));
            subSystemIDprefixs.Add(new KeyValuePair<string, string>("21", "出铁场除尘系统"));
            subSystemIDprefixs.Add(new KeyValuePair<string, string>("23", "铸铁机及铁水罐系统"));
            subSystemIDprefixs.Add(new KeyValuePair<string, string>("26", "区域空压站系统"));
            subSystemIDprefixs.Add(new KeyValuePair<string, string>("30", "喷煤空压站系统"));
            subSystemIDprefixs.Add(new KeyValuePair<string, string>("70", "全厂性五电公用"));
            subSystemIDprefixs.Add(new KeyValuePair<string, string>("73", "全厂性仪表"));
        }

        public bool Export(string templatePath)
        {
            EQASubSystemCollectin subSystems = DrawingData as EQASubSystemCollectin;

            if(subSystems.Count == 0)
                return true;

            subSystems.Sort();

            frmLongEquipmentIndent FrmLongEquipmentIndent = new frmLongEquipmentIndent();
            System.Windows.Forms.DialogResult dlgResult = FrmLongEquipmentIndent.ShowDialog();

            if(dlgResult == System.Windows.Forms.DialogResult.Cancel)
                return true;

            _drawingLanguage = FrmLongEquipmentIndent.Language;

            //
            // 设备中有用电电源一项暂没有使用
            // 本算法中将之用于设备归类
            // 首先提取设备类别的种类，然后分类，分子项列出设备
            //
            IList<string> equipmentTypes = new List<string>();

            lock(subSystems) {
                // SubSystems
                foreach(EQASubSystem subSystem in subSystems) {
                    if(subSystem.Loops.Count > 0) {
                        // Loops
                        foreach(EQALoop loop in subSystem.Loops) {
                            if(loop.Equipments.Count > 0) {
                                // Equipments
                                foreach(EQAEquipment equip in loop.Equipments) {
                                    if(!equipmentTypes.Contains(equip.PowerSupplySource.Trim()))
                                        equipmentTypes.Add(equip.PowerSupplySource.Trim());
                                }
                            } else { continue; }
                        }
                    } else { continue; }
                }
            }


            Microsoft.Office.Interop.Excel.ApplicationClass xlsApp = new ApplicationClass();
            // 打开文件  
            xlsApp.Workbooks.Add(FrmLongEquipmentIndent.TemplatePath);

            Microsoft.Office.Interop.Excel.Workbook xlsWorkBook
                                = xlsApp.Workbooks[1];
            xlsApp.Visible = true;

            try {
                int pageCount;
                int currentPageNumber;
                int currentLineNumber;
                int lastLineNumber;
                string currentprefix = "";

                Microsoft.Office.Interop.Excel.Worksheet xlsWorkSheet;

                switch(_drawingLanguage) {
                    case DrawingLanguage.English:
                        break;

                    case DrawingLanguage.SimpleChinese:
                        currentPageNumber = 1;

                        currentLineNumber = 4;
                        lastLineNumber = currentLineNumber;
                        currentprefix = "";

                        xlsWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlsApp.Worksheets[currentPageNumber];
                        xlsWorkSheet.Activate();

                        lock(subSystems) {
                            // SubSystems
                            foreach(EQASubSystem subSystem in subSystems) {
                                if(subSystem.Loops.Count > 0) {
                                    if(subSystem.SubSystemID.Length != 4) {
                                        xlsWorkSheet.get_Range("A" + currentLineNumber.ToString(), "I" + currentLineNumber.ToString()).Merge(false);
                                        xlsWorkSheet.get_Range("A" + currentLineNumber.ToString(), "A" + currentLineNumber.ToString()).Value2
                                            = subSystem.Name;
                                        xlsWorkSheet.get_Range("A" + currentLineNumber.ToString(), "A" + currentLineNumber.ToString()).RowHeight = 24;
                                        xlsWorkSheet.get_Range("A" + currentLineNumber.ToString(), "A" + currentLineNumber.ToString()).Interior.ColorIndex = 33;

                                        lastLineNumber = currentLineNumber++;

                                    } else if(subSystem.SubSystemID.Length == 4 && !subSystemIDprefixs.ContainsKey(subSystem.SubSystemID.Substring(0, 2))) {
                                        xlsWorkSheet.get_Range("A" + currentLineNumber.ToString(), "I" + currentLineNumber.ToString()).Merge(false);
                                        xlsWorkSheet.get_Range("A" + currentLineNumber.ToString(), "A" + currentLineNumber.ToString()).Value2
                                            = subSystem.Name;
                                        xlsWorkSheet.get_Range("A" + currentLineNumber.ToString(), "A" + currentLineNumber.ToString()).RowHeight = 24;
                                        xlsWorkSheet.get_Range("A" + currentLineNumber.ToString(), "A" + currentLineNumber.ToString()).Interior.ColorIndex = 33;

                                        lastLineNumber = currentLineNumber++;

                                    } else if(subSystem.SubSystemID.Length == 4
                                        && subSystemIDprefixs.ContainsKey(subSystem.SubSystemID.Substring(0, 2))
                                            && subSystem.SubSystemID.Substring(0, 2) != currentprefix) {
                                        currentprefix = subSystem.SubSystemID.Substring(0, 2);

                                        xlsWorkSheet.get_Range("A" + currentLineNumber.ToString(), "I" + currentLineNumber.ToString()).Merge(false);
                                        xlsWorkSheet.get_Range("A" + currentLineNumber.ToString(), "A" + currentLineNumber.ToString()).Value2
                                            = subSystemIDprefixs[currentprefix];
                                        xlsWorkSheet.get_Range("A" + currentLineNumber.ToString(), "A" + currentLineNumber.ToString()).RowHeight = 24;
                                        xlsWorkSheet.get_Range("A" + currentLineNumber.ToString(), "A" + currentLineNumber.ToString()).Interior.ColorIndex = 33;

                                        lastLineNumber = currentLineNumber++;
                                    }

                                    // Loops
                                    foreach(EQALoop loop in subSystem.Loops) {
                                        if(loop.Equipments.Count > 0) {
                                            // Equipments
                                            foreach(EQAEquipment equip in loop.Equipments) {
                                                xlsWorkSheet.get_Range("A" + currentLineNumber.ToString(), "J" + currentLineNumber.ToString()).Value2
                                                    = new object[] {
                                                                    equip.TagNo,
                                                                    equip.Name,
                                                                    equip.EqpType,
                                                                    equip.Quantity,
                                                                    equip.LowerLimit + "~" + equip.UpperLimit+equip.Unit,
                                                                    equip.Spec1 + " " + equip.Spec2 + " " + equip.Spec3,
                                                                    equip.Remark,
                                                                    loop.LoopNo,
                                                                    loop.Location + loop.ProcParameter,
                                                                    equip.FixedPlace,
                                                        };
                                                ++currentLineNumber;
                                            }

                                            xlsWorkSheet.PageSetup.PrintArea = "$A$1"
                                                            + ":" + "$J$" + (currentLineNumber - 1).ToString();

                                            //if (lastLineNumber + 1 == currentLineNumber
                                            //    && subSystemIDprefixs.Values.Contains(
                                            //        Convert.ToString(xlsWorkSheet.get_Range("A" + lastLineNumber.ToString(), "A" + lastLineNumber.ToString()).Value2))) {
                                            //    xlsWorkSheet.get_Range("A" + lastLineNumber.ToString(), "I" + lastLineNumber.ToString())
                                            //            .Delete(XlDeleteShiftDirection.xlShiftUp);
                                            //    currentLineNumber--;
                                            //}
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

            } catch(Exception ex) {
                string e = ex.Message;
                return false;
            }
        }
    }
}
