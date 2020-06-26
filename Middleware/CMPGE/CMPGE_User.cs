using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFContract;

namespace Middleware.CMPGE
{
    class CMPGE_User
    {
        private STCMSG message;
        private string sqlRequest;
        private int id;
        private string username;
        private string password;

        public CMPGE_User()
        {
            this.message = new STCMSG();
        }

        public STCMSG selectByLoginAndPassword(STCMSG message)
        {
            this.message = message;
            this.username = message.User_login;
            this.password = message.User_psw;

            sqlRequest = "SELECT id, email FROM Users WHERE(email='" + username + "') AND (password = '" + password + "');";

            this.message.Data = new object[1] { (object)sqlRequest };

            return this.message;
        }
    }
}
