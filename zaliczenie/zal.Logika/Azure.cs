using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zal.Logika.Model;

namespace zal.Logika
{
  public  class Azure : IStatisticsRepository
    {
        private CloudTable table;
        public Azure()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.table = client.GetTableReference("konwert123");
            this.table.CreateIfNotExists();
        }

        public void AddStatistic(StatisticDTO statistic)
        {
            StatystykaAzure entity = new StatystykaAzure();
            entity.PartitionKey = string.Empty; // computer name;
            entity.RowKey = Guid.NewGuid().ToString();
            entity.DateTime = statistic.DateTime;
            entity.Type = statistic.Type;
            entity.FromUnit = statistic.FromUnit;
            entity.FromTo = statistic.FromTo;
            entity.RawValue = statistic.RawValue;
            entity.ConvertedValue = statistic.ConvertedValue;


            TableOperation insertOperation = TableOperation.Insert(entity);

            table.Execute(insertOperation);
        }

        public IEnumerable<StatisticDTO> GetStatistics()
        {
            TableQuery<StatystykaAzure> query = new TableQuery<StatystykaAzure>();

            return table.ExecuteQuery(query).Select(obj => new StatisticDTO() { DateTime = obj.DateTime, Type = obj.Type, FromUnit = obj.FromUnit, FromTo = obj.FromTo, RawValue = obj.RawValue, ConvertedValue = obj.ConvertedValue }).ToList();
        }
    }
}
