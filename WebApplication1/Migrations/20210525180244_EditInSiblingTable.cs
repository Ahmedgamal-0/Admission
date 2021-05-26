using Microsoft.EntityFrameworkCore.Migrations;

namespace AdmissionSystem.Migrations
{
    public partial class EditInSiblingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Siblings_Applicant_ApplicantId",
                table: "Siblings");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicantId",
                table: "Siblings",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Siblings_Applicant_ApplicantId",
                table: "Siblings",
                column: "ApplicantId",
                principalTable: "Applicant",
                principalColumn: "ApplicantId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Siblings_Applicant_ApplicantId",
                table: "Siblings");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicantId",
                table: "Siblings",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Siblings_Applicant_ApplicantId",
                table: "Siblings",
                column: "ApplicantId",
                principalTable: "Applicant",
                principalColumn: "ApplicantId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
