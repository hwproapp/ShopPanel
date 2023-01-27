using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace newsSite90tv.Migrations
{
    public partial class mig25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tbl_Category",
                table: "Tbl_SizeCategory");

            migrationBuilder.DropColumn(
                name: "Tbl_Size",
                table: "Tbl_SizeCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_SizeCategory_cat_id",
                table: "Tbl_SizeCategory",
                column: "cat_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_SizeCategory_size_id",
                table: "Tbl_SizeCategory",
                column: "size_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_SizeCategory_Tbl_Category_cat_id",
                table: "Tbl_SizeCategory",
                column: "cat_id",
                principalTable: "Tbl_Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_SizeCategory_Tbl_Size_size_id",
                table: "Tbl_SizeCategory",
                column: "size_id",
                principalTable: "Tbl_Size",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_SizeCategory_Tbl_Category_cat_id",
                table: "Tbl_SizeCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_SizeCategory_Tbl_Size_size_id",
                table: "Tbl_SizeCategory");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_SizeCategory_cat_id",
                table: "Tbl_SizeCategory");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_SizeCategory_size_id",
                table: "Tbl_SizeCategory");

            migrationBuilder.AddColumn<int>(
                name: "Tbl_Category",
                table: "Tbl_SizeCategory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Tbl_Size",
                table: "Tbl_SizeCategory",
                nullable: false,
                defaultValue: 0);
        }
    }
}
