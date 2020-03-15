using System;
using System.Collections.Generic;
using System.Text;

namespace Flute.DataStruct.IDS
{
    /// <summary>
    /// 对应分组表"类型"项的内容
    /// </summary>
    public class IDSEnumSystemType
    {
        public static string System { get { return "系统"; } }
        public static string SubSystem { get { return "子系统"; } }
        public static string SubLoop { get { return "子回路"; } }
        public static string Region { get { return "区域"; } }
        public static string SubRegion { get { return "子区域"; } }
        public static string EquipmentCatagory { get { return "设备类别"; } }
        public static string MountingCatagory { get { return "安装类别"; } }
    }

    /// <summary>
    /// 对应安装方案表"类型"项的内容
    /// </summary>
    public class IDSEnumMountingType
    {
        public static string TubeConnection { get { return "导管连接"; } }
        public static string EquipmentMounting { get { return "设备安装"; } }
    }

    public static class IDSEnumSignalCategory
    {
        public const string State = "状态";
        public const string Command = "命令";
        public const string Request = "请求";
        public const string Indication = "显示";
        public const string Others = "其它";
    }

    public static class IDSEnumSignalCategoryCode
    {
        public static string GetCategoryCode(string signalCategory)
        {
            switch (signalCategory) {
                case IDSEnumSignalCategory.State:
                    return IDSEnumSignalCategoryCode.State;

                case IDSEnumSignalCategory.Command:
                    return IDSEnumSignalCategoryCode.Command;

                case IDSEnumSignalCategory.Request:
                    return IDSEnumSignalCategoryCode.Request;

                case IDSEnumSignalCategory.Indication:
                    return IDSEnumSignalCategoryCode.Indication;

                case IDSEnumSignalCategory.Others:
                    return IDSEnumSignalCategoryCode.Others;

                default:
                    return "";
            }
        }

        public const string State = "S";
        public const string Command = "C";
        public const string Request = "R";
        public const string Indication = "I";
        public const string Others = "E";
    }

    public class IDSEnumCableType
    {
        public static string SubEquipment { get { return "子设备"; } }
        public static string Cabinet { get { return "盘箱柜"; } }
    }

    public class IDSEnumWayToGenerateSymbol
    {
        private static string AutoGenerate { get { return "[自动]"; } }
        private static string ManualGenerate { get { return "[手动]"; } }
    }

    public class IDSEnumLocationSymbol
    {
        private static string On { get { return "[]"; } }
        private static string OnTheSide { get { return "[旁]"; } }
    }

    public static class IDSEnumAutoGenerationSymbol
    {
        /// <summary>
        /// 自动
        /// </summary>
        public const string AutoGenerate = "自动";
        /// <summary>
        /// 手动
        /// </summary>
        public const string ManualGenerate = "手动";
        /// <summary>
        /// (空)
        /// </summary>
        public const string Empty = "";
        /// <summary>
        /// 旁
        /// </summary>
        public const string OnTheSide = "旁";
        /// <summary>
        /// 回路
        /// </summary>
        public const string Loop = "回路";
    }
}
