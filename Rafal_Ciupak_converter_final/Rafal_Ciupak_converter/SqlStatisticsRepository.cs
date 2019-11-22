﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafal_Ciupak_converter
{
    class SqlStatisticsRepository : IRepository<StatisticsEntryDto>
    {
        public IEnumerable<StatisticsEntryDto> GetAll()
        {
            using (var db = new ConvDatabase())
            {
                return db.Events.Select(x => new StatisticsEntryDto(x.date, x.from, x.to, x.fromValue, x.resultValue)).ToList();
            }
        }
        public void Save(StatisticsEntryDto dto)
        {
            using (var db = new ConvDatabase())
            {
                db.Events.Add(new Event(1, dto.date, dto.from, dto.to, dto.fromValue, dto.resultValue));
                db.SaveChanges();
            }
        }
    }
}
