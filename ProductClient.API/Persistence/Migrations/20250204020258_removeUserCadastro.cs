using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductClient.API.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class removeUserCadastro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ClientProducts_ClientId_ProductId",
                table: "ClientProducts");

            migrationBuilder.DropColumn(
                name: "UsuarioCadastro",
                table: "Clients");

            migrationBuilder.CreateIndex(
                name: "IX_ClientProducts_ClientId",
                table: "ClientProducts",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ClientProducts_ClientId",
                table: "ClientProducts");

            migrationBuilder.AddColumn<long>(
                name: "UsuarioCadastro",
                table: "Clients",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ClientProducts_ClientId_ProductId",
                table: "ClientProducts",
                columns: new[] { "ClientId", "ProductId" });
        }
    }
}
