using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementSystem.Data.Migrations
{
    public partial class populationinformationdeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_PopulationInformations_FKPopulationInformationID",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "PopulationInformations");

            migrationBuilder.DropIndex(
                name: "IX_Persons_FKPopulationInformationID",
                table: "Persons");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PopulationInformations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BirthDay = table.Column<DateTime>(nullable: false),
                    BirthPlace = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    FatherName = table.Column<string>(nullable: true),
                    LastUpdateTime = table.Column<DateTime>(nullable: true),
                    MotherName = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PopulationInformations", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_FKPopulationInformationID",
                table: "Persons",
                column: "FKPopulationInformationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_PopulationInformations_FKPopulationInformationID",
                table: "Persons",
                column: "FKPopulationInformationID",
                principalTable: "PopulationInformations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
