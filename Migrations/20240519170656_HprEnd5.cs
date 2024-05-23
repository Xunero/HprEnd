using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HprEnd.Migrations
{
    /// <inheritdoc />
    public partial class HprEnd5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Filmy_ID_Kategoria",
                table: "Filmy");

            migrationBuilder.CreateIndex(
                name: "IX_Filmy_ID_Kategoria",
                table: "Filmy",
                column: "ID_Kategoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Filmy_ID_Kategoria",
                table: "Filmy");

            migrationBuilder.CreateIndex(
                name: "IX_Filmy_ID_Kategoria",
                table: "Filmy",
                column: "ID_Kategoria",
                unique: true);
        }
    }
}
