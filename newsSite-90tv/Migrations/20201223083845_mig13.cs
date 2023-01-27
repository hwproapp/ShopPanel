using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace newsSite90tv.Migrations
{
    public partial class mig13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_comment_Tbl_UserApp_UserAppId",
                table: "Tbl_comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_comment_Tbl_Products_prod_id",
                table: "Tbl_comment");

            migrationBuilder.DropColumn(
                name: "time",
                table: "Tbl_ShopComment");

            migrationBuilder.DropColumn(
                name: "UserToken",
                table: "Tbl_comment");

            migrationBuilder.DropColumn(
                name: "time",
                table: "Tbl_comment");

            migrationBuilder.RenameColumn(
                name: "prod_id",
                table: "Tbl_comment",
                newName: "product_id");

            migrationBuilder.RenameColumn(
                name: "UserAppId",
                table: "Tbl_comment",
                newName: "appuser_id");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_comment_prod_id",
                table: "Tbl_comment",
                newName: "IX_Tbl_comment_product_id");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_comment_UserAppId",
                table: "Tbl_comment",
                newName: "IX_Tbl_comment_appuser_id");

            migrationBuilder.AddColumn<bool>(
                name: "IsEnable",
                table: "Tbl_ShopComment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isEnable",
                table: "Tbl_comment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_comment_Tbl_UserApp_appuser_id",
                table: "Tbl_comment",
                column: "appuser_id",
                principalTable: "Tbl_UserApp",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_comment_Tbl_Products_product_id",
                table: "Tbl_comment",
                column: "product_id",
                principalTable: "Tbl_Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_comment_Tbl_UserApp_appuser_id",
                table: "Tbl_comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_comment_Tbl_Products_product_id",
                table: "Tbl_comment");

            migrationBuilder.DropColumn(
                name: "IsEnable",
                table: "Tbl_ShopComment");

            migrationBuilder.DropColumn(
                name: "isEnable",
                table: "Tbl_comment");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "Tbl_comment",
                newName: "prod_id");

            migrationBuilder.RenameColumn(
                name: "appuser_id",
                table: "Tbl_comment",
                newName: "UserAppId");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_comment_product_id",
                table: "Tbl_comment",
                newName: "IX_Tbl_comment_prod_id");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_comment_appuser_id",
                table: "Tbl_comment",
                newName: "IX_Tbl_comment_UserAppId");

            migrationBuilder.AddColumn<string>(
                name: "time",
                table: "Tbl_ShopComment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserToken",
                table: "Tbl_comment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "time",
                table: "Tbl_comment",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_comment_Tbl_UserApp_UserAppId",
                table: "Tbl_comment",
                column: "UserAppId",
                principalTable: "Tbl_UserApp",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_comment_Tbl_Products_prod_id",
                table: "Tbl_comment",
                column: "prod_id",
                principalTable: "Tbl_Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
