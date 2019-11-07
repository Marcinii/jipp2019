﻿using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCoverterPart2.Model
{
    public class StatisticsEntity : TableEntity
    {
        public int Id { get; set; }

        public DateTime? DateTime { get; set; }

        public string UnitFrom { get; set; }

        public string UnitTo { get; set; }

        public string Type { get; set; }

        public int? RawValue { get; set; }

        public double? ConvertedValue { get; set; }
    }
}
