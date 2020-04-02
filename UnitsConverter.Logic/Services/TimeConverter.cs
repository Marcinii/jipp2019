using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitsConverter.Services
{
    class TimeConverter : IConverter
    {
        public string Name => "Czas";
        public List<string> Units => new List<string>(new[] { "dzień", "tydzień"});
        
        
        public decimal Convert(string unitFrom, string unitTo, decimal valueFrom)
        {

            if ( unitFrom == "dzień" && unitTo == "dzień")
                return valueFrom;
            else if (unitFrom == "dzień" && unitTo == "tydzień")
                return valueFrom/7;
            else if (unitFrom == "tydzień" && unitTo == "dzień")
                return valueFrom * 7;
            else if (unitFrom == "tydzień" && unitTo == "tydzień")
                return valueFrom;

            return 0;

        }

    }
}
