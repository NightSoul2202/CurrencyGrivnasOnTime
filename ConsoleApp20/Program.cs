using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp20
{
    internal class Program
    {
        static string GetValueTag(XmlTextReader xml, string Tag)
        {
            while (xml.Read())
            {
                if (xml.NodeType == XmlNodeType.Element &&
                       xml.Name == Tag)
                {
                    xml.Read();
                    return xml.Value;
                }
            }
            return null;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;  
            List<Exchange> list = new List<Exchange>();

            using (XmlTextReader xml = new XmlTextReader("https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange"))
            {
                xml.WhitespaceHandling = WhitespaceHandling.None;
                while(xml.Read()) 
                {
                    
                    if (xml.NodeType == XmlNodeType.Element &&
                        xml.Name == "currency")
                    {
                        string rate;
                        Exchange exchange = new Exchange();
                        exchange.ID = Convert.ToInt32(GetValueTag(xml, "r030"));
                        exchange.Currency = GetValueTag(xml, "txt");
                        rate = GetValueTag(xml, "rate");
                        exchange.Rate = Convert.ToDouble(rate.Replace('.', ','));
                        if (exchange.Rate < 20)
                        {
                            continue;
                        }
                        exchange.CC = GetValueTag(xml, "cc");

                        list.Add(exchange);
                    }
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

            Console.ReadLine();
        }
    }
}
