using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;

namespace ServerTepi22062022
{
    internal class Persona
    {
        public string Nome { get; private set; }
        public string Cognome { get; private set; }
        public string Tel { get; private set; }
        public string Email { get; private set; }
        public Persona(string n, string c, string t, string e)
        {
            Nome = n;
            Cognome = c;
            Tel = t;
            Email = e;
        }
        public Persona() : this(string.Empty, string.Empty, string.Empty, string.Empty)
        {

        }

        public string ToStampa()
        {
            return string.Format("Cognome: " + Cognome + ",Nome: " + Nome + ",Telefono: " + "Email: " + Email + "\n");
        }
    }
    class Oggetto
    {
        public string NomeOggetto { get; private set; }             //nome oggetto
        public string CodiceCatasto { get; private set; }           //codice univoco
        public string Stato { get; private set; }                   //nuovo o usato
        private double prezzoBase; //prezzo di base deciso dal proprieario
        public double PrezzoBase
        {
            get { return prezzoBase; }
            set
            {
                if (prezzoBase > 0)
                    prezzoBase = value;
                else
                    prezzoBase = 1;
            }
        }
        private int anni;                                           //per sapere quanto tempo ha
        public int Anni
        {
            get { return anni; }
            set
            {
                if (anni > 0)
                    anni = value;
                else
                    anni = 1;
            }
        }
        Persona owner;
        /// <summary>
        /// Inserire nome,codice,categoria,stato,base,anni dell'oggetto,
        /// poi scrivere nome poprietario, tel e mail
        /// </summary>
        /// <param name="nomeogg"></param>
        /// <param name="cod"></param>
        /// <param name="categ"></param>
        /// <param name="stato"></param>
        /// <param name="prez"></param>
        /// <param name="anni"></param>
        /// <param name="nomeprop"></param>
        /// <param name="tel"></param>
        /// <param name="email"></param>
        public Oggetto(string nomeogg, string cod, string categ, string stato, double prez, int anni, string n, string c, string t, string e)
        {
            NomeOggetto = nomeogg;
            CodiceCatasto = cod;
            Stato = stato;
            PrezzoBase = prez;
            Anni = anni;
            owner = new Persona(n, c, t, e);
        }
        public Oggetto() : this(string.Empty, string.Empty, string.Empty, string.Empty, 0, 0, string.Empty, string.Empty, string.Empty, string.Empty)
        { }
    }
    class Asta
    {
        public string Name { get; private set; }
        Oggetto oggetto;
        Persona delegato;
        double BaseAsta;
        double incrementoMinimo;
        int porta;
        public int Porta{
            set {
                if (value > 0)
                {
                    porta = value;
                }
                else
                {
                    porta = 696969;
                }
            }
            get { return porta; }
        }
        public Asta(string nome, Oggetto oggetto, Persona delegato)
        {
            Name = nome;

        }

        public void AddDelegato(string n, string c, string t, string e)
        {
            delegato = new Persona(n, c, t, e);
        }
    }
    /// <summary>
    /// Class for creating a TCP connection within a thread for every client that connects to an Auction
    /// </summary>
    class AstaThread
    {
        TcpClient client;
        int clientNumber;
        public AstaThread(TcpClient client, int clientNumber)
        {
            this.client = client;
            this.clientNumber = clientNumber;
            Thread th = new Thread(new ThreadStart(this.GiveInfo));
            th.Start(); //il thread si autolancia
        }
        public void 
    }
    /// <summary>
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
