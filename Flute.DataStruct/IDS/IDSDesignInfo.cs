using System;
using System.Collections.Generic;
using System.Text;

namespace Flute.DataStruct.IDS
{
    public class IDSDesignInfo
    {
        #region .成员属性.

        /// <summary>
        /// Gets or Sets 工程名称
        /// </summary>
        public string ProjectName { get; set; }
        /// <summary>
        /// Gets or Sets 项目编码
        /// </summary>
        public string ProjectID { get; set; }
        /// <summary>
        /// Gets or Sets 图号
        /// </summary>
        public string DrawingID { get; set; }
        /// <summary>
        /// Gets or Sets 设计阶段
        /// </summary>
        public string DesignPhase { get; set; }
        /// <summary>
        /// Gets or Sets 专业
        /// </summary>
        public string Speciality { get; set; }
        /// <summary>
        /// Gets or Sets 设计人
        /// </summary>
        public string DesignedBy { get; set; }
        /// <summary>
        /// Gets or Sets 修改版次
        /// </summary>
        public string RevisionVersion { get; set; }
        /// <summary>
        /// Gets or Sets 设计日期
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// Gets or Sets 审核人
        /// </summary>
        public string CheckedBy { get; set; }
        /// <summary>
        /// Gets or Sets 室审人
        /// </summary>
        public string ApprovedBy { get; set; }
        /// <summary>
        /// Gets or Sets 附加图号
        /// </summary>
        public string AppendDrawingID { get; set; }
        /// <summary>
        /// Gets or Sets 附加图号位数
        /// </summary>
        public Int32 AppendDrawingIDNumber { get; set; }

        #endregion // 成员属性

        /// <summary>
        /// 构造函数, 初始化成员属性为默认值
        /// </summary>
        public IDSDesignInfo()
        {
            ProjectName = "";
            ProjectID = "";
            DrawingID = "";
            DesignPhase = "";
            Speciality = "";
            DesignedBy = "";
            RevisionVersion = "";
            Date = "";
            CheckedBy = "";
            ApprovedBy = "";
            AppendDrawingID = "";
            AppendDrawingIDNumber = 0;
        }

         #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public IDSDesignInfo Copy()
        {
            return MemberwiseClone() as IDSDesignInfo;
        }

        #endregion // Copy
    }
}
