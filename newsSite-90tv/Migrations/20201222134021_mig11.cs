using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace newsSite90tv.Migrations
{
    public partial class mig11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_SellerSell");

            migrationBuilder.DropTable(
                name: "Tbl_UserBuy");

            migrationBuilder.CreateTable(
                name: "Tbl_Buy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    buyer_id = table.Column<long>(nullable: false),
                    buyeradd_id = table.Column<int>(nullable: false),
                    buystatus = table.Column<byte>(nullable: false),
                    createdateml = table.Column<DateTime>(nullable: false),
                    createdatesh = table.Column<string>(nullable: true),
                    isenable = table.Column<bool>(nullable: false),
                    posttype = table.Column<byte>(nullable: false),
                    price = table.Column<int>(nullable: false),
                    product_id = table.Column<long>(nullable: false),
                    qty = table.Column<byte>(nullable: false),
                    shop_id = table.Column<long>(nullable: false),
                    totalprice = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Buy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Buy_Tbl_UserApp_buyer_id",
                        column: x => x.buyer_id,
                        principalTable: "Tbl_UserApp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Buy_Tbl_Useraddress_buyeradd_id",
                        column: x => x.buyeradd_id,
                        principalTable: "Tbl_Useraddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_Buy_Tbl_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Tbl_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Buy_Tbl_Shop_shop_id",
                        column: x => x.shop_id,
                        principalTable: "Tbl_Shop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                name: "Tbl_Sell",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    buy_id = table.Column<int>(nullable: false),
                    createdateml = table.Column<DateTime>(nullable: false),
                    createdatesh = table.Column<string>(nullable: true),
                    isenable = table.Column<bool>(nullable: false),
                    isfix = table.Column<bool>(nullable: false),
                    price = table.Column<int>(nullable: false),
                    product_id = table.Column<long>(nullable: false),
                    qty = table.Column<byte>(nullable: false),
                    seller_id = table.Column<long>(nullable: false),
                    sellstatus = table.Column<byte>(nullable: false),
                    shop_id = table.Column<long>(nullable: false),
                    totalprice = table.Column<int>(nullable: false),
                    totalsellprice = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Sell", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Sell_Tbl_Buy_buy_id",
                        column: x => x.buy_id,
                        principalTable: "Tbl_Buy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Sell_Tbl_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Tbl_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_Sell_Tbl_Salsman_seller_id",
                        column: x => x.seller_id,
                        principalTable: "Tbl_Salsman",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_Sell_Tbl_Shop_shop_id",
                        column: x => x.shop_id,
                        principalTable: "Tbl_Shop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                name: "IX_Tbl_Buy_buyer_id",
                table: "Tbl_Buy",
                column: "buyer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Buy_buyeradd_id",
                table: "Tbl_Buy",
                column: "buyeradd_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Buy_product_id",
                table: "Tbl_Buy",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Buy_shop_id",
                table: "Tbl_Buy",
                column: "shop_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_BuyCheck_buy_id",
                table: "Tbl_BuyCheck",
                column: "buy_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_FixRequest_seller_id",
                table: "Tbl_FixRequest",
                column: "seller_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Sell_buy_id",
                table: "Tbl_Sell",
                column: "buy_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Sell_product_id",
                table: "Tbl_Sell",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Sell_seller_id",
                table: "Tbl_Sell",
                column: "seller_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Sell_shop_id",
                table: "Tbl_Sell",
                column: "shop_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_SellCheck_sell_id",
                table: "Tbl_SellCheck",
                column: "sell_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_SellFix_sell_id",
                table: "Tbl_SellFix",
                column: "sell_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_BuyCheck");

            migrationBuilder.DropTable(
                name: "Tbl_FixRequest");

            migrationBuilder.DropTable(
                name: "Tbl_SellCheck");

            migrationBuilder.DropTable(
                name: "Tbl_SellFix");

            migrationBuilder.DropTable(
                name: "Tbl_Sell");

            migrationBuilder.DropTable(
                name: "Tbl_Buy");

            migrationBuilder.CreateTable(
                name: "Tbl_SellerSell",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    appuser_id = table.Column<long>(nullable: false),
                    createdateml = table.Column<DateTime>(nullable: false),
                    createdatesh = table.Column<string>(nullable: true),
                    fixstate = table.Column<byte>(nullable: false),
                    isenable = table.Column<bool>(nullable: false),
                    orderdetail_id = table.Column<long>(nullable: false),
                    sellstate = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_SellerSell", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_SellerSell_Tbl_UserApp_appuser_id",
                        column: x => x.appuser_id,
                        principalTable: "Tbl_UserApp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_SellerSell_Tbl_orderdetail_orderdetail_id",
                        column: x => x.orderdetail_id,
                        principalTable: "Tbl_orderdetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_UserBuy",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    appuser_id = table.Column<long>(nullable: false),
                    buystate = table.Column<byte>(nullable: false),
                    createdateml = table.Column<DateTime>(nullable: false),
                    createdatesh = table.Column<string>(nullable: true),
                    isenable = table.Column<bool>(nullable: false),
                    orderdetail_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_UserBuy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_UserBuy_Tbl_UserApp_appuser_id",
                        column: x => x.appuser_id,
                        principalTable: "Tbl_UserApp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_UserBuy_Tbl_orderdetail_orderdetail_id",
                        column: x => x.orderdetail_id,
                        principalTable: "Tbl_orderdetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_SellerSell_appuser_id",
                table: "Tbl_SellerSell",
                column: "appuser_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_SellerSell_orderdetail_id",
                table: "Tbl_SellerSell",
                column: "orderdetail_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_UserBuy_appuser_id",
                table: "Tbl_UserBuy",
                column: "appuser_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_UserBuy_orderdetail_id",
                table: "Tbl_UserBuy",
                column: "orderdetail_id");
        }
    }
}
