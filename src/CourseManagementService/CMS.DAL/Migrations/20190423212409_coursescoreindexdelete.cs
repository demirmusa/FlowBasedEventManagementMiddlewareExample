using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.DAL.Migrations
{
    public partial class coursescoreindexdelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentCourseScores_FKStudentID_FKCourseID_Deleted",
                table: "StudentCourseScores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseScores_FKStudentID_FKCourseID_Deleted",
                table: "StudentCourseScores",
                columns: new[] { "FKStudentID", "FKCourseID", "Deleted" },
                unique: true);
        }
    }
}
