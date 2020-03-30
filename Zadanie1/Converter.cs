using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

namespace Zadanie1
{
    class TemperatureConverter
    {
        public float FarenheitToCelcius(float start)
        {
            Console.WriteLine("getting somewhere " + start);
            float end = (start - 32) / 1.8F;
            return end;
        }
        public float CelsiusToFarenheit(float start)
        {
            float end = start * 1.8F + 32;
            return end;
        }
        private float CelsiusToKelvin(float start)
        {
            float end = start + 273.15F;
            return end;
        }
        private float KelvinToCelcius(float start)
        {
            float end = start - 273.15F;
            return end;
        }
        private float FahrenheitToKelvin(float start)
        {
            float end = (start + 459.67F) * (5 / 9);
            return end;
        }
        private float KelvinToFarenheit(float start)
        {
            return (start * (9 / 5)) - 459.67F;
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

            converter.FarenheitToCelcius(123);
        }
    }
   */
}
/*
        public float ConvertTemperature(int value, List<String> start_unit, List<String> end_unit) {
        if (string.Compare(this.start_unit,"F") and (end_unit = "C"); { this.FahrenheitToCelcius(value) };
        if (start_unit = "C") and (end_unit = "F"); { this.CelsiusToFarenheit(value) };
        if (start_unit = "C") and (end_unit = "K"); { this.CelsiusToKelvin(value) };
        if (start_unit = "K") and (end_unit = "C"); { this.KelvinToCelsius(value) };
        if (start_unit = "F") and (end_unit = "K"); { this.FahrenheitToKelvin(value)};
        if (start_unit = "K") and (end_unit = "F"); { this.KelvinToFahrenheit(value)};
    }


    class converter
    {
        public float FahrenheitToCelcius (float start)
        {
            float end = (start - 32) / 1.8F;
            return end;
        }
        public float CelsiusToFarenheit (float start)
        {
            float end = start * 1.8F + 32;
            return end;
        }
        public float CelsiusToKelvin (float start)
        {
            float end = start + 273.15F;
            return end;
        }
        public float KelvinToCelcius (float start)
        {
            float end = start - 273.15F;
            return end;
        }
        public float FahrenheitToKelvin (float start)
        {
            float end = (start + 459.67F) * (5 / 9);
            return end;
        }
        public float KelvinToFarenheit (float start)
        {
            float end = (start * (9 / 5)) - 459.67F;
            return end;
        }
    }
}
*/