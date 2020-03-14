﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Flute.DataStruct.IDS
{
    public class IDSSubSystem
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

        private IDSSystem _system = null;
        /// <summary>
        /// Gets IDS System
        /// </summary>
        public IDSSystem System { get { return _system; } }

        /// <summary>
        /// Gets or Sets 代码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Gets or Sets 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or Sets 名称带入回路
        /// </summary>
        public bool IsNameInLoop { get; set; }
        /// <summary>
        /// Gets or Sets 阶段. e.g. 系统, 设备, 施工
        /// </summary>
        public string Phase { get; set; }
        /// <summary>
        /// Gets or Sets 序号
        /// </summary>
        public string SerialNumber { get; set; }
        /// <summary>
        /// Gets or Sets 说明
        /// </summary>
        public string Description { get; set; }

        private IDSLoopCollection _loops = null;
        /// <summary>
        /// Gets or Sets 回路
        /// </summary>
        public IDSLoopCollection Loops
        {
            get { return _loops; }
            set { _loops = value; }
        }

        /// <summary>
        /// 子系统下所有设备的数量统计
        /// </summary>
        public Int32 EquipmentsCount
        {
            get
            {
                Int32 equipmentsCount = 0;

                lock (this) {
                    if (Loops != null && Loops.Count > 0) {
                        foreach (IDSLoop loop in Loops) {
                            if (loop.SubLoops != null && loop.SubLoops.Count > 0) {
                                foreach (IDSSubLoop subLoop in loop.SubLoops) {
                                    if (subLoop.Equipments != null && subLoop.Equipments.Count > 0) {
                                        equipmentsCount += subLoop.Equipments.Count;
                                    }
                                }
                            }
                        }
                    }
                }
                return equipmentsCount;
            }
        }

        /// <summary>
        /// 子系统下导出设备的数量统计
        /// </summary>
        public Int32 ExportEquipmentsCount
        {
            get
            {
                Int32 exportEquipmentsCount = 0;

                lock (this) {
                    if (Loops != null && Loops.Count > 0) {
                        foreach (IDSLoop loop in Loops) {
                            if (loop.SubLoops != null && loop.SubLoops.Count > 0) {
                                foreach (IDSSubLoop subLoop in loop.SubLoops) {
                                    if (subLoop.Equipments != null && subLoop.Equipments.Count > 0) {
                                        exportEquipmentsCount += subLoop.ExportEquipmentsCount;
                                    }
                                }
                            }
                        }
                    }
                }
                return exportEquipmentsCount;
            }
        }

        #endregion // 成员属性

        private IDSSubSystem()
            : this(null)
        {
        }

        public IDSSubSystem(IDSSystem system)
        {
            ID = "";
            ParentID = "";
            _system = system;
            Code = "";
            Name = "";
            IsNameInLoop = false;
            Phase = "";
            SerialNumber = "";
            Description = "";

            Loops = new IDSLoopCollection();
        }

        #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public IDSSubSystem Copy()
        {
            IDSSubSystem subSystem = MemberwiseClone() as IDSSubSystem;
            subSystem._system = this.System;
            subSystem.Loops = this.Loops.Copy();
            return subSystem;
        }

        #endregion // Copy
    }

    public class IDSSubSystemCollection : List<IDSSubSystem>
    {
        public IDSSubSystemCollection()
        {
        }

        #region .Key Index.

        public IDSSubSystem this[string code]
        {
            get
            {
                if (this.Count > 0) {
                    for (int i = 0; i < this.Count; i++) {
                        if (this[i].Code == code)
                            return (IDSSubSystem)this[i];
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
                        if (this[i].Code == code) {
                            this[i] = value;
                            break;
                        }
                    }
                }
                else
                    throw new System.ArgumentOutOfRangeException("IDS SubSystem Index", "No SubSystem with this Code can be found");
            }
        }

        #endregion // Key Index

        #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public IDSSubSystemCollection Copy()
        {
            IDSSubSystemCollection subSystems = new IDSSubSystemCollection();

            if (this.Count <= 0)
                return subSystems;
            else {
                foreach (IDSSubSystem subSystem in this)
                    subSystems.Add(subSystem.Copy());
                return subSystems;
            }
        }

        #endregion // Copy

        #region .Comparer.

        public static int Comparer(IDSSubSystem x, IDSSubSystem y)
        {
            if (x.Code == null) {
                if (y.Code == null) {
                    // If x.Code is null and y.Code is null, they're
                    // equal. 
                    return 0;
                }
                else {
                    // If x.Code is null and y.Code is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else {
                // If x.Tag is not null...
                //
                if (y.Code == null)
                // ...and y.Code is null, x.Code is greater.
                {
                    return 1;
                }
                else {
                    return string.Compare(x.Code, y.Code /*, true, System.Globalization.CultureInfo.InstalledUICulture*/);
                }
            }
        }

        #endregion // Comparer

        #region .Sort.

        public void Sort()
        {
            base.Sort(IDSSubSystemCollection.Comparer);

            foreach (IDSSubSystem subSystem in this) {
                if (subSystem.Loops != null && subSystem.Loops.Count > 0) {
                    subSystem.Loops.Sort();
                }
            }
        }

        #endregion
    }
}
