﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Flute.DataStruct.IDS
{
    public class IDSEquipment
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

        private IDSSubLoop _subLoop = null;
        /// <summary>
        /// Gets SubLoop
        /// </summary>
        public IDSSubLoop SubLoop { get { return _subLoop; } }

        private string _originalTag = null;
        /// <summary>
        /// Gets or Sets 位号 (数据库中保存的值)
        /// </summary>
        public string OriginalTag
        {
            private get { return _originalTag; }
            set { _originalTag = value; }
        }

        /// <summary>
        /// Gets 位号 
        /// </summary>
        public string Tag
        {
            get
            {
                if (!IDSHelper.IsEncapsulatedInSquareBrackets(_originalTag))
                    return _originalTag;
                else {
                    string contentWithIn = IDSHelper.ContentEncapsulatedInSquareBrackets(_originalTag);
                    if (contentWithIn == IDSEnumAutoGenerationSymbol.AutoGenerate)
                        return _subLoop.Loop.SubSystem.System.Code
                                + "." + _subLoop.Loop.LoopType + FunctionCode
                                + "-" + _subLoop.Loop.SubSystem.Code + _subLoop.Loop.SerialNumber
                                + _subLoop.Loop.Suffix + _subLoop.Code + Suffix;
                    return _originalTag;
                }
            }
        }

        /// <summary>
        /// Gets or Sets 功能代码
        /// </summary>
        public string FunctionCode { get; set; }
        /// <summary>
        /// Gets or Sets 后缀
        /// </summary>
        public string Suffix { get; set; }

        /// <summary>
        /// Gets 功能代码/后缀
        /// </summary>
        public string FunctionCodeAndSuffix { get { return FunctionCode + "/" + Suffix; } }

        /// <summary>
        /// Gets or Sets 设备类型
        /// </summary>
        public string RepositoryCatagoryID { get; set; }
        /// <summary>
        /// Gets or Sets 库序号
        /// </summary>
        public string RepositoryID { get; set; }
        /// <summary>
        /// Gets or Sets 规格1
        /// </summary>
        public string SpecificInfo1 { get; set; }
        /// <summary>
        /// Gets or Sets 规格2
        /// </summary>
        public string SpecificInfo2 { get; set; }
        /// <summary>
        /// Gets or Sets 数量
        /// </summary>
        public Int32 Quantity { get; set; }
        /// <summary>
        /// Gets or Sets 备注
        /// </summary>
        public string Remark { get; set; }

        private IDSRepository _repository = null;
        /// <summary>
        /// Gets or Sets 库设备
        /// </summary>
        public IDSRepository Repository
        {
            get { return _repository; }
            set { _repository = value; }
        }

        private IDSSubEquipmentCollection _subEquipments = null;
        /// <summary>
        /// Gets or Sets 子设备
        /// </summary>
        public IDSSubEquipmentCollection SubEquipments
        {
            get { return _subEquipments; }
            set { _subEquipments = value; }
        }

        #endregion // 成员属性

        private IDSEquipment()
            : this(null)
        {
        }

        public IDSEquipment(IDSSubLoop subLoop)
        {
            ID = "";
            ParentID = "";
            _subLoop = subLoop;
            OriginalTag = "";
            FunctionCode = "";
            Suffix = "";
            RepositoryCatagoryID = "";
            SpecificInfo1 = "";
            SpecificInfo2 = "";
            Quantity = 0;
            Remark = "";
            Repository = new IDSRepository();
            SubEquipments = new IDSSubEquipmentCollection();
        }

        #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public IDSEquipment Copy()
        {
            IDSEquipment equipment = MemberwiseClone() as IDSEquipment;
            equipment._subLoop = this.SubLoop;
            equipment.Repository = this.Repository.Copy();
            equipment.SubEquipments = this.SubEquipments.Copy();

            return equipment;
        }

        #endregion // Copy
    }

    public class IDSEquipmentCollection : List<IDSEquipment>
    {
        public IDSEquipmentCollection()
        {
        }

        #region .Key Index.

        public IDSEquipment this[string tag]
        {
            get
            {
                if (this.Count > 0) {
                    for (int i = 0; i < this.Count; i++) {
                        if (this[i].Tag == tag)
                            return (IDSEquipment)this[i];
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
                    throw new System.ArgumentOutOfRangeException("IDS Equipment Index", "No Equipment with this Tag can be found");
            }
        }

        #endregion // Key Index

        #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public IDSEquipmentCollection Copy()
        {
            IDSEquipmentCollection equipments = new IDSEquipmentCollection();

            if (this.Count <= 0)
                return equipments;
            else {
                foreach (IDSEquipment equipment in this)
                    equipments.Add(equipment.Copy());
                return equipments;
            }
        }

        #endregion // Copy

        public bool ContainsByFunctionCodeAndSuffix(string functionCodeAndSuffix) 
        {
            if (this.Count > 0) {
                for (int i = 0; i < this.Count; i++) {
                    if (this[i].FunctionCodeAndSuffix == functionCodeAndSuffix)
                        return true;
                }
                return false;
            } else
                return false;
        }

        public IDSEquipment GetEquipmentByFunctionCodeAndSuffix(string functionCodeAndSuffix)
        {
            if (this.Count > 0) {
                for (int i = 0; i < this.Count; i++) {
                    if (this[i].FunctionCodeAndSuffix == functionCodeAndSuffix)
                        return (IDSEquipment)this[i];
                }
                return null;
            } else
                return null;
        }

        #region .Comparer.

        public static int Comparer(IDSEquipment x, IDSEquipment y)
        {
            if (x.Tag == null) {
                if (y.Tag == null) {
                    // If x.Tag is null and y.Tag is null, they're
                    // equal. 
                    return 0;
                } else {
                    // If x.Tag is null and y.Tag is not null, y
                    // is greater. 
                    return -1;
                }
            } else {
                // If x.Tag is not null...
                //
                if (y.Tag == null)
                // ...and y.Tag is null, x.Tag is greater.
                {
                    return 1;
                } else {
                    return string.Compare(x.Tag, y.Tag /*, true, System.Globalization.CultureInfo.InstalledUICulture*/);
                }
            }
        }

        #endregion // Comparer

        #region .Sort.

        public new void Sort()
        {
            base.Sort(IDSEquipmentCollection.Comparer);

            foreach (IDSEquipment equipment in this) {
                if (equipment.SubEquipments != null && equipment.SubEquipments.Count > 0) {
                    equipment.SubEquipments.Sort();
                }
            }
        }

        #endregion
    }
}

