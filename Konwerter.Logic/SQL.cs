using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Konwerter.Model;

namespace Konwerter
{
    public class SQL : Statistics
    {
        public void AddStatistic(DataGrid statistic)
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

        public IEnumerable<DataGrid> GetStatistics()
        {
            using (StatisticsModel context = new StatisticsModel())
            {
                return context.Statistics.
                    Select(obj => new DataGrid() { DateTime = obj.DateTime, Type = obj.Type }).
                    ToList();
            }
        }
    }
}
