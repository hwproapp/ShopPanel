using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace newsSite90tv.Migrations
{
    public partial class mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Advertise_Tbl_Shop_shop_id",
                table: "Tbl_Advertise");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Advertise_AspNetUsers_users_id",
                table: "Tbl_Advertise");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_BannerImage_Tbl_WorkerBanner_banner_id",
                table: "Tbl_BannerImage");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_WorkerBanner_Tbl_UserApp_appuser_id",
                table: "Tbl_WorkerBanner");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_WorkerBanner_Tbl_Category_category_id",
                table: "Tbl_WorkerBanner");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_WorkerBanner_Tbl_City_city_id",
                table: "Tbl_WorkerBanner");

            migrationBuilder.DropTable(
                name: "Tbl_enableLevelstate");

            migrationBuilder.DropTable(
                name: "Tbl_EnableLevels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_WorkerBanner",
                table: "Tbl_WorkerBanner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_Advertise",
                table: "Tbl_Advertise");

            migrationBuilder.RenameTable(
                name: "Tbl_WorkerBanner",
                newName: "Tbl_Banner");

            migrationBuilder.RenameTable(
                name: "Tbl_Advertise",
                newName: "Tbl_ShopAdvertise");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_WorkerBanner_city_id",
                table: "Tbl_Banner",
                newName: "IX_Tbl_Banner_city_id");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_WorkerBanner_category_id",
                table: "Tbl_Banner",
                newName: "IX_Tbl_Banner_category_id");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_WorkerBanner_appuser_id",
                table: "Tbl_Banner",
                newName: "IX_Tbl_Banner_appuser_id");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_Advertise_users_id",
                table: "Tbl_ShopAdvertise",
                newName: "IX_Tbl_ShopAdvertise_users_id");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_Advertise_shop_id",
                table: "Tbl_ShopAdvertise",
                newName: "IX_Tbl_ShopAdvertise_shop_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_Banner",
                table: "Tbl_Banner",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_ShopAdvertise",
                table: "Tbl_ShopAdvertise",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Tbl_Plan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dateMiladi = table.Column<DateTime>(nullable: false),
                    dateShamsi = table.Column<string>(nullable: true),
                    desc = table.Column<string>(nullable: true),
                    isEnable = table.Column<bool>(nullable: false),
                    nameen = table.Column<string>(nullable: true),
                    namefa = table.Column<string>(nullable: true),
                    plantype = table.Column<byte>(nullable: false),
                    price = table.Column<int>(nullable: false),
                    status = table.Column<byte>(nullable: false),
                    type = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Plan", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Banner_Tbl_UserApp_appuser_id",
                table: "Tbl_Banner",
                column: "appuser_id",
                principalTable: "Tbl_UserApp",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Banner_Tbl_Category_category_id",
                table: "Tbl_Banner",
                column: "category_id",
                principalTable: "Tbl_Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Banner_Tbl_City_city_id",
                table: "Tbl_Banner",
                column: "city_id",
                principalTable: "Tbl_City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_BannerImage_Tbl_Banner_banner_id",
                table: "Tbl_BannerImage",
                column: "banner_id",
                principalTable: "Tbl_Banner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_ShopAdvertise_Tbl_Shop_shop_id",
                table: "Tbl_ShopAdvertise",
                column: "shop_id",
                principalTable: "Tbl_Shop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_ShopAdvertise_AspNetUsers_users_id",
                table: "Tbl_ShopAdvertise",
                column: "users_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Banner_Tbl_UserApp_appuser_id",
                table: "Tbl_Banner");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Banner_Tbl_Category_category_id",
                table: "Tbl_Banner");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Banner_Tbl_City_city_id",
                table: "Tbl_Banner");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_BannerImage_Tbl_Banner_banner_id",
                table: "Tbl_BannerImage");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_ShopAdvertise_Tbl_Shop_shop_id",
                table: "Tbl_ShopAdvertise");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_ShopAdvertise_AspNetUsers_users_id",
                table: "Tbl_ShopAdvertise");

            migrationBuilder.DropTable(
                name: "Tbl_Plan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_ShopAdvertise",
                table: "Tbl_ShopAdvertise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_Banner",
                table: "Tbl_Banner");

            migrationBuilder.RenameTable(
                name: "Tbl_ShopAdvertise",
                newName: "Tbl_Advertise");

            migrationBuilder.RenameTable(
                name: "Tbl_Banner",
                newName: "Tbl_WorkerBanner");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_ShopAdvertise_users_id",
                table: "Tbl_Advertise",
                newName: "IX_Tbl_Advertise_users_id");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_ShopAdvertise_shop_id",
                table: "Tbl_Advertise",
                newName: "IX_Tbl_Advertise_shop_id");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_Banner_city_id",
                table: "Tbl_WorkerBanner",
                newName: "IX_Tbl_WorkerBanner_city_id");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_Banner_category_id",
                table: "Tbl_WorkerBanner",
                newName: "IX_Tbl_WorkerBanner_category_id");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_Banner_appuser_id",
                table: "Tbl_WorkerBanner",
                newName: "IX_Tbl_WorkerBanner_appuser_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_Advertise",
                table: "Tbl_Advertise",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_WorkerBanner",
                table: "Tbl_WorkerBanner",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Tbl_EnableLevels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    count = table.Column<int>(nullable: false),
                    datemiladi = table.Column<DateTime>(nullable: false),
                    dateshamsi = table.Column<string>(nullable: true),
                    image = table.Column<string>(nullable: true),
                    isenable = table.Column<bool>(nullable: false),
                    price = table.Column<long>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    type = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_EnableLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_enableLevelstate",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    datemiladi = table.Column<string>(nullable: true),
                    dateshamsi = table.Column<string>(nullable: true),
                    isenable = table.Column<bool>(nullable: false),
                    level_id = table.Column<int>(nullable: false),
                    shop_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_enableLevelstate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_enableLevelstate_Tbl_EnableLevels_level_id",
                        column: x => x.level_id,
                        principalTable: "Tbl_EnableLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_enableLevelstate_Tbl_Shop_shop_id",
                        column: x => x.shop_id,
                        principalTable: "Tbl_Shop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_enableLevelstate_level_id",
                table: "Tbl_enableLevelstate",
                column: "level_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_enableLevelstate_shop_id",
                table: "Tbl_enableLevelstate",
                column: "shop_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Advertise_Tbl_Shop_shop_id",
                table: "Tbl_Advertise",
                column: "shop_id",
                principalTable: "Tbl_Shop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Advertise_AspNetUsers_users_id",
                table: "Tbl_Advertise",
                column: "users_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_BannerImage_Tbl_WorkerBanner_banner_id",
                table: "Tbl_BannerImage",
                column: "banner_id",
                principalTable: "Tbl_WorkerBanner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_WorkerBanner_Tbl_UserApp_appuser_id",
                table: "Tbl_WorkerBanner",
                column: "appuser_id",
                principalTable: "Tbl_UserApp",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_WorkerBanner_Tbl_Category_category_id",
                table: "Tbl_WorkerBanner",
                column: "category_id",
                principalTable: "Tbl_Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_WorkerBanner_Tbl_City_city_id",
                table: "Tbl_WorkerBanner",
                column: "city_id",
                principalTable: "Tbl_City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
