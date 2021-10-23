using Microsoft.EntityFrameworkCore.Migrations;

namespace NBG.Visitor.Services.DB.Migrations
{
    public partial class UpdateColumnNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visit_Visitor_VisitId",
                table: "Visit");

            migrationBuilder.DropIndex(
                name: "IX_Visit_VisitId",
                table: "Visit");

            migrationBuilder.AddColumn<int>(
                name: "VisitorId",
                table: "Visit",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visit_VisitorId",
                table: "Visit",
                column: "VisitorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visit_Visitor_VisitorId",
                table: "Visit",
                column: "VisitorId",
                principalTable: "Visitor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visit_Visitor_VisitorId",
                table: "Visit");

            migrationBuilder.DropIndex(
                name: "IX_Visit_VisitorId",
                table: "Visit");

            migrationBuilder.DropColumn(
                name: "VisitorId",
                table: "Visit");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_VisitId",
                table: "Visit",
                column: "VisitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visit_Visitor_VisitId",
                table: "Visit",
                column: "VisitId",
                principalTable: "Visitor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
