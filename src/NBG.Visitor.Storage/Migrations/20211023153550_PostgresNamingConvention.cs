using Microsoft.EntityFrameworkCore.Migrations;

namespace NBG.Visitor.Storage.Migrations
{
    public partial class PostgresNamingConvention : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visit_Company_CompanyLabel",
                table: "Visit");

            migrationBuilder.DropForeignKey(
                name: "FK_Visit_ContactPerson_ContactPersonName",
                table: "Visit");

            migrationBuilder.DropForeignKey(
                name: "FK_Visit_Visitor_VisitorId",
                table: "Visit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Visitor",
                table: "Visitor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Visit",
                table: "Visit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactPerson",
                table: "ContactPerson");

            migrationBuilder.RenameTable(
                name: "Visitor",
                newName: "visitor");

            migrationBuilder.RenameTable(
                name: "Visit",
                newName: "visit");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "company");

            migrationBuilder.RenameTable(
                name: "ContactPerson",
                newName: "contact_person");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "visitor",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "visitor",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "visitor",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "VisitorId",
                table: "visit",
                newName: "visitor_id");

            migrationBuilder.RenameColumn(
                name: "VisitStart",
                table: "visit",
                newName: "visit_start");

            migrationBuilder.RenameColumn(
                name: "VisitEnd",
                table: "visit",
                newName: "visit_end");

            migrationBuilder.RenameColumn(
                name: "ContactPersonName",
                table: "visit",
                newName: "contact_person_name");

            migrationBuilder.RenameColumn(
                name: "CompanyLabel",
                table: "visit",
                newName: "company_label");

            migrationBuilder.RenameIndex(
                name: "IX_Visit_VisitorId",
                table: "visit",
                newName: "IX_visit_visitor_id");

            migrationBuilder.RenameIndex(
                name: "IX_Visit_ContactPersonName",
                table: "visit",
                newName: "IX_visit_contact_person_name");

            migrationBuilder.RenameIndex(
                name: "IX_Visit_CompanyLabel",
                table: "visit",
                newName: "IX_visit_company_label");

            migrationBuilder.RenameColumn(
                name: "CompanyLabel",
                table: "company",
                newName: "company_label");

            migrationBuilder.RenameIndex(
                name: "IX_Company_CompanyLabel",
                table: "company",
                newName: "IX_company_company_label");

            migrationBuilder.RenameIndex(
                name: "IX_ContactPerson_Name",
                table: "contact_person",
                newName: "IX_contact_person_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_visitor",
                table: "visitor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_visit",
                table: "visit",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_company",
                table: "company",
                column: "company_label");

            migrationBuilder.AddPrimaryKey(
                name: "PK_contact_person",
                table: "contact_person",
                column: "Name");

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
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_visit_visitor_visitor_id",
                table: "visit",
                column: "visitor_id",
                principalTable: "visitor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_visitor",
                table: "visitor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_visit",
                table: "visit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_company",
                table: "company");

            migrationBuilder.DropPrimaryKey(
                name: "PK_contact_person",
                table: "contact_person");

            migrationBuilder.RenameTable(
                name: "visitor",
                newName: "Visitor");

            migrationBuilder.RenameTable(
                name: "visit",
                newName: "Visit");

            migrationBuilder.RenameTable(
                name: "company",
                newName: "Company");

            migrationBuilder.RenameTable(
                name: "contact_person",
                newName: "ContactPerson");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "Visitor",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Visitor",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "Visitor",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "visitor_id",
                table: "Visit",
                newName: "VisitorId");

            migrationBuilder.RenameColumn(
                name: "visit_start",
                table: "Visit",
                newName: "VisitStart");

            migrationBuilder.RenameColumn(
                name: "visit_end",
                table: "Visit",
                newName: "VisitEnd");

            migrationBuilder.RenameColumn(
                name: "contact_person_name",
                table: "Visit",
                newName: "ContactPersonName");

            migrationBuilder.RenameColumn(
                name: "company_label",
                table: "Visit",
                newName: "CompanyLabel");

            migrationBuilder.RenameIndex(
                name: "IX_visit_visitor_id",
                table: "Visit",
                newName: "IX_Visit_VisitorId");

            migrationBuilder.RenameIndex(
                name: "IX_visit_contact_person_name",
                table: "Visit",
                newName: "IX_Visit_ContactPersonName");

            migrationBuilder.RenameIndex(
                name: "IX_visit_company_label",
                table: "Visit",
                newName: "IX_Visit_CompanyLabel");

            migrationBuilder.RenameColumn(
                name: "company_label",
                table: "Company",
                newName: "CompanyLabel");

            migrationBuilder.RenameIndex(
                name: "IX_company_company_label",
                table: "Company",
                newName: "IX_Company_CompanyLabel");

            migrationBuilder.RenameIndex(
                name: "IX_contact_person_Name",
                table: "ContactPerson",
                newName: "IX_ContactPerson_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Visitor",
                table: "Visitor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Visit",
                table: "Visit",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "CompanyLabel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactPerson",
                table: "ContactPerson",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Visit_Company_CompanyLabel",
                table: "Visit",
                column: "CompanyLabel",
                principalTable: "Company",
                principalColumn: "CompanyLabel",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Visit_ContactPerson_ContactPersonName",
                table: "Visit",
                column: "ContactPersonName",
                principalTable: "ContactPerson",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Visit_Visitor_VisitorId",
                table: "Visit",
                column: "VisitorId",
                principalTable: "Visitor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
