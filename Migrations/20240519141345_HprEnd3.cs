using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HprEnd.Migrations
{
    /// <inheritdoc />
    public partial class HprEnd3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Opinie",
                columns: table => new
                {
                    ID_Opinie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID_Uzytkownik = table.Column<int>(type: "int", nullable: false),
                    ID_Film = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opinie", x => x.ID_Opinie);
                    table.ForeignKey(
                        name: "FK_Opinie_Filmy_ID_Film",
                        column: x => x.ID_Film,
                        principalTable: "Filmy",
                        principalColumn: "ID_Film",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Opinie_Uzytkownicy_ID_Uzytkownik",
                        column: x => x.ID_Uzytkownik,
                        principalTable: "Uzytkownicy",
                        principalColumn: "ID_Uzytkownik",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Opinie_ID_Film",
                table: "Opinie",
                column: "ID_Film");

            migrationBuilder.CreateIndex(
                name: "IX_Opinie_ID_Uzytkownik",
                table: "Opinie",
                column: "ID_Uzytkownik");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Opinie");
        }
    }
}
