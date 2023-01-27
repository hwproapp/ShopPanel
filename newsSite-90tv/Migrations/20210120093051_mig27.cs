using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace newsSite90tv.Migrations
{
    public partial class mig27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "versionNumber",
                table: "Tbl_Appversion",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "versionName",
                table: "Tbl_Appversion",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<DateTime>(
                name: "dateMiladi",
                table: "Tbl_Appversion",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "dateShamsi",
                table: "Tbl_Appversion",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "desc",
                table: "Tbl_Appversion",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isEnable",
                table: "Tbl_Appversion",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "link",
                table: "Tbl_Appversion",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "status",
                table: "Tbl_Appversion",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dateMiladi",
                table: "Tbl_Appversion");

            migrationBuilder.DropColumn(
                name: "dateShamsi",
                table: "Tbl_Appversion");

            migrationBuilder.DropColumn(
                name: "desc",
                table: "Tbl_Appversion");

            migrationBuilder.DropColumn(
                name: "isEnable",
                table: "Tbl_Appversion");

            migrationBuilder.DropColumn(
                name: "link",
                table: "Tbl_Appversion");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Tbl_Appversion");

            migrationBuilder.AlterColumn<int>(
                name: "versionNumber",
                table: "Tbl_Appversion",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "versionName",
                table: "Tbl_Appversion",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
