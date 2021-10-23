using Microsoft.EntityFrameworkCore.Migrations;

namespace NBG.Visitor.Storage.Migrations
{
    public partial class PostgresNamingConvention2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "visitor",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "visitor",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "visit",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "visit",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "contact_person",
                newName: "name");

            migrationBuilder.RenameIndex(
                name: "IX_contact_person_Name",
                table: "contact_person",
                newName: "IX_contact_person_name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "email",
                table: "visitor",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "visitor",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "visit",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "visit",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "contact_person",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_contact_person_name",
                table: "contact_person",
                newName: "IX_contact_person_Name");
        }
    }
}
