using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitCoverterPart2.Model;

namespace UnitCoverterPart2
{
    public class StatisticsSqlRepository: IStatisticsRepository
    {
        public void AddStatistic(StatisticDTO statistic)
        {
            using (StatisticsModel context = new StatisticsModel())
            {
                context.Statistics.Add(new Statistic()
                {
                    Type = statistic.Type,
                    DateTime = statistic.DateTime
                });

                context.SaveChanges();
            }
        }

        public IEnumerable<StatisticDTO> GetStatistics()
        {
            using (StatisticsModel context = new StatisticsModel())
            {
                return context.Statistics.
                    Select(obj => new StatisticDTO() { DateTime = obj.DateTime, Type = obj.Type }).
                    ToList();
            }
        }
    }
}
