using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace newsSite90tv.Migrations
{
    public partial class mig17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Appsetting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    about = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    isEnable = table.Column<bool>(nullable: false),
                    ownername = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    shabacode = table.Column<string>(nullable: true),
                    user_id = table.Column<string>(nullable: true),
                    wage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Appsetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Appsetting_AspNetUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Appsetting_user_id",
                table: "Tbl_Appsetting",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Appsetting");
        }
    }
}
