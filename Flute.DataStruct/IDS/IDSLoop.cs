using System;
using System.Collections.Generic;
using System.Text;

namespace Flute.DataStruct.IDS
{
    public class IDSLoop
    {
        #region .成员属性.

        /// <summary>
        /// Gets or Sets ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Gets or Sets 父ID
        /// </summary>
        public string ParentID { get; set; }
        /// <summary>
        /// Gets or Sets 位号
        /// </summary>
        public string Tag { get; set; }
        /// <summary>
        /// Gets or Sets 对象
        /// </summary>
        public string LoopType { get; set; }
        /// <summary>
        /// Gets or Sets 序号
        /// </summary>
        public string SerialNumber { get; set; }
        /// <summary>
        /// Gets or Sets 后缀
        /// </summary>
        public string Suffix { get; set; }
        /// <summary>
        /// Gets or Sets 位置
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// Gets or Sets 介质
        /// </summary>
        public string Medium { get; set; }
        /// <summary>
        /// Gets or Sets 参数
        /// </summary>
        public string Parameter { get; set; }
        /// <summary>
        /// Gets or Sets 操作温度
        /// </summary>
        public string NormalTemperature { get; set; }
        /// <summary>
        /// Gets or Sets 最高温度
        /// </summary>Nor
        public string UplimitTemperature { get; set; }
        /// <summary>
        /// Gets or Sets 操作压力
        /// </summary>
        public string NormalPressure { get; set; }
        /// <summary>
        /// Gets or Sets 最高压力
        /// </summary>
        public string UplimitPressure { get; set; }
        /// <summary>
        /// Gets or Sets 压力单位
        /// </summary>
        public string PressureUnit { get; set; }
        /// <summary>
        /// Gets or Sets 管道材质
        /// </summary>
        public string PipeMaterial { get; set; }
        /// <summary>
        /// Gets or Sets 公称通径
        /// </summary>
        public string DN { get; set; }
        /// <summary>
        /// Gets or Sets 容器材质
        /// </summary>
        public string ContainerMaterial { get; set; }
        /// <summary>
        /// Gets or Sets 有无内衬
        /// </summary>
        public bool HasInnerLining { get; set; }
        /// <summary>
        /// Gets or Sets 环境温度
        /// </summary>
        public string AmbientTemperature { get; set; }
        /// <summary>
        /// Gets or Sets 环境防爆等级
        /// </summary>
        public string AmbientExLevel { get; set; }
        /// <summary>
        /// Gets or Sets 介质防爆等级
        /// </summary>
        public string MediumExLevel { get; set; }
        /// <summary>
        /// Gets or Sets 测量范围
        /// </summary>
        public string MeasurementRange { get; set; }
        /// <summary>
        /// Gets or Sets 工艺范围
        /// </summary>
        public string ProcessRange { get; set; }
        /// <summary>
        /// Gets or Sets 单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>fun
        /// Gets or Sets 功能
        /// </summary>
        public string Function { get; set; }
        /// <summary>
        /// Gets or Sets 详细说明
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or Sets 来源
        /// </summary>
        public string Source { get; set; }

        private IDSSubLoopCollection _subLoops = null;
        /// <summary>
        /// Gets or Sets 子回路
        /// </summary>
        public IDSSubLoopCollection SubLoops
        {
            get { return _subLoops; }
            set { _subLoops = value; }
        }

        /// <summary>
        /// 系统下所有设备的数量统计
        /// </summary>
        public Int32 EquipmentsCount
        {
            get
            {
                Int32 equipmentsCount = 0;

                lock (this) {

                    if (SubLoops != null && SubLoops.Count > 0) {
                        foreach (IDSSubLoop subLoop in SubLoops) {
                            if (subLoop.Equipments != null && subLoop.Equipments.Count > 0) {
                                equipmentsCount += subLoop.Equipments.Count;
                            }
                        }
                    }
                }
                return equipmentsCount;
            }
        }

        #endregion // 成员属性

        public IDSLoop()
        {
            ID = "";
            ParentID = "";
            Tag = "";
            LoopType = "";
            SerialNumber = "";
            Suffix = "";
            Location = "";
            Medium = "";
            Parameter = "";
            NormalTemperature = "";
            UplimitTemperature = "";
            NormalPressure = "";
            UplimitPressure = "";
            PressureUnit = "";
            PipeMaterial = "";
            DN = "";
            ContainerMaterial = "";
            HasInnerLining = false;
            AmbientTemperature = "";
            AmbientExLevel = "";
            MediumExLevel = "";
            MeasurementRange = "";
            ProcessRange = "";
            Unit = "";
            Function = "";
            Description = "";
            Source = "";

            SubLoops = new IDSSubLoopCollection();
        }

        #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public IDSLoop Copy()
        {
            IDSLoop loop = MemberwiseClone() as IDSLoop;
            loop.SubLoops = this.SubLoops.Copy();

            return loop;
        }

        #endregion // Copy
    }

    public class IDSLoopCollection : List<IDSLoop>
    {
        public IDSLoopCollection()
        {
        }

        #region .Key Index.

        public IDSLoop this[string tag]
        {
            get
            {
                if (this.Count > 0) {
                    for (int i = 0; i < this.Count; i++) {
                        if (this[i].Tag == tag)
                            return (IDSLoop)this[i];
                    }
                    return null;
                }
                else
                    return null;
            }
            set
            {
                if (this.Count > 0) {
                    for (int i = 0; i < this.Count; i++) {
                        if (this[i].Tag == tag) {
                            this[i] = value;
                            break;
                        }
                    }
                }
                else
                    throw new System.ArgumentOutOfRangeException("IDS Loop Index", "No Loop with this Tag can be found");
            }
        }

        #endregion // Key Index

        #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public IDSLoopCollection Copy()
        {
            IDSLoopCollection loops = new IDSLoopCollection();

            if (this.Count <= 0)
                return loops;
            else {
                foreach (IDSLoop loop in this)
                    loops.Add(loop.Copy());
                return loops;
            }
        }

        #endregion // Copy

        #region .Comparer.

        public static int Comparer(IDSLoop x, IDSLoop y)
        {
            if (x.Tag == null) {
                if (y.Tag == null) {
                    // If x.Tag is null and y.Tag is null, they're
                    // equal. 
                    return 0;
                }
                else {
                    // If x.Tag is null and y.Tag is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else {
                // If x.Tag is not null...
                //
                if (y.Tag == null)
                // ...and y.Tag is null, x.Tag is greater.
                {
                    return 1;
                }
                else {
                    return string.Compare(x.Tag, y.Tag /*, true, System.Globalization.CultureInfo.InstalledUICulture*/);
                }
            }
        }

        #endregion // Comparer

        #region .Sort.

        public void Sort()
        {
            base.Sort(IDSLoopCollection.Comparer);

            foreach (IDSLoop loop in this) {
                if (loop.SubLoops != null && loop.SubLoops.Count > 0) {
                    loop.SubLoops.Sort();
                }
            }
        }

        #endregion
    }
}
