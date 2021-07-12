using Microsoft.EntityFrameworkCore.Migrations;

namespace AdmissionSystem.Migrations
{
    public partial class databse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Siblings_Applicant_ApplicantId",
                table: "Siblings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Siblings",
                table: "Siblings");

            migrationBuilder.RenameTable(
                name: "Siblings",
                newName: "Sibling");

            migrationBuilder.RenameIndex(
                name: "IX_Siblings_ApplicantId",
                table: "Sibling",
                newName: "IX_Sibling_ApplicantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sibling",
                table: "Sibling",
                column: "SibilingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sibling_Applicant_ApplicantId",
                table: "Sibling",
                column: "ApplicantId",
                principalTable: "Applicant",
                principalColumn: "ApplicantId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sibling_Applicant_ApplicantId",
                table: "Sibling");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sibling",
                table: "Sibling");

            migrationBuilder.RenameTable(
                name: "Sibling",
                newName: "Siblings");

            migrationBuilder.RenameIndex(
                name: "IX_Sibling_ApplicantId",
                table: "Siblings",
                newName: "IX_Siblings_ApplicantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Siblings",
                table: "Siblings",
                column: "SibilingId");

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
