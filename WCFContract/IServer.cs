using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFContract
{
    [System.ServiceModel.ServiceContract]
    public interface IServer
    {
        [System.ServiceModel.OperationContract]
        STCMSG service(STCMSG msg);
    }
}
