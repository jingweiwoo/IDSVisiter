using System;
using System.Collections.Generic;
using System.Text;

namespace Flute.DataStruct.IDS
{
    public class IDSSubEquipment
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

        private IDSEquipment _equipment = null;
        /// <summary>
        /// Gets IDSEquipment
        /// </summary>
        public IDSEquipment Equipment { get { return _equipment; } }

        private string _tag = null;
        /// <summary>
        /// Gets or Sets 位号
        /// </summary>
        public string Tag
        {
            get {
                if (!IDSHelper.IsEncapsulatedInSquareBrackets(_tag))
                    return _tag;
                else {
                    string contentWithIn = IDSHelper.ContentEncapsulatedInSquareBrackets(_tag);
                    if (contentWithIn == IDSEnumAutoGenerationSymbol.AutoGenerate)
                        return _equipment.Tag;
                    return _tag;
                }
            }
            set { _tag = value; }
        }
        /// <summary>
        /// Gets or Sets 功能代码
        /// </summary>
        public string FunctionCode { get; set; }
        /// <summary>
        /// Gets or Sets 子设备后缀
        /// </summary>
        public string Suffix { get; set; }
        /// <summary>
        /// Gets or Sets 子设备名称后缀
        /// </summary>
        public string NameSuffix { get; set; }
        /// <summary>
        /// Gets or Sets 安装位置
        /// </summary>
        public string MountingType { get; set; }

        private string _mountingLocation = null;
        /// <summary>
        /// Gets or Sets 安装地点
        /// </summary>
        public string MountingLocation
        {
            get
            {
                if (!IDSHelper.IsEncapsulatedInSquareBrackets(_mountingLocation))
                    return _mountingLocation;
                else {
                    string contentWithIn = IDSHelper.ContentEncapsulatedInSquareBrackets(_mountingLocation);
                    if (IDSEnumAutoGenerationSymbol.Empty == contentWithIn)
                        return _equipment.SubLoop.Loop.Location;
                    else if (IDSEnumAutoGenerationSymbol.OnTheSide == contentWithIn)
                        return _equipment.SubLoop.Loop.Location + "旁";
                    else
                        return _mountingLocation;
                }
            }
            set { _mountingLocation = value; }
        }
        /// <summary>
        /// Gets or Sets 铭牌内容
        /// </summary>
        public string DataPlate { get; set; }
        /// <summary>
        /// Gets or Sets 供电来源
        /// </summary>
        public string PowerSupply { get; set; }
        /// <summary>
        /// Gets or Sets 开关位号
        /// </summary>
        public string SwitchTag { get; set; }
        /// <summary>
        /// Gets or Sets 脱扣电流
        /// </summary>
        public string ActingCurrent { get; set; }

        private IDSMountingScheme _mountingScheme = null;
        /// <summary>
        /// Gets or Sets 安装库信息
        /// </summary>
        public IDSMountingScheme MountingScheme
        {
            get { return _mountingScheme; }
            set { _mountingScheme = value; }
        }

        private IDSCableCollection _cables = null;
        /// <summary>
        /// Gets or Sets 电缆
        /// </summary>
        public IDSCableCollection Cables
        {
            get { return _cables; }
            set { _cables = value; }
        }
        
        #endregion // 成员属性

        private IDSSubEquipment()
            : this(null)
        {
        }

        /// <summary>
        /// 构造函数, 初始化成员属性为默认值
        /// </summary>
        public IDSSubEquipment(IDSEquipment equipment)
        {
            ID = "";
            ParentID = "";
            _equipment = equipment;
            Tag = "";
            FunctionCode = "";
            Suffix = "";
            NameSuffix = "";
            MountingType = "";
            MountingLocation = "";
            DataPlate = "";
            PowerSupply = "";
            SwitchTag = "";
            ActingCurrent = "";

            _cables = new IDSCableCollection();
            _mountingScheme = new IDSMountingScheme();
        }

        #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public IDSSubEquipment Copy()
        {
            IDSSubEquipment idsSubEquipment = MemberwiseClone() as IDSSubEquipment;
            // idsSubEquipment.MountingRepository = this.MountingRepository.Copy();
            idsSubEquipment._equipment = this.Equipment;
            idsSubEquipment.Cables = this.Cables.Copy();
            idsSubEquipment.MountingScheme = this.MountingScheme.Copy();

            return idsSubEquipment;
        }

        #endregion // Copy
    }

    public class IDSSubEquipmentCollection : List<IDSSubEquipment>
    {
        public IDSSubEquipmentCollection()
        {
        }

        #region .Key Index.

        public IDSSubEquipment this[string tag]
        {
            get
            {
                if (this.Count > 0) {
                    for (int i = 0; i < this.Count; i++) {
                        if (this[i].Tag == tag)
                            return (IDSSubEquipment)this[i];
                    }
                    return null;
                } else
                    return null;
            }
            set
            {
                if (this.Count > 0) {
                    for (int i = 0; i < this.Count; i++) {
                        if (this[i].Tag == tag) {
                            this[i] = value;
                            break;
                        }
                    }
                } else
                    throw new System.ArgumentOutOfRangeException("IDSSubEquipment Index", "No SubEquipment with this Tag Number can be found");
            }
        }

        #endregion // Key Index

        #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public IDSSubEquipmentCollection Copy()
        {
            IDSSubEquipmentCollection subEquipments = new IDSSubEquipmentCollection();

            if (this.Count <= 0)
                return subEquipments;
            else {
                foreach (IDSSubEquipment subEquipment in this)
                    subEquipments.Add(subEquipment.Copy());
                return subEquipments;
            }
        }

        #endregion // Copy

        #region .Comparer.

        public static int Comparer(IDSSubEquipment x, IDSSubEquipment y)
        {
            if (x.Tag == null) {
                if (y.Tag == null) {
                    // If x.TagNo is null and y.TagNo is null, they're
                    // equal. 
                    return 0;
                } else {
                    // If x.TagNo is null and y.TagNo is not null, y
                    // is greater. 
                    return -1;
                }
            } else {
                // If x.TagNo is not null...
                //
                if (y.Tag == null)
                // ...and y.TagNo is null, x.TagNo is greater.
                {
                    return 1;
                } else {
                    return string.Compare(x.Tag, y.Tag /*, true, System.Globalization.CultureInfo.InstalledUICulture*/);
                }
            }
        }

        #endregion // Comparer

        #region .Sort.

        public void Sort()
        {
            if (this.Count > 0)
                base.Sort(IDSSubEquipmentCollection.Comparer);

            foreach (IDSSubEquipment subEquipment in this) {
                if (subEquipment.Cables != null && subEquipment.Cables.Count > 0) {
                    subEquipment.Cables.Sort();
                }
            }
        }

        #endregion
    }
}
