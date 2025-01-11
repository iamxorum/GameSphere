using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectAmss.Migrations
{
    /// <inheritdoc />
    public partial class m3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerEvent_AspNetUsers_PlayerId",
                table: "PlayerEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerEvent_Events_EventId",
                table: "PlayerEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerEvent",
                table: "PlayerEvent");

            migrationBuilder.RenameTable(
                name: "PlayerEvent",
                newName: "PlayerEvents");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerEvent_PlayerId",
                table: "PlayerEvents",
                newName: "IX_PlayerEvents_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerEvent_EventId",
                table: "PlayerEvents",
                newName: "IX_PlayerEvents_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerEvents",
                table: "PlayerEvents",
                columns: new[] { "Id", "PlayerId", "EventId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerEvents_AspNetUsers_PlayerId",
                table: "PlayerEvents",
                column: "PlayerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerEvents_Events_EventId",
                table: "PlayerEvents",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerEvents_AspNetUsers_PlayerId",
                table: "PlayerEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerEvents_Events_EventId",
                table: "PlayerEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerEvents",
                table: "PlayerEvents");

            migrationBuilder.RenameTable(
                name: "PlayerEvents",
                newName: "PlayerEvent");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerEvents_PlayerId",
                table: "PlayerEvent",
                newName: "IX_PlayerEvent_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerEvents_EventId",
                table: "PlayerEvent",
                newName: "IX_PlayerEvent_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerEvent",
                table: "PlayerEvent",
                columns: new[] { "Id", "PlayerId", "EventId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerEvent_AspNetUsers_PlayerId",
                table: "PlayerEvent",
                column: "PlayerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerEvent_Events_EventId",
                table: "PlayerEvent",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
