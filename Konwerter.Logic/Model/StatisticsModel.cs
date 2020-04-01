namespace Konwerter.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StatisticsModel : DbContext
    {
        public StatisticsModel()
            : base("name=StatisticsModel")
        {
        }

        public virtual DbSet<Statistic> Statistics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
