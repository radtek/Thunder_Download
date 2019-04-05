#define CONSOLE_TEST
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using dotNetLab.Data.Embedded;
namespace dotNetLab
{
       
    namespace Data.DBEngines.SQLServer
    {
        public class SQLServerDB : LevelDB
        {
            const int DEFAULT_PORT = 1433;
            const string DEFAULT_USERNAME = "shikii";
            const string DEFAULT_IP = "192.168.1.199";
            const string DEFAULT_PASSWORD = "nho318037";

            public DBRoot DBEngine{
                get
                {
                    return this;
                }
            }

            public SQLServerDB()
            {
                this.conn = new SqlConnection();
                this.cmd = new SqlCommand();
                this.DbPar = new SqlParameter("data",System.Data.SqlDbType.Image);
            }
             public override void RawConnect(string IP, int nPort, string _DBName_, string _UserName_, string _Password_)
            {
                 if(conn!=null)
                {
                    conn.Close();
                    conn.Dispose();
                    cmd.Dispose();
                }
                conn = new SqlConnection();
                cmd = new SqlCommand();
                string strCnn = string.Format(
                   "server={0},{1};Initial Catalog={2};User ID={3};Password ={4}"
                    , IP, nPort, _DBName_, _UserName_, _Password_);
                base.Connect(IP, nPort, _DBName_,_UserName_, _Password_,strCnn, ref conn, ref cmd);
 
            }
             public override void Connect(string IP, string DBName, string UserName, string Password)
            {
                RawConnect(IP, DEFAULT_PORT, DBName, UserName, Password);
            }

             public override void GetAllTableNames()
            {
                //SELECT Name FROM SysObjects Where XType='U' ORDER BY Name
                lst_TableNames.Clear();
                dt = this.ProvideTable("SELECT Name FROM SysObjects Where XType='U' ORDER BY Name;", DBOperator.OPERATOR_QUERY_ALL_TABLENAMES);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                     String strTableName = dt.Rows[i][0].ToString();
                    //if (!strTableName.Contains("pg_") && !strTableName.Contains("sql_"))
                        this.lst_TableNames.Add(strTableName);
                }
            }

#if TRANSACTION
            protected override void TransactionConnect(out DbConnection cnn, out DbCommand cmm)
            {
                cnn = new SqlConnection(this.conn.ConnectionString);
                cmm = new SqlCommand();
                try
                {
                    cnn.Open();
                    cmm.Connection = cnn;
                }
                catch (Exception e)
                {
                    strErrorInfo = e.ToString();
                    DBDiagnoseHandler(cnn.ConnectionString, DBOperator.OPERATOR_CONNECT_DB_AFFAIR);
                }

            }
#endif
        }
        public class LocalDB : LevelDB
        {
            public LocalDB()
            {
               
                this.conn = new SqlConnection();
                this.cmd = new SqlCommand();
            }

            public override void Connect(string strSQL_Server_Data_FilePath)
            {
                conn.ConnectionString =
                  string.Format("server=(localdb)\\MSSQLLocalDB;AttachDBFilename={0} ;",
                  strSQL_Server_Data_FilePath
                  );
                try
                {
                    conn.Open();
                    this.cmd.Connection = conn;
#if CONSOLE_TEST
                    Console.WriteLine("Connected LocalDB !");
#endif
                }
                catch (Exception e)
                {

#if CONSOLE_TEST
                    Console.WriteLine("Failed To Connect LocalDB !");
#endif
                    this.strErrorInfo = e.ToString();
                    HandleError(e, cmd, DBOperator.OPERATOR_CONNECT_DB);
                }
            }

            public override void GetAllTableNames()
            {
                //SELECT Name FROM SysObjects Where XType='U' ORDER BY Name
                lst_TableNames.Clear();
                dt = this.ProvideTable("SELECT Name FROM SysObjects Where XType='U' ORDER BY Name;", DBOperator.OPERATOR_QUERY_ALL_TABLENAMES);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    String strTableName = dt.Rows[i][0].ToString();
                    //if (!strTableName.Contains("pg_") && !strTableName.Contains("sql_"))
                    this.lst_TableNames.Add(strTableName);
                }
            }
        }
    }
}
