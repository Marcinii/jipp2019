﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace converter
{
    public interface IConverter
    {
        string Name { get; }
        List<string> Units { get; }
        double Convert(string unitFrom, string unitTo, double value);
    }
}