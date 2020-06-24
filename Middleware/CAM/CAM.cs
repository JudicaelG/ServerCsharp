using Middleware.CTRLWF;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFContract;

namespace Middleware.CAM
{
    class CAM
    {
        private static TraceSource source = new TraceSource("CAM");
        private static CAM instance = null;
        private static readonly object padlock = new object();
        private STCMSG message;
        private IExec exec;

        public CAM()
        {
            this.message = new STCMSG();
        }

        public static CAM Instance
        {
            get
            {
                lock (padlock)
                {
                    if(instance == null)
                    {
                        instance = new CAM();
                    }
                    return instance;
                }
            }
        }

        public STCMSG dispatching(STCMSG message)
        {
            source.TraceEvent(TraceEventType.Start, 0, "dispatching");
            this.message = message;
            if(message.App_name == "Appli1")
            {
                if (message.App_version == "1")
                {
                    if(message.Op_name == "authentifier")
                    {
                        source.TraceEvent(TraceEventType.Start, 0, "authentifier");
                        this.exec = new Auth_V1();
                        this.message = this.exec.exec(this.message);
                        source.TraceEvent(TraceEventType.Stop, 0, "authentifier");
                    }
                }
            }
            source.TraceEvent(TraceEventType.Stop, 0, "dispatching");
            return this.message;
        }
    }
}
