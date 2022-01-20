using Microsoft.EntityFrameworkCore.Migrations;

namespace VisitOnline.Migrations
{
    public partial class Addtiket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tikets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Sender = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    SendDate = table.Column<string>(nullable: true),
                    AnswerDate = table.Column<string>(nullable: true),
                    AnswerBody = table.Column<string>(nullable: true),
                    IsRead = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tikets", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tikets");
        }
    }
}
