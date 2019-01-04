using System;
using System.Collections.Generic;
// using System.Linq;
using System.Text;

namespace EQA.Data.Table
{

    #region .设备表 -- Eqp.

    /// <summary>
    /// 设备表 -- 表名和各列名称
    /// </summary>
    public class TblEqp
    {
        #region .私有变量.

        private static string _tblName = "Eqp";

        private static string _LOOP_TAGNAME = "LOOP_TAGNAME";
        private static string _TAGNAME = "TAGNAME";
        private static string _NAME = "NAME";
        private static string _TYPE = "TYPE";
        private static string _NUM = "NUM";
        private static string _LOW = "LOW";
        private static string _HIGH = "HIGH";
        private static string _UNIT = "UNIT";
        private static string _IN = "IN";
        private static string _OUT = "OUT";
        private static string _PS = "PS";
        private static string _SPEC1 = "SPEC1";
        private static string _SPEC2 = "SPEC2";
        private static string _SPEC3 = "SPEC3";
        private static string _MANU = "MANU";
        private static string _REMARK = "REMARK";
        private static string _LOC = "LOC";
        private static string _AREA = "AREA";
        private static string _PLATENAME = "PLATENAME";
        private static string _INSTDWG = "INSTDWG";
        private static string _HOOKUP = "HOOKUP";
        private static string _NONEQP = "NONEQP";
        private static string _UPS = "UPS";
        private static string _PS_CURRENT = "PS_CURRENT";
        private static string _PS_SOURCE = "PS_SOURCE";

        #endregion

        #region .公共属性.

        /// <summary>
        /// Gets Eqp表名
        /// </summary>
        public static string TblName { get { return _tblName; } }


        /// <summary>
        /// Gets 回路号
        /// </summary>
        public static string LOOP_TAGNAME { get { return _LOOP_TAGNAME; } }

        /// <summary>
        /// Gets 位号
        /// </summary>
        public static string TAGNAME { get { return _TAGNAME; } }

        /// <summary>
        /// Gets 设备名称
        /// </summary>
        public static string NAME { get { return _NAME; } }

        /// <summary>
        /// Gets 设备型号
        /// </summary>
        public static string TYPE { get { return _TYPE; } }

        /// <summary>
        /// Gets 设备数量
        /// </summary>
        public static string NUM { get { return _NUM; } }

        /// <summary>
        /// Gets 显示/测量范围下限
        /// </summary>
        public static string LOW { get { return _LOW; } }

        /// <summary>
        /// Gets 显示/测量范围上限
        /// </summary>
        public static string HIGH { get { return _HIGH; } }

        /// <summary>
        /// Gets 显示/测量单位
        /// </summary>
        public static string UNIT { get { return _UNIT; } }

        /// <summary>
        /// Gets 输入信号
        /// </summary>
        public static string IN { get { return _IN; } }

        /// <summary>
        /// Gets 输出信号
        /// </summary>
        public static string OUT { get { return _OUT; } }

        /// <summary>
        /// Gets 电源
        /// </summary>
        public static string PS { get { return _PS; } }

        /// <summary>
        /// Gets 规格 -- 第1行
        /// </summary>
        public static string SPEC1 { get { return _SPEC1; } }

        /// <summary>
        /// Gets 规格 -- 第2行
        /// </summary>
        public static string SPEC2 { get { return _SPEC2; } }

        /// <summary>
        /// Gets 规格 -- 第3行
        /// </summary>
        public static string SPEC3 { get { return _SPEC3; } }

        /// <summary>
        /// Gets 制造厂或供货商
        /// </summary>
        public static string MANU { get { return _MANU; } }

        /// <summary>
        /// Gets 备注
        /// </summary>
        public static string REMARK { get { return _REMARK; } }

        /// <summary>
        /// Gets 安装地点 -- e.g. 就地
        /// </summary>
        public static string LOC { get { return _LOC; } }

        /// <summary>
        /// Gets 区域
        /// </summary>
        public static string AREA { get { return _AREA; } }

        /// <summary>
        /// Gets 
        /// </summary>
        public static string PLATENAME { get { return _PLATENAME; } }

        /// <summary>
        /// Gets 设备安装图
        /// </summary>
        public static string INSTDWG { get { return _INSTDWG; } }

        /// <summary>
        /// Gets 管线连接图
        /// </summary>
        public static string HOOKUP { get { return _HOOKUP; } }

        /// <summary>
        /// Gets 是否非设备
        /// </summary>
        public static string NONEQP { get { return _NONEQP; } }

        /// <summary>
        /// Gets 是否UPS供电
        /// </summary>
        public static string UPS { get { return _UPS; } }

        /// <summary>
        /// Gets 电流
        /// </summary>
        public static string PS_CURRENT { get { return _PS_CURRENT; } }

        /// <summary>
        /// Gets 电源
        /// </summary>
        public static string PS_SOURCE { get { return _PS_SOURCE; } }

        #endregion
    }

    #endregion  

}
