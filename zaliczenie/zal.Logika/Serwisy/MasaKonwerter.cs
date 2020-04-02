using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zal.Logika.Serwisy
{
    class MasaKonwerter : IConverter
    {
        public string Name => "Masa";
        public List<string> Units => new List<string>(new[] { "mg", "g", "dkg", "kg", "T", "uncja", "funt", "karat", "kwintal" });

        static string[] masaUnits = new string[] { "mg", "g", "dkg", "kg", "T", "uncja", "funt", "karat", "kwintal" };
        static decimal[] masa = new decimal[] { 1000000, 1000, 100, 1, 0.001M, 35.273962M, 2.204623M, 4999.999985M, 0.01M };

        private static decimal Selectmasa(string unit)
        {


            for (int i = 0; i < masaUnits.Length; i++)
                if (unit == masaUnits[i])
                    return masa[i];
            return 0;
        }
        public decimal Convert(string unitFrom, string unitTo, decimal valueFrom)
        {
            return (valueFrom / Selectmasa(unitFrom)) * Selectmasa(unitTo);
        }
    }
}
