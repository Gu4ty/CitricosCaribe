using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CitricosCaribe.Migrations
{
    public partial class AddContratosComprasNacionalesTabla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContratosComprasNacionales",
                columns: table => new
                {
                    FechaContrato = table.Column<DateTime>(nullable: false),
                    FechaPedido = table.Column<DateTime>(nullable: false),
                    TrabajadorID = table.Column<int>(nullable: false),
                    EmpresaID = table.Column<int>(nullable: false),
                    ProductoID = table.Column<int>(nullable: false),
                    CamposOtros = table.Column<string>(nullable: true),
                    DineroGanadoUSD = table.Column<double>(nullable: false),
                    DeAmbasPartes = table.Column<string>(nullable: true),
                    DeLaOtraParte = table.Column<string>(nullable: true),
                    DeUnaParte = table.Column<string>(nullable: true),
                    TipoPago = table.Column<string>(nullable: true),
                    ObjetoDelContrato = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_ContratosComprasNacionales_ProductoID",
                table: "ContratosComprasNacionales",
                column: "ProductoID");

            migrationBuilder.CreateIndex(
                name: "IX_ContratosComprasNacionales_TrabajadorID",
                table: "ContratosComprasNacionales",
                column: "TrabajadorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContratosComprasNacionales");
        }
    }
}
