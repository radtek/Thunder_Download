using System;
using System.Text;
using dotNetLab.Data.Embedded;

using dotNetLab.Data;
using System.Data.Common;

namespace dotNetLab
{
    namespace Data.DBEngines.PostgreSQL
    {
   public class PostgreSQLDB : LevelDB
    {
       protected int nFixedPort = 5432;
       protected string strFixedUserName = "postgres";
       protected string strFixedPassword = "318037";
       protected string strConnectFormatStr =
             "server={0};username={1};database={2};port={3};password={4};";
             object GetReflectOject(string strDllPath, string strObjectFullName)
            {
                return System.Activator.CreateInstanceFrom(strDllPath, strObjectFullName).Unwrap();
            }
            public PostgreSQLDB()
        {
                object obj = this.GetReflectOject("Npgsql.dll", "Npgsql.NpgsqlConnection");

                this.conn =
                    obj
                    as DbConnection;
                this.DbPar =
                    GetReflectOject("Npgsql.dll", "Npgsql.NpgsqlParameter")
                    as DbParameter;
                this.cmd =
                  GetReflectOject("Npgsql.dll", "Npgsql.NpgsqlCommand")
                   as DbCommand;

                //this.DbPar =
                //new NpgsqlParameter("data",
                //NpgsqlTypes.NpgsqlDbType.Bytea);
                this.DbPar.ParameterName = "Data";
                this.DbPar.Value = System.Data.SqlDbType.Image;

            
        }
          
            public override void Connect(string IP, string DBName, string UserName, string Password)
            {
                string str =
                    string.Format(strConnectFormatStr,
                    IP, UserName, DBName, nFixedPort, Password);
                Connect(IP, nFixedPort, DBName, strFixedUserName,
                    strFixedPassword, str, ref conn, ref cmd);
            }

            public override void GetAllTableNames()
            {
                lst_TableNames.Clear();
                dt = this.ProvideTable("SELECT  tablename   FROM   pg_tables;", DBOperator.OPERATOR_QUERY_ALL_TABLENAMES);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    String strTableName = dt.Rows[i][0].ToString();
                    if (!strTableName.Contains("pg_") && !strTableName.Contains("sql_"))
                        this.lst_TableNames.Add(strTableName);
                }
            }

            public override void RawConnect(string IP, int Port, string dbname, string User, string Password)
            {
                string str =
                     string.Format(strConnectFormatStr,
                     IP, UserName, DBName, Port, Password);
                Connect(IP, nFixedPort, DBName, strFixedUserName,
                    strFixedPassword, str, ref conn, ref cmd);
            }

#if TRANSACTION
            protected override void TransactionConnect(out DbConnection cnn,
              out DbCommand cmm)
            {
                cnn = new NpgsqlConnection();
                cmm = new NpgsqlCommand();
            }
#endif
        }
    }

}
