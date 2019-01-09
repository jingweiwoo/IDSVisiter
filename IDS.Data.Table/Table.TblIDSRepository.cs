using System;
using System.Collections.Generic;
using System.Text;

namespace IDS.Data.Table
{
    public class TblIDSRepository
    {
        #region .私有变量.

        private static string _tblName = "库设备表";

        private static string _ID = "ID";
        private static string _parentID = "父ID";
        private static string _type = "子类型";
        private static string _RepositoryID = "库序号";
        private static string _version = "版本";
        private static string _attribute = "设备材料性质";
        private static string _name = "名称";
        private static string _usage = "用途";
        private static string _modelNumber = "型号";
        private static string _nameSuffix = "名称后缀选项";
        private static string _terminalDefinition = "端子";
        private static string _quantityUnit = "单位";
        private static string _notPrintOut = "不打印";
        private static string _text01 = "文本1";
        private static string _text02 = "文本2";
        private static string _text03 = "文本3";
        private static string _text04 = "文本4";
        private static string _text05 = "文本5";
        private static string _text06 = "文本6";
        private static string _text07 = "文本7";
        private static string _text08 = "文本8";
        private static string _text09 = "文本9";
        private static string _text10 = "文本10";
        private static string _text11 = "文本11";
        private static string _text12 = "文本12";
        private static string _text13 = "文本13";
        private static string _text14 = "文本14";
        private static string _text15 = "文本15";
        private static string _text16 = "文本16";
        private static string _text17 = "文本17";
        private static string _text18 = "文本18";
        private static string _text19 = "文本19";
        private static string _text20 = "文本20";
        private static string _text21 = "文本21";
        private static string _text22 = "文本22";
        private static string _text23 = "文本23";
        private static string _text24 = "文本24";
        private static string _text25 = "文本25";
        private static string _text26 = "文本26";
        private static string _text27 = "文本27";
        private static string _text28 = "文本28";
        private static string _remark01 = "备注1";
        private static string _remark02 = "备注2";
        private static string _remark03 = "备注3";
        private static string _value01 = "数值1";
        private static string _value02 = "数值2";
        private static string _value03 = "数值3";
        private static string _value04 = "数值4";
        private static string _value05 = "数值5";
        private static string _value06 = "数值6";
        private static string _value07 = "数值7";
        private static string _value08 = "数值8";
        private static string _value09 = "数值9";
        private static string _value10 = "数值10";
        private static string _value11 = "数值11";
        private static string _value12 = "数值12";
        private static string _value13 = "数值13";
        private static string _value14 = "数值14";
        private static string _value15 = "数值15";
        private static string _value16 = "数值16";
        private static string _value17 = "数值17";
        private static string _value18 = "数值18";
        private static string _value19 = "数值19";
        private static string _value20 = "数值20";
        private static string _value21 = "数值21";
        private static string _value22 = "数值22";
        private static string _value23 = "数值23";
        private static string _value24 = "数值24";
        private static string _value25 = "数值25";
        private static string _value26 = "数值26";
        private static string _value27 = "数值27";
        private static string _value28 = "数值28";
        private static string _yesOrNo01 = "是否01";
        private static string _yesOrNo02 = "是否02";
        private static string _yesOrNo03 = "是否03";
        private static string _yesOrNo04 = "是否04";
        private static string _yesOrNo05 = "是否05";
        private static string _protectionEnabled = "修改保护";

        #endregion

        #region .公共属性.

        /// <summary>
        /// Gets 库设备表 -- 表名
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
        /// Gets 子类型. e.g. 流量/节流装置, 常用/通用设备, 称重/称重传感器 等
        /// </summary>
        public static string Type { get { return _type; } }

        /// <summary>
        /// Gets 库序号
        /// </summary>
        public static string RepositoryID { get { return _RepositoryID; } }

        /// <summary>
        /// Gets 版本
        /// </summary>
        public static string Version { get { return _version; } }

        /// <summary>
        /// Gets 设备材料性质
        /// </summary>
        public static string Attribute { get { return _attribute; } }

        /// <summary>
        /// Gets 名称. e.g. 气动薄膜式套筒导向型单座调节阀, 速度传感器 等
        /// </summary>
        public static string Name { get { return _name; } }

        /// <summary>
        /// Gets 用途. e.g. 接线盒/3路传感器/无防爆, 输入/隔离/一入一出 等
        /// </summary>
        public static string Usage { get { return _usage; } }

        /// <summary>
        /// Gets 型号
        /// </summary>
        public static string ModelNumber { get { return _modelNumber; } }

        /// <summary>
        /// Gets 名称后缀选项
        /// </summary>
        public static string NameSuffix { get { return _nameSuffix; } }

        /// <summary>
        /// Gets 端子
        /// </summary>
        public static string TerminalDefinition { get { return _terminalDefinition; } }

        /// <summary>
        /// Gets 单位. e.g. 个, m, 片 等
        /// </summary>
        public static string QuantityUnit { get { return _quantityUnit; } }

        /// <summary>
        /// Gets 不打印
        /// </summary>
        public static string NotPrintOut { get { return _notPrintOut; } }

        /// <summary>
        /// Gets 文本1
        /// </summary>
        public static string Text01 { get { return _text01; } }

        /// <summary>
        /// Gets 文本2
        /// </summary>
        public static string Text02 { get { return _text02; } }

        /// <summary>
        /// Gets 文本3
        /// </summary>
        public static string Text03 { get { return _text03; } }

        /// <summary>
        /// Gets 文本4
        /// </summary>
        public static string Text04 { get { return _text04; } }

        /// <summary>
        /// Gets 文本5
        /// </summary>
        public static string Text05 { get { return _text05; } }

        /// <summary>
        /// Gets 文本6
        /// </summary>
        public static string Text06 { get { return _text06; } }

        /// <summary>
        /// Gets 文本7
        /// </summary>
        public static string Text07 { get { return _text07; } }

        /// <summary>
        /// Gets 文本8
        /// </summary>
        public static string Text08 { get { return _text08; } }

        /// <summary>
        /// Gets 文本9
        /// </summary>
        public static string Text09 { get { return _text09; } }

        /// <summary>
        /// Gets 文本10
        /// </summary>
        public static string Text10 { get { return _text10; } }

        /// <summary>
        /// Gets 文本11
        /// </summary>
        public static string Text11 { get { return _text11; } }

        /// <summary>
        /// Gets 文本12
        /// </summary>
        public static string Text12 { get { return _text12; } }

        /// <summary>
        /// Gets 文本13
        /// </summary>
        public static string Text13 { get { return _text13; } }

        /// <summary>
        /// Gets 文本14
        /// </summary>
        public static string Text14 { get { return _text14; } }

        /// <summary>
        /// Gets 文本15
        /// </summary>
        public static string Text15 { get { return _text15; } }

        /// <summary>
        /// Gets 文本16
        /// </summary>
        public static string Text16 { get { return _text16; } }

        /// <summary>
        /// Gets 文本17
        /// </summary>
        public static string Text17 { get { return _text17; } }

        /// <summary>
        /// Gets 文本18
        /// </summary>
        public static string Text18 { get { return _text18; } }

        /// <summary>
        /// Gets 文本19
        /// </summary>
        public static string Text19 { get { return _text19; } }

        /// <summary>
        /// Gets 文本20
        /// </summary>
        public static string Text20 { get { return _text20; } }

        /// <summary>
        /// Gets 文本21
        /// </summary>
        public static string Text21 { get { return _text21; } }

        /// <summary>
        /// Gets 文本22
        /// </summary>
        public static string Text22 { get { return _text22; } }

        /// <summary>
        /// Gets 文本23
        /// </summary>
        public static string Text23 { get { return _text23; } }

        /// <summary>
        /// Gets 文本24
        /// </summary>
        public static string Text24 { get { return _text24; } }

        /// <summary>
        /// Gets 文本25
        /// </summary>
        public static string Text25 { get { return _text25; } }

        /// <summary>
        /// Gets 文本26
        /// </summary>
        public static string Text26 { get { return _text26; } }

        /// <summary>
        /// Gets 文本27
        /// </summary>
        public static string Text27 { get { return _text27; } }

        /// <summary>
        /// Gets 文本28
        /// </summary>
        public static string Text28 { get { return _text28; } }

        /// <summary>
        /// Gets 备注1
        /// </summary>
        public static string Remark01 { get { return _remark01; } }

        /// <summary>
        /// Gets 备注2
        /// </summary>
        public static string Remark02 { get { return _remark02; } }

        /// <summary>
        /// Gets 备注3
        /// </summary>
        public static string Remark03 { get { return _remark03; } }

        /// <summary>
        /// Gets 数值1
        /// </summary>
        public static string Value01 { get { return _value01; } }

        /// <summary>
        /// Gets 数值2
        /// </summary>
        public static string Value02 { get { return _value02; } }

        /// <summary>
        /// Gets 数值3
        /// </summary>
        public static string Value03 { get { return _value03; } }

        /// <summary>
        /// Gets 数值4
        /// </summary>
        public static string Value04 { get { return _value04; } }

        /// <summary>
        /// Gets 数值5
        /// </summary>
        public static string Value05 { get { return _value05; } }

        /// <summary>
        /// Gets 数值6
        /// </summary>
        public static string Value06 { get { return _value06; } }

        /// <summary>
        /// Gets 数值7
        /// </summary>
        public static string Value07 { get { return _value07; } }

        /// <summary>
        /// Gets 数值8
        /// </summary>
        public static string Value08 { get { return _value08; } }

        /// <summary>
        /// Gets 数值9
        /// </summary>
        public static string Value09 { get { return _value09; } }

        /// <summary>
        /// Gets 数值10
        /// </summary>
        public static string Value10 { get { return _value10; } }

        /// <summary>
        /// Gets 数值11
        /// </summary>
        public static string Value11 { get { return _value11; } }

        /// <summary>
        /// Gets 数值12
        /// </summary>
        public static string Value12 { get { return _value12; } }

        /// <summary>
        /// Gets 数值13
        /// </summary>
        public static string Value13 { get { return _value13; } }

        /// <summary>
        /// Gets 数值14
        /// </summary>
        public static string Value14 { get { return _value14; } }

        /// <summary>
        /// Gets 数值15
        /// </summary>
        public static string Value15 { get { return _value15; } }

        /// <summary>
        /// Gets 数值16
        /// </summary>
        public static string Value16 { get { return _value16; } }

        /// <summary>
        /// Gets 数值17
        /// </summary>
        public static string Value17 { get { return _value17; } }

        /// <summary>
        /// Gets 数值18
        /// </summary>
        public static string Value18 { get { return _value18; } }

        /// <summary>
        /// Gets 数值19
        /// </summary>
        public static string Value19 { get { return _value19; } }

        /// <summary>
        /// Gets 数值20
        /// </summary>
        public static string Value20 { get { return _value20; } }

        /// <summary>
        /// Gets 数值21
        /// </summary>
        public static string Value21 { get { return _value21; } }

        /// <summary>
        /// Gets 数值22
        /// </summary>
        public static string Value22 { get { return _value22; } }

        /// <summary>
        /// Gets 数值23
        /// </summary>
        public static string Value23 { get { return _value23; } }

        /// <summary>
        /// Gets 数值24
        /// </summary>
        public static string Value24 { get { return _value24; } }

        /// <summary>
        /// Gets 数值25
        /// </summary>
        public static string Value25 { get { return _value25; } }

        /// <summary>
        /// Gets 数值26
        /// </summary>
        public static string Value26 { get { return _value26; } }

        /// <summary>
        /// Gets 数值27
        /// </summary>
        public static string Value27 { get { return _value27; } }

        /// <summary>
        /// Gets 数值28
        /// </summary>
        public static string Value28 { get { return _value28; } }

        /// <summary>
        /// Gets 是否01
        /// </summary>
        public static string YesOrNo01 { get { return _yesOrNo01; } }

        /// <summary>
        /// Gets 是否02
        /// </summary>
        public static string YesOrNo02 { get { return _yesOrNo02; } }

        /// <summary>
        /// Gets 是否03
        /// </summary>
        public static string YesOrNo03 { get { return _yesOrNo03; } }

        /// <summary>
        /// Gets 是否04
        /// </summary>
        public static string YesOrNo04 { get { return _yesOrNo04; } }

        /// <summary>
        /// Gets 是否05
        /// </summary>
        public static string YesOrNo05 { get { return _yesOrNo05; } }

        /// <summary>
        /// Gets 修改保护
        /// </summary>
        public static string ProtectionEnabled { get { return _protectionEnabled; } }

        #endregion
    }
}
