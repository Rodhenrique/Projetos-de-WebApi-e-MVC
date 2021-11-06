using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApi_Canil.Domains
{
    public partial class CanilContext : DbContext
    {
        public CanilContext()
        {
        }

        public CanilContext(DbContextOptions<CanilContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Caes> Caes { get; set; }
        public virtual DbSet<CaesDono> CaesDono { get; set; }
        public virtual DbSet<Donos> Donos { get; set; }
        public virtual DbSet<Raca> Raca { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Caes>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apelido)
                    .HasColumnName("apelido")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdRaca).HasColumnName("idRaca");

                entity.HasOne(d => d.IdRacaNavigation)
                    .WithMany(p => p.Caes)
                    .HasForeignKey(d => d.IdRaca)
                    .HasConstraintName("FK__Caes__idRaca__286302EC");
            });

            modelBuilder.Entity<CaesDono>(entity =>
            {
                entity.ToTable("Caes_Dono");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCao).HasColumnName("idCao");

                entity.Property(e => e.IdDono).HasColumnName("idDono");

                entity.HasOne(d => d.IdCaoNavigation)
                    .WithMany(p => p.CaesDono)
                    .HasForeignKey(d => d.IdCao)
                    .HasConstraintName("FK__Caes_Dono__idCao__2B3F6F97");

                entity.HasOne(d => d.IdDonoNavigation)
                    .WithMany(p => p.CaesDono)
                    .HasForeignKey(d => d.IdDono)
                    .HasConstraintName("FK__Caes_Dono__idDon__2C3393D0");
            });

            modelBuilder.Entity<Donos>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Raca>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Titulo)
                    .HasColumnName("titulo")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
