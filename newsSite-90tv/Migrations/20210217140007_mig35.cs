using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace newsSite90tv.Migrations
{
    public partial class mig35 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_ProductProperty");

            migrationBuilder.DropTable(
                name: "Tbl_Property");

            migrationBuilder.DropTable(
                name: "Tbl_PropertyPart");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_PropertyPart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isenable = table.Column<bool>(nullable: false),
                    key = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_PropertyPart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Property",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cat_id = table.Column<int>(nullable: false),
                    isenable = table.Column<bool>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    part_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Property", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Property_Tbl_Category_cat_id",
                        column: x => x.cat_id,
                        principalTable: "Tbl_Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Property_Tbl_PropertyPart_part_id",
                        column: x => x.part_id,
                        principalTable: "Tbl_PropertyPart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ProductProperty",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    product_id = table.Column<long>(nullable: false),
                    property_id = table.Column<int>(nullable: false),
                    value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ProductProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_ProductProperty_Tbl_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Tbl_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_ProductProperty_Tbl_Property_property_id",
                        column: x => x.property_id,
                        principalTable: "Tbl_Property",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ProductProperty_product_id",
                table: "Tbl_ProductProperty",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ProductProperty_property_id",
                table: "Tbl_ProductProperty",
                column: "property_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Property_cat_id",
                table: "Tbl_Property",
                column: "cat_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Property_part_id",
                table: "Tbl_Property",
                column: "part_id");
        }
    }
}
