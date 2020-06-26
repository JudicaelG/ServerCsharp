using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFContract
{
    [DataContract]
    public struct STCMSG
    {
        [System.Runtime.Serialization.DataMember]
        string app_name;
        [System.Runtime.Serialization.DataMember]
        string app_token;
        [System.Runtime.Serialization.DataMember]
        string app_version;
        [System.Runtime.Serialization.DataMember]
        object[] data;
        [System.Runtime.Serialization.DataMember]
        string op_info;
        [System.Runtime.Serialization.DataMember]
        string op_name;
        [System.Runtime.Serialization.DataMember]
        bool op_statut;
        [System.Runtime.Serialization.DataMember]
        string user_login;
        [System.Runtime.Serialization.DataMember]
        string user_psw;
        [System.Runtime.Serialization.DataMember]
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
