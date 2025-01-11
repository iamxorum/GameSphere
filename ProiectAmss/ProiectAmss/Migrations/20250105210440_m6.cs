using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectAmss.Migrations
{
    /// <inheritdoc />
    public partial class m6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CheckedId",
                table: "PlayerEvents",
                newName: "CheckedIn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CheckedIn",
                table: "PlayerEvents",
                newName: "CheckedId");
        }
    }
}
