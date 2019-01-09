using System;
using System.Collections.Generic;
using System.Text;

namespace Flute.DataStruct.IDS
{
    public class IDSSystem
    {
        #region .成员属性.

        /// <summary>
        /// Gets or Sets 代码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Gets or Sets 名称
        /// </summary>
        public string Name { get; set; }
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

        private IDSSubSystemCollection _subSystems = null;
        /// <summary>
        /// Gets or Sets 回路
        /// </summary>
        public IDSSubSystemCollection SubSystems
        {
            get { return _subSystems; }
            set { _subSystems = value; }
        }

        #endregion // 成员属性

        public IDSSystem()
        {
            Code = "";
            Name = "";
            Phase = "";
            SerialNumber = "";
            Description = "";

            SubSystems = new IDSSubSystemCollection();
        }

        #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public IDSSystem Copy()
        {
            IDSSystem system = MemberwiseClone() as IDSSystem;
            system.SubSystems = this.SubSystems.Copy();
            return system;
        }

        #endregion // Copy
    }

    public class IDSSystemCollection : List<IDSSystem>
    {
        public IDSSystemCollection()
        {
        }

        #region .Key Index.

        public IDSSystem this[string code]
        {
            get
            {
                if (this.Count > 0) {
                    for (int i = 0; i < this.Count; i++) {
                        if (this[i].Code == code)
                            return (IDSSystem)this[i];
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
                    throw new System.ArgumentOutOfRangeException("IDS System Index", "No System with this Code can be found");
            }
        }

        #endregion // Key Index

        #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public IDSSystemCollection Copy()
        {
            IDSSystemCollection systems = new IDSSystemCollection();

            if (this.Count <= 0)
                return systems;
            else {
                foreach (IDSSystem system in this)
                    systems.Add(system.Copy());
                return systems;
            }
        }

        #endregion // Copy

        #region .Comparer.

        public static int Comparer(IDSSystem x, IDSSystem y)
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
            base.Sort(IDSSystemCollection.Comparer);

            foreach (IDSSystem system in this) {
                if (system.SubSystems != null && system.SubSystems.Count > 0) {
                    system.SubSystems.Sort();
                }
            }
        }

        #endregion
    }
}
