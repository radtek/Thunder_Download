using System;
using System.Collections.Generic;
using System.Data.Common;

using dotNetLab.Data;
using dotNetLab.Data.Embedded;
using System.IO;

namespace dotNetLab
{
    namespace Data.DBEngines.Mysql
    {
        public class MysqlDB : LevelDB
        {
            List<String> lst_DBNames;
            List<string> lst_TablesNames;
            int nFixedPort = 3306;
            string strFixedUserName = "root";
            string strFixedPassword = "3633";
           string strConnectFormatStr =
                "server={0};user={1};database={2};port={3};password={4};";
            object GetReflectOject(string strDllPath, string strObjectFullName)
            {
                return System.Activator.CreateInstanceFrom(strDllPath, strObjectFullName).Unwrap();
            }
            void AddRef(string strFileName, byte[] bytArr)
            {
                FileStream fs = new FileStream(strFileName, FileMode.Create);

                fs.Write(bytArr, 0, bytArr.Length);
                fs.Flush();
                fs.Close();
                fs.Dispose();

            }
            public MysqlDB()
            {
                if(!File.Exists("MySql.Data.dll"))
                {
                    AddRef("MySql.Data.dll", DBBase.DBEngines.MySQLDB.MySQLDBRes.MySql_Data);
                }
                object obj = this.GetReflectOject("MySql.Data.dll", "MySql.Data.MySqlClient.MysqlConnection");

                this.conn =
                    obj
                    as DbConnection;
                this.DbPar =
                    GetReflectOject("MySql.Data.dll", "MySql.Data.MySqlClient.MysqlParameter")
                    as DbParameter;
                this.cmd =
                  GetReflectOject("MySql.Data.dll", "MySql.Data.MySqlClient.MysqlCommand")
                   as DbCommand;

                //this.DbPar =
                //new MysqlParameter("data",
                //MysqlTypes.MysqlDbType.Bytea);
                this.DbPar.ParameterName = "Data";
                this.DbPar.Value = System.Data.SqlDbType.Image;
                prepareCollection();
            }

            private void prepareCollection()
            {
                lst_DBNames = new List<string>();
                lst_TablesNames = new List<string>();
            }

            //For Work
            public  void Connect(string IP, string dbname)
            {
                string str =
                    string.Format(strConnectFormatStr, 
                    IP, strFixedUserName, dbname,nFixedPort, strFixedPassword);
                Connect(IP, nFixedPort, dbname, strFixedUserName, 
                    strFixedPassword,str,ref conn,ref cmd);
            }
            public override void Connect(string DBName)
            {
                strIP = "192.168.1.199";
                Connect(strIP, DBName);
            }
            //测试用
            public void Connect()
            {
                strIP = "192.168.1.199";
                Connect(strIP, "mysql");
            }
#if TRANSACTION
            protected override void TransactionConnect(out DbConnection cnn,
              out DbCommand cmm)
            {
                cnn = new MySqlConnection();
                cmm  = new MySqlCommand();
            }
#endif
            public void GetAllDBName()
            {
                string sql = "show databases ;";
                ProvideTable(sql,DBOperator.OPERATOR_QUERY_ALL_DBNAMES);
                try
                {
                    if (dt.Columns.Count >= 0)
                        lst_DBNames.Clear();
                    cmd.CommandText = sql;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                        lst_DBNames.Add(reader[0].ToString());
                    reader.Close();
                }
                catch (Exception e)
                {
                    HandleError(e, cmd, DBOperator.OPERATOR_QUERY_ALL_DBNAMES);
                }


            }
            public void GetAllTableName()
            {
                string sql = "show tables ;";
                ProvideTable(sql,DBOperator.OPERATOR_QUERY_ALL_TABLENAMES);
                try
                {
                    if (dt.Columns.Count >= 0)
                        lst_TablesNames.Clear();
                    cmd.CommandText = sql;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                        lst_TablesNames.Add(reader[0].ToString());
                    reader.Close();
                  

                }
                catch (Exception e)
                {
                    HandleError(e, cmd, 
                        DBOperator.OPERATOR_QUERY_ALL_TABLENAMES);
                }

            }
            public bool NewUser(String strNewUserName, String strPassword)
            {
                try
                {
                    cmd.CommandText = String.Format(
                        " create user '{0}'@'%' identified by '{2}' ;"
                        , strNewUserName, strPassword);
                    return true;
                }
                catch (Exception e)
                {
                    this.strErrorInfo = e.ToString();
                    return false;
                }
            }
            public bool NewUser(String strNewUserName)
            {
                try
                {
                    cmd.CommandText = String.Format(
                        " create user '{0}'@'%' identified by '{1}' ;"
                        , strNewUserName, this.strPassword);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    this.strErrorInfo = e.ToString();
                    return false;
                }
            }
            
            public void  RemoveUser(String strUserName)
            {
                try
                {
                    cmd.CommandText = String.Format("drop user '{0}'@'%';",
                        strUserName);
                    cmd.ExecuteNonQuery();
                     
                }
                catch (Exception e)
                {
                    HandleError(e, cmd, DBOperator.OPERATOR_REMOVE_USER);
                }
            }
            //新增列
            public bool NewColumn(string ColumnName, string ColumnType,string TableName)
            {
                try
                {
                    cmd.CommandText = string.Format("use {0};alter table {1} ;add {2} {3} {4} null;", DBName, TableName, ColumnName, ColumnType);
                    int Infer = cmd.ExecuteNonQuery();
                    if (Infer != -1)
                        return true;
                    else
                        return false;
                }
                catch
                {
                    return false;
                }
            }
            //删除列
            public bool DropColumn(string ColumnName, string TableName)
            {
                cmd.CommandText = string.Format("alter table {0} drop column {1}", TableName, ColumnName);
                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            public override void GetAllTableNames()
            {
                throw new NotImplementedException();
            }
        }
    }
   
}
