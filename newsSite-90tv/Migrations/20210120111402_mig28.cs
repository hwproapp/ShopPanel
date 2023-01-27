using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace newsSite90tv.Migrations
{
    public partial class mig28 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "versionNumber",
                table: "Tbl_Appversion");

            migrationBuilder.AddColumn<int>(
                name: "versionCode",
                table: "Tbl_Appversion",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "versionCode",
                table: "Tbl_Appversion");

            migrationBuilder.AddColumn<string>(
                name: "versionNumber",
                table: "Tbl_Appversion",
                nullable: true);
        }
    }
}
