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
                name: "Company",
                columns: table => new
                {
                    CompanyLabel = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyLabel);
                });

            migrationBuilder.CreateTable(
                name: "ContactPerson",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPerson", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Visitor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Visit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VisitStart = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    VisitEnd = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    VisitorId = table.Column<int>(type: "integer", nullable: false),
                    ContactPersonName = table.Column<string>(type: "text", nullable: false),
                    CompanyLabel = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visit_Company_CompanyLabel",
                        column: x => x.CompanyLabel,
                        principalTable: "Company",
                        principalColumn: "CompanyLabel",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visit_ContactPerson_ContactPersonName",
                        column: x => x.ContactPersonName,
                        principalTable: "ContactPerson",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visit_Visitor_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_CompanyLabel",
                table: "Company",
                column: "CompanyLabel",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactPerson_Name",
                table: "ContactPerson",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visit_CompanyLabel",
                table: "Visit",
                column: "CompanyLabel");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_ContactPersonName",
                table: "Visit",
                column: "ContactPersonName");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_VisitorId",
                table: "Visit",
                column: "VisitorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visit");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "ContactPerson");

            migrationBuilder.DropTable(
                name: "Visitor");
        }
    }
}
