using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Study_Planner_WebApp.Migrations
{
    /// <inheritdoc />
    public partial class WeekInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Week_Information",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userID = table.Column<int>(type: "int", nullable: false),
                    moduleCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    weeks = table.Column<int>(type: "int", nullable: false),
                    hours = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Week_Information", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Week_Information");
        }
    }
}
