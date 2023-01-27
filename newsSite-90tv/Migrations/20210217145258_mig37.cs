using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace newsSite90tv.Migrations
{
    public partial class mig37 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_ReportReason",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isenable = table.Column<bool>(nullable: false),
                    title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ReportReason", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ReportProduct",
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
                    table.PrimaryKey("PK_Tbl_ReportProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_ReportProduct_Tbl_UserApp_appuser_id",
                        column: x => x.appuser_id,
                        principalTable: "Tbl_UserApp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_ReportProduct_Tbl_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Tbl_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_ReportProduct_Tbl_ReportReason_reason_id",
                        column: x => x.reason_id,
                        principalTable: "Tbl_ReportReason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ReportProduct_appuser_id",
                table: "Tbl_ReportProduct",
                column: "appuser_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ReportProduct_product_id",
                table: "Tbl_ReportProduct",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ReportProduct_reason_id",
                table: "Tbl_ReportProduct",
                column: "reason_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_ReportProduct");

            migrationBuilder.DropTable(
                name: "Tbl_ReportReason");
        }
    }
}
