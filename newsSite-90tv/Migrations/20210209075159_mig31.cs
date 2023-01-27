using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace newsSite90tv.Migrations
{
    public partial class mig31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Properties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    category_id = table.Column<int>(nullable: false),
                    isEnable = table.Column<bool>(nullable: false),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Properties_Tbl_Category_category_id",
                        column: x => x.category_id,
                        principalTable: "Tbl_Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_PropertiesValue",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isEnable = table.Column<bool>(nullable: false),
                    properties_id = table.Column<int>(nullable: false),
                    value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_PropertiesValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_PropertiesValue_Tbl_Properties_properties_id",
                        column: x => x.properties_id,
                        principalTable: "Tbl_Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ProductProperties",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    product_id = table.Column<long>(nullable: false),
                    propertiesvalue_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ProductProperties", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tbl_ProductProperties_Tbl_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Tbl_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_ProductProperties_Tbl_PropertiesValue_propertiesvalue_id",
                        column: x => x.propertiesvalue_id,
                        principalTable: "Tbl_PropertiesValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ProductProperties_product_id",
                table: "Tbl_ProductProperties",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ProductProperties_propertiesvalue_id",
                table: "Tbl_ProductProperties",
                column: "propertiesvalue_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Properties_category_id",
                table: "Tbl_Properties",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_PropertiesValue_properties_id",
                table: "Tbl_PropertiesValue",
                column: "properties_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_ProductProperties");

            migrationBuilder.DropTable(
                name: "Tbl_PropertiesValue");

            migrationBuilder.DropTable(
                name: "Tbl_Properties");
        }
    }
}
