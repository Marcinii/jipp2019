using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJ.Services
{
    class TemperatureConverter : IConverter
    {
        public string Name => "Temperatura";
        public List<string> Units => new List<string>(new[] { "C", "K", "F" });
        public decimal Convert(string FromCombobox, string ToCombobox, decimal value)
        {
            decimal Farenheit2Celcius(decimal fahrenheit) =>
         (fahrenheit - 32.0M) / 1.8M;
            decimal Celcius2Farenheit(decimal celsius) =>
              (celsius * 1.8M) + 32.0M;

            decimal Celsius2Kelvin(decimal celsius) =>
             celsius + 273.15M;

            decimal Kelvin2Celsius(decimal kelvin) =>
             kelvin - 273.15M;

            decimal Celsius2Rankie(decimal celsius) =>
              (celsius + 273.15M) * 1.8M;

            decimal Rankie2Celsius(decimal rankine) =>
              (rankine / 1.8M) - 273.15M;

            switch (FromCombobox)
            {
                case "C":
                    switch (ToCombobox)
                    {
                        case "K":
                            return Celsius2Kelvin(value);
                        case "F":
                            return Celcius2Farenheit(value);
                        case "R":
                            return Celsius2Rankie(value);
                    }
                    break;
                case "K":
                    switch (ToCombobox)
                    {
                        case "C":
                            return Kelvin2Celsius(value);
                        case "F":
                            return Celcius2Farenheit(Kelvin2Celsius(value));
                        case "R":
                            return Celsius2Rankie(Kelvin2Celsius(value));
                    }
                    break;
                case "F":
                    switch (ToCombobox)
                    {
                        case "C":
                            return Farenheit2Celcius(value);
                        case "K":
                            return Celsius2Kelvin(Farenheit2Celcius(value));
                        case "R":
                            return Celsius2Rankie(Farenheit2Celcius(value));
                    }
                    break;
                case "R":
                    switch (ToCombobox)
                    {
                        case "C":
                            return Rankie2Celsius(value);
                        case "K":
                            return Celsius2Kelvin(Rankie2Celsius(value));
                        case "F":
                            return Celcius2Farenheit(Rankie2Celsius(value));
                    }
                    break;

            }
            return 0;
        }


    }
}
