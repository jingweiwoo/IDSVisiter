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
        /// Gets or Sets 父ID ------ 对应分组表的"ID" (设备类别)
        /// </summary>
        public string ParentID { get; set; }
        /// <summary>
        /// Gets or Sets 代码
        /// </summary>
        public string Code { get; set; }
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

        #endregion // 成员属性

        public IDSRepositoryCategory()
        {
            ID = "";
            ParentID = "";
            Code = "";
            Name = "";
            Description = "";
            Phase = "";
        }

        #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public IDSRepositoryCategory Copy()
        {
            IDSRepositoryCategory idsRepositoryCategory = MemberwiseClone() as IDSRepositoryCategory;
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

        public IDSRepositoryCategory this[string code]
        {
            get
            {
                if (this.Count > 0) {
                    for (int i = 0; i < this.Count; i++) {
                        if (this[i].Code == code)
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
                        if (this[i].Code == code) {
                            this[i] = value;
                            break;
                        }
                    }
                } else
                    throw new System.ArgumentOutOfRangeException("IDSRepositoryCategory Index", "No Repository Category with this Code can be found");
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

        #region .Comparer.

        public static int Comparer(IDSRepositoryCategory x, IDSRepositoryCategory y)
        {
            if (x.Code == null) {
                if (y.Code == null) {
                    // If x.Code is null and y.Code is null, they're
                    // equal. 
                    return 0;
                } else {
                    // If x.Code is null and y.Code is not null, y
                    // is greater. 
                    return -1;
                }
            } else {
                // If x.Code is not null...
                //
                if (y.Code == null)
                // ...and y.Code is null, x.Code is greater.
                {
                    return 1;
                } else {
                    return string.Compare(x.Code, y.Code /*, true, System.Globalization.CultureInfo.InstalledUICulture*/);
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
