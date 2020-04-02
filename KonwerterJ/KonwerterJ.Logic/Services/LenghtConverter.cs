using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJ.Services
{
    class LenghtConverter : IConverter
    {
        public string Name => "Długość";
        public List<string> Units => new List<string>(new[] { "mm", "cm", "dm", "m", "km", "cal", "stopa", "jard", "mila", "kabel", "mila morska" });
        public static string[] lengthUnits = new string[] { "mm", "cm", "dm", "m", "km", "cal", "stopa", "jard", "mila", "kabel", "mila morska" };
        public static decimal[] length = new decimal[] { 1000, 100, 10, 1, 0.001M, 39.3701M, 3.2808M, 1.0936M, 0.0006M, 0.0054M, 0.0006M };
        static decimal SelectUnit(string unit)
        {


            for (int i = 0; i < lengthUnits.Length; i++)
                if (unit == lengthUnits[i])
                    return length[i];
            return 0;
        }
        public decimal Convert(string unitFrom, string unitTo, decimal valueFrom)
        {

            return (valueFrom / SelectUnit(unitFrom)) * SelectUnit(unitTo);



        }
    }
}
