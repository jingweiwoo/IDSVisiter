using System;
using System.Collections.Generic;
// using System.Linq;
using System.Text;
using System.Data;

namespace Flute.DataStruct.EQA
{
    public class EQALoop
    {
        #region .成员属性.

        /// <summary>
        /// Gets or Sets 子系统号
        /// </summary>
        public string SubSystemID { get; set; }
        /// <summary>
        /// Gets or Sets 回路号. e.g. 0973.F-1101
        /// </summary>
        public string LoopNo { get; set; }
        /// <summary>
        /// Gets or Sets 检测和控制位置. e.g. XX泵组出水总管
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// Gets or Sets 过程/测量介质
        /// </summary>
        public string ProcMedium { get; set; }
        /// <summary>
        /// Gets or Sets 检测内容
        /// </summary>
        public string ProcParameter { get; set; }
        /// <summary>
        /// Gets or Sets 操作数据下限
        /// </summary>
        public string LowerLimit { get; set; }
        /// <summary>
        /// Gets or Sets 操作数据上限
        /// </summary>
        public string UpperLimit { get; set; }
        /// <summary>
        /// Gets or Sets 操作数据单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// Gets or Sets 是否就地显示
        /// </summary>
        public bool HasLocalIndication { get; set; }
        /// <summary>
        /// Gets or Sets 是否就地操作
        /// </summary>
        public bool HasLocalOperating { get; set; }
        /// <summary>
        /// Gets or Sets 是否操作站显示
        /// </summary>
        public bool HasComputerIndication { get; set; }
        /// <summary>
        /// Gets or Sets 是否操作站操作
        /// </summary>
        public bool HasComputerOperating { get; set; }
        /// <summary>
        /// Gets or Sets 是否记录
        /// </summary>
        public bool HasRecording { get; set; }
        /// <summary>
        /// Gets or Sets 是否累计
        /// </summary>
        public bool HasAccumulating { get; set; }
        /// <summary>
        /// Gets or Sets 是否调节
        /// </summary>
        public bool HasControlling { get; set; }
        /// <summary>
        /// Gets or Sets 是否报警
        /// </summary>
        public bool HasAlarm { get; set; }
        /// <summary>
        /// Gets or Sets 是否联锁
        /// </summary>
        public bool HasInterlock { get; set; }
        /// <summary>
        /// Gets or Sets 说明
        /// </summary>
        public string Description { get; set; }


        private EQAEquipmentCollection _equipments;
        public EQAEquipmentCollection Equipments
        {
            get { return _equipments; }
            set { _equipments = value; }
        }

        #endregion // 成员属性

        public EQALoop()
        {
            SubSystemID = "";
            LoopNo = "";
            Location = "";
            ProcMedium = "";
            ProcParameter = "";
            LowerLimit = "";
            UpperLimit = "";
            Unit = "";
            HasLocalIndication = false;
            HasLocalOperating = false;
            HasComputerIndication = false;
            HasComputerOperating = false;
            HasRecording = false;
            HasAccumulating = false;
            HasControlling = false;
            HasAlarm = false;
            HasInterlock = false;
            Description = "";
            _equipments = new EQAEquipmentCollection();
        }

        #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public EQALoop Copy()
        {
            EQALoop loop = MemberwiseClone() as EQALoop;
            loop.Equipments = this.Equipments.Copy();

            return loop;
        }

        #endregion // Clone Members
    }

    public class EQALoopCollection : List<EQALoop>
    {
        public EQALoopCollection()
        {
        }

        #region .Key Index.

        public EQALoop this[string loopNo]
        {
            get
            {
                if (this.Count > 0) {
                    for (int i = 0; i < this.Count; i++) {
                        if (this[i].LoopNo == loopNo)
                            return (EQALoop)this[i];
                    }
                    return null;
                } else
                    return null;
            }
            set
            {
                if (this.Count > 0) {
                    for (int i = 0; i < this.Count; i++) {
                        if (this[i].LoopNo == loopNo) {
                            this[i] = value;
                            break;
                        }
                    }
                } else
                    throw new System.ArgumentOutOfRangeException("Loop Index", "No Loop with this Loop Number can be found");
            }
        }

        #endregion // Key Index

        #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public EQALoopCollection Copy()
        {
            EQALoopCollection loops = new EQALoopCollection();

            if (this.Count <= 0)
                return loops;
            else {
                foreach (EQALoop loop in this)
                    loops.Add(loop.Copy());
                return loops;
            }
        }

        #endregion // Copy

        #region .Comparer.

        public static int Comparer(EQALoop x, EQALoop y)
        {
            if (x.LoopNo == null) {
                if (y.LoopNo == null) {
                    // If x.LoopNo is null and y.LoopNo is null, they're
                    // equal. 
                    return 0;
                } else {
                    // If x.LoopNo is null and y.LoopNo is not null, y
                    // is greater. 
                    return -1;
                }
            } else {
                // If x.LoopNo is not null...
                //
                if (y.LoopNo == null)
                // ...and y.LoopNo is null, x.LoopNo is greater.
                {
                    return 1;
                } else {
                    return string.Compare(x.LoopNo, y.LoopNo /*, true, System.Globalization.CultureInfo.InstalledUICulture*/);
                }
            }
        }

        #endregion // Comparer

        #region .Sort.

        public void Sort()
        {
            if (this.Count > 0)
                base.Sort(EQALoopCollection.Comparer);

            foreach (EQALoop loop in this)
                if (loop.Equipments != null && loop.Equipments.Count > 0)
                    loop.Equipments.Sort();
        }

        #endregion
        

        public EQAEquipment EquipmentInLoops(string EquipmentTagNo)
        {
            if (this.Count > 0) {
                EQAEquipment eqp = new EQAEquipment();
                foreach (EQALoop loop in this) {
                    if ((eqp = loop.Equipments[EquipmentTagNo]) != null) {
                        return eqp;
                    }
                }
                return null;
            }
            return null;
        }
    }
}
