using System;
using System.Collections.Generic;
using System.Text;

namespace IDS.Data.Table
{
    /// <summary>
    /// IO信号表 -- 表名和各列名称
    /// </summary>
    public class TblIDSIOSignal
    {
        #region .私有变量.

        private static string _tblName = "IO信号表";

        private static string _ID = "ID";
        private static string _parentID = "父ID";
        private static string _signalCategory = "类别名称";
        private static string _functionCode = "功能代码";
        private static string _functionName = "功能名称";
        private static string _objectCode = "对象代码";
        private static string _objectName = "对象名称";
        private static string _shortTag = "短位号_Ori";
        private static string _shortName = "短名称_Ori";
        private static string _engineeringRange = "工程范围_Ori";
        private static string _signalType = "信号类型";
        private static string _signalModulePlacement = "安装位置";
        private static string _ioTerminalType = "IO端子排类型";
        private static string _ioTerminalTag = "IO端子排位号";
        private static string _channelNumber = "通道号";
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
        /// Gets 类别名称. e.g. 状态, 命令
        /// </summary>
        public static string SignalCategory { get { return _signalCategory; } }

        /// <summary>
        /// Gets 功能代码. e.g. PV, CV, S
        /// </summary>
        public static string FunctionCode { get { return _functionCode; } }

        /// <summary>
        /// Gets 功能名称. e.g. 过程值, 阀位控制输出
        /// </summary>
        public static string FunctionName { get { return _functionName; } }

        /// <summary>
        /// Gets 对象代码 (暂时没用)
        /// </summary>
        public static string ObjectCode { get { return _objectCode; } }

        /// <summary>
        /// Gets 对象名称 (暂时没用)
        /// </summary>
        public static string ObjectName { get { return _objectName; } }

        /// <summary>
        /// Gets 短位号_Ori (需要关联) e.g. [自动] 组成方式为: 回路位号/类别代码/功能代码
        /// </summary>
        public static string ShortTag { get { return _shortTag; } }

        /// <summary>
        /// Gets 短名称_Ori (需要关联) e.g. [自动] 组成方式为: 回路名称/类别名称/功能名称
        /// </summary>
        public static string ShortName { get { return _shortName; } }

        /// <summary>
        /// Gets 工程范围_Ori (需要关联) e.g. [回路], 0~100%, [T/], [X/B]
        /// </summary>
        public static string EngineeringRange { get { return _engineeringRange; } }

        /// <summary>
        /// Gets 信号类型 e.g. 4~20mADC(A), Pt100, K
        /// </summary>
        public static string SignalType { get { return _signalType; } }

        /// <summary>
        /// Gets 安装位置 (需要关联) e.g. PLC柜1
        /// </summary>
        public static string SignalModulePlacement { get { return _signalModulePlacement; } }

        /// <summary>
        /// Gets IO端子排类型 e.g. AIA, TCA
        /// </summary>
        public static string IOTerminalType { get { return _ioTerminalType; } }

        /// <summary>
        /// Gets IO端子排位号 e.g. 09.XAIA201E, 09.XTCA201E
        /// </summary>
        public static string IOTerminalTag { get { return _ioTerminalTag; } }

        /// <summary>
        /// Gets 通道号 e.g. 03, 09
        /// </summary>
        public static string ChannelNumber { get { return _channelNumber; } }

        /// <summary>
        /// Gets 备注
        /// </summary>
        public static string Remark { get { return _remark; } }

        #endregion


    }
}
