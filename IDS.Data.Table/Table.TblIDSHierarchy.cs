using System;
using System.Collections.Generic;
using System.Text;

namespace IDS.Data.Table
{
    /// <summary>
    /// 分组表 -- 表名和各列名称
    /// </summary>
    public class TblIDSHierarchy
    {
        #region .私有变量.

        private static string _tblName = "分组表";

        private static string _ID = "ID";
        private static string _parentID = "父ID";
        private static string _type = "类型";
        private static string _code = "代码";
        private static string _name = "名称";
        private static string _isNameInLoop = "名称带入回路";
        private static string _description = "说明";
        private static string _phase = "阶段类型";
        private static string _serialNumber = "序号";
        private static string _isNameInFront = "名称拼在前面";

        #endregion

        #region .公共属性.

        /// <summary>
        /// Gets 分组表 -- 表名
        /// </summary>
        public static string TblName { get { return _tblName; } }
        
        /// <summary>
        /// Gets ID
        /// </summary>
        public static string ID { get { return _ID; } }

        /// <summary>
        /// Gets 父ID
        /// 对于类型为"子系统"的项, 父ID为该表"系统"项的"ID"
        /// 对于类型为"子回路"的项, 父ID为回路表的"ID"
        /// </summary>
        public static string ParentID { get { return _parentID; } }

        /// <summary>
        /// Gets 类型. e.g. 系统, 子系统, 子回路
        /// </summary>
        public static string Type { get { return _type; } }

        /// <summary>
        /// Gets 代码. e.g. 热风炉是09, 本体是06
        /// </summary>
        public static string Code { get { return _code; } }

        /// <summary>
        /// Gets 名称. e.g. 热风炉, 公用系统, 1#热风炉 等
        /// </summary>
        public static string Name { get { return _name; } }

        /// <summary>
        /// Gets 名称带入回路
        /// </summary>
        public static string IsNameInLoop { get { return _isNameInLoop; } }

        /// <summary>
        /// Gets 说明
        /// </summary>
        public static string Description { get { return _description; } }

        /// <summary>
        /// Gets 阶段类型. e.g. 系统, 设备, 施工
        /// </summary>
        public static string Phase { get { return _phase; } }

        /// <summary>
        /// Gets 序号
        /// </summary>
        public static string SerialNumber { get { return _serialNumber; } }

        /// <summary>
        /// Gets 名称拼在前面
        /// </summary>
        public static string IsNameInFront { get { return _isNameInFront; } }

        #endregion
    }
}
