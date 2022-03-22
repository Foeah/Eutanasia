using System;
using System.Collections.Generic;
using System.Text;

namespace ServerTepi22062022
{
    class Oggetto
    {
        public string NomeOggetto { get; private set; }             //nome oggetto
        public string CodiceCatasto { get; private set; }           //codice univoco
        public string Categoria { get; private set; }               //categoria(casa, sport...)
        public string Stato { get; private set; }                   //nuovo o usato
        private double baseAsta;                                    //prezzo di base deciso dal proprieario
        public double BaseAsta
        {
            get { return baseAsta; }
            set
            {
                if (value > 0)
                    baseAsta = value;
                else
                    baseAsta = 1;
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
            Categoria = categ;
            Stato = stato;
            BaseAsta = prez;
            Anni = anni;
            owner = new Persona(n, c, t, e);
        }
        public Oggetto() : this(string.Empty, string.Empty, string.Empty, string.Empty, 0, 0, string.Empty, string.Empty, string.Empty, string.Empty)
        { }
        public string ToStampaAll()
        {
            return string.Format
                ("Oggetto: " + NomeOggetto + "\n" +
                "Codice catasto: " + CodiceCatasto + "\n" +
                "Categoria: " + Categoria + "\n" +
                "Stato: " + Stato + "\n" +
                "Base d'asta: " + BaseAsta + "\n" +
                "Anni: " + Anni + "\n" +
                "Proprietario ---> " + owner.ToStampa() + "\n\n\n"
                );
        }
        public string ToStampaItem()
        {
            return string.Format
                ("Oggetto: " + NomeOggetto + "\n" +
                "Codice catasto: " + CodiceCatasto + "\n" +
                "Categoria: " + Categoria + "\n" +
                "Stato: " + Stato + "\n" +
                "Base d'asta: " + BaseAsta + "\n" +
                "Anni: " + Anni + "\n"
                );
        }
        public string ToStampaItemXML()
        {
            return string.Format(
                "<nomeOggetto>" + NomeOggetto + "</nomeOggetto>" + "\n" +
                    "<codiceOggetto>" + CodiceCatasto + "</codiceOggetto>" + "\n" +
                    "<categoriaOggetto>" + Categoria + "</categoriaOggetto>" + "\n" +
                    "<statoOggetto>" + Stato + "</statoOggetto>" + "\n" +
                    "<prezzoOggetto>" + BaseAsta + "</prezzoOggetto>" + "\n" +
                    "<anniOggetto>" + Anni + "</anniOggetto>" + "\n" 
                );

        }
        public string ToStampaOwnerXML()
        {
            return string.Format(owner.ToStampaXML());
        }
        public string ToStampaOwner()
        {
            return string.Format(owner.ToStampa());
        }
    }
}
