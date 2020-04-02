using System.Collections.Generic;
using zal.Logika;

namespace zal
{
   public  interface IStatisticsRepository
    {
        void AddStatistic(StatisticDTO st);
        IEnumerable<StatisticDTO> GetStatistics();
    }
}