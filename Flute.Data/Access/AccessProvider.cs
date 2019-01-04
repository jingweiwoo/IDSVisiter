using System;
using System.Collections.Generic;
// using System.Linq;
using System.Text;

using System.Data;
using System.Data.Common;
using System.Data.OleDb;

namespace Flute.Data
{
    public class AccessProvider : IDbProvider
    {
        bool _isFullTextSearchEnabled = false;
        bool _isCompactDatabase = false;
        bool _isBackupDatabase = false;
        bool _isDbOptimize = false;
        bool _isShrinkData = false;
        bool _isStoreProc = false;

        public DbProviderFactory Instance { get { return OleDbFactory.Instance; } }

        public bool IsFullTextSearchEnabled { get { return _isFullTextSearchEnabled; } }
        public bool IsCompactDatabase { get { return _isCompactDatabase; } }
        public bool IsBackupDatabase { get { return _isBackupDatabase; } }
        public bool IsDbOptimize { get { return _isDbOptimize; } }
        public bool IsShrinkData { get { return _isShrinkData; } }
        public bool IsStoreProc { get { return _isStoreProc; } }


        public void DeriveParameters(IDbCommand cmd)
        {
            if ((cmd as OleDbCommand != null)) {
                OleDbCommandBuilder.DeriveParameters(cmd as OleDbCommand);
            }
        }

        public DbParameter MakeParameters(string ParamName, DbType DbType, Int32 Size)
        {
            OleDbParameter param;

            if(Size >0)
                param = new OleDbParameter(ParamName, (OleDbType)DbType, Size);
            else
                param = new OleDbParameter(ParamName, (OleDbType)DbType);

            return param;                        
        }

        public string GetLastIdSql() { return "SELECT_SCOPE_IDENTITY()"; }
    }
}
