using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFContract
{
    interface IServer
    {
        void service(STCMSG msg);
    }
}
