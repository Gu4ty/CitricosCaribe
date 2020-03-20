﻿// <auto-generated />
using CitricosCaribe.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CitricosCaribe.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200316174209_AddMediosAsignadosTabla")]
    partial class AddMediosAsignadosTabla
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("CitricosCaribe.Models.BaseTransporte", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Direccion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("BasesTransportes");
                });

            modelBuilder.Entity("CitricosCaribe.Models.Direccion", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tipo")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Direcciones");
                });

            modelBuilder.Entity("CitricosCaribe.Models.Empresa", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Empresas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Empresa");
                });

            modelBuilder.Entity("CitricosCaribe.Models.Frigorifico", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Direccion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Frigorificos");
                });

            modelBuilder.Entity("CitricosCaribe.Models.Medio", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Medios");
                });

            modelBuilder.Entity("CitricosCaribe.Models.MedioAsignado", b =>
                {
                    b.Property<int>("TrabajadorID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MedioID")
                        .HasColumnType("INTEGER");

                    b.HasKey("TrabajadorID", "MedioID");

                    b.HasIndex("MedioID");

                    b.ToTable("MediosAsignados");
                });

            modelBuilder.Entity("CitricosCaribe.Models.Producto", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CaracteristicasTecnicas")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<string>("UnidadDeMedida")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("CitricosCaribe.Models.Trabajador", b =>
                {
                    b.Property<int>("CI")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cargo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Departamento")
                        .HasColumnType("TEXT");

                    b.Property<string>("GradoEscolar")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<double>("Sueldo")
                        .HasColumnType("REAL");

                    b.HasKey("CI");

                    b.ToTable("Trabajadores");
                });

            modelBuilder.Entity("CitricosCaribe.Models.Vehiculo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Marca")
                        .HasColumnType("TEXT");

                    b.Property<string>("Modelo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Motor")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Vehiculos");
                });

            modelBuilder.Entity("CitricosCaribe.Models.VehiculoAsignado", b =>
                {
                    b.Property<int>("VehiculoID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TrabajadorID")
                        .HasColumnType("INTEGER");

                    b.HasKey("VehiculoID");

                    b.HasIndex("TrabajadorID")
                        .IsUnique();

                    b.ToTable("VehiculosAsignados");
                });

            modelBuilder.Entity("CitricosCaribe.Models.EmpresaExtranjera", b =>
                {
                    b.HasBaseType("CitricosCaribe.Models.Empresa");

                    b.Property<string>("Pais")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("EmpresaExtranjera");
                });

            modelBuilder.Entity("CitricosCaribe.Models.EmpresaNacional", b =>
                {
                    b.HasBaseType("CitricosCaribe.Models.Empresa");

                    b.Property<string>("Provincia")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("EmpresaNacional");
                });

            modelBuilder.Entity("CitricosCaribe.Models.MedioAsignado", b =>
                {
                    b.HasOne("CitricosCaribe.Models.Medio", "Medio")
                        .WithMany("MedioAsignado")
                        .HasForeignKey("MedioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CitricosCaribe.Models.Trabajador", "Trabajador")
                        .WithMany("MedioAsignado")
                        .HasForeignKey("TrabajadorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CitricosCaribe.Models.VehiculoAsignado", b =>
                {
                    b.HasOne("CitricosCaribe.Models.Trabajador", "Trabajador")
                        .WithOne("VehiculoAsignado")
                        .HasForeignKey("CitricosCaribe.Models.VehiculoAsignado", "TrabajadorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CitricosCaribe.Models.Vehiculo", "Vehiculo")
                        .WithOne("VehiculoAsignado")
                        .HasForeignKey("CitricosCaribe.Models.VehiculoAsignado", "VehiculoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
