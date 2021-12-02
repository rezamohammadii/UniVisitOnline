using Microsoft.EntityFrameworkCore.Migrations;

namespace VisitOnline.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_VisitRequests_RequestId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Sick_VisitRequests_RequestId",
                table: "Sick");

            migrationBuilder.DropIndex(
                name: "IX_Sick_RequestId",
                table: "Sick");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_RequestId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "Sick");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "Doctors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "Sick",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sick_RequestId",
                table: "Sick",
                column: "RequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_RequestId",
                table: "Doctors",
                column: "RequestId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_VisitRequests_RequestId",
                table: "Doctors",
                column: "RequestId",
                principalTable: "VisitRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sick_VisitRequests_RequestId",
                table: "Sick",
                column: "RequestId",
                principalTable: "VisitRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
