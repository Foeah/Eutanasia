using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_Asta_Pietro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Asta asta=new Asta();
            asta = new Asta("fakeBay", "Mario", "Vanni", "1616161616", "mariovanniking@mostrodifirenze.toscana");
            asta.AddItem("certificato DSA+ falso", "1", "scuola", "usato", 200, 1, "Albert", "Chiarafallas", "333-333-3334", "bragnarock@gmail.com");
            asta.AddItem("testosterone di gorilla", "2", "sport", "nuovo", 1000, 0, "Edward", "Gentle", "666-666-6667", "gambedipollo@gmail.com");
            //asta.WriteFileXML();
            Console.WriteLine(asta.ToStampaAsta());
            Console.WriteLine("\n\nCONTENUTO FILE XML:\n    |   |\n    V   V");
            Console.WriteLine(asta.ReadFileXML());

        }
    }
}
