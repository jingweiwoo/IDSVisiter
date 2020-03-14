using System;
using System.Collections.Generic;
using System.Text;

namespace Flute.DataStruct.IDS
{
    public class IDSEquipingLocation
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

        /// <summary>
        /// Gets or Sets 类型. e.g. 网络柜, PLC柜 等
        /// </summary>
        public string CabinetType { get; set; }

        /// <summary>
        /// Gets or Sets 序号
        /// </summary>
        public string SerialNumber { get; set; }
        /// <summary>
        /// Gets 安装位置代码
        /// </summary>
        public string CabinetCode {
            get {
                if (CabinetType == null || SerialNumber == null)
                    return null;

                return CabinetType + SerialNumber;
            }
        }

        /// <summary>
        /// Gets or Sets 说明
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets 区域. 即高层代号. 比如热风炉为09.
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// Gets or Sets 子区域
        /// </summary>
        public string SubArea { get; set; }

        /// <summary>
        /// Gets or Sets 位置代号. 即盘柜的位号
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// Gets or Sets 单元
        /// </summary>
        public string CabinetUnit { get; set; }

        /// <summary>
        /// Gets or Sets 单元高度
        /// </summary>
        public string CabinetUnitHeight { get; set; }

        /// <summary>
        /// Gets or Sets 名称. e.g. 仪表供电柜, 接地箱 等
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets 型号
        /// </summary>
        public string ModelNumber { get; set; }

        /// <summary>
        /// Gets or Sets 外形尺寸
        /// </summary>
        public string Dimension { get; set; }

        /// <summary>
        /// Gets or Sets 颜色
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Gets or Sets 开门方向. e.g. 前后开门,左右封闭, 前开门,左右封闭 等
        /// </summary>
        public string OpenType { get; set; }

        /// <summary>
        /// Gets or Sets 备注
        /// </summary>
        public string Remark { get; set; }

        #endregion

        private IDSEquipingLocation()
            : this(null)
        {
        }

        public IDSEquipingLocation(IDSSubLoop subLoop)
        {
            ID = "";
            ParentID = "";
            _subLoop = subLoop;
            CabinetType = "";
            SerialNumber = "";
            Description = "";
            Area = "";
            SubArea = "";
            Tag = "";
            CabinetUnit = "";
            CabinetUnitHeight = "";
            Name = "";
            ModelNumber = "";
            Dimension = "";
            Color = "";
            OpenType = "";
            Remark = "";
        }

        #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public IDSEquipingLocation Copy()
        {
            IDSEquipingLocation equipingLocation = MemberwiseClone() as IDSEquipingLocation;
            return equipingLocation;
        }

        #endregion // Copy
    }

    public class IDSEquipingLocationCollection : List<IDSEquipingLocation>
    {
        public IDSEquipingLocationCollection()
        {
        }

        #region .Key Index.

        public IDSEquipingLocation this[string cabinetCode]
        {
            get
            {
                if (this.Count > 0) {
                    for (int i = 0; i < this.Count; i++) {
                        if (this[i].CabinetCode == cabinetCode)
                            return (IDSEquipingLocation)this[i];
                    }
                    return null;
                } else
                    return null;
            }
            set
            {
                if (this.Count > 0) {
                    for (int i = 0; i < this.Count; i++) {
                        if (this[i].CabinetCode == cabinetCode) {
                            this[i] = value;
                            break;
                        }
                    }
                } else
                    throw new System.ArgumentOutOfRangeException("IDS Equiping Location Index", "No Equiping Location with this Tag can be found");
            }
        }

        #endregion // Key Index

        #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public IDSEquipingLocationCollection Copy()
        {
            IDSEquipingLocationCollection equipingLocations = new IDSEquipingLocationCollection();

            if (this.Count <= 0)
                return equipingLocations;
            else {
                foreach (IDSEquipingLocation equipingLocation  in this)
                    equipingLocations.Add(equipingLocation.Copy());
                return equipingLocations;
            }
        }

        #endregion // Copy

        #region .Comparer.

        public static int Comparer(IDSEquipingLocation x, IDSEquipingLocation y)
        {
            if (x.CabinetCode == null) {
                if (y.CabinetCode == null) {
                    // If x.CabinetCode is null and y.CabinetCode is null, they're
                    // equal. 
                    return 0;
                } else {
                    // If x.CabinetCode is null and y.CabinetCode is not null, y
                    // is greater. 
                    return -1;
                }
            } else {
                // If x.CabinetCode is not null...
                //
                if (y.CabinetCode == null)
                // ...and y.CabinetCode is null, x.CabinetCode is greater.
                {
                    return 1;
                } else {
                    return string.Compare(x.CabinetCode, y.CabinetCode /*, true, System.Globalization.CultureInfo.InstalledUICulture*/);
                }
            }
        }

        #endregion // Comparer

        #region .Sort.

        public new void Sort()
        {
            base.Sort(IDSEquipingLocationCollection.Comparer);
        }

        #endregion
    }
}