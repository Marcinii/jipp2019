using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitsConverter.Model
{
   public class StatisticsContext : DbContext
    {


        public StatisticsContext()
            : base("name=Statistic")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<StatisticsDTO>()
            //      .Property(e => e.Type)
            //      .IsUnicode(false);

            //modelBuilder.Entity<StatisticsDTO>()
            //    .Property(e => e.FromUnit)
            //    .IsUnicode(false);

            //modelBuilder.Entity<StatisticsDTO>()
            //    .Property(e => e.FromTo)
            //    .IsUnicode(false);

            //modelBuilder.Entity<StatisticsDTO>()
            //    .Property(e => e.RawValue)
            //    .IsUnicode(false);

            //modelBuilder.Entity<StatisticsDTO>()
            //    .Property(e => e.ConvertedValue)
            //    .IsUnicode(false);
        }

        public virtual DbSet<Statistic> Statistic { get; set; }
    }
}

