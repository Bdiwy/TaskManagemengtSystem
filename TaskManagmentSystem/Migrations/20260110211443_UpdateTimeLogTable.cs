using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTimeLogTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "TimeLog",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_TimeLog_UserId",
                table: "TimeLog",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeLog_AspNetUsers_UserId",
                table: "TimeLog",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeLog_AspNetUsers_UserId",
                table: "TimeLog");

            migrationBuilder.DropIndex(
                name: "IX_TimeLog_UserId",
                table: "TimeLog");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TimeLog");
        }
    }
}
