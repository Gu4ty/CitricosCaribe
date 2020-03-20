using Microsoft.EntityFrameworkCore.Migrations;

namespace CitricosCaribe.Migrations
{
    public partial class AddTipoDireccionTransporte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoDireccionBaseTransportes",
                columns: table => new
                {
                    BaseTransporteID = table.Column<int>(nullable: false),
                    DireccionID = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_TipoDireccionBaseTransportes_BaseTransporteID",
                table: "TipoDireccionBaseTransportes",
                column: "BaseTransporteID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoDireccionBaseTransportes_DireccionID",
                table: "TipoDireccionBaseTransportes",
                column: "DireccionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoDireccionBaseTransportes");
        }
    }
}
