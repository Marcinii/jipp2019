using System.Collections.Generic;

namespace UnitCoverterPart2
{
    public interface IStatisticsRepository
    {
        void AddStatistic(StatisticDTO statistic);
        IEnumerable<StatisticDTO> GetStatistics();
    }
}