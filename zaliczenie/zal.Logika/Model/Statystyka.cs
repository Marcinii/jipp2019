
namespace zal.Logika.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

  public  class Statystyka
    {
        public int Id { get; set; }
        public DateTime? DateTime { get; set; }
        public string Type { get; set; }
        public string FromUnit { get; set; }
        public string FromTo { get; set; }
        public string RawValue { get; set; }
        public string ConvertedValue { get; set; }
    }
}
