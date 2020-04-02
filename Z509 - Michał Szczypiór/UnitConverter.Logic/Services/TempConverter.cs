using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace UnitCoverterPart2.Services
{
    public class ExampleConverter : IConverter
    {
        public string name => "Temperatury";
        public List<string> Jednostki => new List<string>(new[] { "C", "F", "K", "R" });
        public decimal C;
        public decimal F;
        public decimal K;
        public decimal R;
        public void FromC(decimal temp)
        {
            C = temp;
            F = (temp * 1.8m) + 32.0m;
            K = temp + 273.15m;
            R = (temp + 273.15m) * 1.8m;
        }
        public void FromF(decimal temp)
        {
            C = (temp - 32.0m) / 1.8m;
            F = temp;
            K = (temp + 459.67m) * 5.0m / 9.0m;
            R = temp + 459.67m;
        }
        public void FromK(decimal temp)
        {
            C = temp - 273.15m;
            F = (temp * 1.8m) - 459.67m;
            K = temp;
            R = (temp - 273.15m) * 1.8m + 491.67m;
        }
        public void FromR(decimal temp)
        {
            C = (temp + 1.8m) - 273.15m;
            F = temp - 459.67m;
            K = (temp - 491.67m) / 1.8m + 273.15m;
            R = temp;
        }
        public decimal Convert(string unitFrom, string unitTo, decimal value)
        {
            Type thisType = this.GetType();
            MethodInfo metoda = thisType.GetMethod("From" + unitFrom);
            metoda.Invoke(this, new object[] { value });
            return System.Convert.ToDecimal(thisType.GetField(unitTo).GetValue(this));
        }
    }
}
