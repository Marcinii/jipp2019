namespace Konwerter.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;


    public partial class Statistic
    {
        public int Id { get; set; }

        public DateTime? DateTime { get; set; }

        [StringLength(50)]
        public string UnitFrom { get; set; }

        [StringLength(50)]
        public string UnitTo { get; set; }

        public int? RawValue { get; set; }

        public int? ConvertedValue { get; set; }

        [StringLength(50)]
        public string Type { get; set; }
    }
}
