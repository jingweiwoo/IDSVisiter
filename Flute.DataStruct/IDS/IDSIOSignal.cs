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

        public string IOTerminalTagAndChannel
        {
            get {
                if (IOTerminalTag == null || ChannelNumber == null)
                    return null;

                return IOTerminalTag + "-" + ChannelNumber;
            }
        }

        /// <summary>
        /// Gets or Sets 备注
        /// </summary>
        public string Remark { get; set; }


        private IDSIOSignal()
            : this(null)
        {
        }

        public IDSIOSignal(IDSSubLoop subLoop)
        {
            ID = "";
            ParentID = "";
            _subLoop = subLoop;
            SignalCategory = "";
            FunctionCode = "";
            FunctionName = "";
            ObjectCode = "";
            ObjectName = "";
            ShortTag = "";
            ShortName = "";
            EngineeringRange = "";
            SignalType = "";
            SignalModulePlacement = "";
            IOTerminalType = "";
            IOTerminalTag = "";
            ChannelNumber = "";
            Remark = "";
        }

        #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public IDSIOSignal Copy()
        {
            IDSIOSignal ioSignal = MemberwiseClone() as IDSIOSignal;
            ioSignal._subLoop = this.SubLoop;

            return ioSignal;
        }

        #endregion // Copy
    }

    public class IDSIOSignalCollection : List<IDSIOSignal>
    {
        public IDSIOSignalCollection()
        {
        }

        #region .Key Index.

        public IDSIOSignal this[string id]
        {
            get
            {
                if (this.Count > 0) {
                    for (int i = 0; i < this.Count; i++) {
                        if (this[i].ID == id)
                            return (IDSIOSignal)this[i];
                    }
                    return null;
                } else
                    return null;
            }
            set
            {
                if (this.Count > 0) {
                    for (int i = 0; i < this.Count; i++) {
                        if (this[i].ID == id) {
                            this[i] = value;
                            break;
                        }
                    }
                } else
                    throw new System.ArgumentOutOfRangeException("IDS IO Signal Index", "No IO Signal with this ID can be found");
            }
        }

        #endregion // Key Index

        #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public IDSIOSignalCollection Copy()
        {
            IDSIOSignalCollection ioSignals = new IDSIOSignalCollection();

            if (this.Count <= 0)
                return ioSignals;
            else {
                foreach (IDSIOSignal ioSignal in this)
                    ioSignals.Add(ioSignal.Copy());
                return ioSignals;
            }
        }

        #endregion // Copy

        #region .Comparer.

        public static int Comparer(IDSIOSignal x, IDSIOSignal y)
        {
            if (x.IOTerminalTagAndChannel == null) {
                if (y.IOTerminalTagAndChannel == null) {
                    // If x.Tag is null and y.Tag is null, they're
                    // equal. 
                    return 0;
                } else {
                    // If x.Tag is null and y.Tag is not null, y
                    // is greater. 
                    return -1;
                }
            } else {
                // If x.Tag is not null...
                //
                if (y.IOTerminalTagAndChannel == null)
                // ...and y.Tag is null, x.Tag is greater.
                {
                    return 1;
                } else {
                    return string.Compare(x.IOTerminalTagAndChannel, y.IOTerminalTagAndChannel /*, true, System.Globalization.CultureInfo.InstalledUICulture*/);
                }
            }
        }

        #endregion // Comparer

        #region .Sort.

        public new void Sort()
        {
            base.Sort(IDSIOSignalCollection.Comparer);
        }

        #endregion
    }
}
