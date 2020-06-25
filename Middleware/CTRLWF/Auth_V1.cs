using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFContract;

namespace Middleware.CTRLWF
{
    class Auth_V1 : IExec
    {
        private STCMSG message;
        private CMPGE.CMPGE_User sql;
        private CAD.CAD cad;

        public Auth_V1()
        {
            this.message = new STCMSG();
            this.cad = new CAD.CAD();
        }
        
        public STCMSG exec(STCMSG message)
        {
            int count;
            this.message = message;
            count = -1;

            this.sql = new CMPGE.CMPGE_User();
            this.message = this.sql.selectByLoginAndPassword(this.message);
            this.message.Data = new object[2] { this.message.Data[0], (object)"result" };
            this.message = this.cad.getRows(this.message);
            count = ((System.Data.DataTable)this.message.Data[0]).Rows.Count;

            if(count == 1)
            {
                this.message.Op_info = "Success";
                this.message.Op_statut = true;
                this.message.User_token = "1234";
            }
            else
            {
                this.message.Op_info = "Fail";
                this.message.Op_statut = false;
            }

            this.message.App_name = null;
            this.message.App_token = null;
            this.message.App_version = null;
            this.message.Data = null;
            this.message.Op_name = null;
            this.message.User_psw = null;

            return this.message;
        }
    }
}
