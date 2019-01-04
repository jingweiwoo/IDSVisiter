using System;
using System.Collections.Generic;
// using System.Linq;
using System.Text;

namespace AppConfig
{
    public class DatabaseConfig
    {
        private static object lockHelper = new object();
        private static DatabaseConfigInfo _databaseConfigInfo = null;

        public static DatabaseConfigInfo Info { get { return _databaseConfigInfo; } }

        /// <summary>
        /// 数据库连接串
        /// </summary>
        public static string ConnectionString { get { return Info.ConnectionString; } }

        /// <summary>
        /// 表前缀
        /// </summary>
        public static string TablePrefix { get { return Info.TablePrefix; } }

        /// <summary>
        /// 数据库类型
        /// </summary>
        public static string DbType { get { return Info.DbType; } }
    }
}
