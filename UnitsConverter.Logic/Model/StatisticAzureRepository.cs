using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitsConverter.Model;
using UnitsConverter;

namespace UnitsConverter.Model
{
   public class StatisticAzureRepository : IStatisticsRepository
    {
        
            private CloudTable table;

            public StatisticAzureRepository()
            {
           
                CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
                CloudTableClient client = storageAccount.CreateCloudTableClient();
                this.table = client.GetTableReference("StatisticsMarcinIwanowski");
                this.table.CreateIfNotExists();
            }

            public void AddStatistic(StatisticDTO statistic)
            {
                StatisticEntity entity = new StatisticEntity();
                entity.PartitionKey = string.Empty; // computer name;
                entity.RowKey = Guid.NewGuid().ToString();
                entity.Type = statistic.Type;
                entity.DateTime = statistic.DateTime;

                TableOperation insertOperation = TableOperation.Insert(entity);

                table.Execute(insertOperation);
            }

            public IEnumerable<StatisticDTO> GetStatistics()
            {
                TableQuery<StatisticEntity> query = new TableQuery<StatisticEntity>();

                return table.ExecuteQuery(query).Select(obj => new StatisticDTO() { DateTime = obj.DateTime, Type = obj.Type }).ToList();
            }
        }
    }

