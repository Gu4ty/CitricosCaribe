using Microsoft.EntityFrameworkCore.Migrations;

namespace CitricosCaribe.Migrations
{
    public partial class AddTipoDireccionFrigorifico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoDireccionFrigorificos",
                columns: table => new
                {
                    FrigorificoID = table.Column<int>(nullable: false),
                    DireccionID = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_TipoDireccionFrigorificos_DireccionID",
                table: "TipoDireccionFrigorificos",
                column: "DireccionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoDireccionFrigorificos");
        }
    }
}
