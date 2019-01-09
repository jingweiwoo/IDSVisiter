using System;
using System.Collections.Generic;
// using System.Linq;
using System.Text;

namespace Flute.DataStruct.EQA
{
    public class EQASubSystem
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

        private EQALoopCollection _loops = null;
        public EQALoopCollection Loops { get { return _loops; } set { _loops = value; } }

        private EQACableCollection _cables = null;
        public EQACableCollection Cables { get { return _cables; } set { _cables = value; } }

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
                        foreach (EQALoop loop in Loops) {
                            if (loop.Equipments != null) {
                                foreach (EQAEquipment eqp in loop.Equipments) {
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

        public EQASubSystem()
        {
            SubSystemID = "";
            Name = "";
            _loops = new EQALoopCollection();
            _cables = new EQACableCollection();
        }

        #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public EQASubSystem Copy()
        {
            EQASubSystem subSystem = MemberwiseClone() as EQASubSystem;
            subSystem.Loops = this.Loops.Copy();

            return subSystem;
        }

        #endregion // Copy
    }

    public class EQASubSystemCollectin : List<EQASubSystem>
    {
        public EQASubSystemCollectin()
        {
        }

        #region .Key Index.

        public EQASubSystem this[string subSystemID]
        {
            get
            {
                if (this.Count > 0) {
                    for (int i = 0; i < this.Count; i++) {
                        if (this[i].SubSystemID == subSystemID)
                            return (EQASubSystem)this[i];
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
        public EQASubSystemCollectin Copy()
        {
            EQASubSystemCollectin subSystems = new EQASubSystemCollectin();

            if (this.Count <= 0)
                return subSystems;
            else {
                foreach (EQASubSystem subSystem in this)
                    subSystems.Add(subSystem.Copy());
                return subSystems;
            }
        }

        #endregion // Copy

        #region .Comparer.

        public static int Comparer(EQASubSystem x, EQASubSystem y)
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
            base.Sort(EQASubSystemCollectin.Comparer);

            foreach (EQASubSystem subSystem in this) {
                if (subSystem.Loops != null && subSystem.Loops.Count > 0) {
                    subSystem.Loops.Sort();
                }
                if (subSystem.Cables != null && subSystem.Cables.Count > 0) {
                    subSystem.Cables.Sort();
                }
            }
        }

        #endregion

        public EQAEquipment EquipmentInSubSystems(string EquipmentTagNo)
        {
            if (this.Count > 0) {
                EQAEquipment eqp = new EQAEquipment();
                foreach (EQASubSystem subSystem in this) {
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
