using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace newsSite90tv.Migrations
{
    public partial class mig22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Buy",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    buyer_id = table.Column<long>(nullable: false),
                    buyeradd_id = table.Column<int>(nullable: false),
                    buystatus = table.Column<byte>(nullable: false),
                    color_id = table.Column<int>(nullable: false),
                    createdateml = table.Column<DateTime>(nullable: false),
                    createdatesh = table.Column<string>(nullable: true),
                    isenable = table.Column<bool>(nullable: false),
                    posttype = table.Column<byte>(nullable: false),
                    price = table.Column<int>(nullable: false),
                    product_id = table.Column<long>(nullable: false),
                    qty = table.Column<int>(nullable: false),
                    shop_id = table.Column<long>(nullable: false),
                    size_id = table.Column<int>(nullable: false),
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
                name: "Tbl_Sell",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    buy_id = table.Column<long>(nullable: false),
                    createdateml = table.Column<DateTime>(nullable: false),
                    createdatesh = table.Column<string>(nullable: true),
                    isenable = table.Column<bool>(nullable: false),
                    price = table.Column<int>(nullable: false),
                    product_id = table.Column<long>(nullable: false),
                    qty = table.Column<int>(nullable: false),
                    removableprice = table.Column<long>(nullable: false),
                    seller_id = table.Column<long>(nullable: false),
                    sellstatus = table.Column<byte>(nullable: false),
                    shop_id = table.Column<long>(nullable: false),
                    totalprice = table.Column<long>(nullable: false),
                    totalsellprice = table.Column<long>(nullable: false)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Sell");

            migrationBuilder.DropTable(
                name: "Tbl_Buy");
        }
    }
}
