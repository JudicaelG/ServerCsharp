using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFContract;

namespace Middleware.CTRLWF
{
    class Decipher_V1 : IExec
    {

        private STCMSG message;

        public Decipher_V1()
        {
            this.message = new STCMSG();
        }

        public STCMSG exec(STCMSG message)
        {
            this.message = message;
            return this.message;
                       
        }

        private static string XORCipher(string data)
        {
            int dataLength = data.Length;
            var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var key = alphabet.Select(x => x.ToString());
            int keysize = 4;
            char[] output = new char[dataLength];
            int keyLength = key.Count();

            for (int i = 0; i < keysize - 1; i++)
                key = key.SelectMany(x => alphabet, (x, y) => x + y);

            foreach(var item in key)
            {
                for(int i = 0; i < dataLength; i++)
                {
                    output[i] = (char)(data[i] ^ key.ToString()[i % keyLength]);
                }
            }

            return new string(output);


        }
    }
}
