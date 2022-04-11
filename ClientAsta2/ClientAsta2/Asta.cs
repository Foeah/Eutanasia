using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;

namespace ClientAsta2
{
    //class Asta
    //{
    //    public string Nome { get; set; }
    //    public Oggetto Oggetto { get; set; }
    //    double baseAsta;
    //    double incrementoMinimo;
    //    int porta;
    //    public double BaseAsta 
    //    {
    //        set
    //        {
    //            if(value > 0)
    //            {
    //                baseAsta = value;
    //            }
    //            else
    //            {
    //                BaseAsta = 1;
    //            }
    //        }
    //        get { return baseAsta; }
    //    }
    //    public double IncrementoMinimo
    //    {
    //        set
    //        {
    //            if (value > 0)
    //            {
    //                IncrementoMinimo = value; 
    //            } 
    //            else
    //            {
    //                IncrementoMinimo=1; 
    //            } 
    //        } 
    //        get { return IncrementoMinimo; }  

    //    }
    //    public int Porta
    //    {
    //        set
    //        {
    //            if (value > 0)
    //            {
    //                porta = value;
    //            }
    //            else
    //            {
    //                porta = 696969;
    //            }
    //        }
    //        get { return porta; }
    //    }
    //    public Asta(string nome, Oggetto oggetto, double baseAsta, double incrementoMinimo, int porta)
    //    {
    //        Nome = nome;
    //        Oggetto=oggetto;
    //        BaseAsta=baseAsta; 
    //        IncrementoMinimo=incrementoMinimo; 
    //        Porta=porta;
    //    }
    //    public Asta(string xmlbyte)
    //    {
    //        string[] rawdata = xmlbyte.Split("<nome>", "</nome>", "<oggetto>", "</oggetto>", "<proprietario>", "</proprietario>", "<baseAsta>", "</baseAsta>", "<incrementoMinimo>", "</incrementoMinimo>", "<porta>", "</porta>");
    //        Nome = rawdata[0];
    //        Oggetto = new Oggetto(rawdata[1]);
    //        BaseAsta = Convert.ToDouble(rawdata[2]);
    //        incrementoMinimo = Convert.ToDouble(rawdata[3]);
    //        porta = Convert.ToInt32(rawdata[4]);
    //    }
    //    public string GetXMLstring()
    //    {
    //        return string.Format("<asta>\n"+
    //                             "\t<nome>{0}</nome>\n"+
    //                             "\t<oggetto>{1}</oggetto>\n"+
    //                             "\t<baseAsta>{2}</baseAsta>\n"+
    //                             "\t<incrementoMinimo>{3}</incrementoMinimo>\n"+
    //                             "\t<porta>{4}</porta>\n"+
    //                             "</asta>\n", Nome, Oggetto.GetXMLstring(), Proprietario.GetXMLstring(), baseAsta, incrementoMinimo, porta);
    //    }
    //}
}
