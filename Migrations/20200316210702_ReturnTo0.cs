﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CitricosCaribe.Migrations
{
    public partial class ReturnTo0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContratosComprasInternacionales");

            migrationBuilder.DropTable(
                name: "ContratosComprasNacionales");

            migrationBuilder.DropTable(
                name: "ContratosVentasInternacionales");

            migrationBuilder.DropTable(
                name: "ContratosVentasNacionales");

            migrationBuilder.DropTable(
                name: "MediosAsignados");

            migrationBuilder.DropTable(
                name: "Ofertas");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Solicitudes");

            migrationBuilder.DropTable(
                name: "TipoDireccionBaseTransportes");

            migrationBuilder.DropTable(
                name: "TipoDireccionFrigorificos");

            migrationBuilder.DropTable(
                name: "TipoDireccionTrabajadores");

            migrationBuilder.DropTable(
                name: "VehiculosAsignados");

            migrationBuilder.DropTable(
                name: "Medios");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "BasesTransportes");

            migrationBuilder.DropTable(
                name: "Frigorificos");

            migrationBuilder.DropTable(
                name: "Direcciones");

            migrationBuilder.DropTable(
                name: "Trabajadores");

            migrationBuilder.DropTable(
                name: "Vehiculos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BasesTransportes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Direccion = table.Column<string>(type: "TEXT", nullable: true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasesTransportes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Direcciones",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tipo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direcciones", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Pais = table.Column<string>(type: "TEXT", nullable: true),
                    Provincia = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Frigorificos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Direccion = table.Column<string>(type: "TEXT", nullable: true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frigorificos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Medios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CaracteristicasTecnicas = table.Column<string>(type: "TEXT", nullable: true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    UnidadDeMedida = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Trabajadores",
                columns: table => new
                {
                    CI = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cargo = table.Column<string>(type: "TEXT", nullable: true),
                    Departamento = table.Column<string>(type: "TEXT", nullable: true),
                    GradoEscolar = table.Column<string>(type: "TEXT", nullable: true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Sueldo = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabajadores", x => x.CI);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Marca = table.Column<string>(type: "TEXT", nullable: true),
                    Modelo = table.Column<string>(type: "TEXT", nullable: true),
                    Motor = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TipoDireccionBaseTransportes",
                columns: table => new
                {
                    BaseTransporteID = table.Column<int>(type: "INTEGER", nullable: false),
                    DireccionID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDireccionBaseTransportes", x => new { x.BaseTransporteID, x.DireccionID });
                    table.ForeignKey(
                        name: "FK_TipoDireccionBaseTransportes_BasesTransportes_BaseTransporteID",
                        column: x => x.BaseTransporteID,
                        principalTable: "BasesTransportes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TipoDireccionBaseTransportes_Direcciones_DireccionID",
                        column: x => x.DireccionID,
                        principalTable: "Direcciones",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TipoDireccionFrigorificos",
                columns: table => new
                {
                    FrigorificoID = table.Column<int>(type: "INTEGER", nullable: false),
                    DireccionID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDireccionFrigorificos", x => x.FrigorificoID);
                    table.ForeignKey(
                        name: "FK_TipoDireccionFrigorificos_Direcciones_DireccionID",
                        column: x => x.DireccionID,
                        principalTable: "Direcciones",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TipoDireccionFrigorificos_Frigorificos_FrigorificoID",
                        column: x => x.FrigorificoID,
                        principalTable: "Frigorificos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ofertas",
                columns: table => new
                {
                    ProductoID = table.Column<int>(type: "INTEGER", nullable: false),
                    EmpresaID = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaOferta = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Calidad = table.Column<string>(type: "TEXT", nullable: true),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Origen = table.Column<string>(type: "TEXT", nullable: true),
                    PuertoDestino = table.Column<string>(type: "TEXT", nullable: true),
                    PuertoOrigen = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ofertas", x => new { x.ProductoID, x.EmpresaID, x.FechaOferta });
                    table.ForeignKey(
                        name: "FK_Ofertas_Empresas_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ofertas_Productos_ProductoID",
                        column: x => x.ProductoID,
                        principalTable: "Productos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    ProductoID = table.Column<int>(type: "INTEGER", nullable: false),
                    EmpresaID = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaOferta = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Calidad = table.Column<string>(type: "TEXT", nullable: true),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Presupuesto = table.Column<double>(type: "REAL", nullable: false),
                    TipoDeDivisas = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => new { x.ProductoID, x.EmpresaID, x.FechaOferta });
                    table.ForeignKey(
                        name: "FK_Pedidos_Empresas_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_Productos_ProductoID",
                        column: x => x.ProductoID,
                        principalTable: "Productos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Solicitudes",
                columns: table => new
                {
                    ProductoID = table.Column<int>(type: "INTEGER", nullable: false),
                    EmpresaID = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaOferta = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Calidad = table.Column<string>(type: "TEXT", nullable: true),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Presupuesto = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitudes", x => new { x.ProductoID, x.EmpresaID, x.FechaOferta });
                    table.ForeignKey(
                        name: "FK_Solicitudes_Empresas_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Solicitudes_Productos_ProductoID",
                        column: x => x.ProductoID,
                        principalTable: "Productos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContratosComprasInternacionales",
                columns: table => new
                {
                    EmpresaID = table.Column<int>(type: "INTEGER", nullable: false),
                    TrabajadorID = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductoID = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaContrato = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaOferta = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CamposOtros = table.Column<string>(type: "TEXT", nullable: true),
                    DeAmbasPartes = table.Column<string>(type: "TEXT", nullable: true),
                    DeLaOtraParte = table.Column<string>(type: "TEXT", nullable: true),
                    DeUnaParte = table.Column<string>(type: "TEXT", nullable: true),
                    DineroGanadoUSD = table.Column<double>(type: "REAL", nullable: false),
                    ObjetoDelContrato = table.Column<string>(type: "TEXT", nullable: true),
                    TipoPago = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratosComprasInternacionales", x => new { x.EmpresaID, x.TrabajadorID, x.ProductoID, x.FechaContrato, x.FechaOferta });
                    table.ForeignKey(
                        name: "FK_ContratosComprasInternacionales_Empresas_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContratosComprasInternacionales_Productos_ProductoID",
                        column: x => x.ProductoID,
                        principalTable: "Productos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContratosComprasInternacionales_Trabajadores_TrabajadorID",
                        column: x => x.TrabajadorID,
                        principalTable: "Trabajadores",
                        principalColumn: "CI",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContratosComprasNacionales",
                columns: table => new
                {
                    EmpresaID = table.Column<int>(type: "INTEGER", nullable: false),
                    TrabajadorID = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductoID = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaContrato = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaPedido = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CamposOtros = table.Column<string>(type: "TEXT", nullable: true),
                    DeAmbasPartes = table.Column<string>(type: "TEXT", nullable: true),
                    DeLaOtraParte = table.Column<string>(type: "TEXT", nullable: true),
                    DeUnaParte = table.Column<string>(type: "TEXT", nullable: true),
                    DineroGanadoUSD = table.Column<double>(type: "REAL", nullable: false),
                    ObjetoDelContrato = table.Column<string>(type: "TEXT", nullable: true),
                    TipoPago = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratosComprasNacionales", x => new { x.EmpresaID, x.TrabajadorID, x.ProductoID, x.FechaContrato, x.FechaPedido });
                    table.ForeignKey(
                        name: "FK_ContratosComprasNacionales_Empresas_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContratosComprasNacionales_Productos_ProductoID",
                        column: x => x.ProductoID,
                        principalTable: "Productos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContratosComprasNacionales_Trabajadores_TrabajadorID",
                        column: x => x.TrabajadorID,
                        principalTable: "Trabajadores",
                        principalColumn: "CI",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContratosVentasInternacionales",
                columns: table => new
                {
                    EmpresaID = table.Column<int>(type: "INTEGER", nullable: false),
                    TrabajadorID = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductoID = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaContrato = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaPedido = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CamposOtros = table.Column<string>(type: "TEXT", nullable: true),
                    DeAmbasPartes = table.Column<string>(type: "TEXT", nullable: true),
                    DeLaOtraParte = table.Column<string>(type: "TEXT", nullable: true),
                    DeUnaParte = table.Column<string>(type: "TEXT", nullable: true),
                    DineroGanadoUSD = table.Column<double>(type: "REAL", nullable: false),
                    ObjetoDelContrato = table.Column<string>(type: "TEXT", nullable: true),
                    TipoPago = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratosVentasInternacionales", x => new { x.EmpresaID, x.TrabajadorID, x.ProductoID, x.FechaContrato, x.FechaPedido });
                    table.ForeignKey(
                        name: "FK_ContratosVentasInternacionales_Empresas_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContratosVentasInternacionales_Productos_ProductoID",
                        column: x => x.ProductoID,
                        principalTable: "Productos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContratosVentasInternacionales_Trabajadores_TrabajadorID",
                        column: x => x.TrabajadorID,
                        principalTable: "Trabajadores",
                        principalColumn: "CI",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContratosVentasNacionales",
                columns: table => new
                {
                    EmpresaID = table.Column<int>(type: "INTEGER", nullable: false),
                    TrabajadorID = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductoID = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaContrato = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaSolicitud = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CamposOtros = table.Column<string>(type: "TEXT", nullable: true),
                    DeAmbasPartes = table.Column<string>(type: "TEXT", nullable: true),
                    DeLaOtraParte = table.Column<string>(type: "TEXT", nullable: true),
                    DeUnaParte = table.Column<string>(type: "TEXT", nullable: true),
                    DineroGanadoUSD = table.Column<double>(type: "REAL", nullable: false),
                    ObjetoDelContrato = table.Column<string>(type: "TEXT", nullable: true),
                    TipoPago = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratosVentasNacionales", x => new { x.EmpresaID, x.TrabajadorID, x.ProductoID, x.FechaContrato, x.FechaSolicitud });
                    table.ForeignKey(
                        name: "FK_ContratosVentasNacionales_Empresas_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContratosVentasNacionales_Productos_ProductoID",
                        column: x => x.ProductoID,
                        principalTable: "Productos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContratosVentasNacionales_Trabajadores_TrabajadorID",
                        column: x => x.TrabajadorID,
                        principalTable: "Trabajadores",
                        principalColumn: "CI",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediosAsignados",
                columns: table => new
                {
                    TrabajadorID = table.Column<int>(type: "INTEGER", nullable: false),
                    MedioID = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediosAsignados", x => new { x.TrabajadorID, x.MedioID });
                    table.ForeignKey(
                        name: "FK_MediosAsignados_Medios_MedioID",
                        column: x => x.MedioID,
                        principalTable: "Medios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediosAsignados_Trabajadores_TrabajadorID",
                        column: x => x.TrabajadorID,
                        principalTable: "Trabajadores",
                        principalColumn: "CI",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TipoDireccionTrabajadores",
                columns: table => new
                {
                    DireccionID = table.Column<int>(type: "INTEGER", nullable: false),
                    TrabajadorID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDireccionTrabajadores", x => new { x.DireccionID, x.TrabajadorID });
                    table.ForeignKey(
                        name: "FK_TipoDireccionTrabajadores_Direcciones_DireccionID",
                        column: x => x.DireccionID,
                        principalTable: "Direcciones",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TipoDireccionTrabajadores_Trabajadores_TrabajadorID",
                        column: x => x.TrabajadorID,
                        principalTable: "Trabajadores",
                        principalColumn: "CI",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehiculosAsignados",
                columns: table => new
                {
                    VehiculoID = table.Column<int>(type: "INTEGER", nullable: false),
                    TrabajadorID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiculosAsignados", x => x.VehiculoID);
                    table.ForeignKey(
                        name: "FK_VehiculosAsignados_Trabajadores_TrabajadorID",
                        column: x => x.TrabajadorID,
                        principalTable: "Trabajadores",
                        principalColumn: "CI",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehiculosAsignados_Vehiculos_VehiculoID",
                        column: x => x.VehiculoID,
                        principalTable: "Vehiculos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContratosComprasInternacionales_ProductoID",
                table: "ContratosComprasInternacionales",
                column: "ProductoID");

            migrationBuilder.CreateIndex(
                name: "IX_ContratosComprasInternacionales_TrabajadorID",
                table: "ContratosComprasInternacionales",
                column: "TrabajadorID");

            migrationBuilder.CreateIndex(
                name: "IX_ContratosComprasNacionales_ProductoID",
                table: "ContratosComprasNacionales",
                column: "ProductoID");

            migrationBuilder.CreateIndex(
                name: "IX_ContratosComprasNacionales_TrabajadorID",
                table: "ContratosComprasNacionales",
                column: "TrabajadorID");

            migrationBuilder.CreateIndex(
                name: "IX_ContratosVentasInternacionales_ProductoID",
                table: "ContratosVentasInternacionales",
                column: "ProductoID");

            migrationBuilder.CreateIndex(
                name: "IX_ContratosVentasInternacionales_TrabajadorID",
                table: "ContratosVentasInternacionales",
                column: "TrabajadorID");

            migrationBuilder.CreateIndex(
                name: "IX_ContratosVentasNacionales_ProductoID",
                table: "ContratosVentasNacionales",
                column: "ProductoID");

            migrationBuilder.CreateIndex(
                name: "IX_ContratosVentasNacionales_TrabajadorID",
                table: "ContratosVentasNacionales",
                column: "TrabajadorID");

            migrationBuilder.CreateIndex(
                name: "IX_MediosAsignados_MedioID",
                table: "MediosAsignados",
                column: "MedioID");

            migrationBuilder.CreateIndex(
                name: "IX_Ofertas_EmpresaID",
                table: "Ofertas",
                column: "EmpresaID");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_EmpresaID",
                table: "Pedidos",
                column: "EmpresaID");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_EmpresaID",
                table: "Solicitudes",
                column: "EmpresaID");

            migrationBuilder.CreateIndex(
                name: "IX_TipoDireccionBaseTransportes_BaseTransporteID",
                table: "TipoDireccionBaseTransportes",
                column: "BaseTransporteID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoDireccionBaseTransportes_DireccionID",
                table: "TipoDireccionBaseTransportes",
                column: "DireccionID");

            migrationBuilder.CreateIndex(
                name: "IX_TipoDireccionFrigorificos_DireccionID",
                table: "TipoDireccionFrigorificos",
                column: "DireccionID");

            migrationBuilder.CreateIndex(
                name: "IX_TipoDireccionTrabajadores_TrabajadorID",
                table: "TipoDireccionTrabajadores",
                column: "TrabajadorID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehiculosAsignados_TrabajadorID",
                table: "VehiculosAsignados",
                column: "TrabajadorID",
                unique: true);
        }
    }
}
