using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace newsSite90tv.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "age",
                table: "Tbl_UserApp");

            migrationBuilder.DropColumn(
                name: "birthdateshamsi",
                table: "Tbl_UserApp");

            migrationBuilder.DropColumn(
                name: "emailactivestatus",
                table: "Tbl_UserApp");

            migrationBuilder.DropColumn(
                name: "lastlogin",
                table: "Tbl_UserApp");

            migrationBuilder.DropColumn(
                name: "isopen",
                table: "Tbl_Shop");

            migrationBuilder.DropColumn(
                name: "sendTime",
                table: "Tbl_Shop");

            migrationBuilder.DropColumn(
                name: "sendprice",
                table: "Tbl_Shop");

            migrationBuilder.DropColumn(
                name: "rate",
                table: "Tbl_Salsman");

            migrationBuilder.DropColumn(
                name: "sabeghe",
                table: "Tbl_Salsman");

            migrationBuilder.RenameColumn(
                name: "emailactivecode",
                table: "Tbl_UserApp",
                newName: "moobile");

            migrationBuilder.AlterColumn<string>(
                name: "birthdate",
                table: "Tbl_UserApp",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "moobile",
                table: "Tbl_UserApp",
                newName: "emailactivecode");

            migrationBuilder.AlterColumn<DateTime>(
                name: "birthdate",
                table: "Tbl_UserApp",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "age",
                table: "Tbl_UserApp",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "birthdateshamsi",
                table: "Tbl_UserApp",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "emailactivestatus",
                table: "Tbl_UserApp",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "lastlogin",
                table: "Tbl_UserApp",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isopen",
                table: "Tbl_Shop",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte>(
                name: "sendTime",
                table: "Tbl_Shop",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<long>(
                name: "sendprice",
                table: "Tbl_Shop",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "rate",
                table: "Tbl_Salsman",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte>(
                name: "sabeghe",
                table: "Tbl_Salsman",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
