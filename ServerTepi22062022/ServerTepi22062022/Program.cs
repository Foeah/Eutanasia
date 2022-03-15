using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;

namespace ServerTepi22062022
{
    /// Class responsible for creating each TCP connection inside a thread for every client whomst connects to 696969
    /// </summary>
    class InfoAsteThread
    {
        List<Asta> ListaAste;
        TcpClient client;
        int clientNumber;
        public InfoAsteThread(TcpClient client, int clientNumber, List<Asta> ListaAste)
        {
            this.client = client;
            this.clientNumber = clientNumber;
            Thread th = new Thread(new ThreadStart(this.GiveInfo));
            th.Start(); //il thread si autolancia
        }
        public void GiveInfo()
        {
            NetworkStream stream = client.GetStream();
            byte[] buf = new byte[256];
            foreach (Asta x in ListaAste)
            {
                buf = System.Text.Encoding.ASCII.GetBytes(x.ToString());
                stream.Write(buf, 0, buf.Length);
            }
            buf = System.Text.Encoding.ASCII.GetBytes("END");
            stream.Write(buf,0,buf.Length);
        }
    }
    class Program
    {
        static void InfoAsteBroadcaster(List<Asta> ListaAste)
        {
            IPAddress[] ip = Dns.GetHostAddresses(Dns.GetHostName());
            TcpListener s = new TcpListener(ip[0], 696969);
            int InfoAsteCounter = 0;
            s.Start();
            while (true)
            {
                TcpClient client = s.AcceptTcpClient();
                InfoAsteCounter++;
                new InfoAsteThread(client, InfoAsteCounter, ListaAste); //offload client info to thread creation class
            }
        }
        static void CreateAsteTcpListener(Asta asta)
        {
            IPAddress[] ip = Dns.GetHostAddresses(Dns.GetHostName());
            TcpListener s = new TcpListener(ip[0], asta.Porta);
            int InfoAsteCounter = 0;
            s.Start();
            while (true)
            {
                TcpClient client = s.AcceptTcpClient();
                InfoAsteCounter++;
                new InfoAste(client, InfoAsteCounter, ListaAste); //offload client info to thread creation class
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to NBay server version Alpha 0.1.a \n...Server is starting...\n\nLoading Auctions from XML...");
            //loading aste
            List<Asta> ListaAste = new List<Asta>();
            Console.WriteLine("Auctions Loaded!\nStarting Threads for each Auction...");
            foreach(Asta x in ListaAste)
            {
                x.
            }
            Console.WriteLine("Threads for each Auction Started!\nStarting InfoAsteBroadcaster Thread...");
            Thread InfoAsteGiver = new Thread(new ThreadStart(InfoAsteBroadcaster(ListaAste)));
            InfoAsteGiver.Start();
        }
    }
}
