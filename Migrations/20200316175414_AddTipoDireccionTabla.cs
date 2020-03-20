using Microsoft.EntityFrameworkCore.Migrations;

namespace CitricosCaribe.Migrations
{
    public partial class AddTipoDireccionTabla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoDireccionTrabajadores",
                columns: table => new
                {
                    TrabajadorID = table.Column<int>(nullable: false),
                    DireccionID = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_TipoDireccionTrabajadores_TrabajadorID",
                table: "TipoDireccionTrabajadores",
                column: "TrabajadorID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoDireccionTrabajadores");
        }
    }
}
