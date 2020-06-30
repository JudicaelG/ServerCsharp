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
        STCMSG messages;
        private CMPGE.CMPGE_User sql;
        private CAD.CAD cad;

        public Receive_French_Files_V1()
        {
            this.messages = new STCMSG();
            this.cad = new CAD.CAD();
        }

        public STCMSG exec(STCMSG message)
        {
            this.messages = message;

            this.sql = new CMPGE.CMPGE_User();

            return this.messages;
        }

    }
}
