using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniverstyTMS.Data.Migrations
{
    public partial class AttanceTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    DVM = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "-")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attances", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attances");
        }
    }
}
