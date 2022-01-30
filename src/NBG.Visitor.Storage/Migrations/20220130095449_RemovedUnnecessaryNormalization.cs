using Microsoft.EntityFrameworkCore.Migrations;

namespace NBG.Visitor.Storage.Migrations
{
    public partial class RemovedUnnecessaryNormalization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_visit_company_company_label",
                table: "visit");

            migrationBuilder.DropForeignKey(
                name: "FK_visit_contact_person_contact_person_name",
                table: "visit");

            migrationBuilder.DropTable(
                name: "company");

            migrationBuilder.DropTable(
                name: "contact_person");

            migrationBuilder.DropIndex(
                name: "IX_visit_company_label",
                table: "visit");

            migrationBuilder.DropIndex(
                name: "IX_visit_contact_person_name",
                table: "visit");

            migrationBuilder.DropColumn(
                name: "contact_person_name",
                table: "visit");

            migrationBuilder.AlterColumn<string>(
                name: "company_label",
                table: "visit",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "contatct_person",
                table: "visit",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "contatct_person",
                table: "visit");

            migrationBuilder.AlterColumn<string>(
                name: "company_label",
                table: "visit",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "contact_person_name",
                table: "visit",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    company_label = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.company_label);
                });

            migrationBuilder.CreateTable(
                name: "contact_person",
                columns: table => new
                {
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contact_person", x => x.name);
                });

            migrationBuilder.CreateIndex(
                name: "IX_visit_company_label",
                table: "visit",
                column: "company_label");

            migrationBuilder.CreateIndex(
                name: "IX_visit_contact_person_name",
                table: "visit",
                column: "contact_person_name");

            migrationBuilder.CreateIndex(
                name: "IX_company_company_label",
                table: "company",
                column: "company_label",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_contact_person_name",
                table: "contact_person",
                column: "name",
                unique: true);

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
        }
    }
}
