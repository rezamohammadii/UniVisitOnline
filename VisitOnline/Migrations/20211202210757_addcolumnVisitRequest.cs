﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace VisitOnline.Migrations
{
    public partial class addcolumnVisitRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "VisitRequests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "VisitRequests");
        }
    }
}
