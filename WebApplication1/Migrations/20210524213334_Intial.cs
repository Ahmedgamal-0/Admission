using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdmissionSystem.Migrations
{
    public partial class Intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applicant",
                columns: table => new
                {
                    ApplicantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    SecondName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PlaceOfBirth = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    Relegion = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    FamilyStatus = table.Column<string>(nullable: true),
                    SpokenLanguage = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Payment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicant", x => x.ApplicantId);
                });

            migrationBuilder.CreateTable(
                name: "AdmissionDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Section = table.Column<string>(nullable: true),
                    Stage = table.Column<string>(nullable: true),
                    Grade = table.Column<string>(nullable: true),
                    AcademicYear = table.Column<string>(nullable: true),
                    ApplicantId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    SchoolName = table.Column<string>(nullable: true),
                    LastYearScore = table.Column<string>(nullable: true),
                    Curriculum = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmissionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdmissionDetails_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "ApplicantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyContact",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Relationship = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    HomeNumber = table.Column<string>(nullable: true),
                    ApplicantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmergencyContact_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "ApplicantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParentInfo",
                columns: table => new
                {
                    FirstName = table.Column<string>(nullable: false),
                    SecondName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PlaceOfBirth = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    Relegion = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Occupation = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    IdentificationType = table.Column<string>(nullable: true),
                    IdentificationNumber = table.Column<string>(nullable: true),
                    ApplicantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentInfo", x => x.FirstName);
                    table.ForeignKey(
                        name: "FK_ParentInfo_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "ApplicantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionDetails_ApplicantId",
                table: "AdmissionDetails",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyContact_ApplicantId",
                table: "EmergencyContact",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentInfo_ApplicantId",
                table: "ParentInfo",
                column: "ApplicantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdmissionDetails");

            migrationBuilder.DropTable(
                name: "EmergencyContact");

            migrationBuilder.DropTable(
                name: "ParentInfo");

            migrationBuilder.DropTable(
                name: "Applicant");
        }
    }
}
