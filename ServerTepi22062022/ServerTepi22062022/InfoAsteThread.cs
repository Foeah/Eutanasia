using System;
using System.Collections.Generic;
using System.Text;

namespace ServerTepi22062022
{
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
    /// <summary>
}
