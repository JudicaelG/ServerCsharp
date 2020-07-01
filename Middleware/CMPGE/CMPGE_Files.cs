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
            this.message.Data = new object[] { new string[] { "AAAA", "le super texte dechiffrer", "fichier1", "les valeurs de ouf" } };

            sqlRequest = "INSERT INTO Results(username, secretKey, secretInformation, fileName, PDF) VALUES ('" + this.message.User_login + "','" + ((string[])this.message.Data[0])[0] + "','" + ((string[])this.message.Data[0])[1] + "','" + ((string[])this.message.Data[0])[2] + "','" + ((string[])this.message.Data[0])[3] + "');";

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
