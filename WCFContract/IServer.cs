﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFContract
{
    public interface IServer
    {
        STCMSG service(STCMSG msg);
    }
}
