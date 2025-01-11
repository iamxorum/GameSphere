using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectAmss.Migrations
{
    /// <inheritdoc />
    public partial class m5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChosenGameId",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_ChosenGameId",
                table: "Events",
                column: "ChosenGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Games_ChosenGameId",
                table: "Events",
                column: "ChosenGameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Games_ChosenGameId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_ChosenGameId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ChosenGameId",
                table: "Events");
        }
    }
}
