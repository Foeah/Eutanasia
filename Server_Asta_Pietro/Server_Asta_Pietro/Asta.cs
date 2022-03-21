using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Threading;

namespace Server_Asta_Pietro
{
    internal class Asta
    {
        public string Name { get; private set; }
        List<Oggetto> elenco = new List<Oggetto>();
        Persona delegato;
        //int porta = 0;
        StreamWriter Writer;
        StreamReader Reader;

        public Asta(string nome, string n, string c, string t, string e)
        {
            Name = nome;
            delegato = new Persona(n, c, t, e);
        }
        public Asta() : this(string.Empty, string.Empty, string.Empty,string.Empty,string.Empty)
        { }

        public void AddItem(string nomeogg, string cod, string categ, string stato, double prez, int anni, string n, string c, string t, string e)
        {
            elenco.Add(new Oggetto(nomeogg, cod, categ, stato, prez, anni, n, c, t, e));
        }
        public Oggetto FindItem(string cod)
        {
            return elenco.Find(x => x.CodiceCatasto == cod);
        }
        public void DeleteItem(string cod)
        {
            elenco.Remove(FindItem(cod));
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
