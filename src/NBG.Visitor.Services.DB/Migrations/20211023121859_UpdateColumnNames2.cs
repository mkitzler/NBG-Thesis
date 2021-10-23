using Microsoft.EntityFrameworkCore.Migrations;

namespace NBG.Visitor.Services.DB.Migrations
{
    public partial class UpdateColumnNames2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visit_Visitor_VisitorId",
                table: "Visit");

            migrationBuilder.DropColumn(
                name: "VisitId",
                table: "Visit");

            migrationBuilder.AlterColumn<int>(
                name: "VisitorId",
                table: "Visit",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Visit_Visitor_VisitorId",
                table: "Visit",
                column: "VisitorId",
                principalTable: "Visitor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visit_Visitor_VisitorId",
                table: "Visit");

            migrationBuilder.AlterColumn<int>(
                name: "VisitorId",
                table: "Visit",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "VisitId",
                table: "Visit",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Visit_Visitor_VisitorId",
                table: "Visit",
                column: "VisitorId",
                principalTable: "Visitor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
