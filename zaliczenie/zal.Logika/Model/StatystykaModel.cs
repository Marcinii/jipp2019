namespace zal.Logika.Model
{

    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using zal;
  

        public partial class StatystykaModel : DbContext
        {
            public StatystykaModel()
                : base("name=Statystyka")
            {
            }

        public virtual DbSet<Statystyka> statystyki { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
            }
        }
    }
