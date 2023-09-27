using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniverstyTMS.Data.Migrations
{
    public partial class TeacherIdAddedIntoGroupLessons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "GroupLessons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GroupLessons_TeacherId",
                table: "GroupLessons",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupLessons_Teachers_TeacherId",
                table: "GroupLessons",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupLessons_Teachers_TeacherId",
                table: "GroupLessons");

            migrationBuilder.DropIndex(
                name: "IX_GroupLessons_TeacherId",
                table: "GroupLessons");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "GroupLessons");
        }
    }
}
