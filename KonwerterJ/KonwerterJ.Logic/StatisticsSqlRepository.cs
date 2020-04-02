using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonwerterJ.Model;

namespace KonwerterJ
{
    public class StatisticsSqlRepository : IStatisticsRepository
    {
        public void AddStatistic(StatisticDTO statistic)
        {
            using (StatisticsModel context = new StatisticsModel())
            {
                context.Statistics.Add(new Statistic()
                { 
                    Type = statistic.Type,
                    DateTime = statistic.DateTime,
                    UnitFrom = statistic.UnitFrom,
                    UnitTo = statistic.UnitTo,
                    ConvertedValue = statistic.ConvertedValue

                }) ;

                context.SaveChanges();
            }
        }

        public IEnumerable<StatisticDTO> GetStatistics()
        {
            using (StatisticsModel context = new StatisticsModel())
            {
                return context.Statistics.
                    Select(obj => new StatisticDTO() { DateTime = obj.DateTime, Type = obj.Type, UnitFrom = obj.UnitFrom, UnitTo = obj.UnitTo, ConvertedValue = obj.ConvertedValue }).
                    ToList();
            }
        }
    }
}
