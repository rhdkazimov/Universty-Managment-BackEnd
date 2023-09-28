using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniverstyTMS.Data.Migrations
{
    public partial class ColNameChangedOnContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gmail",
                table: "ContactForms",
                newName: "Contact");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Contact",
                table: "ContactForms",
                newName: "Gmail");
        }
    }
}
