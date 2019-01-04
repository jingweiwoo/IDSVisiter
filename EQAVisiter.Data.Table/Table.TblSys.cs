using System;
using System.Collections.Generic;
// using System.Linq;
using System.Text;

namespace EQA.Data.Table
{
    /// <summary>
    /// 系统表 -- 表名和各列名称
    /// </summary>
    public class TblSys
    {
        #region .私有变量.

        private static string _tblName = "SYS";

        private static string _ID = "ID";
        private static string _NAME = "NAME";

        #endregion

        #region .公共属性.

        /// <summary>
        /// Gets SYS表名
        /// </summary>
        public static string TblName { get { return _tblName; } }

        /// <summary>
        /// Gets 子系统ID
        /// </summary>
        public static string ID { get { return _ID; } }
        /// <summary>
        /// Gets 子系统名称
        /// </summary>
        public static string NAME { get { return _NAME; } }

        #endregion
    }
}
