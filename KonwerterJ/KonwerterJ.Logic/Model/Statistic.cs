namespace KonwerterJ.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity.Spatial;

    public partial class Statistic
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> DateTime { get; set; }
        public string UnitFrom { get; set; }
        public string UnitTo { get; set; }
        public string RawValue { get; set; }
        public string ConvertedValue { get; set; }
        public string Type { get; set; }
    }
}
