using System;
using System.Collections.Generic;
// using System.Linq;
using System.Text;

namespace EQA.Data.Table
{
    /// <summary>
    /// 导管表 -- 表名和各列名称
    /// </summary>
    public class TblPipe
    {
        #region .私有变量.

        private static string _tblName = "Pipe";

        private static string _SYS = "SYS";
        private static string _TAGNAME = "TAGNAME";
        private static string _SOURCE = "SOURCE";
        private static string _DEST = "DEST";
        private static string _NAME = "NAME";
        private static string _TYPE = "TYPE";
        private static string _LEN = "LEN";
        private static string _REMARK = "REMARK";

        #endregion


        #region .公共属性.

        /// <summary>
        /// 回路表 -- 表名
        /// </summary>
        public static string TblName { get { return _tblName; } }

        public static string SYS { get { return _SYS; } }
        public static string TAGNAME { get { return _TAGNAME; } }
        public static string SOURCE { get { return _SOURCE; } }
        public static string DEST { get { return _DEST; } }
        public static string NAME { get { return _NAME; } }
        public static string TYPE { get { return _TYPE; } }
        public static string LEN { get { return _LEN; } }
        public static string REMARK { get { return _REMARK; } }

        #endregion
    }
}
