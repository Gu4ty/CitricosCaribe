using Microsoft.EntityFrameworkCore.Migrations;

namespace CitricosCaribe.Migrations
{
    public partial class AddMediosAsignadosTabla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MediosAsignados",
                columns: table => new
                {
                    TrabajadorID = table.Column<int>(nullable: false),
                    MedioID = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_MediosAsignados_MedioID",
                table: "MediosAsignados",
                column: "MedioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediosAsignados");
        }
    }
}
