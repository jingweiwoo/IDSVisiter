using System;
using System.Collections.Generic;
using System.Text;

namespace IDS.Data.Table
{
    /// <summary>
    /// 安装材料表 -- 表名和各列名称
    /// </summary>
    public class TblIDSMountingSchemeMaterial
    {
        #region .私有变量.

        private static string _tblName = "安装材料表";

        private static string _ID = "ID";
        private static string _parentID = "父ID";
        private static string _serialNumber = "序号";
        private static string _repositoryID = "库序号";
        private static string _quantity = "数量";
        private static string _remark = "备注";
        private static string _specification = "规格1";

        #endregion

        #region .公共属性.

        /// <summary>
        /// Gets 安装材料表 -- 表名
        /// </summary>
        public static string TblName { get { return _tblName; } }


        /// <summary>
        /// Gets ID
        /// </summary>
        public static string ID { get { return _ID; } }

        /// <summary>
        /// Gets 父ID ------ 对应子设备表的"ID"
        /// </summary>
        public static string ParentID { get { return _parentID; } }

        /// <summary>
        /// Gets 序号
        /// </summary>
        public static string SerialNumber { get { return _serialNumber; } }

        /// <summary>
        /// Gets 库序号
        /// </summary>
        public static string RepositoryID { get { return _repositoryID; } }

        /// <summary>
        /// Gets 数量
        /// </summary>
        public static string Quantity { get { return _quantity; } }

        /// <summary>
        /// Gets 备注
        /// </summary>
        public static string Remark { get { return _remark; } }

        /// <summary>
        /// Gets 规格1
        /// </summary>
        public static string Specification { get { return _specification; } }
        
        #endregion
    }
}
