using System;
using System.Collections.Generic;
using System.Text;

namespace EQA.Data.Table
{
    #region .电缆表 -- Cbl.

    /// <summary>
    /// 电缆表 -- 表名和各列名称
    /// </summary>
    public class TblCbl
    {
        #region .私有变量.

        private static string _tblName = "Cbl";

        private static string _SYS = "SYS";
        private static string _TAGNAME = "TAGNAME";
        private static string _SOURCE = "SOURCE";
        private static string _DEST = "DEST";
        private static string _SPARE = "SPARE";
        private static string _CBL_LEN = "CBL_LEN";
        private static string _CONDUCT_LEN = "CONDUCT_LEN";
        private static string _CBL_TYPE = "CBL_TYPE";
        private static string _CONDUCT_TYPE = "CONDUCT_TYPE";
        private static string _REMARK = "REMARK";
        private static string _ROUTE = "ROUTE";

        #endregion


        #region .公共属性.

        /// <summary>
        /// Gets 电缆表名
        /// </summary>
        public static string TblName { get { return _tblName; } }


        /// <summary>
        /// Gets 子系统ID
        /// </summary>
        public static string SYS { get { return _SYS; } }

        /// <summary>
        /// Gets 电缆编号
        /// </summary>
        public static string TAGNAME { get { return _TAGNAME; } }

        /// <summary>
        /// Gets 电缆起点
        /// </summary>
        public static string SOURCE { get { return _SOURCE; } }

        /// <summary>
        /// Gets 电缆终点
        /// </summary>
        public static string DEST { get { return _DEST; } }

        /// <summary>
        /// Gets 备用芯数
        /// </summary>
        public static string SPARE { get { return _SPARE; } }

        /// <summary>
        /// Gets 电缆长度 (单位 : m)
        /// </summary>
        public static string CBL_LEN { get { return _CBL_LEN; } }

        /// <summary>
        /// Gets 保护管长度 (单位 : m)
        /// </summary>
        public static string CONDUCT_LEN { get { return _CONDUCT_LEN; } }

        /// <summary>
        /// Gets 电缆类型
        /// </summary>
        public static string CBL_TYPE { get { return _CBL_TYPE; } }

        /// <summary>
        /// Gets 保护管类型
        /// </summary>
        public static string CONDUCT_TYPE { get { return _CONDUCT_TYPE; } }

        /// <summary>
        /// Gets 备注
        /// </summary>
        public static string REMARK { get { return _REMARK; } }

        /// <summary>
        /// Gets 电缆路径
        /// </summary>
        public static string ROUTE { get { return _ROUTE; } }

        #endregion
    }

    #endregion
}
