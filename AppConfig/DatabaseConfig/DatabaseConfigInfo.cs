using System;
using System.Collections.Generic;
// using System.Linq;
using System.Text;

namespace AppConfig
{
    [Serializable]
    public class DatabaseConfigInfo : IConfigInfo
    {
        #region .私有字段.

        private string _connectionString = "";	// 数据库连接串-格式(中文为用户修改的内容)：Data Source=数据库服务器地址;User ID=您的数据库用户名;Password=您的数据库用户密码;Initial Catalog=数据库名称;Pooling=true
        private string _tablePrefix = "";		// 数据库中表的前缀
        private string _dbType = "";

        #endregion

        #region .属性.

        /// <summary>
        /// 数据库连接串
        /// 格式(中文为用户修改的内容)：
        ///    Data Source=数据库服务器地址;
        ///    User ID=您的数据库用户名;
        ///    Password=您的数据库用户密码;
        ///    Initial Catalog=数据库名称;Pooling=true
        /// </summary>
        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        /// <summary>
        /// 数据库中表的前缀
        /// </summary>
        public string TablePrefix
        {
            get { return _tablePrefix; }
            set { _tablePrefix = value; }
        }        

        /// <summary>
        /// 数据库类型
        /// </summary>
        public string DbType
        {
            get { return _dbType; }
            set { _dbType = value; }
        }

        #endregion

    }
}
