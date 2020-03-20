using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CitricosCaribe.Migrations
{
    public partial class AddSolicitudesTabla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Solicitudes",
                columns: table => new
                {
                    FechaOferta = table.Column<DateTime>(nullable: false),
                    EmpresaID = table.Column<int>(nullable: false),
                    ProductoID = table.Column<int>(nullable: false),
                    Presupuesto = table.Column<double>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Calidad = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_EmpresaID",
                table: "Solicitudes",
                column: "EmpresaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Solicitudes");
        }
    }
}
