using System.Collections.Generic;

namespace KonwerterJ.Services
{
    public interface IConverter
    {
        string Name { get; }
        List<string> Units { get; }
        decimal Convert(string unitFrom, string unitTo, decimal value);
    }
}