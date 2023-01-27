using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace newsSite90tv.Migrations
{
    public partial class mig15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "count",
                table: "Tbl_orderdetail",
                newName: "qty");

            migrationBuilder.AlterColumn<int>(
                name: "qty",
                table: "Tbl_Sell",
                nullable: false,
                oldClrType: typeof(byte));

            migrationBuilder.AlterColumn<int>(
                name: "totalprice",
                table: "Tbl_orderdetail",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "price",
                table: "Tbl_orderdetail",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "qty",
                table: "Tbl_Buy",
                nullable: false,
                oldClrType: typeof(byte));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "qty",
                table: "Tbl_orderdetail",
                newName: "count");

            migrationBuilder.AlterColumn<byte>(
                name: "qty",
                table: "Tbl_Sell",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "totalprice",
                table: "Tbl_orderdetail",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "price",
                table: "Tbl_orderdetail",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<byte>(
                name: "qty",
                table: "Tbl_Buy",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
