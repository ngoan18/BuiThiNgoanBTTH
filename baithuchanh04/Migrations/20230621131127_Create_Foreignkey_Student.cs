using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace baithuchanh04.Migrations
{
    /// <inheritdoc />
    public partial class Create_Foreignkey_Student : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeID",
                table: "Student",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Student_EmployeeID",
                table: "Student",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Employee_EmployeeID",
                table: "Student",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Employee_EmployeeID",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_EmployeeID",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "Student");
        }
    }
}
