using System;
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

        private string _tag = null;
        /// <summary>
        /// Gets or Sets 位号
        /// </summary>
        public string Tag
        {
            get
            {
                if (!IDSHelper.IsEncapsulatedInSquareBrackets(_tag))
                    return _tag;
                else {
                    string contentWithIn = IDSHelper.ContentEncapsulatedInSquareBrackets(_tag);
                    if (contentWithIn == IDSEnumAutoGenerationSymbol.AutoGenerate)
                        return _subLoop.Loop.SubSystem.System.Code
                                + "." + _subLoop.Loop.LoopType + FunctionCode
                                + "-" + _subLoop.Loop.SubSystem.Code + _subLoop.Loop.SerialNumber
                                + _subLoop.Loop.Suffix + _subLoop.Code + Suffix;
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
        /// Gets or Sets 后缀
        /// </summary>
        public string Suffix { get; set; }
        /// <summary>
        /// Gets or Sets 设备类型
        /// </summary>
        public string EquipmentCatagory { get; set; }
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

        private IDSRepository _equipmentRepository = null;
        /// <summary>
        /// Gets or Sets 库设备
        /// </summary>
        public IDSRepository EquipmentRepository
        {
            get { return _equipmentRepository; }
            set { _equipmentRepository = value; }
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
            Tag = "";
            FunctionCode = "";
            Suffix = "";
            EquipmentCatagory = "";
            SpecificInfo1 = "";
            SpecificInfo2 = "";
            Quantity = 0;
            Remark = "";
            EquipmentRepository = new IDSRepository();
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
            equipment.EquipmentRepository = this.EquipmentRepository.Copy();
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

