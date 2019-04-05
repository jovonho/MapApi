using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MapApi.Models
{
    public partial class mtlosmContext : DbContext
    {
        public mtlosmContext()
        {
        }

        public mtlosmContext(DbContextOptions<mtlosmContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Amenities> Amenities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;database=mtlosm;user=dotnetApp;password=12345");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Amenities>(entity =>
            {
                entity.ToTable("amenities");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(13)");

                entity.Property(e => e.Amenity)
                    .HasColumnName("amenity")
                    .HasColumnType("text");

                entity.Property(e => e.Lat)
                    .HasColumnName("lat")
                    .HasColumnType("decimal(10,7)");

                entity.Property(e => e.Lon)
                    .HasColumnName("lon")
                    .HasColumnType("decimal(11,7)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("text");

                entity.Property(e => e.Pt)
                    .HasColumnName("pt")
                    .HasColumnType("point");
            });
        }
    }
}
