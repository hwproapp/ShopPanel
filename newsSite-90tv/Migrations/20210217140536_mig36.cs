using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace newsSite90tv.Migrations
{
    public partial class mig36 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_ErrorReportProduct");

            migrationBuilder.DropTable(
                name: "Tbl_ErrorReportShop");

            migrationBuilder.DropTable(
                name: "Tbl_ErrorReportReason");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_ErrorReportReason",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isenable = table.Column<bool>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    type = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ErrorReportReason", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ErrorReportProduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    appuser_id = table.Column<long>(nullable: false),
                    dateMiladi = table.Column<DateTime>(nullable: false),
                    dateShamsi = table.Column<string>(nullable: true),
                    isenable = table.Column<bool>(nullable: false),
                    message = table.Column<string>(nullable: true),
                    product_id = table.Column<long>(nullable: false),
                    reason_id = table.Column<int>(nullable: false),
                    status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ErrorReportProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_ErrorReportProduct_Tbl_UserApp_appuser_id",
                        column: x => x.appuser_id,
                        principalTable: "Tbl_UserApp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_ErrorReportProduct_Tbl_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Tbl_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_ErrorReportProduct_Tbl_ErrorReportReason_reason_id",
                        column: x => x.reason_id,
                        principalTable: "Tbl_ErrorReportReason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ErrorReportShop",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    appuser_id = table.Column<long>(nullable: false),
                    dateMiladi = table.Column<DateTime>(nullable: false),
                    dateShamsi = table.Column<string>(nullable: true),
                    isenable = table.Column<bool>(nullable: false),
                    message = table.Column<string>(nullable: true),
                    reason_id = table.Column<int>(nullable: false),
                    shop_id = table.Column<long>(nullable: false),
                    status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ErrorReportShop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_ErrorReportShop_Tbl_UserApp_appuser_id",
                        column: x => x.appuser_id,
                        principalTable: "Tbl_UserApp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_ErrorReportShop_Tbl_ErrorReportReason_reason_id",
                        column: x => x.reason_id,
                        principalTable: "Tbl_ErrorReportReason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_ErrorReportShop_Tbl_Shop_shop_id",
                        column: x => x.shop_id,
                        principalTable: "Tbl_Shop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ErrorReportProduct_appuser_id",
                table: "Tbl_ErrorReportProduct",
                column: "appuser_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ErrorReportProduct_product_id",
                table: "Tbl_ErrorReportProduct",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ErrorReportProduct_reason_id",
                table: "Tbl_ErrorReportProduct",
                column: "reason_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ErrorReportShop_appuser_id",
                table: "Tbl_ErrorReportShop",
                column: "appuser_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ErrorReportShop_reason_id",
                table: "Tbl_ErrorReportShop",
                column: "reason_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ErrorReportShop_shop_id",
                table: "Tbl_ErrorReportShop",
                column: "shop_id");
        }
    }
}
