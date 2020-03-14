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

    public class IDSEnumCableType
    {
        public static string SubEquipment { get { return "子设备"; } }
        public static string Cabinet { get { return "盘箱柜"; } }
    }

    public class IDSEnumWayToGenerateSymbol
    {
        public static string AutoGenerate { get { return "[自动]"; } }
        public static string ManualGenerate { get { return "[手动]"; } }
    }

    public class IDSEnumLocationSymbol
    {
        public static string On { get { return "[]"; } }
        public static string OnTheSide { get { return "[旁]"; } }
    }

    public class IDSEnumConstantSymbol
    {
        public static string AutoGenerate { get { return "自动"; } }
        public static string ManualGenerate { get { return "手动"; } }
        public static string Empty { get { return ""; } }
        public static string OnTheSide { get { return "旁"; } }
    }
}
