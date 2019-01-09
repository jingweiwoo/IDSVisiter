using System;
using System.Collections.Generic;
using System.Text;

namespace IDS.Data.Table
{
    #region .回路表 -- Loop.

    /// <summary>
    /// 回路表 -- 表名和各列名称
    /// </summary>
    public class TblIDSProcessLoop
    {
        #region .私有变量.

        private static string _tblName = "回路表";

        private static string _ID = "ID";
        private static string _parentID = "父ID";
        private static string _loopType = "对象";
        private static string _serialNumber = "序号";
        private static string _suffix = "后缀";
        private static string _location = "短位置";
        private static string _medium = "介质";
        private static string _parameter = "参数";
        private static string _normalTemperature = "操作温度";
        private static string _uplimitTemperature = "最高温度";
        private static string _normalPressure = "操作压力";
        private static string _uplimitPressure = "最高压力";
        private static string _pressureUnit = "压力单位";
        private static string _pipeMaterial = "管道材质";
        private static string _DN = "公称通径";
        private static string _containerMaterial = "容器材质";
        private static string _hasInnerLining = "有无内衬";
        private static string _ambientTemperature = "环境温度";
        private static string _ambientExLevel = "环境防爆等级";
        private static string _mediumExLevel = "介质防爆等级";
        private static string _measurementRange = "测量范围";
        private static string _processRange = "工艺参数";
        private static string _unit = "单位";
        private static string _function = "功能";
        private static string _description = "详细说明";
        private static string _source = "来源";

        #endregion
        
        #region .公共属性.

        /// <summary>
        /// Gets 回路表 -- 表名
        /// </summary>
        public static string TblName { get { return _tblName; } }


        /// <summary>
        /// Gets ID
        /// </summary>
        public static string ID { get { return _ID; } }

        /// <summary>
        /// Gets 父ID ------ 对应分组表的"ID"
        /// </summary>
        public static string ParentID { get { return _parentID; } }

        /// <summary>
        /// Gets 对象. e.g. A, F, P, T
        /// </summary>
        public static string LoopType { get { return _loopType; } }

        /// <summary>
        /// Gets 序号
        /// </summary>
        public static string SerialNumber { get { return _serialNumber; } }

        /// <summary>
        /// Gets 后缀
        /// </summary>
        public static string Suffix { get { return _suffix; } }

        /// <summary>
        /// Gets 短位置. e.g. 焦炉煤气总管
        /// </summary>
        public static string Location { get { return _location; } }

        /// <summary>
        /// Gets 介质
        /// </summary>
        public static string Medium { get { return _medium; } }

        /// <summary>
        /// Gets 参数. e.g. 流量, 压力
        /// </summary>
        public static string Parameter { get { return _parameter; } }

        /// <summary>
        /// Gets 操作温度
        /// </summary>
        public static string NormalTemperature { get { return _normalTemperature; } }

        /// <summary>
        /// Gets 最高温度
        /// </summary>
        public static string UplimitTemperature { get { return _uplimitTemperature; } }

        /// <summary>
        /// Gets 操作压力
        /// </summary>
        public static string NormalPressure { get { return _normalPressure; } }

        /// <summary>
        /// Gets 最高压力
        /// </summary>
        public static string UplimitPressure { get { return _uplimitPressure; } }

        /// <summary>
        /// Gets 压力单位
        /// </summary>
        public static string PressureUnit { get { return _pressureUnit; } }

        /// <summary>
        /// Gets 管道材质
        /// </summary>
        public static string PipeMaterial { get { return _pipeMaterial; } }

        /// <summary>
        /// Gets 公称通径
        /// </summary>
        public static string DN { get { return _DN; } }

        /// <summary>
        /// Gets 容器材质
        /// </summary>
        public static string ContainerMaterial { get { return _containerMaterial; } }

        /// <summary>
        /// Gets 有无内衬
        /// </summary>
        public static string HasInnerLining { get { return _hasInnerLining; } }

        /// <summary>
        /// Gets 环境温度
        /// </summary>
        public static string AmbientTemperature { get { return _ambientTemperature; } }

        /// <summary>
        /// Gets 环境防爆等级
        /// </summary>
        public static string AmbientExLevel { get { return _ambientExLevel; } }

        /// <summary>
        /// Gets 介质防爆等级
        /// </summary>
        public static string MediumExLevel { get { return _mediumExLevel; } }

        /// <summary>
        /// Gets 测量范围
        /// </summary>
        public static string MeasurementRange { get { return _measurementRange; } }

        /// <summary>
        /// Gets 工艺参数. means 工艺参数范围
        /// </summary>
        public static string ProcessRange { get { return _processRange; } }

        /// <summary>
        /// Gets 单位
        /// </summary>
        public static string Unit { get { return _unit; } }

        /// <summary>
        /// Gets 功能
        /// </summary>
        public static string Function { get { return _function; } }

        /// <summary>
        /// Gets 详细说明
        /// </summary>
        public static string Description { get { return _description; } }

        /// <summary>
        /// Gets 来源
        /// </summary>
        public static string Source { get { return _source; } }

        #endregion
     }

    #endregion
}
