using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zal.Logika.Model
{
   public class StatystykaAzure : TableEntity
    {
        public string Type { get; set; }

        public DateTime? DateTime { get; set; }
        public string FromUnit { get; set; }
        public string FromTo { get; set; }
        public string RawValue { get; set; }
        public string ConvertedValue { get; set; }
    }
}
