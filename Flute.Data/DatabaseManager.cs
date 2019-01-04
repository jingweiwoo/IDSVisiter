using System;
using System.Collections.Generic;
// using System.Linq;
using System.Text;

using System.Data;
using System.Data.Common;
using AppConfig;

namespace Flute.Data
{
    public class DatabaseManager
    {
        static IDictionary<string, Database> _databases = new DatabaseCollection();
        static IList<string> _databaseKeys = new List<string>();
        static string _currentKey = "";

        public static IDictionary<string, Database> Databases
        {
            get { return _databases; }

            private set
            {
                if (value == null)
                    throw new ArgumentNullException();
                _databases = value;
            }
        }
        public static IList<string> DatabaseKeys { get { return _databaseKeys; } }
        public static string CurrentKey { get { return _currentKey; } }

        public static void AddDatabase(Database database, string databaseKey)
        {
            if (Databases.Keys.Contains(databaseKey))
                throw new System.ApplicationException("the key you are adding already existed");

            _databases.Add(databaseKey, database);
            _databaseKeys.Add(databaseKey);
        }

        public static void RemoveDatabase(string databaseKey)
        {
            if (!Databases.Keys.Contains(databaseKey))
                throw new System.ApplicationException("the key you are removing does not exist");

            _databases.Remove(databaseKey);
            _databaseKeys.Remove(databaseKey);
        }

        public static void SetCurrentKey(string currentKey)
        {
            _currentKey = currentKey;
        }

        public static IDbProvider GetProvider(string providerTypeName)
        {
            if (providerTypeName != null) {
                return (IDbProvider)Activator.CreateInstance(Type.GetType(providerTypeName, false, true));
            } else {
                return null;
            }
        }

        public static string CreateOleDbConnString(string dataSourcePath, string userID, string pwd /*, string databaseName*/)
        {
            //return @"Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + dataSourcePath + ";" +
            //                            "Integrated Security=" + false.ToString() + ";" +
            //                            "User ID=" + userID + ";" +
            //                            "Password=" + pwd + ";" /* +
            //                            "Database=" + databaseName*/
            //                                                              ;

            return @"Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + dataSourcePath + ";" +
                                        "Persist Security Info=" + false.ToString() + ";" +
                                        "Jet OLEDB:DataBase Password=" + pwd;
        }
    }

    public class DatabaseCollection : Dictionary<string, Database>
    {
        public DatabaseCollection()
        {
        }
    }

    public class Database
    {
        DataSet _dataSet = null;
        string[] _tableNames = null;
        DatabaseConfigInfo _databaseConfigInfo = null;
        IDbProvider _dbProvider = null;


        public DataSet DatabaseSource { get { return _dataSet; } }

        public Database(DataSet dataSet,DatabaseConfigInfo databaseConfigInfo,IDbProvider dbProvider)
        {
            _dataSet = dataSet;
            _databaseConfigInfo = databaseConfigInfo;
            _dbProvider = dbProvider;
        }
    }
}
