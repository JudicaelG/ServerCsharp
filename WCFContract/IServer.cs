using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFContract
{
    [System.ServiceModel.ServiceContract(Name="IcomposantService", Namespace="http://localhost")]
    public interface IServer
    {
        [System.ServiceModel.OperationContract]
        STCMSG service(STCMSG msg);
    }
}
