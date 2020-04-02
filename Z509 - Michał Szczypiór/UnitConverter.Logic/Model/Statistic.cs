namespace UnitCoverterPart2.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Statistic
    {
        public int Id { get; set; }

        public DateTime? DateTime { get; set; }

        [StringLength(50)]
        public string UnitFrom { get; set; }

        [StringLength(50)]
        public string UnitTo { get; set; }

        public decimal? RawValue { get; set; }

        public decimal? ConvertedValue { get; set; }

        [StringLength(50)]
        public string Type { get; set; }
    }
}
