using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace UnitCoverterPart2.Services
{
    public class LenghtConverter : IConverter
    {
        public string name => "Długości";
        public List<string> Jednostki => new List<string>(new[] { "mm", "cm", "dcm", "m", "km", "cal", "stopa", "jard", "mila", "kabel", "mila morska" });
        public decimal mm;
        public decimal cm;
        public decimal dcm;
        public decimal m;
        public decimal km;
        public decimal cal;
        public decimal stopa;
        public decimal jard;
        public decimal mila;
        public decimal kabel;
        public decimal mila_morska;
        public void Frommm(decimal temp)
        {
            cm = temp / 10m;
            dcm = temp / 100m;
            m = temp / 1000m;
            km = temp / 1000000m;
            cal = temp * 0.03937m;
            stopa = temp * 0.003281m;
            jard = temp * 0.001094m;
            mila = temp * 6.213699e-7m;
            kabel = temp * 0.000005m;
            mila_morska = temp * 5.399557e-7m;
            mm = temp;
        }
        public void Fromcm(decimal temp)
        {
            mm = temp * 10m;
            dcm = temp / 10m;
            m = temp / 100m;
            km = temp / 100000m;
            cal = temp * 0.393701m;
            stopa = temp * 0.032808m;
            jard = temp * 0.010936m;
            mila = temp * 0.000006m;
            kabel = temp * 0.000054m;
            mila_morska = temp * 0.000005m;
            cm = temp;
        }
        public void Fromdcm(decimal temp)
        {
            mm = temp * 100m;
            cm = temp * 10m;
            m = temp / 10m;
            km = temp / 10000m;
            cal = temp * 3.937008m;
            stopa = temp * 0.328084m;
            jard = temp * 0.109361m;
            mila = temp * 0.000062m;
            kabel = temp * 0.00054m;
            mila_morska = temp * 0.000054m;
            dcm = temp;
        }
        public void Fromm(decimal temp)
        {
            mm = temp * 1000m;
            cm = temp * 100m;
            dcm = temp * 10m;
            km = temp / 1000m;
            cal = temp * 39.370079m;
            stopa = temp * 3.28084m;
            jard = temp * 1.093613m;
            mila = temp * 0.000621m;
            kabel = temp * 0.0054m;
            mila_morska = temp * 0.00054m;
            m = temp;
        }
        public void Fromkm(decimal temp)
        {
            mm = temp * 1000000m;
            cm = temp * 100000m;
            dcm = temp * 10000m;
            m = temp * 1000m;
            cal = temp * 39370.07874m;
            stopa = temp * 3280.839895m;
            jard = temp * 1093.613298m;
            mila = temp * 0.621371m;
            kabel = temp * 5.399568m;
            mila_morska = temp * 0.539957m;
            km = temp;
        }
        public void Fromcal(decimal temp)
        {
            mm = temp * 25.4m;
            cm = temp * 2.54m;
            dcm = temp * 0.254m;
            m = temp * 0.0254m;
            km = temp * 0.000025m;
            stopa = temp * 0.083333m;
            jard = temp * 0.027778m;
            mila = temp * 0.000016m;
            kabel = temp * 0.000137m;
            mila_morska = temp * 0.000014m;
            cal = temp;
        }
        public void Fromstopa(decimal temp)
        {
            mm = temp * 304.8m;
            cm = temp * 30.48m;
            dcm = temp * 3.048m;
            m = temp * 0.3048m;
            km = temp * 0.000305m;
            cal = temp * 12m;
            jard = temp * 0.027778m;
            mila = temp * 0.000016m;
            kabel = temp * 0.000137m;
            mila_morska = temp * 0.000014m;
            stopa = temp;
        }
        public void Fromjard(decimal temp)
        {
            mm = temp * 914.4m;
            cm = temp * 91.44m;
            dcm = temp * 9.144m;
            m = temp * 0.9144m;
            km = temp * 0.000914m;
            cal = temp * 36m;
            stopa = temp * 3m;
            mila = temp * 1m;
            kabel = temp * 0.004937m;
            mila_morska = temp * 0.000494m;
            jard = temp;
        }
        public void Frommila(decimal temp)
        {
            mm = temp * 1609344m;
            cm = temp * 160934.4m;
            dcm = temp * 16093.44m;
            m = temp * 1609.344m;
            km = temp * 1.609344m;
            cal = temp * 63360m;
            stopa = temp * 5280m;
            jard = temp * 1760m;
            kabel = temp * 8.689762m;
            mila_morska = temp * 0.868976m;
            mila = temp;
        }
        public void Fromkabel(decimal temp)
        {
            mm = temp * 185200m;
            cm = temp * 18520m;
            dcm = temp * 1852m;
            m = temp * 185.2m;
            km = temp * 0.1852m;
            cal = temp * 7291.338583m;
            stopa = temp * 607.611549m;
            jard = temp * 202.537183m;
            mila = temp * 0.115078m;
            mila_morska = temp * 0.1m;
            kabel = temp;
        }
        public void Frommila_morska(decimal temp)
        {
            mm = temp * 1852000m;
            cm = temp * 185200m;
            dcm = temp * 18520m;
            m = temp * 1852m;
            km = temp * 1.852m;
            cal = temp * 72913.385827m;
            stopa = temp * 6076.115486m;
            jard = temp * 2025.371829m;
            mila = temp * 1.150779m;
            kabel = temp * 10m;
            mila_morska = temp;
        }
        public decimal Convert(string unitFrom, string unitTo, decimal value)
        {
            Type thisType = this.GetType();
            if (unitFrom == "mila morska")
                unitFrom = "mila_morska";
            if (unitTo == "mila morska")
                unitTo = "mila_morska";
            MethodInfo metoda = thisType.GetMethod("From" + unitFrom);
            
            metoda.Invoke(this, new object[] { value });
            return System.Convert.ToDecimal(thisType.GetField(unitTo).GetValue(this));
        }
    }
}
