using System;
using System.Collections.Generic;
using System.Text;

namespace IDS.Data.Table
{
    class TblIDSCabinetInSubLoop
    {
        #region .私有变量.

        private static string _tblName = "安装位置表";

        private static string _ID = "ID";
        private static string _parentID = "父ID";
        private static string _cabinetType = "类型";
        private static string _serialNumber = "序号";
        private static string _description = "说明";
        private static string _area = "区域";
        private static string _subArea = "子区域";
        private static string _tag = "位置代号";
        private static string _cabinetUnit = "单元";
        private static string _cabinetUnitHeight = "单元高度";
        private static string _name = "名称";
        private static string _modelNumber = "型号";
        private static string _dimension = "外形尺寸";
        private static string _color = "颜色";
        private static string _openType = "开门方向";
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
        /// Gets 序号
        /// </summary>
        public static string SerialNumber { get { return _serialNumber; } }

        /// <summary>
        /// Gets 说明
        /// </summary>
        public static string Description { get { return _description; } }

        /// <summary>
        /// Gets 区域. 即高层代号. 比如热风炉为09.
        /// </summary>
        public static string Area { get { return _area; } }

        /// <summary>
        /// Gets 子区域
        /// </summary>
        public static string SubArea { get { return _subArea; } }

        /// <summary>
        /// Gets 位置代号. 即盘柜的位号
        /// </summary>
        public static string Tag { get { return _tag; } }

        /// <summary>
        /// Gets 单元
        /// </summary>
        public static string CabinetUnit { get { return _cabinetUnit; } }

        /// <summary>
        /// Gets 单元高度
        /// </summary>
        public static string CabinetUnitHeight { get { return _cabinetUnitHeight; } }

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
        /// Gets 备注
        /// </summary>
        public static string Remark { get { return _remark; } }

        #endregion
    }
}
