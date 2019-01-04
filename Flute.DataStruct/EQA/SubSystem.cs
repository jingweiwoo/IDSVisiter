using System;
using System.Collections.Generic;
// using System.Linq;
using System.Text;

namespace Flute.DataStruct.EQA
{
    public class SubSystem
    {
        #region .成员属性.

        /// <summary>
        /// 子系统ID
        /// </summary>
        public string SubSystemID { get; set; }
        /// <summary>
        /// 子系统名称
        /// </summary>
        public string Name { get; set; }

        private LoopCollection _loops = null;
        public LoopCollection Loops { get { return _loops; } set { _loops = value; } }

        private CableCollection _cables = null;
        public CableCollection Cables { get { return _cables; } set { _cables = value; } }

        #endregion // 成员属性

        /// <summary>
        /// 子系统下所有设备的数量统计, 不包括非设备
        /// </summary>
        public Int32 EquipmentsCount
        {
            get
            {
                Int32 equipmentsCount = 0;
                lock (this) {
                    if (Loops != null && Loops.Count > 0) {
                        foreach (Loop loop in Loops) {
                            if (loop.Equipments != null) {
                                foreach (Equipment eqp in loop.Equipments) {
                                    equipmentsCount += eqp.IsEquipment ? 1 : 0;
                                }
                            }
                        }
                    }
                }
                return equipmentsCount;
            }
        }

        public Int32 CablesCount
        {
            get
            {
                Int32 cablesCount = 0;
                lock (this) {
                    if (Cables != null && Cables.Count > 0) {
                        return Cables.Count;
                    }
                }
                return cablesCount;
            }
        }

        public SubSystem()
        {
            SubSystemID = "";
            Name = "";
            _loops = new LoopCollection();
            _cables = new CableCollection();
        }

        #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public SubSystem Copy()
        {
            SubSystem subSystem = MemberwiseClone() as SubSystem;
            subSystem.Loops = this.Loops.Copy();

            return subSystem;
        }

        #endregion // Copy
    }

    public class SubSystemCollectin : List<SubSystem>
    {
        public SubSystemCollectin()
        {
        }

        #region .Key Index.

        public SubSystem this[string subSystemID]
        {
            get
            {
                if (this.Count > 0) {
                    for (int i = 0; i < this.Count; i++) {
                        if (this[i].SubSystemID == subSystemID)
                            return (SubSystem)this[i];
                    }
                    return null;
                } else
                    return null;
            }
            set
            {
                if (this.Count > 0) {
                    for (int i = 0; i < this.Count; i++) {
                        if (this[i].SubSystemID == subSystemID) {
                            this[i] = value;
                            break;
                        }
                    }
                } else
                    throw new System.ArgumentOutOfRangeException("SubSystem Index", "No SubSystem with this ID can be found");
            }
        }

        #endregion // Key Index

        #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public SubSystemCollectin Copy()
        {
            SubSystemCollectin subSystems = new SubSystemCollectin();

            if (this.Count <= 0)
                return subSystems;
            else {
                foreach (SubSystem subSystem in this)
                    subSystems.Add(subSystem.Copy());
                return subSystems;
            }
        }

        #endregion // Copy

        #region .Comparer.

        public static int Comparer(SubSystem x, SubSystem y)
        {
            if (x.SubSystemID == null) {
                if (y.SubSystemID == null) {
                    // If x.SubSystemID is null and y.SubSystemID is null, they're
                    // equal. 
                    return 0;
                } else {
                    // If x.SubSystemID is null and y.SubSystemID is not null, y
                    // is greater. 
                    return -1;
                }
            } else {
                // If x.SubSystemID is not null...
                //
                if (y.SubSystemID == null)
                // ...and y.SubSystemID is null, x.SubSystemID is greater.
                {
                    return 1;
                } else {
                    return string.Compare(x.SubSystemID, y.SubSystemID /*, true, System.Globalization.CultureInfo.InstalledUICulture*/);
                }
            }
        }

        #endregion // Comparer

        #region .Sort.

        public void Sort()
        {
            base.Sort(SubSystemCollectin.Comparer);

            foreach (SubSystem subSystem in this) {
                if (subSystem.Loops != null && subSystem.Loops.Count > 0) {
                    subSystem.Loops.Sort();
                }
                if (subSystem.Cables != null && subSystem.Cables.Count > 0) {
                    subSystem.Cables.Sort();
                }
            }
        }

        #endregion

        public Equipment EquipmentInSubSystems(string EquipmentTagNo)
        {
            if (this.Count > 0) {
                Equipment eqp = new Equipment();
                foreach (SubSystem subSystem in this) {
                    if ((eqp = subSystem.Loops.EquipmentInLoops(EquipmentTagNo)) != null) {
                        return eqp;
                    }
                }
                return null;
            }
            return null;
        }
    }
}
