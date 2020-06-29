using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ServiceModel;
using Middleware.SVC;

namespace Server
{
    class Program
    {

        private static ServiceHost host;

        static void Main(string[] args)
        {
            Program.init_server();
        }

        static void init_server()
        {
            int i;
            Program.host = new ServiceHost(typeof(SVC));
            try
            {
                host.Open();
                Console.WriteLine("<--Serveur ouvert-->");
                

                for (i = 0; i < host.Description.Endpoints.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Description du service {0}", i);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Adresse : " + host.Description.Endpoints[i].Address);
                    Console.WriteLine("Binding : " + host.Description.Endpoints[i].Binding);
                    Console.WriteLine("Contract Type : " + host.Description.Endpoints[i].Contract.ContractType);
                    Console.WriteLine("Contract Name : " + host.Description.Endpoints[i].Contract.Name);
                    Console.WriteLine("Uri : " + host.Description.Endpoints[i].ListenUri.Host);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.Read();
            }
            finally
            {
                Console.WriteLine("<--Fin de l'initialisation-->");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n" + host.State.ToString());
                Console.Read();
            }
        }
    }
}
