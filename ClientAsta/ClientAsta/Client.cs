using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ClientAsta
{
    class Client
    {
        private NetworkStream stream;
        private double budget;
        public double Budget
        {
            private set
            {
                budget = value;
            }
            get
            {
                return budget;
            }
        }

        public Client(double budget)
        {
            Budget = budget;
        }

        public void Attivita()
        {
            TcpClient client;
            try
            {
                client = new TcpClient(Dns.GetHostName(), 10100);
                stream = client.GetStream();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e.Message);
            }
        }

        public string OffertaMigliore()
        {
            string richiesta = "Offerta Migliore?";
            stream.Write(System.Text.Encoding.ASCII.GetBytes(richiesta), 0, richiesta.Length);
            byte[] rispostaB = new byte[256];
            int i = stream.Read(rispostaB, 0, rispostaB.Length);
            string offertaBest = System.Text.Encoding.ASCII.GetString(rispostaB, 0, i);
            return offertaBest;
        }
        //public string Rilanci(double offerta)     
        //{
        //   // string  rilanci = "Vuoi lanciare?";     //return 
        //    Console.WriteLine("Vuoi lanciare? Rispondi SI o NO");
        //    string risposta;
        //    if(risposta=="SI")
        //    {
        //        if (Budget < offerta)
        //            rilanci = "non sono possibili lanci";   //return 
        //        else
        //            stream.Write(System.Text.Encoding.ASCII.GetBytes(rilanci), 0, rilanci.Length);
        //        byte[] rispostaB = new byte[256];
        //        int i = stream.Read(rispostaB, 0, rispostaB.Length);
        //        string offertaBest = System.Text.Encoding.ASCII.GetString(rispostaB, 0, i);
        //        return offertaBest;          
        //}
    }

}
