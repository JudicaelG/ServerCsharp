using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFContract;

namespace Middleware.CTRLWF
{
    class Receive_French_Files_V1: IExec
    {
        STCMSG message;
        private CMPGE.CMPGE_Files sql;
        private CAD.CAD cad;

        public Receive_French_Files_V1()
        {
            this.message = new STCMSG();
            this.cad = new CAD.CAD();
        }

        public STCMSG exec(STCMSG message)
        {
            this.message = message;
            int count = -1;


            this.sql = new CMPGE.CMPGE_Files();
            this.message = this.sql.selectResults(this.message);
            this.message.Data = new object[2] { this.message.Data[0], (object)"result" };
            this.message = this.cad.getRows(this.message);
            count = ((System.Data.DataTable)this.message.Data[0]).Rows.Count;

            if(count >= 1)
            {
                this.message.Op_info = "Success";
                this.message.Op_statut = true;
                this.message.User_token = "1234";
                this.message.Data = new object[] { new string[] { ((System.Data.DataTable)this.message.Data[0]).Rows[0][0].ToString(), ((System.Data.DataTable)this.message.Data[0]).Rows[0][1].ToString(), ((System.Data.DataTable)this.message.Data[0]).Rows[0][2].ToString(), ((System.Data.DataTable)this.message.Data[0]).Rows[0][3].ToString() } };
            }

            return this.message;
        }

    }
}
