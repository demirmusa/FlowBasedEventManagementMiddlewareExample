using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.DAL.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseInformations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    LastUpdateTime = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    FKPreviousVersionID = table.Column<int>(nullable: true),
                    CourseTitle = table.Column<string>(nullable: true),
                    CourseDescription = table.Column<string>(nullable: true),
                    FKTeacherID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseInformations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourseJunctions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    LastUpdateTime = table.Column<DateTime>(nullable: true),
                    FKStudentID = table.Column<int>(nullable: false),
                    FKCourseID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourseJunctions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourseScores",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    LastUpdateTime = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    FKPreviousVersionID = table.Column<int>(nullable: true),
                    FKCourseID = table.Column<int>(nullable: false),
                    FKStudentID = table.Column<int>(nullable: false),
                    Score = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourseScores", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseJunctions_FKStudentID_FKCourseID",
                table: "StudentCourseJunctions",
                columns: new[] { "FKStudentID", "FKCourseID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseScores_FKStudentID_FKCourseID_Deleted",
                table: "StudentCourseScores",
                columns: new[] { "FKStudentID", "FKCourseID", "Deleted" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseInformations");

            migrationBuilder.DropTable(
                name: "StudentCourseJunctions");

            migrationBuilder.DropTable(
                name: "StudentCourseScores");
        }
    }
}
