using System;
using System.Collections.Generic;
using System.Text;

namespace IDS.Data.Table
{
    public class TblIDSCable
    {
        #region .私有变量.

        private static string _tblName = "盘箱柜设备表";

        private static string _ID = "ID";
        private static string _parentID = "父ID";
        private static string _type = "类型";
        private static string _serialNumber = "序号";
        private static string _cableTag = "电缆号_Ori";
        private static string _destinationEquipmentTag = "终点位号_Ori";
        private static string _cableRepositoryID = "电缆库序号";
        private static string _cableLength = "电缆长度";
        private static string _spareCoreNumber = "备用芯";
        private static string _tubeRepositoryID = "保护管库序号";
        private static string _tubeLength = "保护管长度";
        private static string _cableSpecification = "电缆规格";
        private static string _remark = "备注";
        private static string _wayToGenerate = "产生方式";

        #endregion

        #region .公共属性.

        /// <summary>
        /// Gets 电缆表 -- 表名
        /// </summary>
        public static string TblName { get { return _tblName; } }


        /// <summary>
        /// Gets ID
        /// </summary>
        public static string ID { get { return _ID; } }

        /// <summary>
        /// Gets 父ID ------ 分别对应设备表和盘箱柜表的"ID"
        /// </summary>
        public static string ParentID { get { return _parentID; } }

        /// <summary>
        /// Gets 类型. e.g. 子设备, 盘箱柜 等
        /// </summary>
        public static string Type { get { return _type; } }

        /// <summary>
        /// Gets 序号
        /// </summary>
        public static string SerialNumber { get { return _serialNumber; } }

        /// <summary>
        /// Gets 电缆号. e.g. W-09.TE-6204
        /// </summary>
        public static string CableTag { get { return _cableTag; } }

        /// <summary>
        /// Gets 终点位号
        /// </summary>
        public static string DestinationEquipmentTag { get { return _destinationEquipmentTag; } }

        /// <summary>
        /// Gets 电缆库序号. 在库设备中定义
        /// </summary>
        public static string CableRepositoryID { get { return _cableRepositoryID; } }

        /// <summary>
        /// Gets 电缆长度.
        /// </summary>
        public static string CableLength { get { return _cableLength; } }

        /// <summary>
        /// Gets 备用芯.
        /// </summary>
        public static string SpareCoreNumber { get { return _spareCoreNumber; } }

        /// <summary>
        /// Gets 保护管库序号. 在库设备中定义
        /// </summary>
        public static string TubeRepositoryID { get { return _tubeRepositoryID; } }

        /// <summary>
        /// Gets 保护管长度
        /// </summary>
        public static string TubeLength { get { return _tubeLength; } }

        /// <summary>
        /// Gets 电缆规格
        /// </summary>
        public static string CableSpecification { get { return _cableSpecification; } }

        /// <summary>
        /// Gets 备注
        /// </summary>
        public static string Remark { get { return _remark; } }

        /// <summary>
        /// Gets 产生方式
        /// </summary>
        public static string WayToGenerate { get { return _wayToGenerate; } }

        #endregion
    }
}
