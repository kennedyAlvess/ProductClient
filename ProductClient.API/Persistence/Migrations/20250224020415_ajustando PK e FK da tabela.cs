using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductClient.API.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ajustandoPKeFKdatabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientProducts",
                table: "ClientProducts");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "ClientProducts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientProducts",
                table: "ClientProducts",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientProducts",
                table: "ClientProducts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ClientProducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientProducts",
                table: "ClientProducts",
                columns: new[] { "ClientId", "ProductId" });
        }
    }
}
