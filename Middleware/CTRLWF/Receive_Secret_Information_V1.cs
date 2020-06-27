using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFContract;

namespace Middleware.CTRLWF
{
    class Receive_Secret_Information_V1 : IExec
    {
        STCMSG message;

        public Receive_Secret_Information_V1()
        {
            this.message = new STCMSG();
        }

        public STCMSG exec(STCMSG message)
        {
            this.message = message;


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
