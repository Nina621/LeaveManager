using Microsoft.EntityFrameworkCore.Migrations;

namespace LeaveManager.Data.Migrations
{
    public partial class employe2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "employe_id",
                table: "LeaveAllocations");

            migrationBuilder.DropColumn(
                name: "leave_type_id",
                table: "LeaveAllocations");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "LeaveAllocations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LAId",
                table: "LeaveAllocations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "leaveTypeId",
                table: "LeaveAllocations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LeaveAllocations_EmployeeId",
                table: "LeaveAllocations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveAllocations_LAId",
                table: "LeaveAllocations",
                column: "LAId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveAllocations_AspNetUsers_EmployeeId",
                table: "LeaveAllocations",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveAllocations_LeaveAllocations_LAId",
                table: "LeaveAllocations",
                column: "LAId",
                principalTable: "LeaveAllocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveAllocations_AspNetUsers_EmployeeId",
                table: "LeaveAllocations");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveAllocations_LeaveAllocations_LAId",
                table: "LeaveAllocations");

            migrationBuilder.DropIndex(
                name: "IX_LeaveAllocations_EmployeeId",
                table: "LeaveAllocations");

            migrationBuilder.DropIndex(
                name: "IX_LeaveAllocations_LAId",
                table: "LeaveAllocations");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "LeaveAllocations");

            migrationBuilder.DropColumn(
                name: "LAId",
                table: "LeaveAllocations");

            migrationBuilder.DropColumn(
                name: "leaveTypeId",
                table: "LeaveAllocations");

            migrationBuilder.AddColumn<string>(
                name: "employe_id",
                table: "LeaveAllocations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "leave_type_id",
                table: "LeaveAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
