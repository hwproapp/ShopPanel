using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace newsSite90tv.Migrations
{
    public partial class mig26 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Size_Tbl_Category_cat_id",
                table: "Tbl_Size");

            migrationBuilder.DropColumn(
                name: "isEnable",
                table: "Tbl_Appsetting");

            migrationBuilder.AlterColumn<int>(
                name: "cat_id",
                table: "Tbl_Size",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Size_Tbl_Category_cat_id",
                table: "Tbl_Size",
                column: "cat_id",
                principalTable: "Tbl_Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Size_Tbl_Category_cat_id",
                table: "Tbl_Size");

            migrationBuilder.AlterColumn<int>(
                name: "cat_id",
                table: "Tbl_Size",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isEnable",
                table: "Tbl_Appsetting",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Size_Tbl_Category_cat_id",
                table: "Tbl_Size",
                column: "cat_id",
                principalTable: "Tbl_Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
