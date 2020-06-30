using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFContract;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.CompilerServices;

namespace Middleware.CAD
{
    class CAD
    {
        private STCMSG message;
        private SqlCommand sqlCommand;
        private SqlDataAdapter dataAdapter;
        private SqlConnection sqlConnection;
        private string sqlRequest;
        private string sqlConnectionString;
        private DataSet dataSet;

        public CAD()
        {
            this.message = new STCMSG();
            this.sqlCommand = new SqlCommand();
            this.sqlConnection = new SqlConnection();
            this.dataAdapter = new SqlDataAdapter();
            this.dataSet = new DataSet();

            this.sqlConnectionString = @"Data Source=DESKTOP-OQSDNT6; initial Catalog=ProjetC#; User ID=DB_WCF;Password=DB_WCF";
            this.sqlConnection.ConnectionString = this.sqlConnectionString;
            this.sqlCommand.CommandType = CommandType.Text;
            this.sqlCommand.Connection = this.sqlConnection;
        }

        public STCMSG getRows(STCMSG _message)
        {
            this.message = _message;
            this.sqlRequest = (string)message.Data[0];
            this.sqlCommand.CommandText = this.sqlRequest;
            this.dataAdapter.SelectCommand = this.sqlCommand;
            this.dataAdapter.Fill(this.dataSet, (string)_message.Data[1]);
            this.message.Data = new object[1] { (object)this.dataSet.Tables[0] };
            
            return this.message;
        }

        public STCMSG setRows(STCMSG message) 
        {

            this.message = message;
            this.sqlRequest = (string)message.Data[0];
            this.sqlCommand.Connection.Open();
            this.sqlCommand.CommandText = this.sqlRequest;
            this.sqlCommand.ExecuteReader();
            this.sqlCommand.Connection.Close();
            return this.message;  
        }
        
    }
}