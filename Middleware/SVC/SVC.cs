using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFContract;

namespace Middleware.SVC
{
    public class SVC: IServer
    {
        private STCMSG message;
        private object m_service;

        public SVC()
        {
            this.message = new STCMSG();
            this.m_service = null;
        }

        [System.Security.Permissions.PrincipalPermission(System.Security.Permissions.SecurityAction.Demand,Role =@"BUILTIN\Utilisateurs")]
        public STCMSG service(STCMSG message)
        {
            int i;
            if(message.App_token == "1234")
            {
                if(message.Op_name == "authentifier")
                {
                    this.message = message;
                    this.m_service = new PCS.PCS();
                    this.message = ((PCS.PCS)this.m_service).authentifier(this.message);
                }

                if(message.Op_name == "decipher")
                {
                    this.message = message;
                    this.m_service = new PCS.PCS();
                    this.message = ((PCS.PCS)this.m_service).authentifier(this.message);
                }
            }
            else
            {
                this.message.App_name = "";
                this.message.App_token = "";
                this.message.App_version = "";
                this.message.Data = null;
                this.message.Op_info = "Cette application n'est pas prise en charge par la plateforme";
                this.message.Op_name = "";
                this.message.Op_statut = false;
                this.message.User_login = "";
                this.message.User_psw = "";
                this.message.User_token = "";
            }

            return this.message;
        }
    }
}
