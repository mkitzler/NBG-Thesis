using Microsoft.EntityFrameworkCore.Migrations;

namespace NBG.Visitor.Storage.Migrations
{
    public partial class ClassRelationRemoveEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_visit_company_company_label",
                table: "visit");

            migrationBuilder.DropForeignKey(
                name: "FK_visit_contact_person_contact_person_name",
                table: "visit");

            migrationBuilder.DropForeignKey(
                name: "FK_visit_visitor_visitor_id",
                table: "visit");

            migrationBuilder.RenameColumn(
                name: "visitor_id",
                table: "visit",
                newName: "VisitorId");

            migrationBuilder.RenameColumn(
                name: "contact_person_name",
                table: "visit",
                newName: "ContactPersonName");

            migrationBuilder.RenameColumn(
                name: "company_label",
                table: "visit",
                newName: "CompanyLabel");

            migrationBuilder.RenameIndex(
                name: "IX_visit_visitor_id",
                table: "visit",
                newName: "IX_visit_VisitorId");

            migrationBuilder.RenameIndex(
                name: "IX_visit_contact_person_name",
                table: "visit",
                newName: "IX_visit_ContactPersonName");

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

            migrationBuilder.AddForeignKey(
                name: "FK_visit_contact_person_ContactPersonName",
                table: "visit",
                column: "ContactPersonName",
                principalTable: "contact_person",
                principalColumn: "name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_visit_visitor_VisitorId",
                table: "visit",
                column: "VisitorId",
                principalTable: "visitor",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_visit_company_CompanyLabel",
                table: "visit");

            migrationBuilder.DropForeignKey(
                name: "FK_visit_contact_person_ContactPersonName",
                table: "visit");

            migrationBuilder.DropForeignKey(
                name: "FK_visit_visitor_VisitorId",
                table: "visit");

            migrationBuilder.RenameColumn(
                name: "VisitorId",
                table: "visit",
                newName: "visitor_id");

            migrationBuilder.RenameColumn(
                name: "ContactPersonName",
                table: "visit",
                newName: "contact_person_name");

            migrationBuilder.RenameColumn(
                name: "CompanyLabel",
                table: "visit",
                newName: "company_label");

            migrationBuilder.RenameIndex(
                name: "IX_visit_VisitorId",
                table: "visit",
                newName: "IX_visit_visitor_id");

            migrationBuilder.RenameIndex(
                name: "IX_visit_ContactPersonName",
                table: "visit",
                newName: "IX_visit_contact_person_name");

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

            migrationBuilder.AddForeignKey(
                name: "FK_visit_contact_person_contact_person_name",
                table: "visit",
                column: "contact_person_name",
                principalTable: "contact_person",
                principalColumn: "name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_visit_visitor_visitor_id",
                table: "visit",
                column: "visitor_id",
                principalTable: "visitor",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
