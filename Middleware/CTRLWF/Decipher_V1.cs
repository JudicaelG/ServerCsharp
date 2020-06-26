using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
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
            this.message.Data = new object[1] { new string[] { "fichier1", "test de ouf"} };

            CancellationTokenSource cts = new CancellationTokenSource();
            ParallelOptions po = new ParallelOptions();
            po.CancellationToken = cts.Token;
            po.MaxDegreeOfParallelism = Environment.ProcessorCount;

            //lancé une tâche pour cancel la boucle parallel for dans un autre thread
            Task.Factory.StartNew(() =>
            {
                if (this.message.Op_name == "canceldecipher")
                {
                    cts.Cancel();
                }
            });

            try
            {
                Parallel.For(0, this.message.Data.Length, po, index => {
                    sendInQueue(((string[])this.message.Data[index])[0], XORCipher(((string[])this.message.Data[index])[1]), this.message);
                });


            }
            catch(OperationCanceledException e)
            {
                this.message.Op_info = e.Message;
            }
            finally
            {
                cts.Dispose();
            }

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
                    output[i] = (char)(data[i] ^ item[i % item.Length]);
                    
                }
                return new string(output);
            }

            return null;
        }


        private static void sendInQueue(string nameFile, string contentFile, STCMSG message)
        {
            //requete web
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"http://192.168.42.58:10080/AcquisitionService/AcquisitionServiceBean");
            request.Headers.Add(@"SOAPAction:");
            request.ContentType = "text/xml; charset=\"iso-8859-1\"";
            request.Accept = "text/xml";
            request.Method = "POST";

            //Xml document
            XmlDocument SOAPReqBody = new XmlDocument();
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>
                <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
                <soap:Body> <acquisitionOperation> <user>" + message.User_login + "</user> <nameFile>" + nameFile + "</nameFile> <contentFile>" + contentFile + "</contentFile> </acquisitionOperation> </soap:Body> </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }

        }
    }
}
