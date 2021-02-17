using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace edmi_meters_backend.Models
{
    public partial class EdmiMeterDBContext : DbContext
    {
        public EdmiMeterDBContext()
        {
        }

        public EdmiMeterDBContext(DbContextOptions<EdmiMeterDBContext> options)
            : base(options)
        {
        }


        public virtual DbSet<ElectricMeter> ElectricMeter { get; set; }
        public virtual DbSet<Gateways> Gateways { get; set; }
        public virtual DbSet<WaterMeter> WaterMeter { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseMySQL(Configuration.GetConnectionString("EdmiMeterContext"));
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ElectricMeter>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.FirmwareVersion)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Serial).HasColumnType("int(11)");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Gateways>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.FirmwareVersion)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Ip)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Port)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Serial).HasColumnType("int(11)");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<WaterMeter>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.FirmwareVersion)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Serial).HasColumnType("int(11)");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
