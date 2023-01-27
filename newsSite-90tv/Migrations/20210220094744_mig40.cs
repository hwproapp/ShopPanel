using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace newsSite90tv.Migrations
{
    public partial class mig40 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_filemanager");

            migrationBuilder.AddColumn<string>(
                name: "image",
                table: "Tbl_Banner",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ostan_id",
                table: "Tbl_Banner",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Banner_ostan_id",
                table: "Tbl_Banner",
                column: "ostan_id");


            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Banner_Tbl_Ostans_ostan_id",
                table: "Tbl_Banner",
                column: "ostan_id",
                principalTable: "Tbl_Ostans",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Banner_Tbl_Ostans_ostan_id",
                table: "Tbl_Banner");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Banner_ostan_id",
                table: "Tbl_Banner");

            migrationBuilder.DropColumn(
                name: "image",
                table: "Tbl_Banner");

            migrationBuilder.DropColumn(
                name: "ostan_id",
                table: "Tbl_Banner");

            migrationBuilder.CreateTable(
                name: "Tbl_filemanager",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    path = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_filemanager", x => x.Id);
                });
        }
    }
}
