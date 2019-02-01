using System;
using System.Collections.Generic;
using System.Text;

namespace IDS.Data.Table
{
    public class TblDesignInfo
    {
        #region .私有变量.

        private static string _tblName = "设计信息表";

        private static string _projectName = "工程名称";
        private static string _projectID = "项目编码";
        private static string _drawingID = "图号";
        private static string _designPhase = "设计阶段";
        private static string _speciality = "专业";
        private static string _designedBy = "设计人";
        private static string _revisionVersion = "修改版次";
        private static string _date = "设计日期";

        private static string _checkedBy = "审核人";
        private static string _approvedBy = "室审人";

        private static string _appendDrawingID = "附加图号";
        private static string _appendDrawingIDNumber = "附加图号位数";

        #endregion

        #region .公共属性.

        /// <summary>
        /// Gets 设计信息表 -- 表名
        /// </summary>
        public static string TblName { get { return _tblName; } }


        /// <summary>
        /// Gets 工程名称
        /// </summary>
        public static string ProjectName { get { return _projectName; } }

        /// <summary>
        /// Gets 项目编码
        /// </summary>
        public static string ProjectID { get { return _projectID; } }

        /// <summary>
        /// Gets 图号
        /// </summary>
        public static string DrawingID { get { return _drawingID; } }

        /// <summary>
        /// Gets 设计阶段
        /// </summary>
        public static string DesignPhase { get { return _designPhase; } }

        /// <summary>
        /// Gets 专业
        /// </summary>
        public static string Speciality { get { return _speciality; } }

        /// <summary>
        /// Gets 设计人
        /// </summary>
        public static string DesignedBy { get { return _designedBy; } }

        /// <summary>
        /// Gets 修改版次
        /// </summary>
        public static string RevisionVersion { get { return _revisionVersion; } }

        /// <summary>
        /// Gets 设计日期
        /// </summary>
        public static string Date { get { return _date; } }

        /// <summary>
        /// Gets 审核人
        /// </summary>
        public static string CheckedBy { get { return _checkedBy; } }

        /// <summary>
        /// Gets 室审人
        /// </summary>
        public static string ApprovedBy { get { return _approvedBy; } }

        /// <summary>
        /// Gets 附加图号
        /// </summary>
        public static string AppendDrawingID { get { return _appendDrawingID; } }

        /// <summary>
        /// Gets 附加图号位数
        /// </summary>
        public static string AppendDrawingIDNumber { get { return _appendDrawingIDNumber; } }
        
        #endregion
    }
}
