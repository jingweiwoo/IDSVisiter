using System;
using System.Collections.Generic;
using System.Text;

namespace Flute.DataStruct.IDS
{
    public class IDSMountingScheme
    {
        #region .成员属性.

        /// <summary>
        /// Gets or Sets 安装方案ID
        /// </summary>
        public string MountingSchemeID { get; set; }
        /// <summary>
        /// Gets or Sets 安装方案类型
        /// </summary>
        public string MountingType { get; set; }
        /// <summary>
        /// Gets or Sets 用途
        /// </summary>
        public string Usage { get; set; }
        /// <summary>
        /// Gets or Sets 文件名
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Gets or Sets 导管库序号
        /// </summary>
        public string TubeRepositoryID { get; set; }
        /// <summary>
        /// Gets or Sets 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// Gets or Sets 修改保护
        /// </summary>
        public bool ProtectionEnabled { get; set; }

        private IDSRepositoryCollection _repositories = null;
        /// <summary>
        /// Gets or Sets 安装材料
        /// </summary>
        public IDSRepositoryCollection Repositories
        {
            get { return _repositories; }
            set { _repositories = value; }
        }

        private IDSRepository _tubeRepository = null;
        /// <summary>
        /// Gets or Sets 导管材料
        /// </summary>
        public IDSRepository TubeRepository
        {
            get { return _tubeRepository; }
            set { _tubeRepository = value; }
        }

        #endregion // 成员属性

        public IDSMountingScheme()
        {
            MountingSchemeID = "";
            MountingType = "";
            Usage = "";
            FileName = "";
            TubeRepositoryID = "";
            Remark = "";
            ProtectionEnabled = false;

            Repositories = new IDSRepositoryCollection();
            TubeRepository = new IDSRepository();
        }

        #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public IDSMountingScheme Copy()
        {
            IDSMountingScheme mountingScheme = MemberwiseClone() as IDSMountingScheme;
            mountingScheme.Repositories = this.Repositories.Copy();
            mountingScheme.TubeRepository = this.TubeRepository.Copy();
            return mountingScheme;
        }

        #endregion // Copy
    }

    public class IDSMountingSchemeCollection : List<IDSMountingScheme>
    {
        public IDSMountingSchemeCollection()
        {
        }

        #region .Key Index.

        public IDSMountingScheme this[string mountingSchemeID]
        {
            get
            {
                if (this.Count > 0) {
                    for (int i = 0; i < this.Count; i++) {
                        if (this[i].MountingSchemeID == mountingSchemeID)
                            return (IDSMountingScheme)this[i];
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
                        if (this[i].MountingSchemeID == mountingSchemeID) {
                            this[i] = value;
                            break;
                        }
                    }
                }
                else
                    throw new System.ArgumentOutOfRangeException("IDS MountingScheme Index", "No MountingScheme with this Code can be found");
            }
        }

        #endregion // Key Index

        #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public IDSMountingSchemeCollection Copy()
        {
            IDSMountingSchemeCollection mountingSchemes = new IDSMountingSchemeCollection();

            if (this.Count <= 0)
                return mountingSchemes;
            else {
                foreach (IDSMountingScheme mountingScheme in this)
                    mountingSchemes.Add(mountingScheme.Copy());
                return mountingSchemes;
            }
        }

        #endregion // Copy

        #region .Comparer.

        public static int Comparer(IDSMountingScheme x, IDSMountingScheme y)
        {
            if (x.MountingSchemeID == null) {
                if (y.MountingSchemeID == null) {
                    // If x.MountingSchemeID is null and y.MountingSchemeID is null, they're
                    // equal. 
                    return 0;
                }
                else {
                    // If x.MountingSchemeID is null and y.MountingSchemeID is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else {
                // If x.MountingSchemeID is not null...
                //
                if (y.MountingSchemeID == null)
                // ...and y.MountingSchemeID is null, x.MountingSchemeID is greater.
                {
                    return 1;
                }
                else {
                    return string.Compare(x.MountingSchemeID, y.MountingSchemeID /*, true, System.Globalization.CultureInfo.InstalledUICulture*/);
                }
            }
        }

        #endregion // Comparer

        #region .Sort.

        public void Sort()
        {
            base.Sort(IDSMountingSchemeCollection.Comparer);

            foreach (IDSMountingScheme mountingScheme in this) {
                if (mountingScheme.Repositories != null && mountingScheme.Repositories.Count > 0) {
                    mountingScheme.Repositories.Sort();
                }
            }
        }

        #endregion
    }
}
