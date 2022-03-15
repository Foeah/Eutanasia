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
        public Persona(string nome, string cognome, string telefono, string email)
        {
            Nome = nome;
            Cognome = cognome;
            Tel = telefono;
            Email = email;
        }
        public Persona() : this(string.Empty, string.Empty, string.Empty, string.Empty)
        {

        }

        public string ToStampa()
        {
            return string.Format("Cognome: " + Cognome + ",Nome: " + Nome + ",Telefono: " + "Email: " + Email + "\n");
        }
    }
}
