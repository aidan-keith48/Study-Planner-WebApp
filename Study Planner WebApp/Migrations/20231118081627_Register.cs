using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Study_Planner_WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Register : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecordedHours",
                table: "Module");

            migrationBuilder.CreateTable(
                name: "RegisterUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterUser", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegisterUser");

            migrationBuilder.AddColumn<double>(
                name: "RecordedHours",
                table: "Module",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
