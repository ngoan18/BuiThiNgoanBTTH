using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace baithuchanh04.Migrations
{
    /// <inheritdoc />
    public partial class Create_Foreignkey_Employee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerID",
                table: "Employee",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CustomerID",
                table: "Employee",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Customer_CustomerID",
                table: "Employee",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Customer_CustomerID",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_CustomerID",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Employee");
        }
    }
}
