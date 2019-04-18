using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementSystem.DAL.Migrations
{
    public partial class personsurname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SurName",
                table: "Persons",
                newName: "Surname");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Persons",
                newName: "SurName");
        }
    }
}
