using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PentingtonRails.Models
{
    public partial class PentingtonRailsContext : DbContext
    {
        public PentingtonRailsContext()
        {
        }

        public PentingtonRailsContext(DbContextOptions<PentingtonRailsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarToConfig> CarToConfigs { get; set; }
        public virtual DbSet<Conductor> Conductors { get; set; }
        public virtual DbSet<Station> Stations { get; set; }
        public virtual DbSet<TrainConfig> TrainConfigs { get; set; }
        public virtual DbSet<TrainEngine> TrainEngines { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=ACEARL\\SQLEXPRESS;Initial Catalog=PentingtonRails;User ID=api;Password=GamerTime420");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(e => e.Notes).IsFixedLength(true);
            });

            modelBuilder.Entity<CarToConfig>(entity =>
            {
                entity.HasOne(d => d.Car)
                    .WithMany()
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CarToConfig_Cars");

                entity.HasOne(d => d.TrainConfigNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.TrainConfig)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CarToConfig_TrainConfig");
            });

            modelBuilder.Entity<Conductor>(entity =>
            {
                entity.Property(e => e.FirstName).IsFixedLength(true);

                entity.Property(e => e.LastName).IsFixedLength(true);
            });

            modelBuilder.Entity<Station>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).IsFixedLength(true);
            });

            modelBuilder.Entity<TrainConfig>(entity =>
            {
                entity.HasOne(d => d.ConductorNavigation)
                    .WithMany(p => p.TrainConfigs)
                    .HasForeignKey(d => d.Conductor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Conductors_TrainConfig");

                entity.HasOne(d => d.EngineNavigation)
                    .WithMany(p => p.TrainConfigs)
                    .HasForeignKey(d => d.Engine)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrainConfig_TrainEngines");
            });

            modelBuilder.Entity<TrainEngine>(entity =>
            {
                entity.Property(e => e.FuelType).IsFixedLength(true);
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.HasOne(d => d.Config)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.ConfigId)
                    .HasConstraintName("FK_Trip_TrainConfig1");

                entity.HasOne(d => d.DestinationNavigation)
                    .WithMany(p => p.TripDestinationNavigations)
                    .HasForeignKey(d => d.Destination)
                    .HasConstraintName("FK_Trip_TrainConfig");

                entity.HasOne(d => d.SourceNavigation)
                    .WithMany(p => p.TripSourceNavigations)
                    .HasForeignKey(d => d.Source)
                    .HasConstraintName("FK_Trip_Stations");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
