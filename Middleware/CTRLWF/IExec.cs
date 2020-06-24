using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFContract;

namespace Middleware.CTRLWF
{
    interface IExec
    {
        STCMSG exec(STCMSG message);
    }
}
