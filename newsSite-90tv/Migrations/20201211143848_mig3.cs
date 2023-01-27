using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace newsSite90tv.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Advertise_Tbl_Salsman_sel_id",
                table: "Tbl_Advertise");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Advertise_sel_id",
                table: "Tbl_Advertise");

            migrationBuilder.DropColumn(
                name: "desc",
                table: "Tbl_Advertise");

            migrationBuilder.DropColumn(
                name: "time",
                table: "Tbl_Advertise");

            migrationBuilder.DropColumn(
                name: "title",
                table: "Tbl_Advertise");

            migrationBuilder.DropColumn(
                name: "userapptoken",
                table: "Tbl_Advertise");

            migrationBuilder.DropColumn(
                name: "viewCount",
                table: "Tbl_Advertise");

            migrationBuilder.RenameColumn(
                name: "sel_id",
                table: "Tbl_Advertise",
                newName: "appuser_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "appuser_id",
                table: "Tbl_Advertise",
                newName: "sel_id");

            migrationBuilder.AddColumn<string>(
                name: "desc",
                table: "Tbl_Advertise",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "time",
                table: "Tbl_Advertise",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "Tbl_Advertise",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userapptoken",
                table: "Tbl_Advertise",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "viewCount",
                table: "Tbl_Advertise",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Advertise_sel_id",
                table: "Tbl_Advertise",
                column: "sel_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Advertise_Tbl_Salsman_sel_id",
                table: "Tbl_Advertise",
                column: "sel_id",
                principalTable: "Tbl_Salsman",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
