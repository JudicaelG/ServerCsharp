using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFContract;

namespace Middleware.CMPGE
{
    class CMPGE_Files
    {
        private STCMSG message;
        private string sqlRequest;

        public CMPGE_Files()
        {
            this.message = new STCMSG();
        }


        /// <summary>
        /// créer la requête pour insérer le triplet dans la base de donnée pour le client
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public STCMSG insertResults(STCMSG message)
        {
            this.message = message;

            sqlRequest = "INSERT INTO Results(username, secretKey, secretInformation, fileName) VALUES ('" + this.message.User_login + "','" + this.message.Data[2] + "','" + this.message.Data[0] + "','" + this.message.Data[1] + "');";

            this.message.Data = new object[1] { (object)sqlRequest };
            return this.message;
        }

        /// <summary>
        /// créer la requête pour sélectionné le fichier decypher 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public STCMSG selectResults(STCMSG message)
        {
            this.message = message;

            sqlRequest = "SELECT secretKey, secretInformation, fileName, PDF FROM Results WHERE (username = '" + this.message.User_login + "');";

            this.message.Data = new object[1] { (object)sqlRequest };
            return this.message;
        }

    }
}
