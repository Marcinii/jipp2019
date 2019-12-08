﻿namespace UnitConverter.SDK
{
    public interface IUnitConverter
    {
        string Type { get; }

        string Unit { get; }

        decimal ConvertToSI(decimal value);

        decimal ConvertFromSI(decimal value);
    }
}