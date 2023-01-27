using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace newsSite90tv.Migrations
{
    public partial class mig19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_ProductColor_Tbl_Shop_shop_id",
                table: "Tbl_ProductColor");

            migrationBuilder.RenameColumn(
                name: "ismultisell",
                table: "Tbl_Products",
                newName: "isexist");

            migrationBuilder.AddColumn<int>(
                name: "offpercent",
                table: "Tbl_Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "price",
                table: "Tbl_Products",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "qty",
                table: "Tbl_Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "seller_id",
                table: "Tbl_Products",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "shop_id",
                table: "Tbl_Products",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "shop_id",
                table: "Tbl_ProductColor",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Products_seller_id",
                table: "Tbl_Products",
                column: "seller_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Products_shop_id",
                table: "Tbl_Products",
                column: "shop_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_ProductColor_Tbl_Shop_shop_id",
                table: "Tbl_ProductColor",
                column: "shop_id",
                principalTable: "Tbl_Shop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Products_Tbl_Salsman_seller_id",
                table: "Tbl_Products",
                column: "seller_id",
                principalTable: "Tbl_Salsman",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Products_Tbl_Shop_shop_id",
                table: "Tbl_Products",
                column: "shop_id",
                principalTable: "Tbl_Shop",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_ProductColor_Tbl_Shop_shop_id",
                table: "Tbl_ProductColor");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Products_Tbl_Salsman_seller_id",
                table: "Tbl_Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Products_Tbl_Shop_shop_id",
                table: "Tbl_Products");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Products_seller_id",
                table: "Tbl_Products");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Products_shop_id",
                table: "Tbl_Products");

            migrationBuilder.DropColumn(
                name: "offpercent",
                table: "Tbl_Products");

            migrationBuilder.DropColumn(
                name: "price",
                table: "Tbl_Products");

            migrationBuilder.DropColumn(
                name: "qty",
                table: "Tbl_Products");

            migrationBuilder.DropColumn(
                name: "seller_id",
                table: "Tbl_Products");

            migrationBuilder.DropColumn(
                name: "shop_id",
                table: "Tbl_Products");

            migrationBuilder.RenameColumn(
                name: "isexist",
                table: "Tbl_Products",
                newName: "ismultisell");

            migrationBuilder.AlterColumn<long>(
                name: "shop_id",
                table: "Tbl_ProductColor",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_ProductColor_Tbl_Shop_shop_id",
                table: "Tbl_ProductColor",
                column: "shop_id",
                principalTable: "Tbl_Shop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
