using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdmissionSystem.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicalHistory",
                columns: table => new
                {
                    MedicalHistoryId = table.Column<Guid>(nullable: false),
                    Glass = table.Column<string>(nullable: true),
                    Hearing = table.Column<string>(nullable: true),
                    MedicalConditions = table.Column<int>(nullable: false),
                    PhysiologicalConditions = table.Column<string>(nullable: true),
                    PhysiologicalNeed = table.Column<string>(nullable: true),
                    ApplicantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistory", x => x.MedicalHistoryId);
                    table.ForeignKey(
                        name: "FK_MedicalHistory_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "ApplicantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentId = table.Column<Guid>(nullable: false),
                    SchoolId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<float>(nullable: false),
                    PaymentMethod = table.Column<string>(nullable: true),
                    ApplicantId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    BankCode = table.Column<string>(nullable: true),
                    FawryCode = table.Column<string>(nullable: true),
                    CardNumber = table.Column<int>(nullable: true),
                    ExpirationDate = table.Column<DateTime>(nullable: true),
                    Cvv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payment_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "ApplicantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Siblings",
                columns: table => new
                {
                    SibilingId = table.Column<Guid>(nullable: false),
                    Relationship = table.Column<string>(nullable: true),
                    SiblingName = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    SchoolName = table.Column<string>(nullable: true),
                    ApplicantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siblings", x => x.SibilingId);
                    table.ForeignKey(
                        name: "FK_Siblings_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "ApplicantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistory_ApplicantId",
                table: "MedicalHistory",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_ApplicantId",
                table: "Payment",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_Siblings_ApplicantId",
                table: "Siblings",
                column: "ApplicantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalHistory");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Siblings");
        }
    }
}
