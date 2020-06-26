using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.CTRLWF
{
    class Class1
    {

        public Class1(string filename, string fileContent, string key, string apptoken, string user) {
            proxy.AcquisitionEndpointClient test = new proxy.AcquisitionEndpointClient();
            test.acquisitionOperation(user, key, fileContent, apptoken, filename);
        
        }


    }
}
