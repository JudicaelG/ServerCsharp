using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using WCFContract;

namespace Middleware.CTRLWF
{
    

    class Receive_Secret_Information_V1 : IExec
    {
        STCMSG message;
        private CMPGE.CMPGE_User sql;
        private CAD.CAD cad;

        public Receive_Secret_Information_V1()
        {
            this.message = new STCMSG();
            this.cad = new CAD.CAD();
        }

        public STCMSG exec(STCMSG message)
        {
            this.message = message;
            int count = -1;

            this.sql = new CMPGE.CMPGE_User();
            this.message = this.sql.insertResults(this.message);
            this.message.Data = new object[2] { this.message.Data[0], (object)"result" };
            this.message = this.cad.setRows(this.message);

            this.message.Op_info = "Success";
            this.message.Op_statut = true;
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
