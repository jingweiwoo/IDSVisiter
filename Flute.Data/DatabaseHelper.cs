using System;
using System.Collections.Generic;
// using System.Linq;
using System.Text;

using System.Data;
using System.Data.Common;
using System.Data.OleDb;

using Flute;

namespace Flute.Data
{
    public class DatabaseHelper
    {
        #region .DataSet Operations.

        /// <summary>
        /// 创建并填充数据集
        /// </summary>
        /// <param name="connString"></param>
        /// <param name="dbProvider"></param>
        /// <param name="TblNames"></param>
        /// <returns></returns>
        public static DataSet CreateDataSet(string connString, IDbProvider dbProvider, params string[] TblNames)
        {
            DataSet dataSet = new DataSet();

            if (TblNames.Length <= 0 || connString == null || dbProvider == null) {
                return dataSet;
            } else {
                DbProviderFactory dbProvFactory = dbProvider.Instance;

                DbConnection dbConn = dbProvFactory.CreateConnection();
                dbConn.ConnectionString = connString;

                DbDataAdapter dataAdapter = dbProvFactory.CreateDataAdapter();

                try {
                    if (dbConn.State != ConnectionState.Open)
                        try {
                            dbConn.Open();
                        } catch (System.Data.DataException ex) {
                            Flute.Service.MessageBoxWinForm.Info("连接到数据", "连接数据库时出现异常.\n", ex.Message + "\n" + ex.Source);
                        }

                    foreach (string TblName in TblNames) {
                        dataAdapter.SelectCommand = dbProvFactory.CreateCommand();
                        dataAdapter.SelectCommand.Connection = dbConn;
                        dataAdapter.SelectCommand.CommandText = "SELECT * " + "FROM " + TblName;

                        dataAdapter.SelectCommand.Transaction = dbConn.BeginTransaction(IsolationLevel.ReadCommitted);
                        try {
                            dataAdapter.Fill(dataSet, TblName);
                            dataAdapter.SelectCommand.Transaction.Commit();
                        } catch (DataException ex) {
                            dataAdapter.SelectCommand.Transaction.Rollback();
                            Flute.Service.MessageBoxWinForm.Info("填充数据集", "填充表[" + TblName + "]是出现异常,请检查程序.", ex.Message + "\n" + ex.Source);
                            continue;
                        }
                    }
                } finally {
                    dbConn.Close();
                }

                return dataSet;
            }
        }

        #endregion // DataSet Operation
    }
}
