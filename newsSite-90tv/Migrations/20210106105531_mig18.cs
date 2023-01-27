using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace newsSite90tv.Migrations
{
    public partial class mig18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Checkout_bank_id",
                table: "Tbl_Checkout",
                column: "bank_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Checkout_Tbl_sellerBank_bank_id",
                table: "Tbl_Checkout",
                column: "bank_id",
                principalTable: "Tbl_sellerBank",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Checkout_Tbl_sellerBank_bank_id",
                table: "Tbl_Checkout");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Checkout_bank_id",
                table: "Tbl_Checkout");
        }
    }
}
