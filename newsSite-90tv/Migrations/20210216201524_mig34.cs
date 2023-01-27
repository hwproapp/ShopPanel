using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace newsSite90tv.Migrations
{
    public partial class mig34 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_ProductProperties_Tbl_Properties_property_id",
                table: "Tbl_ProductProperties");

            migrationBuilder.RenameColumn(
                name: "property_id",
                table: "Tbl_ProductProperties",
                newName: "properties_id");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_ProductProperties_property_id",
                table: "Tbl_ProductProperties",
                newName: "IX_Tbl_ProductProperties_properties_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_ProductProperties_Tbl_Properties_properties_id",
                table: "Tbl_ProductProperties",
                column: "properties_id",
                principalTable: "Tbl_Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_ProductProperties_Tbl_Properties_properties_id",
                table: "Tbl_ProductProperties");

            migrationBuilder.RenameColumn(
                name: "properties_id",
                table: "Tbl_ProductProperties",
                newName: "property_id");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_ProductProperties_properties_id",
                table: "Tbl_ProductProperties",
                newName: "IX_Tbl_ProductProperties_property_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_ProductProperties_Tbl_Properties_property_id",
                table: "Tbl_ProductProperties",
                column: "property_id",
                principalTable: "Tbl_Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
