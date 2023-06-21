using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiThucHanh1704.Migrations
{
    /// <inheritdoc />
    public partial class Faculty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faculty",
                columns: table => new
                {
                    FacultyID = table.Column<string>(type: "TEXT", nullable: false),
                    FacultyName = table.Column<string>(type: "TEXT", nullable: false),
                    FacultyEmail = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.FacultyID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faculty");
        }
    }
}
