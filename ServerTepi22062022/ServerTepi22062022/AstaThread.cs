using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;

namespace ServerTepi22062022
{
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
            Thread th = new Thread(new ThreadStart(this.MaintainConnection));
            th.Start(); //il thread si autolancia
        }
        public void MaintainConnection()
        {
            NetworkStream stream = client.GetStream();
            byte[] buf = new byte[256];
            bool astaAperta = true;
            while (astaAperta)
            {
                //fa le cose
            }
            stream.Close();
        }
    }
}
