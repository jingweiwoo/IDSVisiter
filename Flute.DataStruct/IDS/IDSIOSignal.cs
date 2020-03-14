using System;
using System.Collections.Generic;
using System.Text;

namespace Flute.DataStruct.IDS
{
    public class IDSIOSignal
    {
        /// <summary>
        /// Gets or Sets ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Gets or Sets 父ID
        /// </summary>
        public string ParentID { get; set; }

        private IDSSubLoop _subLoop = null;
        public IDSSubLoop SubLoop { get { return _subLoop; } }

        /// <summary>
        /// Gets or Sets 类别名称. e.g. 状态, 命令
        /// </summary>
        public string SignalCategory { get; set; }

        /// <summary>
        /// Gets or Sets  功能代码. e.g. PV, CV, S
        /// </summary>
        public string FunctionCode { get; set; }

        /// <summary>
        /// Gets or Sets  功能名称. e.g. 过程值, 阀位控制输出
        /// </summary>
        public string FunctionName { get; set; }

        /// <summary>
        /// Gets or Sets  对象代码 (暂时没用)
        /// </summary>
        public string ObjectCode { get; set; }

        /// <summary>
        /// Gets or Sets  对象名称 (暂时没用)
        /// </summary>
        public string ObjectName { get; set; }

        private string _shortTag = null;
        /// <summary>
        /// Gets or Sets 短位号_Ori (需要关联) e.g. [自动] 组成方式为: 回路位号/类别代码/功能代码
        /// </summary>
        public string ShortTag
        {
            get { return _shortTag; }
            set { _shortTag = value; }
        }

        private string _shortName = null;
        /// <summary>
        /// Gets or Sets 短名称_Ori (需要关联) e.g. [自动] 组成方式为: 回路名称/类别名称/功能名称
        /// </summary>
        public string ShortName
        {
            get { return _shortName; }
            set { _shortName = value; }
        }

        private string _engineeringRange;
        /// <summary>
        /// Gets or Sets 工程范围_Ori (需要关联) e.g. [回路], 0~100%, [T/], [X/B]
        /// </summary>
        public string EngineeringRange
        {
            get { return _engineeringRange; }
            set { _engineeringRange = value; }
        }

        /// <summary>
        /// Gets or Sets 信号类型 e.g. 4~20mADC(A), Pt100, K
        /// </summary>
        public string SignalType { get; set; }

        private string _signalModulePlacement;
        /// <summary>
        /// Gets or Sets 安装位置 (需要关联) e.g. PLC柜1
        /// </summary>
        public string SignalModulePlacement { 
            get { return _signalModulePlacement; }
            set { _signalModulePlacement = value; }
        }

        /// <summary>
        /// Gets or Sets IO端子排类型 e.g. AIA, TCA
        /// </summary>
        public string IOTerminalType { get; set; }

        /// <summary>
        /// Gets or Sets IO端子排位号 e.g. 09.XAIA201E, 09.XTCA201E
        /// </summary>
        public string IOTerminalTag { get; set; }

        /// <summary>
        /// Gets or Sets 通道号 e.g. 03, 09
        /// </summary>
        public string ChannelNumber { get; set; }

        /// <summary>
        /// Gets or Sets 备注
        /// </summary>
        public string Remark { get; set; }  
    }
}
