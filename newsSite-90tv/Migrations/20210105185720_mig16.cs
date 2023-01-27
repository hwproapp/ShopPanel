using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace newsSite90tv.Migrations
{
    public partial class mig16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_BuyCheck");

            migrationBuilder.DropTable(
                name: "Tbl_FixRequest");

            migrationBuilder.DropTable(
                name: "Tbl_SellCheck");

            migrationBuilder.DropTable(
                name: "Tbl_SellFix");

            migrationBuilder.DropColumn(
                name: "fromdateshamsi",
                table: "Tbl_Shop");

            migrationBuilder.DropColumn(
                name: "todate",
                table: "Tbl_Shop");

            migrationBuilder.DropColumn(
                name: "todateshamsi",
                table: "Tbl_Shop");

            migrationBuilder.DropColumn(
                name: "isfix",
                table: "Tbl_Sell");

            migrationBuilder.AddColumn<int>(
                name: "removableprice",
                table: "Tbl_Sell",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Tbl_Checkout",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    bank_id = table.Column<long>(nullable: false),
                    checkoutprice = table.Column<int>(nullable: false),
                    datemiladi = table.Column<DateTime>(nullable: false),
                    dateshamsi = table.Column<string>(nullable: true),
                    seller_id = table.Column<long>(nullable: false),
                    shop_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Checkout", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Checkout_Tbl_Salsman_seller_id",
                        column: x => x.seller_id,
                        principalTable: "Tbl_Salsman",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Checkout_Tbl_Shop_shop_id",
                        column: x => x.shop_id,
                        principalTable: "Tbl_Shop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_CheckoutRequest",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    bank_id = table.Column<long>(nullable: false),
                    dateMiladi = table.Column<DateTime>(nullable: false),
                    dateShamsi = table.Column<string>(nullable: true),
                    requestprice = table.Column<int>(nullable: false),
                    seller_id = table.Column<long>(nullable: false),
                    shop_id = table.Column<long>(nullable: false),
                    status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_CheckoutRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_CheckoutRequest_Tbl_sellerBank_bank_id",
                        column: x => x.bank_id,
                        principalTable: "Tbl_sellerBank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_CheckoutRequest_Tbl_Salsman_seller_id",
                        column: x => x.seller_id,
                        principalTable: "Tbl_Salsman",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_CheckoutRequest_Tbl_Shop_shop_id",
                        column: x => x.shop_id,
                        principalTable: "Tbl_Shop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Checkout_seller_id",
                table: "Tbl_Checkout",
                column: "seller_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Checkout_shop_id",
                table: "Tbl_Checkout",
                column: "shop_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_CheckoutRequest_bank_id",
                table: "Tbl_CheckoutRequest",
                column: "bank_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_CheckoutRequest_seller_id",
                table: "Tbl_CheckoutRequest",
                column: "seller_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_CheckoutRequest_shop_id",
                table: "Tbl_CheckoutRequest",
                column: "shop_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Checkout");

            migrationBuilder.DropTable(
                name: "Tbl_CheckoutRequest");

            migrationBuilder.DropColumn(
                name: "removableprice",
                table: "Tbl_Sell");

            migrationBuilder.AddColumn<string>(
                name: "fromdateshamsi",
                table: "Tbl_Shop",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "todate",
                table: "Tbl_Shop",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "todateshamsi",
                table: "Tbl_Shop",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isfix",
                table: "Tbl_Sell",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Tbl_BuyCheck",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    buy_id = table.Column<int>(nullable: false),
                    dateMiladi = table.Column<DateTime>(nullable: false),
                    dateShamsi = table.Column<string>(nullable: true),
                    desc = table.Column<string>(nullable: true),
                    isenable = table.Column<bool>(nullable: false),
                    status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_BuyCheck", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_BuyCheck_Tbl_Buy_buy_id",
                        column: x => x.buy_id,
                        principalTable: "Tbl_Buy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_FixRequest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dateMiladi = table.Column<DateTime>(nullable: false),
                    dateShamsi = table.Column<string>(nullable: true),
                    isenable = table.Column<bool>(nullable: false),
                    seller_id = table.Column<long>(nullable: false),
                    status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_FixRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_FixRequest_Tbl_Salsman_seller_id",
                        column: x => x.seller_id,
                        principalTable: "Tbl_Salsman",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_SellCheck",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dateMiladi = table.Column<DateTime>(nullable: false),
                    dateShamsi = table.Column<string>(nullable: true),
                    desc = table.Column<string>(nullable: true),
                    isenable = table.Column<bool>(nullable: false),
                    sell_id = table.Column<int>(nullable: false),
                    status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_SellCheck", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_SellCheck_Tbl_Sell_sell_id",
                        column: x => x.sell_id,
                        principalTable: "Tbl_Sell",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_SellFix",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    createdateml = table.Column<DateTime>(nullable: false),
                    createdatesh = table.Column<string>(nullable: true),
                    sell_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_SellFix", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_SellFix_Tbl_Sell_sell_id",
                        column: x => x.sell_id,
                        principalTable: "Tbl_Sell",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_BuyCheck_buy_id",
                table: "Tbl_BuyCheck",
                column: "buy_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_FixRequest_seller_id",
                table: "Tbl_FixRequest",
                column: "seller_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_SellCheck_sell_id",
                table: "Tbl_SellCheck",
                column: "sell_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_SellFix_sell_id",
                table: "Tbl_SellFix",
                column: "sell_id");
        }
    }
}
