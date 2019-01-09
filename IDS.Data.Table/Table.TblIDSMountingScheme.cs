using System;
using System.Collections.Generic;
using System.Text;

namespace IDS.Data.Table
{
    /// <summary>
    /// 安装方案表 -- 表名和各列名称
    /// </summary>
    public class TblIDSMountingScheme
    {
        #region .私有变量.

        private static string _tblName = "安装方案表";

        private static string _ID = "ID";
        private static string _parentID = "父ID";
        private static string _mountingSchemeID = "名称";
        private static string _mountingType = "类型";
        private static string _usage = "用途";
        private static string _fileName = "文件名";
        private static string _tubeRepositoryID = "导管库序号";
        private static string _remark = "备注";
        private static string _protectionEnabled = "修改保护";

        #endregion

        #region .公共属性.

        /// <summary>
        /// Gets 安装方案表 -- 表名
        /// </summary>
        public static string TblName { get { return _tblName; } }


        /// <summary>
        /// Gets ID
        /// </summary>
        public static string ID { get { return _ID; } }

        /// <summary>
        /// Gets 父ID ------ 对应子设备表的"ID"
        /// </summary>
        public static string ParentID { get { return _parentID; } }

        /// <summary>
        /// Gets 名称. e.g. HK-LQ16H, PE-GM64GN 等
        /// </summary>
        public static string MountingSchemeID { get { return _mountingSchemeID; } }

        /// <summary>
        /// Gets 类型. e.g. 导管连接, 设备安装 等
        /// </summary>
        public static string MountingType { get { return _mountingType; } }

        /// <summary>
        /// Gets 用途
        /// </summary>
        public static string Usage { get { return _usage; } }

        /// <summary>
        /// Gets 文件名
        /// </summary>
        public static string FileName { get { return _fileName; } }

        /// <summary>
        /// Gets 导管库序号 - 对应库设备表的"库序号"
        /// </summary>
        public static string TubeRepositoryID { get { return _tubeRepositoryID; } }

        /// <summary>
        /// Gets 备注
        /// </summary>
        public static string Remark { get { return _remark; } }

        /// <summary>
        /// Gets 修改保护
        /// </summary>
        public static string ProtectionEnabled { get { return _protectionEnabled; } }
        
        #endregion
    }
}
