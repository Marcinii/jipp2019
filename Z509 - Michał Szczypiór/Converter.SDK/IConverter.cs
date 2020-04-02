using System.Collections.Generic;

namespace UnitCoverterPart2.Services
{
    public interface IConverter
    {
        string name { get; }
        List<string> Jednostki { get; }
        decimal Convert(string unitFrom, string unitTo, decimal value);
    }
}