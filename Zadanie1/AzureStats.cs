using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace Zadanie1
{
    class Stat:TableEntity 
    {
        private string timestamp;
        private string fromUnit;
        private string toUnit;
        private double before;
        private double after;
        public void AssignRowKey()
        {
            this.RowKey = timestamp;
        }
        public void AssignPartitionKey()
        {
            this.PartitionKey = fromUnit + "-" + toUnit;
        }
        public string Timestamp
        {
            get
            {
                return timestamp;
            }
            set
            {
                timestamp = value;
            }
        }
        public string FromUnit
        {
            get
            {
                return fromUnit;
            }
            set
            {
                fromUnit = value;
            }
        }
        public string ToUnit
        {
            get
            {
                return toUnit;
            }
            set
            {
                toUnit = value;
            }
        }
        public double Before
        {
            get
            {
                return before;
            }
            set
            {
                before = value;
            }
        }
        public double After
        {
            get
            {
                return after;
            }
            set
            {
                after = value;
            }
        }
    }
}
