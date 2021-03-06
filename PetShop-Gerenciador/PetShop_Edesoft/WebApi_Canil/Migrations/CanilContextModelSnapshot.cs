// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi_Canil.Domains;

namespace WebApi_Canil.Migrations
{
    [DbContext(typeof(CanilContext))]
    partial class CanilContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113");

            modelBuilder.Entity("WebApi_Canil.Domains.Caes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Apelido")
                        .HasColumnName("apelido")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<int?>("IdRaca")
                        .HasColumnName("idRaca");

                    b.HasKey("Id");

                    b.HasIndex("IdRaca");

                    b.ToTable("Caes");
                });

            modelBuilder.Entity("WebApi_Canil.Domains.CaesDono", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int?>("IdCao")
                        .HasColumnName("idCao");

                    b.Property<int?>("IdDono")
                        .HasColumnName("idDono");

                    b.HasKey("Id");

                    b.HasIndex("IdCao");

                    b.HasIndex("IdDono");

                    b.ToTable("Caes_Dono");
                });

            modelBuilder.Entity("WebApi_Canil.Domains.Donos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Nome")
                        .HasColumnName("nome")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Donos");
                });

            modelBuilder.Entity("WebApi_Canil.Domains.Raca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Titulo")
                        .HasColumnName("titulo")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Raca");
                });

            modelBuilder.Entity("WebApi_Canil.Domains.Caes", b =>
                {
                    b.HasOne("WebApi_Canil.Domains.Raca", "IdRacaNavigation")
                        .WithMany("Caes")
                        .HasForeignKey("IdRaca")
                        .HasConstraintName("FK__Caes__idRaca__286302EC");
                });

            modelBuilder.Entity("WebApi_Canil.Domains.CaesDono", b =>
                {
                    b.HasOne("WebApi_Canil.Domains.Caes", "IdCaoNavigation")
                        .WithMany("CaesDono")
                        .HasForeignKey("IdCao")
                        .HasConstraintName("FK__Caes_Dono__idCao__2B3F6F97");

                    b.HasOne("WebApi_Canil.Domains.Donos", "IdDonoNavigation")
                        .WithMany("CaesDono")
                        .HasForeignKey("IdDono")
                        .HasConstraintName("FK__Caes_Dono__idDon__2C3393D0");
                });
#pragma warning restore 612, 618
        }
    }
}
