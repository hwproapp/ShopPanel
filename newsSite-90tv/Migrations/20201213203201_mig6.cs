using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace newsSite90tv.Migrations
{
    public partial class mig6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fromdate",
                table: "Tbl_Shop");

            migrationBuilder.DropColumn(
                name: "bio",
                table: "Tbl_Salsman");

            migrationBuilder.DropColumn(
                name: "isSelect",
                table: "Tbl_ProductSeller");

            migrationBuilder.DropColumn(
                name: "offpercent",
                table: "Tbl_ProductColor");

            migrationBuilder.DropColumn(
                name: "price",
                table: "Tbl_ProductColor");

            migrationBuilder.DropColumn(
                name: "code",
                table: "Tbl_Banner");

            migrationBuilder.DropColumn(
                name: "fromdate",
                table: "Tbl_Banner");

            migrationBuilder.DropColumn(
                name: "isexpire",
                table: "Tbl_Banner");

            migrationBuilder.RenameColumn(
                name: "moobile",
                table: "Tbl_UserApp",
                newName: "mobile");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ProductSeller_seller_id",
                table: "Tbl_ProductSeller",
                column: "seller_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_ProductSeller_Tbl_Salsman_seller_id",
                table: "Tbl_ProductSeller",
                column: "seller_id",
                principalTable: "Tbl_Salsman",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_ProductSeller_Tbl_Salsman_seller_id",
                table: "Tbl_ProductSeller");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_ProductSeller_seller_id",
                table: "Tbl_ProductSeller");

            migrationBuilder.RenameColumn(
                name: "mobile",
                table: "Tbl_UserApp",
                newName: "moobile");

            migrationBuilder.AddColumn<DateTime>(
                name: "fromdate",
                table: "Tbl_Shop",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "bio",
                table: "Tbl_Salsman",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isSelect",
                table: "Tbl_ProductSeller",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte>(
                name: "offpercent",
                table: "Tbl_ProductColor",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<long>(
                name: "price",
                table: "Tbl_ProductColor",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "code",
                table: "Tbl_Banner",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fromdate",
                table: "Tbl_Banner",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isexpire",
                table: "Tbl_Banner",
                nullable: false,
                defaultValue: false);
        }
    }
}
