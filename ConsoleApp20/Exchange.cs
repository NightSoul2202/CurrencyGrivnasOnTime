using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp20
{
    internal class Exchange
    {
        public int ID { get; set; }
        public string Currency { get; set; }
        public double Rate { get; set; }
        public string CC { get; set; }
        public override string ToString()
        {
            return $"{ID} : Назва валюти {Currency}; Курс : {Rate}₴; Абревіатура : {CC};";
        }
    }
}
