using System;
using System.Collections.Generic;
// using System.Linq;
using System.Text;

namespace Flute.DataStruct.EQA
{
    public class Equipment
    {
        #region .成员属性.

        /// <summary>
        /// Gets or Sets 位号
        /// </summary>
        public string TagNo { get; set; }
        /// <summary>
        /// Gets or Sets 回路号
        /// </summary>
        public string LoopNo { get; set; }
        /// <summary>
        /// Gets or Sets 设备名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or Sets 设备型号
        /// </summary>
        public string EqpType { get; set; }
        /// <summary>
        /// Gets or Sets 设备数量
        /// </summary>
        public Int32 Quantity { get; set; }
        /// <summary>
        /// Gets or Sets 显示/测量范围下限
        /// </summary>
        public string LowerLimit { get; set; }
        /// <summary>
        /// Gets or Sets 显示/测量范围上限
        /// </summary>
        public string UpperLimit { get; set; }
        /// <summary>
        /// Gets or Sets 显示/测量单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// Gets or Sets 输入信号
        /// </summary>
        public string InputSignal { get; set; }
        /// <summary>
        /// Gets or Sets 输出信号
        /// </summary>
        public string OutputSignal { get; set; }
        /// <summary>
        /// Gets or Sets 电源
        /// </summary>
        public string PowerSupply { get; set; }
        /// <summary>
        /// Gets or Sets 规格栏第1行
        /// </summary>
        public string Spec1 { get; set; }
        /// <summary>
        /// Gets or Sets 规格栏第2行
        /// </summary>
        public string Spec2 { get; set; }
        /// <summary>
        /// Gets or Sets 规格栏第3行
        /// </summary>
        public string Spec3 { get; set; }
        /// <summary>
        /// Gets 规格
        /// </summary>
        public string Specification { get { return Spec1 + Spec2 + Spec3; } }
        /// <summary>
        /// Gets or Sets 制造厂或供货商
        /// </summary>
        public string Manufacturer { get; set; }
        /// <summary>
        /// Gets or Sets 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// Gets or Sets 安装地点 -- e.g. 就地
        /// </summary>
        public string FixedPlace { get; set; }
        /// <summary>
        /// Gets or Sets 安装区域
        /// </summary>
        public string Area { get; set; }
        /// <summary>
        /// Gets or Sets 
        /// </summary>
        public string PlateName { get; set; }
        /// <summary>
        /// Gets or Sets 设备安装图
        /// </summary>
        public string InstDrawing { get; set; }
        /// <summary>
        /// Gets or Sets 管路连接图
        /// </summary>
        public string HookupDrawing { get; set; }
        /// <summary>
        /// Gets or Sets 是否非设备
        /// </summary>
        public bool IsEquipment { get; set; }
        /// <summary>
        /// Gets or Sets 是否UPS供电
        /// </summary>
        public bool IsPoweredByUPS { get; set; }
        /// <summary>
        /// Gets or Sets 
        /// </summary>
        public Int32 PowerSupplyCurrent { get; set; }
        /// <summary>
        /// Gets or Sets 
        /// </summary>
        public string PowerSupplySource { get; set; }

        #endregion // 成员属性

        /// <summary>
        /// 构造函数, 初始化成员属性为默认值
        /// </summary>
        public Equipment()
        {
            TagNo = "";
            LoopNo = "";
            Name = "";
            EqpType = "";
            Quantity = 0;
            LowerLimit = "";
            UpperLimit = "";
            Unit = "";
            InputSignal = "";
            OutputSignal = "";
            PowerSupply = "";
            Spec1 = "";
            Spec2 = "";
            Spec3 = "";
            Manufacturer = "";
            Remark = "";
            FixedPlace = "";
            Area = "";
            PlateName = "";
            InstDrawing = "";
            HookupDrawing = "";
            IsEquipment = true;
            IsPoweredByUPS = false;
            PowerSupplyCurrent = 0;
            PowerSupplySource = "";
        }

        #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public Equipment Copy()
        {
            return MemberwiseClone() as Equipment;
        }

        #endregion // Copy
    }

    public class EquipmentCollection : List<Equipment>
    {
        public EquipmentCollection()
        {
        }

        #region .Key Index.

        public Equipment this[string tagNo]
        {
            get
            {
                if (this.Count > 0) {
                    for (int i = 0; i < this.Count; i++) {
                        if (this[i].TagNo == tagNo)
                            return (Equipment)this[i];
                    }
                    return null;
                } else
                    return null;
            }
            set
            {
                if (this.Count > 0) {
                    for (int i = 0; i < this.Count; i++) {
                        if (this[i].TagNo == tagNo) {
                            this[i] = value;
                            break;
                        }
                    }
                } else
                    throw new System.ArgumentOutOfRangeException("Equipment Index", "No Equipment with this Tag Number can be found");
            }
        }

        #endregion // Key Index

        #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public EquipmentCollection Copy()
        {
            EquipmentCollection equipments = new EquipmentCollection();

            if (this.Count <= 0)
                return equipments;
            else {
                foreach (Equipment equipment in this)
                    equipments.Add(equipment.Copy());
                return equipments;
            }
        }

        #endregion // Copy

        #region .Comparer.

        public static int Comparer(Equipment x, Equipment y)
        {
            if (x.TagNo == null) {
                if (y.TagNo == null) {
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
                if (y.TagNo == null)
                // ...and y.TagNo is null, x.TagNo is greater.
                {
                    return 1;
                } else {
                    return string.Compare(x.TagNo, y.TagNo /*, true, System.Globalization.CultureInfo.InstalledUICulture*/);
                }
            }
        }

        #endregion // Comparer

        #region .Sort.

        public void Sort()
        {
            if (this.Count > 0)
                base.Sort(EquipmentCollection.Comparer);
        }

        #endregion
    }
}
