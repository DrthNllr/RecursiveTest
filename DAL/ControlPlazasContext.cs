using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RecursiveTest.Entities;
using RecursiveTest.Helpers;

namespace RecursiveTest.DAL
{
    public partial class ControlPlazasContext : DbContext
    {
        public ControlPlazasContext()
        {
        }

        public ControlPlazasContext(DbContextOptions<ControlPlazasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Plaza> Plazas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //Se sustituye la cadena de conexión del scaffolding por la guardada en App.json
                optionsBuilder.UseSqlServer(HelperConfiguration.GetAppConfiguration().ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plaza>(entity =>
            {
                entity.ToTable("Plaza");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CatPuesto)
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Horas).HasColumnType("decimal(4, 1)");

                entity.HasOne(d => d.PlazaOrigenNavigation)
                    .WithMany(p => p.InversePlazaOrigenNavigation)
                    .HasForeignKey(d => d.PlazaOrigen)
                    .HasConstraintName("FK__Plaza__PlazaOrig__24927208");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
