using System;
using System.Collections.Generic;
using System.Text;

namespace IDS.Data.Table
{
    public class TblIDSCabinet
    {
        #region .私有变量.

        private static string _tblName = "盘箱柜表";

        private static string _ID = "ID";
        private static string _parentID = "父ID";
        private static string _cabinetType = "类型";
        private static string _cabinetTypeCode = "类型代码";
        private static string _serialNumber = "序号";
        private static string _mountingLocation = "安装地点_Ori";
        private static string _usage = "用途";
        private static string _name = "名称";
        private static string _modelNumber = "型号";
        private static string _dimension = "外形尺寸";
        private static string _color = "颜色";
        private static string _openType = "开门方向";
        private static string _supplier = "供货商";
        private static string _specification = "规格";
        private static string _remark = "备注";

        #endregion

        #region .公共属性.

        /// <summary>
        /// Gets 盘箱柜表 -- 表名
        /// </summary>
        public static string TblName { get { return _tblName; } }


        /// <summary>
        /// Gets ID
        /// </summary>
        public static string ID { get { return _ID; } }

        /// <summary>
        /// Gets 父ID ------ 对应分组表的"ID"
        /// </summary>
        public static string ParentID { get { return _parentID; } }

        /// <summary>
        /// Gets 类型. e.g. 网络柜, PLC柜 等
        /// </summary>
        public static string CabinetType { get { return _cabinetType; } }

        /// <summary>
        /// Gets 类型代码. e.g. GP, CP, [自动] 等
        /// </summary>
        public static string CabinetTypeCode { get { return _cabinetTypeCode; } }

        /// <summary>
        /// Gets 序号
        /// </summary>
        public static string SerialNumber { get { return _serialNumber; } }

        /// <summary>
        /// Gets 安装地点_Ori. e.g. [自动], NOF/RTF空煤气平台 等
        /// </summary>
        public static string MountingLocation { get { return _mountingLocation; } }

        /// <summary>
        /// Gets 用途
        /// </summary>
        public static string Usage { get { return _usage; } }

        /// <summary>
        /// Gets 名称. e.g. 仪表供电柜, 接地箱 等
        /// </summary>
        public static string Name { get { return _name; } }

        /// <summary>
        /// Gets 型号
        /// </summary>
        public static string ModelNumber { get { return _modelNumber; } }

        /// <summary>
        /// Gets 外形尺寸
        /// </summary>
        public static string Dimension { get { return _dimension; } }

        /// <summary>
        /// Gets 颜色
        /// </summary>
        public static string Color { get { return _color; } }

        /// <summary>
        /// Gets 开门方向. e.g. 前后开门,左右封闭, 前开门,左右封闭 等
        /// </summary>
        public static string OpenType { get { return _openType; } }

        /// <summary>
        /// Gets 供货商
        /// </summary>
        public static string Supplier { get { return _supplier; } }

        /// <summary>
        /// Gets 规格
        /// </summary>
        public static string Specification { get { return _specification; } }

        /// <summary>
        /// Gets 备注
        /// </summary>
        public static string Remark { get { return _remark; } }

        #endregion

    }
}
