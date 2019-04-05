using dotNetLab.Data.Embedded;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OracleClient;
namespace dotNetLab.Data.DBEngines.Oracle
{
    public class OracleDB : LevelDB
    {
        const int DEFAULT_PORT = 1433;
        const string DEFAULT_USERNAME = "shikii";
        const string DEFAULT_IP = "192.168.1.199";
        const string DEFAULT_PASSWORD = "nho318037";

     
        public OracleDB()
        {
            
            this.conn = new OracleConnection();
            this.cmd = new OracleCommand();
            this.DbPar = new OracleParameter("data", System.Data.OracleClient.OracleType.Blob);
        }
        public override void RawConnect(string IP, int nPort, string _DBName_, string _UserName_, string _Password_)
        {
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
                cmd.Dispose();
            }
            conn = new OracleConnection();
            cmd = new OracleCommand();
            string strCnn = 
                string.Format("user id={0};password={1};data source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST={2})(PORT={3}))(CONNECT_DATA=(SERVICE_NAME={4})))",
                _UserName_, _Password_, IP, nPort, _DBName_);
               
            base.Connect(IP, nPort, _DBName_, _UserName_, _Password_, strCnn, ref conn, ref cmd);

        }
        public override void Connect(string IP, string DBName, string UserName, string Password)
        {
            RawConnect(IP, DEFAULT_PORT, DBName, UserName, Password);
        }

        // 尚示实现
        public override void GetAllTableNames()
        {
            //SELECT Name FROM SysObjects Where XType='U' ORDER BY Name
            lst_TableNames.Clear();
            dt = this.ProvideTable("SELECT Name FROM SysObjects Where XType='U' ORDER BY Name;", DBOperator.OPERATOR_QUERY_ALL_TABLENAMES);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String strTableName = dt.Rows[i][0].ToString();
                //if (!strTableName.Contains("pg_") && !strTableName.Contains("Oracle_"))
                this.lst_TableNames.Add(strTableName);
            }
        }

#if TRANSACTION
            protected override void TransactionConnect(out DbConnection cnn, out DbCommand cmm)
            {
                cnn = new OracleConnection(this.conn.ConnectionString);
                cmm = new OracleCommand();
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
}
