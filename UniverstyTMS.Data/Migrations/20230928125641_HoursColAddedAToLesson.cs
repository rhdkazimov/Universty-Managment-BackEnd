using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniverstyTMS.Data.Migrations
{
    public partial class HoursColAddedAToLesson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Hours",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hours",
                table: "Lessons");
        }
    }
}
