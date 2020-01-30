﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;

namespace Converter
{
    public class ResultAzureRepository : ICalculationResultRepository
    {
        private CloudTable table;

        public ResultAzureRepository()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.table = client.GetTableReference("StatisticsAdrianZwolinski");
            this.table.CreateIfNotExistsAsync();
        }

        public async Task AddResult(CalculationResultDTO result)
        {
            CalculationResultEntity entity = new CalculationResultEntity();
            entity.PartitionKey = string.Empty; // computer name;
            entity.RowKey = Guid.NewGuid().ToString();
            entity.DateTime = result.CreatedAt;
            entity.UnitType = result.UnitType;
            entity.ToUnit = result.ToUnit;
            entity.FromValue = (double)result.FromValue;
            entity.FromUnit = result.FromUnit;
            entity.ToValue = (double)result.ToValue;

            TableOperation insertOperation = TableOperation.Insert(entity);

            await table.ExecuteAsync(insertOperation);
        }

        public async Task<List<CalculationResultDTO>> GetResults()
        {
            TableQuery<CalculationResultEntity> query = new TableQuery<CalculationResultEntity>();

            return table.ExecuteQuerySegmentedAsync(query,null).Result.Select(obj => new CalculationResultDTO()
            {
                FromValue = (decimal)obj.FromValue,
                ToValue = (decimal)obj.ToValue,
                FromUnit = obj.FromUnit,
                ToUnit = obj.ToUnit,
                CreatedAt = obj.DateTime,
                UnitType = obj.UnitType,
                Id = Guid.Parse(obj.RowKey)
            }).ToList();
        }
    }
}
