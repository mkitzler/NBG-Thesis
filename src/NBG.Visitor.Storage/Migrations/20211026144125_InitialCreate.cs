using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NBG.Visitor.Storage.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "visitor",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_visitor", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "visit",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    visit_start = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    visit_end = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    visitor_id = table.Column<int>(type: "integer", nullable: false),
                    contact_person_name = table.Column<string>(type: "text", nullable: true),
                    company_label = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_visit", x => x.id);
                    table.ForeignKey(
                        name: "FK_visit_company_company_label",
                        column: x => x.company_label,
                        principalTable: "company",
                        principalColumn: "company_label",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_visit_contact_person_contact_person_name",
                        column: x => x.contact_person_name,
                        principalTable: "contact_person",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_visit_visitor_visitor_id",
                        column: x => x.visitor_id,
                        principalTable: "visitor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_visit_company_label",
                table: "visit",
                column: "company_label");

            migrationBuilder.CreateIndex(
                name: "IX_visit_contact_person_name",
                table: "visit",
                column: "contact_person_name");

            migrationBuilder.CreateIndex(
                name: "IX_visit_visitor_id",
                table: "visit",
                column: "visitor_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "visit");

            migrationBuilder.DropTable(
                name: "company");

            migrationBuilder.DropTable(
                name: "contact_person");

            migrationBuilder.DropTable(
                name: "visitor");
        }
    }
}
