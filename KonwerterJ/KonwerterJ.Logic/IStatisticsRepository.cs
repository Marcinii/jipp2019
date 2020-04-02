using System.Collections.Generic;

namespace KonwerterJ.Model
{
    public interface IStatisticsRepository
    {
        void AddStatistic(StatisticDTO statistic);
        IEnumerable<StatisticDTO> GetStatistics();
    }
}