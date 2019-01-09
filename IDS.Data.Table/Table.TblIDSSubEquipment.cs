using System;
using System.Collections.Generic;
using System.Text;

namespace IDS.Data.Table
{
    public class TblIDSSubEquipment
    {
        #region .私有变量.

        private static string _tblName = "子设备表";

        private static string _ID = "ID";
        private static string _parentID = "父ID";
        private static string _functionCode = "功能";
        private static string _suffix = "后缀";
        private static string _tag = "实际位号_Ori";
        private static string _nameSuffix = "名称后缀";
        private static string _mountingType = "安装位置";
        private static string _mountingLocation = "安装地点_Ori";
        private static string _dataPlate = "铭牌内容_Ori";
        private static string _mountingRepositoryID = "安装库序号";
        private static string _powerSupply = "供电来源";
        private static string _switchTag = "开关位号_Ori";
        private static string _actingCurrent = "脱扣电流";

        #endregion

        #region .公共属性.

        /// <summary>
        /// Gets 子设备表 -- 表名
        /// </summary>
        public static string TblName { get { return _tblName; } }


        /// <summary>
        /// Gets ID
        /// </summary>
        public static string ID { get { return _ID; } }

        /// <summary>
        /// Gets 父ID ------ 对应设备表的"ID"
        /// </summary>
        public static string ParentID { get { return _parentID; } }

        /// <summary>
        /// Gets 功能. e.g. X, ET 等
        /// </summary>
        public static string FunctionCode { get { return _functionCode; } }

        /// <summary>
        /// Gets 后缀
        /// </summary>
        public static string Suffix { get { return _suffix; } }

        /// <summary>
        /// Gets 实际位号_Ori. e.g. [自动], 09.FT-1301
        /// </summary>
        public static string Tag { get { return _tag; } }

        /// <summary>
        /// Gets 名称后缀. e.g. 红外测温仪, 电源箱 等
        /// </summary>
        public static string NameSuffix { get { return _nameSuffix; } }

        /// <summary>
        /// Gets 安装位置. e.g. 就地, 仪表柜1 等
        /// </summary>
        public static string MountingType { get { return _mountingType; } }

        /// <summary>
        /// Gets 安装地点_Ori. e.g. 高炉主控室, [], [旁] 等
        /// </summary>
        public static string MountingLocation { get { return _mountingLocation; } }

        /// <summary>
        /// Gets 铭牌内容_Ori. e.g. [自动] 等
        /// </summary>
        public static string DataPlate { get { return _dataPlate; } }

        /// <summary>
        /// Gets 安装库序号 ------ 对应安装方案表的"名称"
        /// e.g. TE-GM27VYN, 详见产品说明书 等
        /// </summary>
        public static string MountingRepositoryID { get { return _mountingRepositoryID; } }

        /// <summary>
        /// Gets 供电来源. e.g. 24VDC(UPS), 09.YP01-380VAC 等
        /// </summary>
        public static string PowerSupply { get { return _powerSupply; } }

        /// <summary>
        /// Gets 开关位号_Ori. e.g. [自动], Q3-09.YP01-17 等
        /// </summary>
        public static string SwitchTag { get { return _switchTag; } }

        /// <summary>
        /// Gets 脱扣电流
        /// </summary>
        public static string ActingCurrent { get { return _actingCurrent; } }

        #endregion
    }
}
