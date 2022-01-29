using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBG.Visitor.Storage.Migrations
{
    public partial class AddedGuidToVisit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.AddColumn<Guid>(
                name: "uuid",
                table: "visit",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "uuid",
                table: "visit");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,");
        }
    }
}
