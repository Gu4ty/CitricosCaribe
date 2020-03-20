using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CitricosCaribe.Migrations
{
    public partial class AddOfertasTabla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ofertas",
                columns: table => new
                {
                    FechaOferta = table.Column<DateTime>(nullable: false),
                    EmpresaID = table.Column<int>(nullable: false),
                    ProductoID = table.Column<int>(nullable: false),
                    Origen = table.Column<string>(nullable: true),
                    Cantidad = table.Column<int>(nullable: false),
                    PuertoOrigen = table.Column<string>(nullable: true),
                    PuertoDestino = table.Column<string>(nullable: true),
                    Calidad = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_Ofertas_EmpresaID",
                table: "Ofertas",
                column: "EmpresaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ofertas");
        }
    }
}
