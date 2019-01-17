using System;
using System.Collections.Generic;
using System.Text;

namespace Flute.DataStruct.IDS
{
    public class IDSRepository
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
        /// Gets or Sets 库序号
        /// </summary>
        public string RepositoryID { get; set; }
        /// <summary>
        /// Gets or Sets 子类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Gets or Sets 版本
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// Gets or Sets 设备材料性质
        /// </summary>
        public string Attribute { get; set; }
        /// <summary>
        /// Gets or Sets 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or Sets 用途
        /// </summary>
        public string Usage { get; set; }
        /// <summary>
        /// Gets or Sets 型号
        /// </summary>
        public string ModelNumber { get; set; }
        /// <summary>
        /// Gets or Sets 名称后缀选项
        /// </summary>
        public string NameSuffix { get; set; }
        /// <summary>
        /// Gets or Sets 端子
        /// </summary>
        public string TerminalDefinition { get; set; }
        /// <summary>
        /// Gets or Sets 单位
        /// </summary>
        public string QuantityUnit { get; set; }
        /// <summary>
        /// Gets or Sets 不打印
        /// </summary>
        public bool NotPrintOut { get; set; }

        /// <summary>
        /// Gets or Sets 文本1
        /// </summary>
        public string Text01 { get; set; }
        /// <summary>
        /// Gets or Sets 文本2
        /// </summary>
        public string Text02 { get; set; }
        /// <summary>
        /// Gets or Sets 文本3
        /// </summary>
        public string Text03 { get; set; }
        /// <summary>
        /// Gets or Sets 文本4
        /// </summary>
        public string Text04 { get; set; }
        /// <summary>
        /// Gets or Sets 文本5
        /// </summary>
        public string Text05 { get; set; }
        /// <summary>
        /// Gets or Sets 文本6
        /// </summary>
        public string Text06 { get; set; }
        /// <summary>
        /// Gets or Sets 文本7
        /// </summary>
        public string Text07 { get; set; }
        /// <summary>
        /// Gets or Sets 文本8
        /// </summary>
        public string Text08 { get; set; }
        /// <summary>
        /// Gets or Sets 文本9
        /// </summary>
        public string Text09 { get; set; }
        /// <summary>
        /// Gets or Sets 文本10
        /// </summary>
        public string Text10 { get; set; }
        /// <summary>
        /// Gets or Sets 文本11
        /// </summary>
        public string Text11 { get; set; }
        /// <summary>
        /// Gets or Sets 文本12
        /// </summary>
        public string Text12 { get; set; }
        /// <summary>
        /// Gets or Sets 文本13
        /// </summary>
        public string Text13 { get; set; }
        /// <summary>
        /// Gets or Sets 文本14
        /// </summary>
        public string Text14 { get; set; }
        /// <summary>
        /// Gets or Sets 文本15
        /// </summary>
        public string Text15 { get; set; }
        /// <summary>
        /// Gets or Sets 文本16
        /// </summary>
        public string Text16 { get; set; }
        /// <summary>
        /// Gets or Sets 文本17
        /// </summary>
        public string Text17 { get; set; }
        /// <summary>
        /// Gets or Sets 文本18
        /// </summary>
        public string Text18 { get; set; }
        /// <summary>
        /// Gets or Sets 文本19
        /// </summary>
        public string Text19 { get; set; }
        /// <summary>
        /// Gets or Sets 文本20
        /// </summary>
        public string Text20 { get; set; }
        /// <summary>
        /// Gets or Sets 文本21
        /// </summary>
        public string Text21 { get; set; }
        /// <summary>
        /// Gets or Sets 文本22
        /// </summary>
        public string Text22 { get; set; }
        /// <summary>
        /// Gets or Sets 文本23
        /// </summary>
        public string Text23 { get; set; }
        /// <summary>
        /// Gets or Sets 文本24
        /// </summary>
        public string Text24 { get; set; }
        /// <summary>
        /// Gets or Sets 文本25
        /// </summary>
        public string Text25 { get; set; }
        /// <summary>
        /// Gets or Sets 文本26
        /// </summary>
        public string Text26 { get; set; }
        /// <summary>
        /// Gets or Sets 文本27
        /// </summary>
        public string Text27 { get; set; }
        /// <summary>
        /// Gets or Sets 文本28
        /// </summary>
        public string Text28 { get; set; }

        /// <summary>
        /// Gets or Sets 备注1
        /// </summary>
        public string Remark01 { get; set; }
        /// <summary>
        /// Gets or Sets 备注2
        /// </summary>
        public string Remark02 { get; set; }
        /// <summary>
        /// Gets or Sets 备注3
        /// </summary>
        public string Remark03 { get; set; }

        /// <summary>
        /// Gets or Sets 数值1
        /// </summary>
        public Int32 Value01 { get; set; }
        /// <summary>
        /// Gets or Sets 数值2
        /// </summary>
        public Int32 Value02 { get; set; }
        /// <summary>
        /// Gets or Sets 数值3
        /// </summary>
        public Int32 Value03 { get; set; }
        /// <summary>
        /// Gets or Sets 数值4
        /// </summary>
        public Int32 Value04 { get; set; }
        /// <summary>
        /// Gets or Sets 数值5
        /// </summary>
        public Int32 Value05 { get; set; }
        /// <summary>
        /// Gets or Sets 数值6
        /// </summary>
        public Int32 Value06 { get; set; }
        /// <summary>
        /// Gets or Sets 数值7
        /// </summary>
        public Int32 Value07 { get; set; }
        /// <summary>
        /// Gets or Sets 数值8
        /// </summary>
        public Int32 Value08 { get; set; }
        /// <summary>
        /// Gets or Sets 数值9
        /// </summary>
        public Int32 Value09 { get; set; }
        /// <summary>
        /// Gets or Sets 数值10
        /// </summary>
        public Int32 Value10 { get; set; }
        /// <summary>
        /// Gets or Sets 数值11
        /// </summary>
        public Int32 Value11 { get; set; }
        /// <summary>
        /// Gets or Sets 数值12
        /// </summary>
        public Int32 Value12 { get; set; }
        /// <summary>
        /// Gets or Sets 数值13
        /// </summary>
        public Int32 Value13 { get; set; }
        /// <summary>
        /// Gets or Sets 数值14
        /// </summary>
        public Int32 Value14 { get; set; }
        /// <summary>
        /// Gets or Sets 数值15
        /// </summary>
        public Int32 Value15 { get; set; }
        /// <summary>
        /// Gets or Sets 数值16
        /// </summary>
        public Int32 Value16 { get; set; }
        /// <summary>
        /// Gets or Sets 数值17
        /// </summary>
        public Int32 Value17 { get; set; }
        /// <summary>
        /// Gets or Sets 数值18
        /// </summary>
        public Int32 Value18 { get; set; }
        /// <summary>
        /// Gets or Sets 数值19
        /// </summary>
        public Int32 Value19 { get; set; }
        /// <summary>
        /// Gets or Sets 数值20
        /// </summary>
        public Int32 Value20 { get; set; }
        /// <summary>
        /// Gets or Sets 数值21
        /// </summary>
        public Int32 Value21 { get; set; }
        /// <summary>
        /// Gets or Sets 数值22
        /// </summary>
        public Int32 Value22 { get; set; }
        /// <summary>
        /// Gets or Sets 数值23
        /// </summary>
        public Int32 Value23 { get; set; }
        /// <summary>
        /// Gets or Sets 数值24
        /// </summary>
        public Int32 Value24 { get; set; }
        /// <summary>
        /// Gets or Sets 数值25
        /// </summary>
        public Int32 Value25 { get; set; }
        /// <summary>
        /// Gets or Sets 数值26
        /// </summary>
        public Int32 Value26 { get; set; }
        /// <summary>
        /// Gets or Sets 数值27
        /// </summary>
        public Int32 Value27 { get; set; }
        /// <summary>
        /// Gets or Sets 数值28
        /// </summary>
        public Int32 Value28 { get; set; }

        /// <summary>
        /// Gets or Sets 是否1
        /// </summary>
        public bool YesOrNo01 { get; set; }
        /// <summary>
        /// Gets or Sets 是否2
        /// </summary>
        public bool YesOrNo02 { get; set; }
        /// <summary>
        /// Gets or Sets 是否3
        /// </summary>
        public bool YesOrNo03 { get; set; }
        /// <summary>
        /// Gets or Sets 是否4
        /// </summary>
        public bool YesOrNo04 { get; set; }
        /// <summary>
        /// Gets or Sets 是否5
        /// </summary>
        public bool YesOrNo05 { get; set; }

        /// <summary>
        /// Gets or Sets 修改保护
        /// </summary>
        public bool ProtectionEnabled { get; set; }


        #endregion // 成员属性

        /// <summary>
        /// 构造函数, 初始化成员属性为默认值
        /// </summary>
        public IDSRepository()
        {
            ID = "";
            ParentID = "";
            RepositoryID = "";
            Type = "";
            Version = "";
            Attribute = "";
            Name = "";
            Usage = "";
            ModelNumber = "";
            NameSuffix = "";
            TerminalDefinition = "";
            QuantityUnit = "";
            NotPrintOut = false;

            Text01 = "";
            Text02 = "";
            Text03 = "";
            Text04 = "";
            Text05 = "";
            Text06 = "";
            Text07 = "";
            Text08 = "";
            Text09 = "";
            Text10 = "";
            Text11 = "";
            Text12 = "";
            Text13 = "";
            Text14 = "";
            Text15 = "";
            Text16 = "";
            Text17 = "";
            Text18 = "";
            Text19 = "";
            Text20 = "";
            Text21 = "";
            Text22 = "";
            Text23 = "";
            Text24 = "";
            Text25 = "";
            Text26 = "";
            Text27 = "";
            Text28 = "";

            Remark01 = "";
            Remark02 = "";
            Remark03 = "";

            Value01 = 0;
            Value02 = 0;
            Value03 = 0;
            Value04 = 0;
            Value05 = 0;
            Value06 = 0;
            Value07 = 0;
            Value08 = 0;
            Value09 = 0;
            Value10 = 0;
            Value11 = 0;
            Value12 = 0;
            Value13 = 0;
            Value14 = 0;
            Value15 = 0;
            Value16 = 0;
            Value17 = 0;
            Value18 = 0;
            Value19 = 0;
            Value20 = 0;
            Value21 = 0;
            Value22 = 0;
            Value23 = 0;
            Value24 = 0;
            Value25 = 0;
            Value26 = 0;
            Value27 = 0;
            Value28 = 0;

            YesOrNo01 = false;
            YesOrNo02 = false;
            YesOrNo03 = false;
            YesOrNo04 = false;
            YesOrNo05 = false;

            ProtectionEnabled = false;
        }

        #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public IDSRepository Copy()
        {
            IDSRepository idsRepository = MemberwiseClone() as IDSRepository;
            return idsRepository;
        }

        #endregion // Copy
    }

    public class IDSRepositoryCollection : List<IDSRepository>
    {
        public IDSRepositoryCollection()
        {
        }

        #region .Key Index.

        public IDSRepository this[string repositoryID]
        {
            get
            {
                if (this.Count > 0) {
                    for (int i = 0; i < this.Count; i++) {
                        if (this[i].RepositoryID == repositoryID)
                            return (IDSRepository)this[i];
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
                        if (this[i].RepositoryID == repositoryID) {
                            this[i] = value;
                            break;
                        }
                    }
                }
                else
                    throw new System.ArgumentOutOfRangeException("IDSRepository Index", "No Repository with this Repository ID can be found");
            }
        }

        #endregion // Key Index

        #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public IDSRepositoryCollection Copy()
        {
            IDSRepositoryCollection repositories = new IDSRepositoryCollection();

            if (this.Count <= 0)
                return repositories;
            else {
                foreach (IDSRepository repository in this)
                    repositories.Add(repository.Copy());
                return repositories;
            }
        }

        #endregion // Copy

        #region .Comparer.

        public static int Comparer(IDSRepository x, IDSRepository y)
        {
            if (x.RepositoryID == null) {
                if (y.RepositoryID == null) {
                    // If x.RepositoryID is null and y.RepositoryID is null, they're
                    // equal. 
                    return 0;
                }
                else {
                    // If x.RepositoryID is null and y.RepositoryID is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else {
                // If x.RepositoryID is not null...
                //
                if (y.RepositoryID == null)
                // ...and y.RepositoryID is null, x.RepositoryID is greater.
                {
                    return 1;
                }
                else {
                    return string.Compare(x.RepositoryID, y.RepositoryID /*, true, System.Globalization.CultureInfo.InstalledUICulture*/);
                }
            }
        }

        #endregion // Comparer

        #region .Sort.

        public void Sort()
        {
            if (this.Count > 0)
                base.Sort(IDSRepositoryCollection.Comparer);
        }

        #endregion
    }
}
