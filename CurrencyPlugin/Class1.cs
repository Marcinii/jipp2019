using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ConverterLogic;

namespace CurrencyPlugin
{
    public class Plugin:Converter
    {
        name = "CurrencyPlugin";
        private string[] units = { "EUR", "PLN" };
        private double rate;
        
        public Plugin()
        {
            XmlReader rateReader = XmlReader.Create("http://api.nbp.pl/api/exchangerates/rates/A/EUR/");
            rateReader.MoveToContent();
            while (rateReader.Read())
            {
                if (rateReader.Name == "Mid")
                {
                    rate = double.Parse(rateReader.Value);
                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }
        public string [] Units
        {
            get
            {
                return units;
            }
        }
        public double FromEUR(double from)
        {
            return from * rate;
        }
        public double FromPLN(double from)
        {
            return from / rate;
        }
    }
}
