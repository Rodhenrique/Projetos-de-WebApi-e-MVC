using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Be3_Gerenciador.Domains
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pacientes> Pacientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pacientes>(entity =>
            {
                entity.HasIndex(e => e.Cpf)
                    .HasName("UQ__Paciente__C1F89731A677EC53")
                    .IsUnique();

                entity.Property(e => e.CarterinhaDoConvenio)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Convenio)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cpf)
                    .HasColumnName("CPF")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.DataDeNascimento)
                    .HasColumnName("Data de nascimento")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Genero)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Prontuario)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasColumnName("RG")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Sobrenome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Uf)
                    .IsRequired()
                    .HasColumnName("UF")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.ValidadeDaCarteirinha).HasColumnType("date");
            });
        }
    }
}
