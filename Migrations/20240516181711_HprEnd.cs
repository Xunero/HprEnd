using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HprEnd.Migrations
{
    /// <inheritdoc />
    public partial class HprEnd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorie",
                columns: table => new
                {
                    ID_Kategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorie", x => x.ID_Kategoria);
                });

            migrationBuilder.CreateTable(
                name: "Oceny",
                columns: table => new
                {
                    ID_FilmOcena = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ocena = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oceny", x => x.ID_FilmOcena);
                });

            migrationBuilder.CreateTable(
                name: "Producenci",
                columns: table => new
                {
                    ID_Producent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Siedziba = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producenci", x => x.ID_Producent);
                });

            migrationBuilder.CreateTable(
                name: "Typy",
                columns: table => new
                {
                    ID_Typ = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Typ_uzytkownika = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Typy", x => x.ID_Typ);
                });

            migrationBuilder.CreateTable(
                name: "Filmy",
                columns: table => new
                {
                    ID_Film = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytul = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Data_wydania = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dlugosc = table.Column<int>(type: "int", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID_Producent = table.Column<int>(type: "int", nullable: false),
                    ID_Kategoria = table.Column<int>(type: "int", nullable: false),
                    ID_FilmOcena = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmy", x => x.ID_Film);
                    table.ForeignKey(
                        name: "FK_Filmy_Kategorie_ID_Kategoria",
                        column: x => x.ID_Kategoria,
                        principalTable: "Kategorie",
                        principalColumn: "ID_Kategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Filmy_Oceny_ID_FilmOcena",
                        column: x => x.ID_FilmOcena,
                        principalTable: "Oceny",
                        principalColumn: "ID_FilmOcena",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Filmy_Producenci_ID_Producent",
                        column: x => x.ID_Producent,
                        principalTable: "Producenci",
                        principalColumn: "ID_Producent",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Uzytkownicy",
                columns: table => new
                {
                    ID_Uzytkownik = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Haslo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ID_Typ = table.Column<int>(type: "int", nullable: false),
                    TypID_Typ = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzytkownicy", x => x.ID_Uzytkownik);
                    table.ForeignKey(
                        name: "FK_Uzytkownicy_Typy_TypID_Typ",
                        column: x => x.TypID_Typ,
                        principalTable: "Typy",
                        principalColumn: "ID_Typ");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filmy_ID_FilmOcena",
                table: "Filmy",
                column: "ID_FilmOcena");

            migrationBuilder.CreateIndex(
                name: "IX_Filmy_ID_Kategoria",
                table: "Filmy",
                column: "ID_Kategoria",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Filmy_ID_Producent",
                table: "Filmy",
                column: "ID_Producent");

            migrationBuilder.CreateIndex(
                name: "IX_Uzytkownicy_TypID_Typ",
                table: "Uzytkownicy",
                column: "TypID_Typ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filmy");

            migrationBuilder.DropTable(
                name: "Uzytkownicy");

            migrationBuilder.DropTable(
                name: "Kategorie");

            migrationBuilder.DropTable(
                name: "Oceny");

            migrationBuilder.DropTable(
                name: "Producenci");

            migrationBuilder.DropTable(
                name: "Typy");
        }
    }
}
