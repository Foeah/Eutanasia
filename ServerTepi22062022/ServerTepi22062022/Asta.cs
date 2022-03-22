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
        double baseAsta;
        double incrementoMinimo;
        int porta;
        public double BaseAsta 
        {
            set
            {
                if(value > 0)
                {
                    baseAsta = value;
                }
                else
                {
                    BaseAsta = 1;
                }
            }
            get { return baseAsta; }
        }
        public double IncrementoMinimo
        {
            set
            {
                if (value > 0)
                {
                    IncrementoMinimo = value 
                } 
                else
                {
                    IncrementoMinimo=1; 
                } 
            } 
            get { return IncrementoMinimo; }  

        }
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
        public Asta(string nome, Oggetto oggetto, Persona proprietario, double baseAsta, double incrementoMinimo, int porta)
        {
            Name = nome;
            Oggetto=oggetto;
            Proprietario=proprietario; 
            BaseAsta=baseAsta; 
            IncrementoMinimo=incrementoMinimo; 
            Porta=porta; 
            


        }
        public void AddDelegato(string n, string c, string t, string e)
        {
            delegato = new Persona(n, c, t, e);
        }
        public string ToStampaAsta()
        {
            string s = "---------------------------------------------- " + Name.ToUpper() + "----------------------------------------------\n"+"DELEGATO:\n"+delegato.ToStampa()+"\n\n";
            foreach (Oggetto a in elenco)
                s += a.ToStampaAll();
            return s;
        }
        public string ToStampaAstaXML()
        {
            return string.Format("<nomeAsta>"+Name+"</nomeAsta"+"\n");
        }
        public void WriteFileXML()
        {
            Writer = new StreamWriter(File.Open(@"C:\Users\Pietro\Desktop\TEP\LAB\Server_Asta_Pietro\Server_Asta_Pietro\bin\Debug\file.xml", FileMode.Append));
            foreach (Oggetto a in elenco)
            {
                Writer.WriteLine(ToStampaAstaXML()+delegato.ToStampaXML()+a.ToStampaItemXML()+a.ToStampaOwnerXML()+"\n\r");
            }
            Writer.Close();
        }
        public string ReadFileXML()
        {
            try
            {
                Reader = new StreamReader(@"C:\Users\Pietro\Desktop\TEP\LAB\Server_Asta_Pietro\Server_Asta_Pietro\bin\Debug\file.xml");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            string s = Reader.ReadToEnd();
            Reader.Close();
            return string.Format(s);
        }
        
    }
    }
}
