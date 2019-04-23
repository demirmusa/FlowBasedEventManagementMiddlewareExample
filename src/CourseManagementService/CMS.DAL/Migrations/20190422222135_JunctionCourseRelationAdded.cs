using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.DAL.Migrations
{
    public partial class JunctionCourseRelationAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseJunctions_FKCourseID",
                table: "StudentCourseJunctions",
                column: "FKCourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourseJunctions_CourseInformations_FKCourseID",
                table: "StudentCourseJunctions",
                column: "FKCourseID",
                principalTable: "CourseInformations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourseJunctions_CourseInformations_FKCourseID",
                table: "StudentCourseJunctions");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourseJunctions_FKCourseID",
                table: "StudentCourseJunctions");
        }
    }
}
