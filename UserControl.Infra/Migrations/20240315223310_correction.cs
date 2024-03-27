using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserControl.Infra.Migrations
{
    /// <inheritdoc />
    public partial class correction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_prato",
                table: "prato");

            migrationBuilder.RenameTable(
                name: "prato",
                newName: "user");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                table: "user",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                table: "user");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "prato");

            migrationBuilder.AddPrimaryKey(
                name: "PK_prato",
                table: "prato",
                column: "Id");
        }
    }
}
