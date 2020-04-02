using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace UnitCoverterPart2.Services
{
    public class WeightConverter : IConverter
    {
        public string name => "Masy";
        public List<string> Jednostki => new List<string>(new[] { "mg", "g", "dag", "kg", "T", "Uncja", "Funt", "Karat", "Kwintal" });
        public decimal mg;
        public decimal g;
        public decimal dag;
        public decimal kg;
        public decimal T;
        public decimal Uncja;
        public decimal Funt;
        public decimal Karat;
        public decimal Kwintal;
        public void Frommg(decimal temp)
        {
            mg = temp;
            g = temp / 1000.0m;
            dag = temp / 10000.0m;
            kg = temp / 1000000.0m;
            T = temp / 1000000000.0m;
            Uncja = temp / 28349.523m;
            Funt = temp / 453592.37m;
            Karat = temp / 200.0m;
            Kwintal = temp / 100000000.0m;
        }
        public void Fromg(decimal temp)
        {
            mg = temp * 1000.0m;
            g = temp;
            dag = temp / 10.0m;
            kg = temp / 1000.0m;
            T = temp / 1000000.0m;
            Uncja = temp / 28.349523m;
            Funt = temp / 453.59237m;
            Karat = temp / 0.2m;
            Kwintal = temp / 100000.0m;
        }
        public void Fromdag(decimal temp)
        {
            mg = temp * 10000.0m;
            g = temp * 10.0m;
            dag = temp;
            kg = temp / 100.0m;
            T = temp / 100000.0m;
            Uncja = temp / 2.8349523m;
            Funt = temp / 45.359237m;
            Karat = temp / 0.02m;
            Kwintal = temp / 10000.0m;
        }
        public void Fromkg(decimal temp)
        {
            mg = temp * 1000000.0m;
            g = temp * 1000.0m;
            dag = temp * 100.0m;
            kg = temp;
            T = temp / 1000.0m;
            Uncja = temp / 0.028349523m;
            Funt = temp / 0.45359237m;
            Karat = temp / 0.0002m;
            Kwintal = temp / 100.0m;
        }
        public void FromT(decimal temp)
        {
            mg = temp * 1000000000.0m;
            g = temp * 1000000.0m;
            dag = temp * 10000.0m;
            kg = temp * 1000.0m;
            T = temp;
            Uncja = temp / 0.000028349523m;
            Funt = temp / 0.00045359237m;
            Karat = temp / 0.0000002m;
            Kwintal = temp / 0.1m;
        }
        public void FromUncja(decimal temp)
        {
            mg = temp * 28349.523m;
            g = temp * 28.349523m;
            dag = temp * 2.8349523m;
            kg = temp * 0.028349523m;
            T = temp * 0.000028349523m;
            Uncja = temp;
            Funt = (temp * 0.028349523m) / 0.45359237m;
            Karat = (temp * 0.028349523m) / 0.0002m;
            Kwintal = (temp * 0.028349523m) / 100.0m;
        }
        public void FromFunt(decimal temp)
        {
            mg = temp * 453592.37m;
            g = temp * 453.59237m;
            dag = temp * 45.359237m;
            kg = temp * 0.45359237m;
            T = temp * 0.00045359237m;
            Uncja = (temp * 0.45359237m) / 0.028349523m;
            Funt = temp;
            Karat = (temp * 0.45359237m) / 0.0002m;
            Kwintal = (temp * 453592.37m) / 100000000.0m;
        }
        public void FromKarat(decimal temp)
        {
            mg = temp * 200.0m;
            g = temp * 0.2m;
            dag = temp * 0.02m;
            kg = temp * 0.0002m;
            T = temp * 0.0000002m;
            Uncja = (temp * 0.0002m) / 0.028349523m;
            Funt = (temp * 0.0002m) / 0.45359237m;
            Karat = temp;
            Kwintal = (temp * 0.0002m) / 100.0m;
        }
        public void FromKwintal(decimal temp)
        {
            mg = temp * 100000000.0m;
            g = temp * 100000.0m;
            dag = temp * 10000.0m;
            kg = temp * 100.0m;
            T = temp * 0.1m;
            Uncja = (temp * 100.0m) / 0.028349523m;
            Funt = (temp * 100000000.0m) / 453592.37m;
            Karat = (temp * 100.0m) / 0.0002m;
            Kwintal = temp;
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
