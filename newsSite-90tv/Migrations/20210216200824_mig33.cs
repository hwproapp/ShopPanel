using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace newsSite90tv.Migrations
{
    public partial class mig33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "property_id",
                table: "Tbl_ProductProperties",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ProductProperties_property_id",
                table: "Tbl_ProductProperties",
                column: "property_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_ProductProperties_Tbl_Properties_property_id",
                table: "Tbl_ProductProperties",
                column: "property_id",
                principalTable: "Tbl_Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_ProductProperties_Tbl_Properties_property_id",
                table: "Tbl_ProductProperties");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_ProductProperties_property_id",
                table: "Tbl_ProductProperties");

            migrationBuilder.DropColumn(
                name: "property_id",
                table: "Tbl_ProductProperties");
        }
    }
}
