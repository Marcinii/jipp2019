using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zal.Logika.Model;

namespace zal.Logika
{
  
          public class BazaDanych : IStatisticsRepository
        {
            public void AddStatistic(StatisticDTO statistic)
            {
                using (StatystykaModel context = new StatystykaModel())
                {
                    context.statystyki.Add(new Statystyka()
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
                using (StatystykaModel context = new StatystykaModel())
                {
                    return context.statystyki.
                        Select(obj => new StatisticDTO() { DateTime = obj.DateTime, Type = obj.Type, FromUnit = obj.FromUnit, FromTo = obj.FromTo, ConvertedValue = obj.ConvertedValue }).
                        ToList();
                }



            }
        }
    }
