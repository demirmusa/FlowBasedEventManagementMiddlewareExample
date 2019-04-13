using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementSystem.Data.Migrations
{
    public partial class personphoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Persons",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Persons");
        }
    }
}
