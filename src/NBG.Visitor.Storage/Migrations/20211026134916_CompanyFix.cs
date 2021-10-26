using Microsoft.EntityFrameworkCore.Migrations;

namespace NBG.Visitor.Storage.Migrations
{
    public partial class CompanyFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_visit_company_CompanyLabel",
                table: "visit");

            migrationBuilder.RenameColumn(
                name: "CompanyLabel",
                table: "visit",
                newName: "company_label");

            migrationBuilder.RenameIndex(
                name: "IX_visit_CompanyLabel",
                table: "visit",
                newName: "IX_visit_company_label");

            migrationBuilder.AddForeignKey(
                name: "FK_visit_company_company_label",
                table: "visit",
                column: "company_label",
                principalTable: "company",
                principalColumn: "company_label",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_visit_company_company_label",
                table: "visit");

            migrationBuilder.RenameColumn(
                name: "company_label",
                table: "visit",
                newName: "CompanyLabel");

            migrationBuilder.RenameIndex(
                name: "IX_visit_company_label",
                table: "visit",
                newName: "IX_visit_CompanyLabel");

            migrationBuilder.AddForeignKey(
                name: "FK_visit_company_CompanyLabel",
                table: "visit",
                column: "CompanyLabel",
                principalTable: "company",
                principalColumn: "company_label",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
