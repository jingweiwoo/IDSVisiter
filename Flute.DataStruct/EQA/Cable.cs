using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Flute.DataStruct.EQA
{
    public class Cable
    {
        #region .成员属性.

        /// <summary>
        /// Gets or Sets 子系统号
        /// </summary>
        public string SubSystemID { get; set; }

        /// <summary>
        /// Gets or Sets 电缆编号
        /// </summary>
        public string CableNo { get; set; }

        /// <summary>
        /// Gets or Sets 电缆起点
        /// </summary>
        public string StartPosition { get; set; }

        /// <summary>
        /// Gets or Sets 电缆终点
        /// </summary>
        public string EndPosition { get; set; }

        /// <summary>
        /// Gets or Sets 备用芯
        /// </summary>
        public Int32 SpareCableCore { get; set; }

        /// <summary>
        /// Gets or Sets 电缆长度
        /// </summary>
        public Int32 CableLength { get; set; }

        /// <summary>
        /// Gets or Sets 保护管长度
        /// </summary>
        public Int32 ConductLength { get; set; }

        /// <summary>
        /// Gets or Sets 电缆规格
        /// </summary>
        public string CableSpec { get; set; }

        /// <summary>
        /// Gets or Sets 保护管规格
        /// </summary>
        public string ConductSpec { get; set; }

        /// <summary>
        /// Gets or Sets 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// Gets or Sets 电缆路径
        /// </summary>
        public string Route { get; set; }

        #endregion //成员属性

        public Cable()
        {
            SubSystemID = "";
            CableNo = "";
            StartPosition = "";
            EndPosition = "";
            SpareCableCore = 0;
            CableLength = 0;
            ConductLength = 0;
            CableSpec = "";
            ConductSpec = "";
            Remark = "";
            Route = "";
        }

        #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public Cable Copy()
        {
            Cable cable = MemberwiseClone() as Cable;
            return cable;
        }

        #endregion // Clone Members
    }

    public class CableCollection : List<Cable>
    {
        public CableCollection()
        {
        }

        #region .Key Index.

        public Cable this[string cableNo]
        {
            get
            {
                if (this.Count > 0)
                {
                    for (int i = 0; i < this.Count; i++)
                    {
                        if (this[i].CableNo == cableNo)
                            return (Cable)this[i];
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
                        if (this[i].CableNo == cableNo)
                        {
                            this[i] = value;
                            break;
                        }
                    }
                }
                else
                    throw new System.ArgumentOutOfRangeException("Cable Index", "No Cable with this Cable Number can be found");
            }
        }

        #endregion // Key Index

        #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public CableCollection Copy()
        {
            CableCollection cables = new CableCollection();

            if (this.Count <= 0)
                return cables;
            else
            {
                foreach (Cable cable in this)
                    cables.Add(cable.Copy());
                return cables;
            }
        }

        #endregion // Copy

        #region .Comparer.

        public static int Comparer(Cable x, Cable y)
        {
            if (x.CableNo == null)
            {
                if (y.CableNo == null)
                {
                    // If x.LoopNo is null and y.LoopNo is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x.LoopNo is null and y.LoopNo is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                // If x.LoopNo is not null...
                //
                if (y.CableNo == null)
                // ...and y.LoopNo is null, x.LoopNo is greater.
                {
                    return 1;
                }
                else
                {
                    return string.Compare(x.CableNo, y.CableNo /*, true, System.Globalization.CultureInfo.InstalledUICulture*/);
                }
            }
        }

        #endregion // Comparer

        #region .Sort.

        public void Sort()
        {
            if (this.Count > 0)
                base.Sort(CableCollection.Comparer);
        }

        #endregion // Sort
    }
}
