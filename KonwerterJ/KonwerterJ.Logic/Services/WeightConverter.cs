using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJ.Services
{
    class WeightConverter : IConverter
    {
        public string Name => "Waga";
        public List<string> Units => new List<string>(new[] { "mg", "g", "dkg", "kg", "T", "uncja", "funt", "karat", "kwintal" });

        static string[] weightUnits = new string[] { "mg", "g", "dkg", "kg", "T", "uncja", "funt", "karat", "kwintal" };
        static decimal[] weight = new decimal[] { 1000000, 1000, 100, 1, 0.001M, 35.273962M, 2.204623M, 4999.999985M, 0.01M };

        private static decimal SelectWeight(string unit)
        {


            for (int i = 0; i < weightUnits.Length; i++)
                if (unit == weightUnits[i])
                    return weight[i];
            return 0;
        }
        public decimal Convert(string unitFrom, string unitTo, decimal valueFrom)
        {
            return (valueFrom / SelectWeight(unitFrom)) * SelectWeight(unitTo);
        }
    }
}
