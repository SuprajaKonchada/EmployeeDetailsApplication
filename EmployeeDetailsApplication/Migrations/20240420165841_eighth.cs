using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeDetailsApplication.Migrations
{
    /// <inheritdoc />
    public partial class eighth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeProject",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeSkill",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeProject",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeSkill",
                table: "Employees");
        }
    }
}
