using System.Collections.Generic;

namespace Konwerter
{
    public interface Statistics
    {
        void AddStatistic(DataGrid statistic);
        IEnumerable<DataGrid> GetStatistics();
    }
}