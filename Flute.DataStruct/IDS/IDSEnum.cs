using System;
using System.Collections.Generic;
using System.Text;

namespace Flute.DataStruct.IDS
{
    /// <summary>
    /// 对应分组表"类型"项的内容
    /// </summary>
    public static class IDSEnumSystemType
    {
        /// <summary>
        /// 系统
        /// </summary>
        public const string System = "系统";
        /// <summary>
        /// 子系统
        /// </summary>
        public const string SubSystem = "子系统";
        /// <summary>
        /// 子回路
        /// </summary>
        public const string SubLoop = "子回路";
        /// <summary>
        /// 区域
        /// </summary>
        public const string Region = "区域";
        /// <summary>
        /// 子区域
        /// </summary>
        public const string SubRegion = "子区域";
        /// <summary>
        /// 设备类别
        /// </summary>
        public const string RepositoryCatagory = "设备类别";
        /// <summary>
        /// 安装类别
        /// </summary>
        public const string MountingCatagory = "安装类别";
    }

    /// <summary>
    /// 对应分组表"阶段类型"项的内容
    /// </summary>
    public static class IDSEnumPhaseType
    {
        /// <summary>
        /// 系统
        /// </summary>
        public const string SystemDesign = "系统";
        /// <summary>
        /// 设备
        /// </summary>
        public const string EquipmentDesign = "设备";
        /// <summary>
        /// 施工
        /// </summary>
        public const string ConstructionDesign = "施工";
        /// <summary>
        /// 其它
        /// </summary>
        public const string Others = "其它";
    }

    /// <summary>
    /// 对应安装方案表"类型"项的内容
    /// </summary>
    public class IDSEnumMountingType
    {
        public const string TubeConnection = "导管连接";
        public const string EquipmentMounting = "设备安装";
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

    public static class IDSEnumRepositoryType
    {
        /// <summary>
        /// 常用/通用设备
        /// </summary>
        public const string CommonGeneralEquipment = @"常用/通用设备";
        /// <summary>
        /// 常用/无格式设备
        /// </summary>
        public const string CommonEquipment = @"常用/无格式设备";
        /// <summary>
        /// 常用/取压口
        /// </summary>
        public const string CommonPeEquipment = @"常用/取压口";
        /// <summary>
        /// 常用/简单设备
        /// </summary>
        public const string CommonSimpleEquipment = @"常用/简单设备";

        /// <summary>
        /// 称重/称重传感器
        /// </summary>
        public const string WeightingLoadCell = @"称重/称重传感器";
        /// <summary>
        /// 称重/皮带秤
        /// </summary>
        public const string WeightingBeltScale = @"称重/皮带秤";
        /// <summary>
        /// 称重/钢卷秤
        /// </summary>
        public const string WeightingSteelRollScale = @"称重/钢卷秤";
        /// <summary>
        /// 称重/轨道衡
        /// </summary>
        public const string WeightingRailWeighBridge = @"称重/轨道衡";

        /// <summary>
        /// 阀门/调节阀_气体
        /// </summary>
        public const string ValveRegulationGas = @"阀门/调节阀_气体";
        /// <summary>
        /// 阀门/调节阀_液体
        /// </summary>
        public const string ValveRegulationLiquid = @"阀门/调节阀_液体";
        /// <summary>
        /// 阀门/调节阀_蒸汽
        /// </summary>
        public const string ValveRegulationSteam = @"阀门/调节阀_蒸汽";
        /// <summary>
        /// 阀门/切断阀
        /// </summary>
        public const string ValveShutOff = @"阀门/切断阀";



    }
}
