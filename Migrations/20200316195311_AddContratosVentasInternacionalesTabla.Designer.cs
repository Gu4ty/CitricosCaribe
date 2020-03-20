﻿// <auto-generated />
using System;
using CitricosCaribe.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CitricosCaribe.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200316195311_AddContratosVentasInternacionalesTabla")]
    partial class AddContratosVentasInternacionalesTabla
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

            modelBuilder.Entity("CitricosCaribe.Models.ContratoCompraInternacional", b =>
                {
                    b.Property<int>("EmpresaID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TrabajadorID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductoID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaContrato")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaOferta")
                        .HasColumnType("TEXT");

                    b.Property<string>("CamposOtros")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeAmbasPartes")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeLaOtraParte")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeUnaParte")
                        .HasColumnType("TEXT");

                    b.Property<double>("DineroGanadoUSD")
                        .HasColumnType("REAL");

                    b.Property<string>("ObjetoDelContrato")
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoPago")
                        .HasColumnType("TEXT");

                    b.HasKey("EmpresaID", "TrabajadorID", "ProductoID", "FechaContrato", "FechaOferta");

                    b.HasIndex("ProductoID");

                    b.HasIndex("TrabajadorID");

                    b.ToTable("ContratosComprasInternacionales");
                });

            modelBuilder.Entity("CitricosCaribe.Models.ContratoVentaInternacional", b =>
                {
                    b.Property<int>("EmpresaID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TrabajadorID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductoID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaContrato")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaPedido")
                        .HasColumnType("TEXT");

                    b.Property<string>("CamposOtros")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeAmbasPartes")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeLaOtraParte")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeUnaParte")
                        .HasColumnType("TEXT");

                    b.Property<double>("DineroGanadoUSD")
                        .HasColumnType("REAL");

                    b.Property<string>("ObjetoDelContrato")
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoPago")
                        .HasColumnType("TEXT");

                    b.HasKey("EmpresaID", "TrabajadorID", "ProductoID", "FechaContrato", "FechaPedido");

                    b.HasIndex("ProductoID");

                    b.HasIndex("TrabajadorID");

                    b.ToTable("ContratosVentasInternacionales");
                });

            modelBuilder.Entity("CitricosCaribe.Models.ContratoVentaNacional", b =>
                {
                    b.Property<int>("EmpresaID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TrabajadorID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductoID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaContrato")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaSolicitud")
                        .HasColumnType("TEXT");

                    b.Property<string>("CamposOtros")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeAmbasPartes")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeLaOtraParte")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeUnaParte")
                        .HasColumnType("TEXT");

                    b.Property<double>("DineroGanadoUSD")
                        .HasColumnType("REAL");

                    b.Property<string>("ObjetoDelContrato")
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoPago")
                        .HasColumnType("TEXT");

                    b.HasKey("EmpresaID", "TrabajadorID", "ProductoID", "FechaContrato", "FechaSolicitud");

                    b.HasIndex("ProductoID");

                    b.HasIndex("TrabajadorID");

                    b.ToTable("ContratosVentasNacionales");
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

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.HasKey("TrabajadorID", "MedioID");

                    b.HasIndex("MedioID");

                    b.ToTable("MediosAsignados");
                });

            modelBuilder.Entity("CitricosCaribe.Models.Oferta", b =>
                {
                    b.Property<int>("ProductoID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EmpresaID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaOferta")
                        .HasColumnType("TEXT");

                    b.Property<string>("Calidad")
                        .HasColumnType("TEXT");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Origen")
                        .HasColumnType("TEXT");

                    b.Property<string>("PuertoDestino")
                        .HasColumnType("TEXT");

                    b.Property<string>("PuertoOrigen")
                        .HasColumnType("TEXT");

                    b.HasKey("ProductoID", "EmpresaID", "FechaOferta");

                    b.HasIndex("EmpresaID");

                    b.ToTable("Ofertas");
                });

            modelBuilder.Entity("CitricosCaribe.Models.Pedido", b =>
                {
                    b.Property<int>("ProductoID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EmpresaID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaOferta")
                        .HasColumnType("TEXT");

                    b.Property<string>("Calidad")
                        .HasColumnType("TEXT");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Presupuesto")
                        .HasColumnType("REAL");

                    b.Property<string>("TipoDeDivisas")
                        .HasColumnType("TEXT");

                    b.HasKey("ProductoID", "EmpresaID", "FechaOferta");

                    b.HasIndex("EmpresaID");

                    b.ToTable("Pedidos");
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

            modelBuilder.Entity("CitricosCaribe.Models.Solicitud", b =>
                {
                    b.Property<int>("ProductoID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EmpresaID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaOferta")
                        .HasColumnType("TEXT");

                    b.Property<string>("Calidad")
                        .HasColumnType("TEXT");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Presupuesto")
                        .HasColumnType("REAL");

                    b.HasKey("ProductoID", "EmpresaID", "FechaOferta");

                    b.HasIndex("EmpresaID");

                    b.ToTable("Solicitudes");
                });

            modelBuilder.Entity("CitricosCaribe.Models.TipoDireccionBaseTransporte", b =>
                {
                    b.Property<int>("BaseTransporteID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DireccionID")
                        .HasColumnType("INTEGER");

                    b.HasKey("BaseTransporteID", "DireccionID");

                    b.HasIndex("BaseTransporteID")
                        .IsUnique();

                    b.HasIndex("DireccionID");

                    b.ToTable("TipoDireccionBaseTransportes");
                });

            modelBuilder.Entity("CitricosCaribe.Models.TipoDireccionFrigorifico", b =>
                {
                    b.Property<int>("FrigorificoID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DireccionID")
                        .HasColumnType("INTEGER");

                    b.HasKey("FrigorificoID");

                    b.HasIndex("DireccionID");

                    b.ToTable("TipoDireccionFrigorificos");
                });

            modelBuilder.Entity("CitricosCaribe.Models.TipoDireccionTrabajador", b =>
                {
                    b.Property<int>("DireccionID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TrabajadorID")
                        .HasColumnType("INTEGER");

                    b.HasKey("DireccionID", "TrabajadorID");

                    b.HasIndex("TrabajadorID")
                        .IsUnique();

                    b.ToTable("TipoDireccionTrabajadores");
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

            modelBuilder.Entity("CitricosCaribe.Models.ContratoCompraInternacional", b =>
                {
                    b.HasOne("CitricosCaribe.Models.Empresa", "Empresa")
                        .WithMany("ContratoCompraInternacionales")
                        .HasForeignKey("EmpresaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CitricosCaribe.Models.Producto", "Producto")
                        .WithMany("ContratoCompraInternacionales")
                        .HasForeignKey("ProductoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CitricosCaribe.Models.Trabajador", "Trabajador")
                        .WithMany("ContratoCompraInternacionales")
                        .HasForeignKey("TrabajadorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CitricosCaribe.Models.ContratoVentaInternacional", b =>
                {
                    b.HasOne("CitricosCaribe.Models.Empresa", "Empresa")
                        .WithMany("ContratoVentaInternacionales")
                        .HasForeignKey("EmpresaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CitricosCaribe.Models.Producto", "Producto")
                        .WithMany("ContratoVentaInternacionales")
                        .HasForeignKey("ProductoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CitricosCaribe.Models.Trabajador", "Trabajador")
                        .WithMany("ContratoVentaInternacionales")
                        .HasForeignKey("TrabajadorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CitricosCaribe.Models.ContratoVentaNacional", b =>
                {
                    b.HasOne("CitricosCaribe.Models.Empresa", "Empresa")
                        .WithMany("ContratoVentaNacionales")
                        .HasForeignKey("EmpresaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CitricosCaribe.Models.Producto", "Producto")
                        .WithMany("ContratoVentaNacionales")
                        .HasForeignKey("ProductoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CitricosCaribe.Models.Trabajador", "Trabajador")
                        .WithMany("ContratoVentaNacionales")
                        .HasForeignKey("TrabajadorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("CitricosCaribe.Models.Oferta", b =>
                {
                    b.HasOne("CitricosCaribe.Models.Empresa", "Empresa")
                        .WithMany("Ofertas")
                        .HasForeignKey("EmpresaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CitricosCaribe.Models.Producto", "Producto")
                        .WithMany("Ofertas")
                        .HasForeignKey("ProductoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CitricosCaribe.Models.Pedido", b =>
                {
                    b.HasOne("CitricosCaribe.Models.Empresa", "Empresa")
                        .WithMany("Pedidos")
                        .HasForeignKey("EmpresaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CitricosCaribe.Models.Producto", "Producto")
                        .WithMany("Pedidos")
                        .HasForeignKey("ProductoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CitricosCaribe.Models.Solicitud", b =>
                {
                    b.HasOne("CitricosCaribe.Models.Empresa", "Empresa")
                        .WithMany("Solicitudes")
                        .HasForeignKey("EmpresaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CitricosCaribe.Models.Producto", "Producto")
                        .WithMany("Solicitudes")
                        .HasForeignKey("ProductoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CitricosCaribe.Models.TipoDireccionBaseTransporte", b =>
                {
                    b.HasOne("CitricosCaribe.Models.BaseTransporte", "BaseTransporte")
                        .WithOne("TipoDireccionBaseTransporte")
                        .HasForeignKey("CitricosCaribe.Models.TipoDireccionBaseTransporte", "BaseTransporteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CitricosCaribe.Models.Direccion", "Direccion")
                        .WithMany("TipoDireccionBaseTransportes")
                        .HasForeignKey("DireccionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CitricosCaribe.Models.TipoDireccionFrigorifico", b =>
                {
                    b.HasOne("CitricosCaribe.Models.Direccion", "Direccion")
                        .WithMany("TipoDireccionFrigorificos")
                        .HasForeignKey("DireccionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CitricosCaribe.Models.Frigorifico", "Frigorifico")
                        .WithOne("TipoDireccionFrigorifico")
                        .HasForeignKey("CitricosCaribe.Models.TipoDireccionFrigorifico", "FrigorificoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CitricosCaribe.Models.TipoDireccionTrabajador", b =>
                {
                    b.HasOne("CitricosCaribe.Models.Direccion", "Direccion")
                        .WithMany("TipoDireccionTrabajador")
                        .HasForeignKey("DireccionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CitricosCaribe.Models.Trabajador", "Trabajador")
                        .WithOne("TipoDireccionTrabajador")
                        .HasForeignKey("CitricosCaribe.Models.TipoDireccionTrabajador", "TrabajadorID")
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
