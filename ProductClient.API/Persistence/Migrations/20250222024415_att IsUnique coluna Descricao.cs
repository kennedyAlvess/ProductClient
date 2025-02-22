using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductClient.API.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class attIsUniquecolunaDescricao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_Descricao",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Descricao",
                table: "Products",
                column: "Descricao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_Descricao",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Descricao",
                table: "Products",
                column: "Descricao",
                unique: true);
        }
    }
}
