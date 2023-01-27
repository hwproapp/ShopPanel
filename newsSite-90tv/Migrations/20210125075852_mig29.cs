using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace newsSite90tv.Migrations
{
    public partial class mig29 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_ShopComment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_ShopComment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsEnable = table.Column<bool>(nullable: false),
                    appuser_id = table.Column<long>(nullable: false),
                    body = table.Column<string>(nullable: true),
                    dateMiladi = table.Column<DateTime>(nullable: false),
                    dateShamsi = table.Column<string>(nullable: true),
                    replyto = table.Column<int>(nullable: false),
                    shop_id = table.Column<long>(nullable: false),
                    status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ShopComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_ShopComment_Tbl_UserApp_appuser_id",
                        column: x => x.appuser_id,
                        principalTable: "Tbl_UserApp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_ShopComment_Tbl_Shop_shop_id",
                        column: x => x.shop_id,
                        principalTable: "Tbl_Shop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ShopComment_appuser_id",
                table: "Tbl_ShopComment",
                column: "appuser_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ShopComment_shop_id",
                table: "Tbl_ShopComment",
                column: "shop_id");
        }
    }
}
