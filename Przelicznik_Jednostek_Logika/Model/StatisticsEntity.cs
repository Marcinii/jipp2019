﻿using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przelicznik_Jednostek.Model
{
    public class StatisticsEntity : TableEntity
    {
        public int Id { get; set; }

        public DateTime? DateTime { get; set; }
        public string UnitFrom { get; set; }
        public string UnitTo { get; set; }

        public string RawValue { get; set; }

        public string ConvertedValue { get; set; }
        public string Type { get; set; }
    }
}
