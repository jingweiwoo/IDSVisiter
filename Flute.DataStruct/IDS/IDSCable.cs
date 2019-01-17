using System;
using System.Collections.Generic;
using System.Text;

namespace Flute.DataStruct.IDS
{
    public class IDSCable
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
        /// Gets or Sets 位号
        /// </summary>
        public string Tag { get; set; }
        /// <summary>
        /// Gets or Sets 类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Gets or Sets 序号
        /// </summary>
        public string SerialNumber { get; set; }
        /// <summary>
        /// Gets or Sets 终点设备位号
        /// </summary>
        public string DestinationEquipmentTag { get; set; }
        /// <summary>
        /// Gets or Sets 电缆长度
        /// </summary>
        public float CableLength { get; set; }
        /// <summary>
        /// Gets or Sets 备用芯数量
        /// </summary>
        public Int32 SpareCoreNumber { get; set; }
        /// <summary>
        /// Gets or Sets 保护管长度
        /// </summary>
        public float TubeLength { get; set; }
        /// <summary>
        /// Gets or Sets 电缆规格
        /// </summary>
        public Int32 CableSpecification { get; set; }
        /// <summary>
        /// Gets or Sets 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// Gets or Sets 产生方式
        /// </summary>
        public string WayToGenerate { get; set; }


        private IDSRepository _cableRepository = null;
        /// <summary>
        /// Gets or Sets 电缆库信息
        /// </summary>
        public IDSRepository CableRepository
        {
            get { return _cableRepository; }
            set { _cableRepository = value; }
        }

        private IDSRepository _tubeRepository = null;
        /// <summary>
        /// Gets or Sets 电缆库信息
        /// </summary>
        public IDSRepository TubeRepository
        {
            get { return _tubeRepository; }
            set { _tubeRepository = value; }
        }

        #endregion // 成员属性

        /// <summary>
        /// 构造函数, 初始化成员属性为默认值
        /// </summary>
        public IDSCable()
        {
            ID = "";
            ParentID = "";
            Tag = "";
            Type = "";
            SerialNumber = "";
            DestinationEquipmentTag = "";
            CableLength = 0.0f;
            SpareCoreNumber = 0;
            TubeLength = 0;
            CableSpecification = 0;
            Remark = "";
            WayToGenerate = "";

            CableRepository = new IDSRepository();
            TubeRepository = new IDSRepository();
        }

         #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public IDSCable Copy()
        {
            IDSCable idsCable = MemberwiseClone() as IDSCable;
            idsCable.CableRepository = this.CableRepository.Copy();
            idsCable.TubeRepository = this.TubeRepository.Copy();
            return idsCable;
        }

        #endregion // Copy
    }

    public class IDSCableCollection : List<IDSCable>
    {
        public IDSCableCollection()
        {
        }

        #region .Key Index.

        public IDSCable this[string tag]
        {
            get
            {
                if (this.Count > 0)
                {
                    for (int i = 0; i < this.Count; i++)
                    {
                        if (this[i].Tag == tag)
                            return (IDSCable)this[i];
                    }
                    return null;
                }
                else
                    return null;
            }
            set
            {
                if (this.Count > 0)
                {
                    for (int i = 0; i < this.Count; i++)
                    {
                        if (this[i].Tag == tag)
                        {
                            this[i] = value;
                            break;
                        }
                    }
                }
                else
                    throw new System.ArgumentOutOfRangeException("IDS Cable Index", "No Cable with this Tag can be found");
            }
        }

        #endregion // Key Index

        #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public IDSCableCollection Copy()
        {
            IDSCableCollection cables = new IDSCableCollection();

            if (this.Count <= 0)
                return cables;
            else
            {
                foreach (IDSCable cable in this)
                    cables.Add(cable.Copy());
                return cables;
            }
        }

        #endregion // Copy

        #region .Comparer.

        public static int Comparer(IDSCable x, IDSCable y)
        {
            if (x.Tag == null)
            {
                if (y.Tag == null)
                {
                    // If x.Tag is null and y.Tag is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x.Tag is null and y.Tag is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                // If x.Tag is not null...
                //
                if (y.Tag == null)
                // ...and y.Tag is null, x.Tag is greater.
                {
                    return 1;
                }
                else
                {
                    return string.Compare(x.Tag, y.Tag /*, true, System.Globalization.CultureInfo.InstalledUICulture*/);
                }
            }
        }

        #endregion // Comparer

        #region .Sort.

        public void Sort()
        {
            base.Sort(IDSCableCollection.Comparer);
        }

        #endregion
    }
}
