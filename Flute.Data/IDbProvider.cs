using System;
using System.Collections.Generic;
// using System.Linq;
using System.Text;

using System.Data;
using System.Data.Common;

namespace Flute.Data
{
    public interface IDbProvider
    {
        /// <summary>
        /// 返回DbProviderFactory实例
        /// </summary>
        DbProviderFactory Instance { get; }

        /// <summary>
        /// 是否支持全文搜索
        /// </summary>
        bool IsFullTextSearchEnabled { get; }

        /// <summary>
        /// 是否支持压缩数据库
        /// </summary>
        bool IsCompactDatabase { get; }

        /// <summary>
        /// 是否支持备份数据库
        /// </summary>
        bool IsBackupDatabase { get; }

        /// <summary>
        /// 是否支持数据库优化
        /// </summary>
        bool IsDbOptimize { get; }

        /// <summary>
        /// 是否支持数据库收缩
        /// </summary>
        bool IsShrinkData { get; }
        
        /// <summary>
        /// 是否支持存储过程
        /// </summary>
        bool IsStoreProc { get; }

               

        /// <summary>
        /// 检索SQL参数信息并填充
        /// </summary>
        /// <param name="cmd"></param>
        void DeriveParameters(IDbCommand cmd);

        /// <summary>
        /// 创建SQL参数
        /// </summary>
        /// <param name="ParamName"></param>
        /// <param name="DbType"></param>
        /// <param name="Size"></param>
        /// <returns></returns>
        DbParameter MakeParameters(string ParamName, DbType DbType, Int32 Size);

        /// <summary>
        /// 返回刚插入记录的自增ID值, 如不支持则为""
        /// </summary>
        /// <returns></returns>
        string GetLastIdSql();
    }
}
