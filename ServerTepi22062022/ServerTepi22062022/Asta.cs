using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;

namespace ServerTepi22062022
{
    class Asta
    {
        public string Name { get; private set; }
        Oggetto oggetto;
        Persona delegato;
        double BaseAsta;
        double incrementoMinimo;
        int porta;
        public int Porta
        {
            set
            {
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
}
