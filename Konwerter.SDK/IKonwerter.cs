using System.Collections.Generic;

namespace Konwerter.Services
{
    public interface IKonwerter
    {
        string Name { get; }
        List<string> Units { get; }
        decimal Convert(string unitFrom, string unitTo, decimal value);
    }
}