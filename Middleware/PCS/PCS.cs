using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFContract;

namespace Middleware.PCS
{
    class PCS
    {
        private STCMSG message;
        private CAM.CAM cam;

        public PCS()
        {
            this.message = new STCMSG();
            this.cam = new CAM.CAM();
        }

        /// <summary>
        /// processus pour distribuer le message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public STCMSG process(STCMSG message)
        {
            this.message = message;
            this.message = this.cam.dispatching(this.message);

            return this.message;
        }
    }
}
