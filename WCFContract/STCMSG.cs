using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFContract
{
    public struct STCMSG
    {
        string app_name;
        string app_token;
        string app_version;
        object[] data;
        string op_info;
        string op_name;
        bool op_statut;
        string user_login;
        string user_psw;
        string user_token;

        public string App_name { get => app_name; set => app_name = value; }
        public string App_token { get => app_token; set => app_token = value; }
        public string App_version { get => app_version; set => app_version = value; }
        public object[] Data { get => data; set => data = value; }
        public string Op_info { get => op_info; set => op_info = value; }
        public string Op_name { get => op_name; set => op_name = value; }
        public bool Op_statut { get => op_statut; set => op_statut = value; }
        public string User_login { get => user_login; set => user_login = value; }
        public string User_psw { get => user_psw; set => user_psw = value; }
        public string User_token { get => user_token; set => user_token = value; }
    }
}
