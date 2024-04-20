using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeDetailsApplication.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_EmployeeId",
                table: "Skills",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_EmployeeId",
                table: "Projects",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Employees_EmployeeId",
                table: "Projects",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Employees_EmployeeId",
                table: "Skills",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Employees_EmployeeId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Employees_EmployeeId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_EmployeeId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Projects_EmployeeId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Projects");
        }
    }
}
