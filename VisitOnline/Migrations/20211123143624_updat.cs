using Microsoft.EntityFrameworkCore.Migrations;

namespace VisitOnline.Migrations
{
    public partial class updat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Users_UsersId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Sicks_Users_UsersId",
                table: "Sicks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sicks",
                table: "Sicks");

            migrationBuilder.DropIndex(
                name: "IX_Sicks_UsersId",
                table: "Sicks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_UsersId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Sicks");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Sicks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Doctors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sicks",
                table: "Sicks",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Users_UserId",
                table: "Doctors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sicks_Users_UserId",
                table: "Sicks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Users_UserId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Sicks_Users_UserId",
                table: "Sicks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sicks",
                table: "Sicks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Sicks",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "Sicks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sicks",
                table: "Sicks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sicks_UsersId",
                table: "Sicks",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_UsersId",
                table: "Doctors",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Users_UsersId",
                table: "Doctors",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sicks_Users_UsersId",
                table: "Sicks",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
