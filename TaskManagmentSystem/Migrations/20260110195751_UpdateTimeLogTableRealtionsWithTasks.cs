using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTimeLogTableRealtionsWithTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeLog_TaskLists_TaskId",
                table: "TimeLog");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeLog_UserTasks_TaskId",
                table: "TimeLog",
                column: "TaskId",
                principalTable: "UserTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeLog_UserTasks_TaskId",
                table: "TimeLog");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeLog_TaskLists_TaskId",
                table: "TimeLog",
                column: "TaskId",
                principalTable: "TaskLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
