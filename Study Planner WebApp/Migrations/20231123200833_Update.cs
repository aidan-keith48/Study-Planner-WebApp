using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Study_Planner_WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "studentId",
                table: "RecordData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "userID",
                table: "Module",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "studentId",
                table: "RecordData");

            migrationBuilder.DropColumn(
                name: "userID",
                table: "Module");
        }
    }
}
