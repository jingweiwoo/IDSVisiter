using System;
using System.Collections.Generic;
using System.Text;

namespace Flute.DataStruct.IDS
{
    public class IDSMountingSchemeMaterial
    {
        #region .成员属性.

        /// <summary>
        /// Gets or Sets 序号
        /// </summary>
        public string SerialNumber { get; set; }
        /// <summary>
        /// Gets or Sets 数量
        /// </summary>
        public Int32 Quantity { get; set; }
        /// <summary>
        /// Gets or Sets 规格
        /// </summary>
        public string Specification { get; set; }
        /// <summary>
        /// Gets or Sets 备注
        /// </summary>
        public string Remark { get; set; }
        
        private IDSRepository _materialRepository = null;
        /// <summary>
        /// Gets or Sets 材料
        /// </summary>
        public IDSRepository MaterialRepository
        {
            get { return _materialRepository; }
            set { _materialRepository = value; }
        }

        #endregion // 成员属性

        public IDSMountingSchemeMaterial()
        {
            SerialNumber = "";
            Quantity = 0;
            Specification = "";
            Remark = "";
            
            MaterialRepository = new IDSRepository();
        }

        #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public IDSMountingSchemeMaterial Copy()
        {
            IDSMountingSchemeMaterial mountingSchemeMaterial = MemberwiseClone() as IDSMountingSchemeMaterial;
            mountingSchemeMaterial.MaterialRepository = this.MaterialRepository.Copy();
            return mountingSchemeMaterial;
        }

        #endregion // Copy
    }

    public class IDSMountingSchemeMaterialCollection : List<IDSMountingSchemeMaterial>
    {
        public IDSMountingSchemeMaterialCollection()
        {
        }

        #region .Key Index.

        public IDSMountingSchemeMaterial this[string serialNumber]
        {
            get
            {
                if (this.Count > 0) {
                    for (int i = 0; i < this.Count; i++) {
                        if (this[i].SerialNumber == serialNumber)
                            return (IDSMountingSchemeMaterial)this[i];
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
                        if (this[i].SerialNumber == serialNumber) {
                            this[i] = value;
                            break;
                        }
                    }
                }
                else
                    throw new System.ArgumentOutOfRangeException("IDS MountingSchemeMaterial Index", "No MountingSchemeMaterial with this Code can be found");
            }
        }

        #endregion // Key Index

        #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public IDSMountingSchemeMaterialCollection Copy()
        {
            IDSMountingSchemeMaterialCollection mountingSchemeMaterials = new IDSMountingSchemeMaterialCollection();

            if (this.Count <= 0)
                return mountingSchemeMaterials;
            else {
                foreach (IDSMountingSchemeMaterial mountingSchemeMaterial in this)
                    mountingSchemeMaterials.Add(mountingSchemeMaterial.Copy());
                return mountingSchemeMaterials;
            }
        }

        #endregion // Copy

        #region .Comparer.

        public static int Comparer(IDSMountingSchemeMaterial x, IDSMountingSchemeMaterial y)
        {
            if (x.SerialNumber == null) {
                if (y.SerialNumber == null) {
                    // If x.SerialNumber is null and y.SerialNumber is null, they're
                    // equal. 
                    return 0;
                }
                else {
                    // If x.SerialNumber is null and y.SerialNumber is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else {
                // If x.SerialNumber is not null...
                //
                if (y.SerialNumber == null)
                // ...and y.SerialNumber is null, x.SerialNumber is greater.
                {
                    return 1;
                }
                else {
                    return string.Compare(x.SerialNumber, y.SerialNumber /*, true, System.Globalization.CultureInfo.InstalledUICulture*/);
                }
            }
        }

        #endregion // Comparer

        #region .Sort.

        public void Sort()
        {
            base.Sort(IDSMountingSchemeMaterialCollection.Comparer);
        }

        #endregion
    }
}
