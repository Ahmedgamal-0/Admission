using Microsoft.EntityFrameworkCore.Migrations;

namespace AdmissionSystem.Migrations
{
    public partial class EditDataTypeofAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Siblings_Applicant_ApplicantId",
                table: "Siblings");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicantId",
                table: "Siblings",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "PhysiologicalNeed",
                table: "MedicalHistory",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MedicalConditions",
                table: "MedicalHistory",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "Hearing",
                table: "MedicalHistory",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Glass",
                table: "MedicalHistory",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Siblings_Applicant_ApplicantId",
                table: "Siblings",
                column: "ApplicantId",
                principalTable: "Applicant",
                principalColumn: "ApplicantId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "PhysiologicalNeed",
                table: "MedicalHistory",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "MedicalConditions",
                table: "MedicalHistory",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Hearing",
                table: "MedicalHistory",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<string>(
                name: "Glass",
                table: "MedicalHistory",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AddForeignKey(
                name: "FK_Siblings_Applicant_ApplicantId",
                table: "Siblings",
                column: "ApplicantId",
                principalTable: "Applicant",
                principalColumn: "ApplicantId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
