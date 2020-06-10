namespace FutbolAnalizWeb.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FutbolDb : DbContext
    {
        public FutbolDb()
            : base("name=FutbolDb")
        {
        }

        public virtual DbSet<Lig> Lig { get; set; }
        public virtual DbSet<Mac> Mac { get; set; }
        public virtual DbSet<Sezon> Sezon { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Takim> Takim { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lig>()
                .HasMany(e => e.Sezon)
                .WithRequired(e => e.Lig)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sezon>()
                .HasMany(e => e.Mac)
                .WithRequired(e => e.Sezon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Takim>()
                .HasMany(e => e.Mac)
                .WithRequired(e => e.Takim)
                .HasForeignKey(e => e.evTk_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Takim>()
                .HasMany(e => e.Mac1)
                .WithRequired(e => e.Takim1)
                .HasForeignKey(e => e.depTk_id)
                .WillCascadeOnDelete(false);
        }
    }
}
