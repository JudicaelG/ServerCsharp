using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
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

        /// <summary>
        /// Exécute le dechiffrage des fichiers
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public STCMSG exec(STCMSG message)
        {
            this.message = message;
            CancellationTokenSource cts = new CancellationTokenSource();
            ParallelOptions po = new ParallelOptions();
            po.CancellationToken = cts.Token;
            po.MaxDegreeOfParallelism = Environment.ProcessorCount;
            Encoding iso = Encoding.GetEncoding("ISO-8859-1");
            //lancé une tâche pour cancel la boucle parallel for dans un autre thread
            Task.Factory.StartNew(() =>
            {
                if (this.message.Op_info == "cancel")
                {
                    cts.Cancel();
                }

            });

            try
            {
                Parallel.For(0, this.message.Data.Length, po, index => {
                    byte[] textByte = iso.GetBytes(((string[])this.message.Data[index])[1]);
                    XORCipher(textByte, ((string[])this.message.Data[index])[0], message);                    
                });

                this.message.Op_info = "decypher fini";
                this.message.Op_statut = false;
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
                this.message.Op_info = "decypher fini";
                this.message.Op_statut = true;
            }
            finally
            {
                cts.Dispose();
            }

            this.message.App_name = null;
            this.message.App_token = null;
            this.message.App_version = null;
            this.message.Data = null;
            this.message.Op_name = null;
            this.message.User_psw = null;
            return this.message;

        }

        /// <summary>
        /// déchiffrage des fichiers et envoie vers la queue JMS
        /// </summary>
        /// <param name="data"></param>
        /// <param name="namefile"></param>
        /// <param name="message"></param>
        private static void XORCipher(byte[] data, string namefile, STCMSG message)
        {
            int dataLength = data.Length;
            var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var key = alphabet.Select(x => x.ToString());
            int keysize = 4;
            byte[] output = new byte[dataLength];
            int keyLength = key.Count();

            for (int i = 0; i < keysize - 1; i++)
                key = key.SelectMany(x => alphabet, (x, y) => x + y);

            foreach(var item in key)
            {
                byte[] keyBytes = Encoding.UTF8.GetBytes(item);
                for(int i = 0; i < dataLength; i++)
                {
                    //output[i] = (char)(data[i] ^ item[i % item.Length]);
                    output[i] = (byte)(data[i] ^ keyBytes[i % keyBytes.Length]);
                    
                }
                //string str = new string(output);
                Encoding iso = Encoding.GetEncoding("ISO-8859-1");
                //Encoding utf8 = Encoding.UTF8;
                Encoding unicode = Encoding.Unicode;
                //byte[] utfbytes = utf8.GetBytes(str);
                //byte[] isoBytes = Encoding.Convert(utf8, iso, utfbytes);
                //string textFinal = iso.GetString(isoBytes);
                //string textFinal = Encoding.Unicode.GetString(output);
                //byte[] isoBytes = Encoding.Convert(unicode, iso, output);
                string textFinal = RemoveInvalidXmlChars(iso.GetString(output));

                //string correctedText = Regex.Replace(textFinal, @"[^\u0000-\u007f]", string.Empty);
                //string stringWanted = correctedText.Replace("<", "&lt;")
                //                                   .Replace("&", "&amp;")
                //                                   .Replace(">", "&gt;")
                //                                   .Replace("\"", "&quot;")
                //                                      .Replace("'", "&apos;")
                //                                      .Replace("\u000f", "")
                //                                      .Replace("\u0002", "")
                //                                      .Replace("\u007f", "");
            

                proxy.AcquisitionEndpointClient sendToQueue = new proxy.AcquisitionEndpointClient();
                sendToQueue.Open();
                sendToQueue.acquisitionOperation(message.User_login, item, textFinal, message.App_token, namefile);
                sendToQueue.Close();


            }
        }

        /// <summary>
        /// Supprime les charactères invalide pour envoyer le message dans la queue JMS
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static string RemoveInvalidXmlChars(string text)
        {
            var validXmlChars = text.Where(ch => XmlConvert.IsXmlChar(ch)).ToArray();
            return new string(validXmlChars);
        }


    }
}
