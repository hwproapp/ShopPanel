using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace newsSite90tv.Migrations
{
    public partial class mig38 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "replyto",
                table: "Tbl_comment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "replyto",
                table: "Tbl_comment",
                nullable: false,
                defaultValue: 0);
        }
    }
}
