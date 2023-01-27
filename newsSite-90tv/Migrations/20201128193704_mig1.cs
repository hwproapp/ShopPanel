using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace newsSite90tv.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    RoleLevel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    BirthDayDate = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserImagePath = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    gender = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Brand",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isenable = table.Column<bool>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    nameen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParentId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    datemiladi = table.Column<DateTime>(nullable: false),
                    dateshamsi = table.Column<string>(nullable: true),
                    image = table.Column<string>(nullable: true),
                    isenable = table.Column<bool>(nullable: false),
                    type = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Color",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    code = table.Column<string>(nullable: true),
                    isenable = table.Column<bool>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    nameen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Color", x => x.Id);
                });

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
                name: "Tbl_Favorite",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    appuser_id = table.Column<long>(nullable: false),
                    product_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Favorite", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Tbl_Ostans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Ostans", x => x.Id);
                });

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_UserApp",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    User_id = table.Column<string>(nullable: true),
                    age = table.Column<byte>(nullable: false),
                    birthdate = table.Column<DateTime>(nullable: false),
                    birthdateshamsi = table.Column<string>(nullable: true),
                    datemiladi = table.Column<DateTime>(nullable: false),
                    dateshamsi = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    emailactivecode = table.Column<string>(nullable: true),
                    emailactivestatus = table.Column<bool>(nullable: false),
                    firstName = table.Column<string>(nullable: true),
                    gender = table.Column<byte>(nullable: false),
                    image = table.Column<string>(nullable: true),
                    isEnable = table.Column<bool>(nullable: false),
                    lastName = table.Column<string>(nullable: true),
                    lastlogin = table.Column<DateTime>(nullable: false),
                    mobileActiveCode = table.Column<string>(nullable: true),
                    mobileActiveStatus = table.Column<bool>(nullable: false),
                    nationalcode = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    token = table.Column<string>(nullable: true),
                    type = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_UserApp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_UserApp_AspNetUsers_User_id",
                        column: x => x.User_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Products",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    User_id = table.Column<string>(nullable: true),
                    brand_id = table.Column<int>(nullable: false),
                    cat_id = table.Column<int>(nullable: false),
                    dateMiladi = table.Column<DateTime>(nullable: false),
                    dateShamsi = table.Column<string>(nullable: true),
                    desc = table.Column<string>(nullable: true),
                    enable = table.Column<bool>(nullable: false),
                    image = table.Column<string>(nullable: true),
                    ismultisell = table.Column<bool>(nullable: false),
                    likeCount = table.Column<int>(nullable: false),
                    productcode = table.Column<string>(nullable: true),
                    status = table.Column<byte>(nullable: false),
                    summary = table.Column<string>(nullable: true),
                    title = table.Column<string>(nullable: true),
                    viewCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Products_AspNetUsers_User_id",
                        column: x => x.User_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_Products_Tbl_Brand_brand_id",
                        column: x => x.brand_id,
                        principalTable: "Tbl_Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Products_Tbl_Category_cat_id",
                        column: x => x.cat_id,
                        principalTable: "Tbl_Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_City",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ostan_id = table.Column<int>(nullable: false),
                    title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_City_Tbl_Ostans_ostan_id",
                        column: x => x.ostan_id,
                        principalTable: "Tbl_Ostans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Tbl_Order",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    appuser_id = table.Column<long>(nullable: false),
                    codeorder = table.Column<string>(nullable: true),
                    datemiladi = table.Column<DateTime>(nullable: false),
                    dateshamsi = table.Column<string>(nullable: true),
                    finishdatemiladi = table.Column<DateTime>(nullable: false),
                    finishdateshamsi = table.Column<string>(nullable: true),
                    isEnable = table.Column<bool>(nullable: false),
                    isfinish = table.Column<bool>(nullable: false),
                    sendprice = table.Column<long>(nullable: false),
                    sumprice = table.Column<long>(nullable: false),
                    useradd_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Order_Tbl_UserApp_appuser_id",
                        column: x => x.appuser_id,
                        principalTable: "Tbl_UserApp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_payment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    amount = table.Column<long>(nullable: false),
                    appuser_id = table.Column<long>(nullable: false),
                    comment = table.Column<string>(nullable: true),
                    datemiladi = table.Column<DateTime>(nullable: false),
                    dateshamsi = table.Column<string>(nullable: true),
                    desbank = table.Column<string>(nullable: true),
                    isSuccess = table.Column<bool>(nullable: false),
                    isenable = table.Column<bool>(nullable: false),
                    order_id = table.Column<long>(nullable: false),
                    refid = table.Column<string>(nullable: true),
                    sourceBank = table.Column<string>(nullable: true),
                    updatedateml = table.Column<DateTime>(nullable: false),
                    updatedatesh = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_payment_Tbl_UserApp_appuser_id",
                        column: x => x.appuser_id,
                        principalTable: "Tbl_UserApp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Salsman",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    appuser_id = table.Column<long>(nullable: false),
                    bio = table.Column<string>(nullable: true),
                    dateMiladi = table.Column<DateTime>(nullable: false),
                    dateShamsi = table.Column<string>(nullable: true),
                    isEnable = table.Column<bool>(nullable: false),
                    rate = table.Column<int>(nullable: false),
                    sabeghe = table.Column<byte>(nullable: false),
                    status = table.Column<byte>(nullable: false),
                    user_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Salsman", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Salsman_Tbl_UserApp_appuser_id",
                        column: x => x.appuser_id,
                        principalTable: "Tbl_UserApp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Salsman_AspNetUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_UserAlarm",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    appuser_id = table.Column<long>(nullable: false),
                    body = table.Column<string>(nullable: true),
                    dateMiladi = table.Column<DateTime>(nullable: false),
                    dateShamsi = table.Column<string>(nullable: true),
                    isenable = table.Column<bool>(nullable: false),
                    status = table.Column<byte>(nullable: false),
                    title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_UserAlarm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_UserAlarm_Tbl_UserApp_appuser_id",
                        column: x => x.appuser_id,
                        principalTable: "Tbl_UserApp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_comment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserAppId = table.Column<long>(nullable: false),
                    UserToken = table.Column<string>(nullable: true),
                    body = table.Column<string>(nullable: true),
                    dateMiladi = table.Column<DateTime>(nullable: false),
                    dateShamsi = table.Column<string>(nullable: true),
                    prod_id = table.Column<long>(nullable: false),
                    replyto = table.Column<int>(nullable: false),
                    status = table.Column<byte>(nullable: false),
                    time = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_comment_Tbl_UserApp_UserAppId",
                        column: x => x.UserAppId,
                        principalTable: "Tbl_UserApp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_comment_Tbl_Products_prod_id",
                        column: x => x.prod_id,
                        principalTable: "Tbl_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Tbl_ProductGallary",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    imagepath = table.Column<string>(nullable: true),
                    product_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ProductGallary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_ProductGallary_Tbl_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Tbl_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Useraddress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    address = table.Column<string>(nullable: true),
                    appuser_id = table.Column<long>(nullable: false),
                    city_id = table.Column<int>(nullable: false),
                    datemiladi = table.Column<DateTime>(nullable: false),
                    dateshamsi = table.Column<string>(nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    isenable = table.Column<bool>(nullable: false),
                    lat = table.Column<string>(nullable: true),
                    lot = table.Column<string>(nullable: true),
                    mobile = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    ostan_id = table.Column<int>(nullable: false),
                    phone = table.Column<string>(nullable: true),
                    postalcode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Useraddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Useraddress_Tbl_UserApp_appuser_id",
                        column: x => x.appuser_id,
                        principalTable: "Tbl_UserApp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Useraddress_Tbl_City_city_id",
                        column: x => x.city_id,
                        principalTable: "Tbl_City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Useraddress_Tbl_Ostans_ostan_id",
                        column: x => x.ostan_id,
                        principalTable: "Tbl_Ostans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_WorkerBanner",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    appuser_id = table.Column<long>(nullable: false),
                    category_id = table.Column<int>(nullable: false),
                    city_id = table.Column<int>(nullable: false),
                    code = table.Column<string>(nullable: true),
                    dateMiladi = table.Column<DateTime>(nullable: false),
                    dateShamsi = table.Column<string>(nullable: true),
                    desc = table.Column<string>(nullable: true),
                    fromdate = table.Column<DateTime>(nullable: false),
                    isenable = table.Column<bool>(nullable: false),
                    isexpire = table.Column<bool>(nullable: false),
                    status = table.Column<byte>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    todate = table.Column<DateTime>(nullable: false),
                    viewcount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_WorkerBanner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_WorkerBanner_Tbl_UserApp_appuser_id",
                        column: x => x.appuser_id,
                        principalTable: "Tbl_UserApp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_WorkerBanner_Tbl_Category_category_id",
                        column: x => x.category_id,
                        principalTable: "Tbl_Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_WorkerBanner_Tbl_City_city_id",
                        column: x => x.city_id,
                        principalTable: "Tbl_City",
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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_sellerBank",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BankNom = table.Column<string>(nullable: true),
                    bankname = table.Column<string>(nullable: true),
                    dateMiladi = table.Column<DateTime>(nullable: false),
                    dateShamsi = table.Column<string>(nullable: true),
                    isenable = table.Column<bool>(nullable: false),
                    owner = table.Column<string>(nullable: true),
                    seller_id = table.Column<long>(nullable: false),
                    shabNom = table.Column<string>(nullable: true),
                    status = table.Column<byte>(nullable: false),
                    user_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_sellerBank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_sellerBank_Tbl_Salsman_seller_id",
                        column: x => x.seller_id,
                        principalTable: "Tbl_Salsman",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_sellerBank_AspNetUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Shop",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    address = table.Column<string>(nullable: true),
                    cat_id = table.Column<int>(nullable: false),
                    city_id = table.Column<int>(nullable: false),
                    dateMiladi = table.Column<DateTime>(nullable: false),
                    dateShamsi = table.Column<string>(nullable: true),
                    enable = table.Column<bool>(nullable: false),
                    fromdate = table.Column<DateTime>(nullable: false),
                    fromdateshamsi = table.Column<string>(nullable: true),
                    image = table.Column<string>(nullable: true),
                    isopen = table.Column<bool>(nullable: false),
                    lat = table.Column<string>(nullable: true),
                    lot = table.Column<string>(nullable: true),
                    ostan_id = table.Column<int>(nullable: false),
                    seller_id = table.Column<long>(nullable: false),
                    sendTime = table.Column<byte>(nullable: false),
                    sendprice = table.Column<long>(nullable: false),
                    status = table.Column<byte>(nullable: false),
                    summary = table.Column<string>(nullable: true),
                    title = table.Column<string>(nullable: true),
                    todate = table.Column<DateTime>(nullable: false),
                    todateshamsi = table.Column<string>(nullable: true),
                    user_id = table.Column<string>(nullable: true),
                    viewCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Shop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Shop_Tbl_Category_cat_id",
                        column: x => x.cat_id,
                        principalTable: "Tbl_Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Shop_Tbl_City_city_id",
                        column: x => x.city_id,
                        principalTable: "Tbl_City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Shop_Tbl_Ostans_ostan_id",
                        column: x => x.ostan_id,
                        principalTable: "Tbl_Ostans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_Shop_Tbl_Salsman_seller_id",
                        column: x => x.seller_id,
                        principalTable: "Tbl_Salsman",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Shop_AspNetUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_BannerImage",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    banner_id = table.Column<long>(nullable: false),
                    image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_BannerImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_BannerImage_Tbl_WorkerBanner_banner_id",
                        column: x => x.banner_id,
                        principalTable: "Tbl_WorkerBanner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Advertise",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dateMiladi = table.Column<DateTime>(nullable: false),
                    dateShamsi = table.Column<string>(nullable: true),
                    desc = table.Column<string>(nullable: true),
                    fromdatemiladi = table.Column<DateTime>(nullable: false),
                    fromdateshamsi = table.Column<string>(nullable: true),
                    image = table.Column<string>(nullable: true),
                    isenable = table.Column<bool>(nullable: false),
                    sel_id = table.Column<long>(nullable: false),
                    shop_id = table.Column<long>(nullable: false),
                    status = table.Column<byte>(nullable: false),
                    time = table.Column<string>(nullable: true),
                    title = table.Column<string>(nullable: true),
                    todatemiladi = table.Column<DateTime>(nullable: false),
                    todateshamsi = table.Column<string>(nullable: true),
                    userapptoken = table.Column<string>(nullable: true),
                    users_id = table.Column<string>(nullable: true),
                    viewCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Advertise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Advertise_Tbl_Salsman_sel_id",
                        column: x => x.sel_id,
                        principalTable: "Tbl_Salsman",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Advertise_Tbl_Shop_shop_id",
                        column: x => x.shop_id,
                        principalTable: "Tbl_Shop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_Advertise_AspNetUsers_users_id",
                        column: x => x.users_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_FollowShop",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dateMiladi = table.Column<DateTime>(nullable: false),
                    dateShamsi = table.Column<string>(nullable: true),
                    isenable = table.Column<bool>(nullable: false),
                    shop_id = table.Column<long>(nullable: false),
                    time = table.Column<string>(nullable: true),
                    userapp_id = table.Column<long>(nullable: false),
                    usertoken = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_FollowShop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_FollowShop_Tbl_Shop_shop_id",
                        column: x => x.shop_id,
                        principalTable: "Tbl_Shop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_FollowShop_Tbl_UserApp_userapp_id",
                        column: x => x.userapp_id,
                        principalTable: "Tbl_UserApp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_orderdetail",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    color_id = table.Column<int>(nullable: false),
                    count = table.Column<int>(nullable: false),
                    isenable = table.Column<bool>(nullable: false),
                    order_id = table.Column<long>(nullable: false),
                    price = table.Column<long>(nullable: false),
                    product_id = table.Column<long>(nullable: false),
                    shop_id = table.Column<long>(nullable: false),
                    totalprice = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_orderdetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_orderdetail_Tbl_Order_order_id",
                        column: x => x.order_id,
                        principalTable: "Tbl_Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_orderdetail_Tbl_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Tbl_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_orderdetail_Tbl_Shop_shop_id",
                        column: x => x.shop_id,
                        principalTable: "Tbl_Shop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction    );
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ProductColor",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    color_id = table.Column<int>(nullable: false),
                    isEnable = table.Column<bool>(nullable: false),
                    offpercent = table.Column<byte>(nullable: false),
                    price = table.Column<long>(nullable: false),
                    product_id = table.Column<long>(nullable: false),
                    shop_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ProductColor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_ProductColor_Tbl_Color_color_id",
                        column: x => x.color_id,
                        principalTable: "Tbl_Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_ProductColor_Tbl_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Tbl_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_ProductColor_Tbl_Shop_shop_id",
                        column: x => x.shop_id,
                        principalTable: "Tbl_Shop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ProductSeller",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dateMiladi = table.Column<DateTime>(nullable: false),
                    dateShamsi = table.Column<string>(nullable: true),
                    isEnable = table.Column<bool>(nullable: false),
                    isExist = table.Column<bool>(nullable: false),
                    isSelect = table.Column<bool>(nullable: false),
                    ismainseller = table.Column<bool>(nullable: false),
                    offpercent = table.Column<byte>(nullable: false),
                    price = table.Column<long>(nullable: false),
                    productType = table.Column<byte>(nullable: false),
                    product_id = table.Column<long>(nullable: false),
                    qty = table.Column<byte>(nullable: false),
                    shop_id = table.Column<long>(nullable: false),
                    status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ProductSeller", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_ProductSeller_Tbl_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Tbl_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_ProductSeller_Tbl_Shop_shop_id",
                        column: x => x.shop_id,
                        principalTable: "Tbl_Shop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ShopComment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    appuser_id = table.Column<long>(nullable: false),
                    body = table.Column<string>(nullable: true),
                    dateMiladi = table.Column<DateTime>(nullable: false),
                    dateShamsi = table.Column<string>(nullable: true),
                    replyto = table.Column<int>(nullable: false),
                    shop_id = table.Column<long>(nullable: false),
                    status = table.Column<byte>(nullable: false),
                    time = table.Column<string>(nullable: true)
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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_SellerSell",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    appuser_id = table.Column<long>(nullable: false),
                    createdateml = table.Column<DateTime>(nullable: false),
                    createdatesh = table.Column<string>(nullable: true),
                    fixstate = table.Column<byte>(nullable: false),
                    isenable = table.Column<bool>(nullable: false),
                    orderdetail_id = table.Column<long>(nullable: false),
                    sellstate = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_SellerSell", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_SellerSell_Tbl_UserApp_appuser_id",
                        column: x => x.appuser_id,
                        principalTable: "Tbl_UserApp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_SellerSell_Tbl_orderdetail_orderdetail_id",
                        column: x => x.orderdetail_id,
                        principalTable: "Tbl_orderdetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_UserBuy",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    appuser_id = table.Column<long>(nullable: false),
                    buystate = table.Column<byte>(nullable: false),
                    createdateml = table.Column<DateTime>(nullable: false),
                    createdatesh = table.Column<string>(nullable: true),
                    isenable = table.Column<bool>(nullable: false),
                    orderdetail_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_UserBuy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_UserBuy_Tbl_UserApp_appuser_id",
                        column: x => x.appuser_id,
                        principalTable: "Tbl_UserApp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_UserBuy_Tbl_orderdetail_orderdetail_id",
                        column: x => x.orderdetail_id,
                        principalTable: "Tbl_orderdetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Advertise_sel_id",
                table: "Tbl_Advertise",
                column: "sel_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Advertise_shop_id",
                table: "Tbl_Advertise",
                column: "shop_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Advertise_users_id",
                table: "Tbl_Advertise",
                column: "users_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_BannerImage_banner_id",
                table: "Tbl_BannerImage",
                column: "banner_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_City_ostan_id",
                table: "Tbl_City",
                column: "ostan_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_comment_UserAppId",
                table: "Tbl_comment",
                column: "UserAppId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_comment_prod_id",
                table: "Tbl_comment",
                column: "prod_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_enableLevelstate_level_id",
                table: "Tbl_enableLevelstate",
                column: "level_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_enableLevelstate_shop_id",
                table: "Tbl_enableLevelstate",
                column: "shop_id");

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

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_FollowShop_shop_id",
                table: "Tbl_FollowShop",
                column: "shop_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_FollowShop_userapp_id",
                table: "Tbl_FollowShop",
                column: "userapp_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Order_appuser_id",
                table: "Tbl_Order",
                column: "appuser_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_orderdetail_order_id",
                table: "Tbl_orderdetail",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_orderdetail_product_id",
                table: "Tbl_orderdetail",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_orderdetail_shop_id",
                table: "Tbl_orderdetail",
                column: "shop_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_payment_appuser_id",
                table: "Tbl_payment",
                column: "appuser_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ProductColor_color_id",
                table: "Tbl_ProductColor",
                column: "color_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ProductColor_product_id",
                table: "Tbl_ProductColor",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ProductColor_shop_id",
                table: "Tbl_ProductColor",
                column: "shop_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ProductGallary_product_id",
                table: "Tbl_ProductGallary",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ProductProperty_product_id",
                table: "Tbl_ProductProperty",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ProductProperty_property_id",
                table: "Tbl_ProductProperty",
                column: "property_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Products_User_id",
                table: "Tbl_Products",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Products_brand_id",
                table: "Tbl_Products",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Products_cat_id",
                table: "Tbl_Products",
                column: "cat_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ProductSeller_product_id",
                table: "Tbl_ProductSeller",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ProductSeller_shop_id",
                table: "Tbl_ProductSeller",
                column: "shop_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Property_cat_id",
                table: "Tbl_Property",
                column: "cat_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Property_part_id",
                table: "Tbl_Property",
                column: "part_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Salsman_appuser_id",
                table: "Tbl_Salsman",
                column: "appuser_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Salsman_user_id",
                table: "Tbl_Salsman",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_sellerBank_seller_id",
                table: "Tbl_sellerBank",
                column: "seller_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_sellerBank_user_id",
                table: "Tbl_sellerBank",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_SellerSell_appuser_id",
                table: "Tbl_SellerSell",
                column: "appuser_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_SellerSell_orderdetail_id",
                table: "Tbl_SellerSell",
                column: "orderdetail_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Shop_cat_id",
                table: "Tbl_Shop",
                column: "cat_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Shop_city_id",
                table: "Tbl_Shop",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Shop_ostan_id",
                table: "Tbl_Shop",
                column: "ostan_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Shop_seller_id",
                table: "Tbl_Shop",
                column: "seller_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Shop_user_id",
                table: "Tbl_Shop",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ShopComment_appuser_id",
                table: "Tbl_ShopComment",
                column: "appuser_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ShopComment_shop_id",
                table: "Tbl_ShopComment",
                column: "shop_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Useraddress_appuser_id",
                table: "Tbl_Useraddress",
                column: "appuser_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Useraddress_city_id",
                table: "Tbl_Useraddress",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Useraddress_ostan_id",
                table: "Tbl_Useraddress",
                column: "ostan_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_UserAlarm_appuser_id",
                table: "Tbl_UserAlarm",
                column: "appuser_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_UserApp_User_id",
                table: "Tbl_UserApp",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_UserBuy_appuser_id",
                table: "Tbl_UserBuy",
                column: "appuser_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_UserBuy_orderdetail_id",
                table: "Tbl_UserBuy",
                column: "orderdetail_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_WorkerBanner_appuser_id",
                table: "Tbl_WorkerBanner",
                column: "appuser_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_WorkerBanner_category_id",
                table: "Tbl_WorkerBanner",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_WorkerBanner_city_id",
                table: "Tbl_WorkerBanner",
                column: "city_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Tbl_Advertise");

            migrationBuilder.DropTable(
                name: "Tbl_BannerImage");

            migrationBuilder.DropTable(
                name: "Tbl_comment");

            migrationBuilder.DropTable(
                name: "Tbl_enableLevelstate");

            migrationBuilder.DropTable(
                name: "Tbl_ErrorReportProduct");

            migrationBuilder.DropTable(
                name: "Tbl_ErrorReportShop");

            migrationBuilder.DropTable(
                name: "Tbl_Favorite");

            migrationBuilder.DropTable(
                name: "Tbl_filemanager");

            migrationBuilder.DropTable(
                name: "Tbl_FollowShop");

            migrationBuilder.DropTable(
                name: "Tbl_payment");

            migrationBuilder.DropTable(
                name: "Tbl_ProductColor");

            migrationBuilder.DropTable(
                name: "Tbl_ProductGallary");

            migrationBuilder.DropTable(
                name: "Tbl_ProductProperty");

            migrationBuilder.DropTable(
                name: "Tbl_ProductSeller");

            migrationBuilder.DropTable(
                name: "Tbl_sellerBank");

            migrationBuilder.DropTable(
                name: "Tbl_SellerSell");

            migrationBuilder.DropTable(
                name: "Tbl_ShopComment");

            migrationBuilder.DropTable(
                name: "Tbl_Useraddress");

            migrationBuilder.DropTable(
                name: "Tbl_UserAlarm");

            migrationBuilder.DropTable(
                name: "Tbl_UserBuy");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Tbl_WorkerBanner");

            migrationBuilder.DropTable(
                name: "Tbl_EnableLevels");

            migrationBuilder.DropTable(
                name: "Tbl_ErrorReportReason");

            migrationBuilder.DropTable(
                name: "Tbl_Color");

            migrationBuilder.DropTable(
                name: "Tbl_Property");

            migrationBuilder.DropTable(
                name: "Tbl_orderdetail");

            migrationBuilder.DropTable(
                name: "Tbl_PropertyPart");

            migrationBuilder.DropTable(
                name: "Tbl_Order");

            migrationBuilder.DropTable(
                name: "Tbl_Products");

            migrationBuilder.DropTable(
                name: "Tbl_Shop");

            migrationBuilder.DropTable(
                name: "Tbl_Brand");

            migrationBuilder.DropTable(
                name: "Tbl_Category");

            migrationBuilder.DropTable(
                name: "Tbl_City");

            migrationBuilder.DropTable(
                name: "Tbl_Salsman");

            migrationBuilder.DropTable(
                name: "Tbl_Ostans");

            migrationBuilder.DropTable(
                name: "Tbl_UserApp");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
