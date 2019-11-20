﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.SDK
{
    public interface IConverter
    {
        string Name { get; }
        List<string> Units { get; }
        double Convert(string fromUnit, string toUnit, double convertedValue);
    }
}
