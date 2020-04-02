using System.Collections.Generic;

namespace UnitsConverter.Services
{
    public interface IConverter
    {
        string Name { get; }
        List<string> Units { get; }
        decimal Convert(string FromCombobox, string ToCombobox, decimal valueFrom);
    }
}
