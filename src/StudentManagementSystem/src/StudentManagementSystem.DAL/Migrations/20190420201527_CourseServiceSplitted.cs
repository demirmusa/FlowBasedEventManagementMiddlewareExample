using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementSystem.DAL.Migrations
{
    public partial class CourseServiceSplitted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseInformations");

            migrationBuilder.DropTable(
                name: "StudentCourseJunctions");

            migrationBuilder.DropTable(
                name: "StudentCourseScores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseInformations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseDescription = table.Column<string>(nullable: true),
                    CourseTitle = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    FKPreviousVersionID = table.Column<int>(nullable: true),
                    FKTeacherID = table.Column<int>(nullable: false),
                    LastUpdateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseInformations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CourseInformations_Teachers_FKTeacherID",
                        column: x => x.FKTeacherID,
                        principalTable: "Teachers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourseJunctions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    FKCourseID = table.Column<int>(nullable: false),
                    FKStudentID = table.Column<int>(nullable: false),
                    LastUpdateTime = table.Column<DateTime>(nullable: true)
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
                    Deleted = table.Column<bool>(nullable: false),
                    FKCourseID = table.Column<int>(nullable: false),
                    FKPreviousVersionID = table.Column<int>(nullable: true),
                    FKStudentID = table.Column<int>(nullable: false),
                    LastUpdateTime = table.Column<DateTime>(nullable: true),
                    Score = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourseScores", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseInformations_FKTeacherID",
                table: "CourseInformations",
                column: "FKTeacherID");
        }
    }
}
