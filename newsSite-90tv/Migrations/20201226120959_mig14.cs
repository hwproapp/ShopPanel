using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace newsSite90tv.Migrations
{
    public partial class mig14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "desbank",
                table: "Tbl_payment");

            migrationBuilder.DropColumn(
                name: "sourceBank",
                table: "Tbl_payment");

            migrationBuilder.DropColumn(
                name: "updatedateml",
                table: "Tbl_payment");

            migrationBuilder.DropColumn(
                name: "updatedatesh",
                table: "Tbl_payment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "desbank",
                table: "Tbl_payment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "sourceBank",
                table: "Tbl_payment",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updatedateml",
                table: "Tbl_payment",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "updatedatesh",
                table: "Tbl_payment",
                nullable: true);
        }
    }
}
