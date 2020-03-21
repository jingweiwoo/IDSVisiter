using System;
using System.Collections.Generic;
using System.Text;

namespace Flute.DataStruct.IDS
{
    public class IDSRepositoryCategory
    {
        #region .成员属性.
        /// <summary>
        /// Gets or Sets ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Gets or Sets 父ID ------ 常数0
        /// </summary>
        public string ParentID { get; set; }
        /// <summary>
        /// Gets or Sets 设备类型 (对应表中的"代码"项 Code)
        /// </summary>
        public string RepositoryCatagoryID { get; set; }
        /// <summary>
        /// Gets or Sets 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or Sets 说明
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or Sets 阶段类型
        /// </summary>
        public string Phase { get; set; }
        /// <summary>
        /// Gets or Sets 库设备
        /// </summary>
        public IDSRepositoryCollection Repositories { get; set; }

        #endregion // 成员属性

        public IDSRepositoryCategory()
        {
            ID = "";
            ParentID = "";
            RepositoryCatagoryID = "";
            Name = "";
            Description = "";
            Phase = "";

            Repositories = new IDSRepositoryCollection();
        }

        #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public IDSRepositoryCategory Copy()
        {
            IDSRepositoryCategory idsRepositoryCategory = MemberwiseClone() as IDSRepositoryCategory;
            if (Repositories != null && Repositories.Count > 0)
                foreach (IDSRepository repository in this.Repositories) {
                    idsRepositoryCategory.Repositories.Add(repository.Copy());
                }
            return idsRepositoryCategory;
        }

        #endregion // Copy
    }

    public class IDSRepositoryCategoryCollection : List<IDSRepositoryCategory>
    {
        public IDSRepositoryCategoryCollection()
        {
        }

        #region .Key Index.

        public IDSRepositoryCategory this[string repositoryCatagoryID]
        {
            get
            {
                if (this.Count > 0) {
                    for (int i = 0; i < this.Count; i++) {
                        if (this[i].RepositoryCatagoryID == repositoryCatagoryID)
                            return (IDSRepositoryCategory)this[i];
                    }
                    return null;
                } else
                    return null;
            }
            set
            {
                if (this.Count > 0) {
                    for (int i = 0; i < this.Count; i++) {
                        if (this[i].RepositoryCatagoryID == repositoryCatagoryID) {
                            this[i] = value;
                            break;
                        }
                    }
                } else
                    throw new System.ArgumentOutOfRangeException("IDSRepositoryCategory Index", "No Repository Category with this RepositoryCatagoryID can be found");
            }
        }

        #endregion // Key Index

        #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public IDSRepositoryCategoryCollection Copy()
        {
            IDSRepositoryCategoryCollection repositoryCategories = new IDSRepositoryCategoryCollection();

            if (this.Count <= 0)
                return repositoryCategories;
            else {
                foreach (IDSRepositoryCategory repositoryCategory in this)
                    repositoryCategories.Add(repositoryCategory.Copy());
                return repositoryCategories;
            }
        }

        #endregion // Copy

        public bool ContainsByRepositoryCatagoryID(string repositoryCatagoryID)
        {
            if (this.Count > 0) {
                for (int i = 0; i < this.Count; i++) {
                    if (this[i].RepositoryCatagoryID == repositoryCatagoryID)
                        return true;
                }
                return false;
            } else
                return false;
        }

        #region .Comparer.

        public static int Comparer(IDSRepositoryCategory x, IDSRepositoryCategory y)
        {
            if (x.RepositoryCatagoryID == null) {
                if (y.RepositoryCatagoryID == null) {
                    // If x.RepositoryCatagoryID is null and y.RepositoryCatagoryID is null, they're
                    // equal. 
                    return 0;
                } else {
                    // If x.RepositoryCatagoryID is null and y.RepositoryCatagoryID is not null, y
                    // is greater. 
                    return -1;
                }
            } else {
                // If x.RepositoryCatagoryID is not null...
                //
                if (y.RepositoryCatagoryID == null)
                // ...and y.RepositoryCatagoryID is null, x.RepositoryCatagoryID is greater.
                {
                    return 1;
                } else {
                    return string.Compare(x.RepositoryCatagoryID, y.RepositoryCatagoryID /*, true, System.Globalization.CultureInfo.InstalledUICulture*/);
                }
            }
        }

        #endregion // Comparer

        #region .Sort.

        public new void Sort()
        {
            if (this.Count > 0)
                base.Sort(IDSRepositoryCategoryCollection.Comparer);
        }

        #endregion
    }
}
