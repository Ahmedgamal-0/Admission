using Microsoft.EntityFrameworkCore.Migrations;

namespace AdmissionSystem.Migrations
{
    public partial class newVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Payment_ApplicantId",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_MedicalHistory_ApplicantId",
                table: "MedicalHistory");

            migrationBuilder.DropIndex(
                name: "IX_AdmissionDetails_ApplicantId",
                table: "AdmissionDetails");

            migrationBuilder.DropColumn(
                name: "Payment",
                table: "Applicant");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_ApplicantId",
                table: "Payment",
                column: "ApplicantId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistory_ApplicantId",
                table: "MedicalHistory",
                column: "ApplicantId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionDetails_ApplicantId",
                table: "AdmissionDetails",
                column: "ApplicantId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Payment_ApplicantId",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_MedicalHistory_ApplicantId",
                table: "MedicalHistory");

            migrationBuilder.DropIndex(
                name: "IX_AdmissionDetails_ApplicantId",
                table: "AdmissionDetails");

            migrationBuilder.AddColumn<string>(
                name: "Payment",
                table: "Applicant",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payment_ApplicantId",
                table: "Payment",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistory_ApplicantId",
                table: "MedicalHistory",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionDetails_ApplicantId",
                table: "AdmissionDetails",
                column: "ApplicantId");
        }
    }
}
