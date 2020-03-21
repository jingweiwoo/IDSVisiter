using System;
using System.Collections.Generic;
using System.Text;

namespace Flute.DataStruct.IDS
{
    public class IDSSubLoop
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

        private IDSLoop _loop = null;
        /// <summary>
        /// Gets IDSLoop
        /// </summary>
        public IDSLoop Loop { get { return _loop; } }
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
        public bool IsNameInSubLoop { get; set; }
        /// <summary>
        /// Gets or Sets 名称拼在前面
        /// </summary>
        public bool IsNameInFront { get; set; }
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

        private IDSEquipmentCollection _equipments = null;
        /// <summary>
        /// Gets or Sets 设备
        /// </summary>
        public IDSEquipmentCollection Equipments
        {
            get { return _equipments; }
            set { _equipments = value; }
        }

        private IDSEquipingLocationCollection _equipingLocations = null;
        /// <summary>
        /// Gets or Sets 安装位置
        /// </summary>
        public IDSEquipingLocationCollection EquipingLocations
        {
            get { return _equipingLocations; }
            set { _equipingLocations = value; }
        }

        private IDSIOSignalCollection _ioSignals = null;
        /// <summary>
        /// Gets or Sets I/O信号
        /// </summary>
        public IDSIOSignalCollection IOSignals
        {
            get { return _ioSignals; }
            set { _ioSignals = value; }
        }

        /// <summary>
        /// 子回路下导出设备的数量统计
        /// </summary>
        public Int32 ExportEquipmentsCount
        {
            get
            {
                Int32 exportEquipmentsCount = 0;

                lock (this) {
                    if (this.Equipments != null && this.Equipments.Count > 0) {
                        foreach (IDSEquipment equip in this.Equipments) {
                            if (equip.Repository.ExportAllowed == true)
                                exportEquipmentsCount++;
                        }
                    }
                }
                return exportEquipmentsCount;
            }
        }

        #endregion // 成员属性

        private IDSSubLoop()
            : this(null)
        {
        }

        public IDSSubLoop(IDSLoop loop)
        {
            ID = "";
            ParentID = "";
            _loop = loop;
            Code = "";
            Name = "";
            Phase = "";
            SerialNumber = "";
            Description = "";
            IsNameInSubLoop = false;
            IsNameInFront = false;

            Equipments = new IDSEquipmentCollection();
            EquipingLocations = new IDSEquipingLocationCollection();
            IOSignals = new IDSIOSignalCollection();
        }

        #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public IDSSubLoop Copy()
        {
            IDSSubLoop subLoop = MemberwiseClone() as IDSSubLoop;
            subLoop._loop = this.Loop;
            subLoop.Equipments = this.Equipments.Copy();
            subLoop.EquipingLocations = this.EquipingLocations.Copy();
            subLoop.IOSignals = this.IOSignals.Copy();
            return subLoop;
        }

        #endregion // Copy
    }

    public class IDSSubLoopCollection : List<IDSSubLoop>
    {
        public IDSSubLoopCollection()
        {
        }

        #region .Key Index.

        public IDSSubLoop this[string id]
        {
            get
            {
                if (this.Count > 0) {
                    for (int i = 0; i < this.Count; i++) {
                        if (this[i].ID == id)
                            return (IDSSubLoop)this[i];
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
                        if (this[i].ID == id) {
                            this[i] = value;
                            break;
                        }
                    }
                }
                else
                    throw new System.ArgumentOutOfRangeException("IDS SubLoop Index", "No SubLoop with this ID can be found");
            }
        }

        #endregion // Key Index

        #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public IDSSubLoopCollection Copy()
        {
            IDSSubLoopCollection subLoops = new IDSSubLoopCollection();

            if (this.Count <= 0)
                return subLoops;
            else {
                foreach (IDSSubLoop subLoop in this)
                    subLoops.Add(subLoop.Copy());
                return subLoops;
            }
        }

        #endregion // Copy

        #region .Comparer.

        public static int Comparer(IDSSubLoop x, IDSSubLoop y)
        {
            if (x.ID == null) {
                if (y.ID == null) {
                    // If x.ID is null and y.ID is null, they're
                    // equal. 
                    return 0;
                }
                else {
                    // If x.ID is null and y.ID is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else {
                // If x.ID is not null...
                //
                if (y.ID == null)
                // ...and y.ID is null, x.ID is greater.
                {
                    return 1;
                }
                else {
                    return string.Compare(x.ID, y.ID /*, true, System.Globalization.CultureInfo.InstalledUICulture*/);
                }
            }
        }

        #endregion // Comparer

        #region .Sort.

        public void Sort()
        {
            base.Sort(IDSSubLoopCollection.Comparer);

            foreach (IDSSubLoop subLoop in this) {
                if (subLoop.Equipments != null && subLoop.Equipments.Count > 0) {
                    subLoop.Equipments.Sort();
                }
            }
        }

        #endregion
    }
}
