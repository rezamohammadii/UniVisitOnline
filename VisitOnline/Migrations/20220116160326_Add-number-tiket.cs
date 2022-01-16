using Microsoft.EntityFrameworkCore.Migrations;

namespace VisitOnline.Migrations
{
    public partial class Addnumbertiket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberTiket",
                table: "Tikets",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberTiket",
                table: "Tikets");
        }
    }
}
