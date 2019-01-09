using System;
using System.Collections.Generic;
using System.Text;

namespace IDS.Data.Table
{
    public class TblIDSCabinetEquipment
    {
        #region .私有变量.

        private static string _tblName = "盘箱柜设备表";

        private static string _ID = "ID";
        private static string _parentID = "父ID";
        private static string _shortTag = "短位号";
        private static string _isTagContainsCabinetTag = "盘箱柜位号带入位号";
        private static string _equipmentCatagory = "设备类别";
        private static string _equipmentRepositoryID = "库序号";
        private static string _specificeInfo1 = "规格1";
        private static string _specificeInfo2 = "规格2";
        private static string _quantity = "数量";
        private static string _remark = "备注";
        private static string _isSuppliedWithCabinet = "随盘供货";

        #endregion

        #region .公共属性.

        /// <summary>
        /// Gets 盘箱柜设备表 -- 表名
        /// </summary>
        public static string TblName { get { return _tblName; } }


        /// <summary>
        /// Gets ID
        /// </summary>
        public static string ID { get { return _ID; } }

        /// <summary>
        /// Gets 父ID ------ 对应盘箱柜表的"ID"
        /// </summary>
        public static string ParentID { get { return _parentID; } }

        /// <summary>
        /// Gets 短位号. e.g. ES, X001 等
        /// </summary>
        public static string ShortTag { get { return _shortTag; } }

        /// <summary>
        /// Gets 盘箱柜位号带入位号
        /// </summary>
        public static string IsTagContainsCabinetTag { get { return _isTagContainsCabinetTag; } }

        /// <summary>
        /// Gets 设备类型. e.g. Y, ES, TG端子 等, 在库设备中定义
        /// </summary>
        public static string EquipmentCatagory { get { return _equipmentCatagory; } }

        /// <summary>
        /// Gets 库序号
        /// </summary>
        public static string EquipmentRepositoryID { get { return _equipmentRepositoryID; } }

        /// <summary>
        /// Gets 规格1. 在库设备中定义
        /// </summary>
        public static string SpecificeInfo1 { get { return _specificeInfo1; } }

        /// <summary>
        /// Gets 规格2. 在库设备中定义
        /// </summary>
        public static string SpecificeInfo2 { get { return _specificeInfo2; } }

        /// <summary>
        /// Gets 数量
        /// </summary>
        public static string Quantity { get { return _quantity; } }

        /// <summary>
        /// Gets 备注
        /// </summary>
        public static string Remark { get { return _remark; } }

        /// <summary>
        /// Gets 随盘供货
        /// </summary>
        public static string IsSuppliedWithCabinet { get { return _isSuppliedWithCabinet; } }

        #endregion
    }
}
