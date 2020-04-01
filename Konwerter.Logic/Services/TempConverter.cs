using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Services
{
    public class TempConverter : IKonwerter
    {
        public string Name => "Czas";

        public List<string> Units => new List<string>(new[] { "Bajt", "Terabajt" });

        public decimal Convert(string startValue, string endValue, decimal value)
        {

            if (startValue == "Bajt" && endValue == "Terabajt")
            {
                value= value/(10000000000000);
                return value;
            }

            else if (startValue == "Terabajt")
            {
                value = value * 10000000000000;
                return value;
            }
           

            else
                return value; 
            }

   
        
    }
}
