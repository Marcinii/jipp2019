using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Services
{
    public class LengthConverter : IKonwerter
    {
        public string Name => "Długości";

        public List<string> Units => new List<string>(new[] { "m", "km" , "cm"});

        public decimal Convert(string startsValue, string endValue, decimal value)
        {
                       
            if (startsValue == "cm" && endValue =="m")
            {
                return value * 10; 
            }
            else if (startsValue == "cm" && endValue == "km")
            {
                return value * 10000;
            }
            else if (startsValue == "km" && endValue == "cm")
            {
                return value / 10000;
            }
            else if (startsValue == "km" && endValue == "m")
            {
                return value / 1000;
            }
            else if (startsValue == "m" && endValue == "cm")
            {
                return value / 10;
            }
            else if (startsValue == "m" && endValue == "km")
            {
                return value / 1000;
            }

            else
                return value;
        }
    }
    }

