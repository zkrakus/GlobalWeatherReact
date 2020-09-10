using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Weather.Persistence.Models;

namespace Weather.Persistence
{
    public partial class WeatherDbContext : DbContext
    {
        public WeatherDbContext()
        {
        }

        public WeatherDbContext(DbContextOptions<WeatherDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(255);

                entity.Property(e => e.CountryId)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
