using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VisitOnline.Migrations
{
    public partial class AddVisitRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VisitRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SickId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    NumberNoskhe = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitRequests_Sick_SickId",
                        column: x => x.SickId,
                        principalTable: "Sick",
                        principalColumn: "SickId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VisitRequests_SickId",
                table: "VisitRequests",
                column: "SickId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VisitRequests");
        }
    }
}
