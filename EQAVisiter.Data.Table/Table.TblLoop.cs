using System;
using System.Collections.Generic;
using System.Text;

namespace EQA.Data.Table
{

    #region .回路表 -- Loop.

    /// <summary>
    /// 回路表 -- 表名和各列名称
    /// </summary>
    public class TblLoop
    {
        #region .私有变量.

        private static string _tblName = "Loop";

        private static string _SYS_ID = "SYS_ID";
        private static string _TAGNAME = "TAGNAME";
        private static string _LOC = "LOC";
        private static string _MED = "MED";
        private static string _CHR = "CHR";
        private static string _LOW = "LOW";
        private static string _HIGH = "HIGH";
        private static string _UNIT = "UNIT";
        private static string _LI = "LI";
        private static string _LO = "LO";
        private static string _I = "I";
        private static string _O = "O";
        private static string _R = "R";
        private static string _Q = "Q";
        private static string _C = "C";
        private static string _A = "A";
        private static string _S = "S";
        private static string _DESCRIP = "DESCRIP";

        #endregion


        #region .公共属性.

        /// <summary>
        /// Gets 回路表 -- 表名
        /// </summary>
        public static string TblName { get { return _tblName; } }


        /// <summary>
        /// Gets 子系统号
        /// </summary>
        public static string SYS_ID { get { return _SYS_ID; } }

        /// <summary>
        /// Gets 回路号. e.g. 0973.F-1101
        /// </summary>
        public static string LOOP_TAGNAME { get { return _TAGNAME; } }

        /// <summary>
        /// Gets 检测和控制位置. e.g. XX泵组出水总管
        /// </summary>
        public static string LOC { get { return _LOC; } }

        /// <summary>
        /// Gets 过程/测量介质
        /// </summary>
        public static string MED { get { return _MED; } }

        /// <summary>
        /// Gets 检测内容
        /// </summary>
        public static string CHR { get { return _CHR; } }

        /// <summary>
        /// Gets 操作数据下限
        /// </summary>
        public static string LOW { get { return _LOW; } }

        /// <summary>
        /// Gets 操作数据上限
        /// </summary>
        public static string HIGH { get { return _HIGH; } }

        /// <summary>
        /// Gets 操作数据单位
        /// </summary>
        public static string UNIT { get { return _UNIT; } }

        /// <summary>
        /// Gets 就地显示
        /// </summary>
        public static string LI { get { return _LI; } }

        /// <summary>
        /// Gets 就地操作
        /// </summary>
        public static string LO { get { return _LO; } }

        /// <summary>
        /// Gets 显示
        /// </summary>
        public static string I { get { return _I; } }

        /// <summary>
        /// Gets 操作
        /// </summary>
        public static string O { get { return _O; } }

        /// <summary>
        /// Gets 记录
        /// </summary>
        public static string R { get { return _R; } }

        /// <summary>
        /// Gets 累计
        /// </summary>
        public static string Q { get { return _Q; } }

        /// <summary>
        /// Gets 调节
        /// </summary>
        public static string C { get { return _C; } }

        /// <summary>
        /// Gets 报警
        /// </summary>
        public static string A { get { return _A; } }

        /// <summary>
        /// Gets 联锁
        /// </summary>
        public static string S { get { return _S; } }

        /// <summary>
        /// Gets 说明
        /// </summary>
        public static string DESCRIP { get { return _DESCRIP; } }

        #endregion
    }

    #endregion

}
