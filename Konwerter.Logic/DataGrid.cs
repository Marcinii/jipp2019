using System;

namespace Konwerter
{
    public class DataGrid
    {
       
        public DateTime? Date { get; set; }

        public string Log { get; set; }

        public DateTime? DateTime { get; set; }
        public string UnitFrom { get; set; }
        public string UnitTo { get; set; }

        public int? RawValue { get; set; }

        public int? ConvertedValue { get; set; }
        public string Type { get; set; }
    }
}