using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Konwerter.Model;

namespace Konwerter
{
    public class Azure : Statistics
    {
        private CloudTable table;

        public Azure()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.table = client.GetTableReference("RafalMStatisctics");
            this.table.CreateIfNotExists();
        }

        public void AddStatistic(DataGrid statistic)
        {
            StatisticsEntity entity = new StatisticsEntity();
            entity.PartitionKey = string.Empty;
            entity.RowKey = Guid.NewGuid().ToString();
            entity.Type = statistic.Log;
            entity.DateTime = statistic.Date;

            TableOperation insertOperation = TableOperation.Insert(entity);

            table.Execute(insertOperation);
        }

        public IEnumerable<DataGrid> GetStatistics()
        {
            TableQuery<StatisticsEntity> query = new TableQuery<StatisticsEntity>();

            return table.ExecuteQuery(query).Select(obj => new DataGrid() { Date = obj.DateTime, Log = obj.Type }).ToList();

        }
    }
}
