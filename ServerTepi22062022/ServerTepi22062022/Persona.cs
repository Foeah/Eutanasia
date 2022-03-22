using System;
using System.Collections.Generic;
using System.Text;

namespace ServerTepi22062022
{
    class Persona
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
        { }
        public string ToStampaXML()
        {
            return string.Format(
                "<nomeProprietario>" + Nome + "</nomeOggetto>" + "\n" +
                    "<cognomeProprietario>" + Cognome + "</cognomeOggetto>" + "\n" +
                    "<telefonoProprietario>" + Tel + "</telefonoOggetto>" + "\n" +
                    "<emailProprietario>" + Email + "</emailOggetto>" + "\n" 
                );
        }
        public string ToStampa()
        {
            return string.Format(Cognome + "  " + Nome + "    Tel: " + Tel + "  Email: " + Email + "\n");
        }
    }
}
