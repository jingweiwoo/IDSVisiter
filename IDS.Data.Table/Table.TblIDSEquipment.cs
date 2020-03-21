using System;
using System.Collections.Generic;
using System.Text;

namespace IDS.Data.Table
{
    /// <summary>
    /// 设备表 -- 表名和各列名称
    /// </summary>
    public class TblIDSEquipment
    {
        #region .私有变量.

        private static string _tblName = "设备表";

        private static string _ID = "ID";
        private static string _parentID = "父ID";
        private static string _function = "功能";
        private static string _suffix = "后缀";
        private static string _tag = "实际位号_Ori";
        private static string _reporitoryCatagoryID = "设备类别";
        private static string _repositoryID = "库序号";
        private static string _specificeInfo1 = "规格1_Ori";
        private static string _specificeInfo2 = "规格2_Ori";
        private static string _quantity = "数量";
        private static string _remark = "备注";

        #endregion

        #region .公共属性.

        /// <summary>
        /// Gets 设备表 -- 表名
        /// </summary>
        public static string TblName { get { return _tblName; } }


        /// <summary>
        /// Gets ID
        /// </summary>
        public static string ID { get { return _ID; } }

        /// <summary>
        /// Gets 父ID ------ 对应分组表的"ID" (分组表中的子回路)
        /// </summary>
        public static string ParentID { get { return _parentID; } }

        /// <summary>
        /// Gets 功能. e.g. IT, Y, ET, E
        /// </summary>
        public static string Function { get { return _function; } }

        /// <summary>
        /// Gets 后缀
        /// </summary>
        public static string Suffix { get { return _suffix; } }

        /// <summary>
        /// Gets 实际位号_Ori. e.g. [自动], 09.FT-1301
        /// </summary>
        public static string Tag { get { return _tag; } }

        /// <summary>
        /// Gets 设备类型. e.g. TT, TR 等, 在库设备中定义
        /// </summary>
        public static string RepositoryCatagoryID { get { return _reporitoryCatagoryID; } }

        /// <summary>
        /// Gets 库序号
        /// </summary>
        public static string RepositoryID { get { return _repositoryID; } }

        /// <summary>
        /// Gets 规格1_Ori. 在库设备中定义
        /// </summary>
        public static string SpecificeInfo1 { get { return _specificeInfo1; } }

        /// <summary>
        /// Gets 规格2_Ori. 在库设备中定义
        /// </summary>
        public static string SpecificeInfo2 { get { return _specificeInfo2; } }

        /// <summary>
        /// Gets 数量
        /// </summary>
        public static string Quantity { get { return _quantity; } }

        /// <summary>
        /// Gets 备注
        /// </summary>
        public static string Remark { get { return _remark; } }

        #endregion
    }
}
