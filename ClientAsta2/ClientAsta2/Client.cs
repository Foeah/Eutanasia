using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ClientAsta2
{
    internal class Client
    {
        private NetworkStream stream;
        private NetworkStream stream2;

        public NetworkStream Stream { get; }
        public NetworkStream Stream2 { get; }

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
        public Client(double budget,NetworkStream nt)
        {
            Budget = budget;
            stream = nt;
        }

        public Client(NetworkStream nt, double budget)
        {
            Budget = budget;
            stream2 = nt;
        }
        public void Attivita()
        {
            TcpClient client;
            try
            {
                client = new TcpClient(Dns.GetHostName(), 696969);
                stream = client.GetStream();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e.Message);
            }
        }

        public void Attivita2(int numeroPorta)
        {
            TcpClient client;
            try
            {
                client = new TcpClient(Dns.GetHostName(), numeroPorta);
                stream2 = client.GetStream();
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
        public bool Rilanci(double offerta)
        {
            if (Budget < offerta || offerta<double.Parse(OffertaMigliore()))
                return false;
            else
            {
                Budget -= offerta;
                //NetworkStream streamAsta = NumeroDiPortaAsta(numeroPorta);
                byte[] offertaB = new byte[256];
                offertaB = System.Text.Encoding.ASCII.GetBytes(offerta.ToString());
                stream2.Write(offertaB, 0, offertaB.Length);
                return true;
            }
        }

        //public NetworkStream NumeroDiPortaAsta(int numeroPorta)
        //{
        //    TcpClient client2;
        //    NetworkStream stream2;
        //    try
        //    {
        //        client2 = new TcpClient(Dns.GetHostName(), numeroPorta);
        //        stream2 = client2.GetStream();
        //        return stream2;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("{0}", e.Message);
        //        return null;
        //    }
        //}

        public override string ToString()
        {
            return Budget.ToString() + "$" + stream.ToString();
        }

        public void ModificaBudget(double aggiunta)
        {
            Budget += aggiunta;
        }
    }
}
