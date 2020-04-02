using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitsConverter;
using UnitsConverter.Services;

namespace UnitsConverter.Model
{

        public class StatisticsSqlRepository : IStatisticsRepository
        {
            public void AddStatistic(StatisticDTO statistic)
            {
                using (StatisticsContext context = new StatisticsContext())
                {
                    context.Statistic.Add(new Statistic()
                    {
                        Type = statistic.Type,
                        DateTime = statistic.DateTime,
                        FromUnit = statistic.FromUnit,
                        FromTo = statistic.FromTo,
                        ConvertedValue = statistic.ConvertedValue
                    });

                    context.SaveChanges();
                }
            }



        public IEnumerable<StatisticDTO> GetStatistics()
        {
            using (StatisticsContext context = new StatisticsContext())
            {
                return context.Statistic.
                    Select(obj => new StatisticDTO() { DateTime = obj.DateTime, Type = obj.Type, FromUnit = obj.FromUnit, FromTo = obj.FromTo, ConvertedValue = obj.ConvertedValue }).
                    ToList();
            }



        }
        }
    }
