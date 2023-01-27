using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace newsSite90tv.Migrations
{
    public partial class mig9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Tbl_Plan");

            migrationBuilder.DropColumn(
                name: "sendprice",
                table: "Tbl_Order");

            migrationBuilder.AddColumn<int>(
                name: "offpercent",
                table: "Tbl_Plan",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "sumprice",
                table: "Tbl_Order",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<int>(
                name: "postprice",
                table: "Tbl_Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte>(
                name: "posttype",
                table: "Tbl_Order",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "Tbl_AdvertisePlanState",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    adv_id = table.Column<long>(nullable: false),
                    expiredateml = table.Column<DateTime>(nullable: false),
                    expiredatesh = table.Column<string>(nullable: true),
                    plan_id = table.Column<int>(nullable: false),
                    startdateml = table.Column<DateTime>(nullable: false),
                    startdatesh = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_AdvertisePlanState", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_AdvertisePlanState_Tbl_ShopAdvertise_adv_id",
                        column: x => x.adv_id,
                        principalTable: "Tbl_ShopAdvertise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_AdvertisePlanState_Tbl_Plan_plan_id",
                        column: x => x.plan_id,
                        principalTable: "Tbl_Plan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ShopPlanState",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    expiredateml = table.Column<DateTime>(nullable: false),
                    expiredatesh = table.Column<string>(nullable: true),
                    plan_id = table.Column<int>(nullable: false),
                    shop_id = table.Column<long>(nullable: false),
                    startdateml = table.Column<DateTime>(nullable: false),
                    startdatesh = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ShopPlanState", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_ShopPlanState_Tbl_Plan_plan_id",
                        column: x => x.plan_id,
                        principalTable: "Tbl_Plan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_ShopPlanState_Tbl_Shop_shop_id",
                        column: x => x.shop_id,
                        principalTable: "Tbl_Shop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_AdvertisePlanState_adv_id",
                table: "Tbl_AdvertisePlanState",
                column: "adv_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_AdvertisePlanState_plan_id",
                table: "Tbl_AdvertisePlanState",
                column: "plan_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ShopPlanState_plan_id",
                table: "Tbl_ShopPlanState",
                column: "plan_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ShopPlanState_shop_id",
                table: "Tbl_ShopPlanState",
                column: "shop_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_AdvertisePlanState");

            migrationBuilder.DropTable(
                name: "Tbl_ShopPlanState");

            migrationBuilder.DropColumn(
                name: "offpercent",
                table: "Tbl_Plan");

            migrationBuilder.DropColumn(
                name: "postprice",
                table: "Tbl_Order");

            migrationBuilder.DropColumn(
                name: "posttype",
                table: "Tbl_Order");

            migrationBuilder.AddColumn<byte>(
                name: "status",
                table: "Tbl_Plan",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AlterColumn<long>(
                name: "sumprice",
                table: "Tbl_Order",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<long>(
                name: "sendprice",
                table: "Tbl_Order",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
