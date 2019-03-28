using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementSystem.Data.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PopulationInformations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    LastUpdateTime = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    Nationality = table.Column<string>(nullable: true),
                    MotherName = table.Column<string>(nullable: true),
                    FatherName = table.Column<string>(nullable: true),
                    BirthDay = table.Column<DateTime>(nullable: false),
                    BirthPlace = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PopulationInformations", x => x.ID);
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

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    LastUpdateTime = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SurName = table.Column<string>(nullable: true),
                    FKPopulationInformationID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Persons_PopulationInformations_FKPopulationInformationID",
                        column: x => x.FKPopulationInformationID,
                        principalTable: "PopulationInformations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    LastUpdateTime = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    FKPersonID = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Persons_FKPersonID",
                        column: x => x.FKPersonID,
                        principalTable: "Persons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentInformations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    LastUpdateTime = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    StudentNumber = table.Column<string>(nullable: true),
                    FKUserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentInformations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StudentInformations_Users_FKUserID",
                        column: x => x.FKUserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    LastUpdateTime = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CurrentTitle = table.Column<string>(nullable: true),
                    FKUserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Teachers_Users_FKUserID",
                        column: x => x.FKUserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    table.ForeignKey(
                        name: "FK_CourseInformations_Teachers_FKTeacherID",
                        column: x => x.FKTeacherID,
                        principalTable: "Teachers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseInformations_FKTeacherID",
                table: "CourseInformations",
                column: "FKTeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_FKPopulationInformationID",
                table: "Persons",
                column: "FKPopulationInformationID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInformations_FKUserID",
                table: "StudentInformations",
                column: "FKUserID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInformations_StudentNumber",
                table: "StudentInformations",
                column: "StudentNumber",
                unique: true,
                filter: "[StudentNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_FKUserID",
                table: "Teachers",
                column: "FKUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FKPersonID",
                table: "Users",
                column: "FKPersonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseInformations");

            migrationBuilder.DropTable(
                name: "StudentCourseJunctions");

            migrationBuilder.DropTable(
                name: "StudentCourseScores");

            migrationBuilder.DropTable(
                name: "StudentInformations");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "PopulationInformations");
        }
    }
}
