using Microsoft.EntityFrameworkCore.Migrations;

namespace VisitOnline.Migrations
{
    public partial class updatetablevisitrequset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "VisitRequests");

            migrationBuilder.AddColumn<string>(
                name: "AnswerDoctor",
                table: "VisitRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DateAnswer",
                table: "VisitRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DateRequest",
                table: "VisitRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PicNoskhe",
                table: "VisitRequests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswerDoctor",
                table: "VisitRequests");

            migrationBuilder.DropColumn(
                name: "DateAnswer",
                table: "VisitRequests");

            migrationBuilder.DropColumn(
                name: "DateRequest",
                table: "VisitRequests");

            migrationBuilder.DropColumn(
                name: "PicNoskhe",
                table: "VisitRequests");

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "VisitRequests",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
