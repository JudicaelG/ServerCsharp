using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.ServiceModel;
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
            this.message.Data = new object[1] { new string[] { "fichièr1", "test de ouf"} };

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
                    XORCipher(((string[])this.message.Data[index])[1], ((string[])this.message.Data[index])[0], message);                    
                });

                this.message.Op_info = "decipher en cours";
                this.message.Op_statut = true;
                this.message.App_name = null;
                this.message.App_token = null;
                this.message.App_version = null;
                this.message.Data = null;
                this.message.Op_name = null;
                this.message.User_psw = null;
                return this.message;

            }
            catch(OperationCanceledException e)
            {
                this.message.Op_info = e.Message;
            }
            finally
            {
                cts.Dispose();
            }

            
            this.message.Op_statut = false;
            this.message.App_name = null;
            this.message.App_token = null;
            this.message.App_version = null;
            this.message.Data = null;
            this.message.Op_name = null;
            this.message.User_psw = null;
            return this.message;

        }

        private static void XORCipher(string data, string namefile, STCMSG message)
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
                proxy.AcquisitionEndpointClient sendToQueue = new proxy.AcquisitionEndpointClient();
                sendToQueue.Open();
                sendToQueue.acquisitionOperation(message.User_login, item, new string(output), message.App_token, namefile);
                sendToQueue.Close();


            }
        }


        private static void sendInQueue(string nameFile, string contentFile, string key, STCMSG message)
        {



            proxy.AcquisitionEndpointClient test = new proxy.AcquisitionEndpointClient("AcquisitionPort");
            Console.WriteLine(test.Endpoint);
            test.acquisitionOperation(message.User_login, key, contentFile, message.App_token, nameFile);
            ////requete web
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"http://192.168.0.30:10080/AcquisitionService/AcquisitionServiceBean");
            //request.Headers.Add(@"SOAPAction:acquisitionOperation");
            //request.ContentType = "text/xml; charset=\"ISO-8859-1\"";
            //request.Accept = "text/xml";
            //request.Method = "POST";


            ////Xml document
            //XmlDocument SOAPReqBody = new XmlDocument();
            //SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""ISO-8859-1""?>
            //    <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
            //    <soap:Body xmlns:ns2=""http://facade.communication.cesi.com/""> <acquisitionOperation> <email>" + message.User_login + "</email> <key>" + key + "</key> <decipherMessage>" + contentFile + "</decipherMessage> <appToken>" + message.App_token + "</appToken> <fileName>" + nameFile + "</fileName> </acquisitionOperation> </soap:Body> </soap:Envelope>");

            //using (Stream stream = request.GetRequestStream())
            //{
            //    SOAPReqBody.Save(stream);
            //}

            //using (WebResponse Serviceres = request.GetResponse())
            //{
            //    using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
            //    {
            //        //reading stream    
            //        var ServiceResult = rd.ReadToEnd();
            //        //writting stream result on console    
            //        Console.WriteLine(ServiceResult);
            //        Console.ReadLine();
            //    }
            //}
        }

    }
}
