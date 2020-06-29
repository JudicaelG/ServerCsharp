using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFContract
{
    [System.ServiceModel.ServiceContract]
    public interface IServer
    {
        ///<summary>
        /// Permet d'envoyer un message au service WCF
        /// </summary>
        /// <param name="msg">Message</param>
        /// <returns>Tickets data</returns>
        [System.ServiceModel.OperationContract]
        STCMSG service(STCMSG msg);

    }

    public interface IServerCallback
    {
        [OperationContract(IsOneWay = true)]
        void Files();
    }
}
