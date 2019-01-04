using System;
using System.Collections.Generic;
// using System.Linq;
using System.Text;

using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Flute.Data
{
    public class SqlServerProvider : IDbProvider
    {
        bool _isFullTextSearchEnabled = true;
        bool _isCompactDatabase = true;
        bool _isBackupDatabase = true;
        bool _isDbOptimize = false;
        bool _isShrinkData = true;
        bool _isStoreProc = true;

        public DbProviderFactory Instance { get { return SqlClientFactory.Instance; } }

        public bool IsFullTextSearchEnabled { get { return _isFullTextSearchEnabled; } }
        public bool IsCompactDatabase { get { return _isCompactDatabase; } }
        public bool IsBackupDatabase { get { return _isBackupDatabase; } }
        public bool IsDbOptimize { get { return _isDbOptimize; } }
        public bool IsShrinkData { get { return _isShrinkData; } }
        public bool IsStoreProc { get { return _isStoreProc; } }


        public void DeriveParameters(IDbCommand cmd)
        {
            if ((cmd as SqlCommand) != null) {
                SqlCommandBuilder.DeriveParameters(cmd as SqlCommand);
            }
        }

        public DbParameter MakeParameters(string ParamName, DbType DbType, Int32 Size)
        {
            SqlParameter param;

            if (Size > 0)
                param = new SqlParameter(ParamName, (SqlDbType)DbType, Size);
            else
                param = new SqlParameter(ParamName, (SqlDbType)DbType);

            return param;
        }

        public string GetLastIdSql() { return "SELECT SCOPE_IDENTITY()"; }
    }
}
