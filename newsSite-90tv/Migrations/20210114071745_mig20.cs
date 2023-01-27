using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace newsSite90tv.Migrations
{
    public partial class mig20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_ProductColor_Tbl_Shop_shop_id",
                table: "Tbl_ProductColor");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_ProductColor_shop_id",
                table: "Tbl_ProductColor");

            migrationBuilder.DropColumn(
                name: "isEnable",
                table: "Tbl_ProductColor");

            migrationBuilder.DropColumn(
                name: "shop_id",
                table: "Tbl_ProductColor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isEnable",
                table: "Tbl_ProductColor",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "shop_id",
                table: "Tbl_ProductColor",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ProductColor_shop_id",
                table: "Tbl_ProductColor",
                column: "shop_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_ProductColor_Tbl_Shop_shop_id",
                table: "Tbl_ProductColor",
                column: "shop_id",
                principalTable: "Tbl_Shop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
