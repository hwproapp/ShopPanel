using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace newsSite90tv.Migrations
{
    public partial class mig23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_AdvertisePlanState");

            migrationBuilder.RenameColumn(
                name: "summary",
                table: "Tbl_Products",
                newName: "keyword");

            migrationBuilder.AddColumn<string>(
                name: "garanty",
                table: "Tbl_Products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tbl_Appversion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    versionName = table.Column<int>(nullable: false),
                    versionNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Appversion", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ProductSize_size_id",
                table: "Tbl_ProductSize",
                column: "size_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_ProductSize_Tbl_Size_size_id",
                table: "Tbl_ProductSize",
                column: "size_id",
                principalTable: "Tbl_Size",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_ProductSize_Tbl_Size_size_id",
                table: "Tbl_ProductSize");

            migrationBuilder.DropTable(
                name: "Tbl_Appversion");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_ProductSize_size_id",
                table: "Tbl_ProductSize");

            migrationBuilder.DropColumn(
                name: "garanty",
                table: "Tbl_Products");

            migrationBuilder.RenameColumn(
                name: "keyword",
                table: "Tbl_Products",
                newName: "summary");

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

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_AdvertisePlanState_adv_id",
                table: "Tbl_AdvertisePlanState",
                column: "adv_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_AdvertisePlanState_plan_id",
                table: "Tbl_AdvertisePlanState",
                column: "plan_id");
        }
    }
}
