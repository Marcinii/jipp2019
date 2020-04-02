using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

/* 
1. Convert freely between:
- Celsius
- Fahrenheit
- Kelvin
- Rankine

2. Convert lengths between:
- Metric
- Imperial
- Marinal

3. Convert mass between:
- Metreic
- Imperial
- Carat
- Quintal

We have 3 inputs: value(int), start(list), end(list)
We expect 1 output: converted(int)

---
class Converter(value, start, end):
    """
    Inputs:
    - value: input value
    - start: start unit
    - end: end unit
    """

    # we can either infer the property (mass, length, temperature) from the input values
    # ... or we add some navigation in the app and the property is derived from that

    def convert_temp():
        ...

    def convert_mass():
        ...

    def convert_length():
        ...
*/

namespace Converter
{
    class TemperatureConverter
    {
        public static string units = "Celsius, Fahrenheit, Kelvin";
        //public static string[] Units => units;
        public static double FahrenheitToCelcius(double start)
        {
            Console.WriteLine("getting somewhere " + start);
            double end = (start - 32) / 1.8;
            return end;
        }
        public static double CelsiusToFahrenheit(double start)
        {
            double end = start * 1.8F + 32;
            return end;
        }
        public static double CelsiusToKelvin(double start)
        {
            double end = start + 273.15;
            return end;
        }
        public static double KelvinToCelcius(double start)
        {
            double end = start - 273.15;
            return end;
        }
        public static double FahrenheitToKelvin(double start)
        {
            double end = (start + 459.67) * (5.00/9.00);
            return end;
        }
        public static double KelvinToFahrenheit(double start)
        {
            return (start * (9 / 5)) - 459.67;
        }
    }
    class MassConverter
    {
        public static string units =  "Kilograms, Pounds, Carats";
        public static double KilogramsToPounds(double start)
        {
            return start * 2.2046;
        }
        public static double KilogramsToCarat(double start)
        {
            return start / 5000;
        }
        public static double PoundsToKilograms(double start)
        {
            return start * 0.45359237;
        }
        public static double PoundsToCarat(double start)
        {
            return start / 2267.96185;
        }
        public static double CaratToKilograms(double start)
        {
            return start * 0.0002;
        }
        public static double CaratToPounds(double start)
        {
            return start * 0.00053584577614;
        }
    }
    class LengthConverter
    {
        public static string units =  "Kilometers, Miles, NautMiles";
        public static double KilometersToMiles(double start)
        {
            return start * 0.621371192;
        }
        public static double KilometersToNautMiles(double start)
        {
            return start * 0.539956803;
        }
        public static double MilesToKilometers(double start)
        {
            return start * 1.609344;
        }
        public static double MilesToNautMiles(double start)
        {
            return start * 0.868976242;
        }
        public static double NautMilesToKilometers(double start)
        {
            return start * 1.85200;
        }
        public static double NautMilesToMiles(double start)
        {
            return start * 1.15077945;
        }
    }
    /*
    public class Converter {
        static void Main(string[] args)
        {
            // valid temperature units of conversion
            IList<String> temperature_units = new List<String> { "F", "C", "K" };

            // new converter instance
            TemperatureConverter converter = new TemperatureConverter();

            converter.FahrenheitToCelcius(123);
        }
    }
   */
}
/*
        public double ConvertTemperature(int value, List<String> start_unit, List<String> end_unit) {
        if (string.Compare(this.start_unit,"F") and (end_unit = "C"); { this.FahrenheitToCelcius(value) };
        if (start_unit = "C") and (end_unit = "F"); { this.CelsiusToFahrenheit(value) };
        if (start_unit = "C") and (end_unit = "K"); { this.CelsiusToKelvin(value) };
        if (start_unit = "K") and (end_unit = "C"); { this.KelvinToCelsius(value) };
        if (start_unit = "F") and (end_unit = "K"); { this.FahrenheitToKelvin(value)};
        if (start_unit = "K") and (end_unit = "F"); { this.KelvinToFahrenheit(value)};
    }


    class converter
    {
        public double FahrenheitToCelcius (double start)
        {
            double end = (start - 32) / 1.8F;
            return end;
        }
        public double CelsiusToFahrenheit (double start)
        {
            double end = start * 1.8F + 32;
            return end;
        }
        public double CelsiusToKelvin (double start)
        {
            double end = start + 273.15F;
            return end;
        }
        public double KelvinToCelcius (double start)
        {
            double end = start - 273.15F;
            return end;
        }
        public double FahrenheitToKelvin (double start)
        {
            double end = (start + 459.67F) * (5 / 9);
            return end;
        }
        public double KelvinToFahrenheit (double start)
        {
            double end = (start * (9 / 5)) - 459.67F;
            return end;
        }
    }
}
*/