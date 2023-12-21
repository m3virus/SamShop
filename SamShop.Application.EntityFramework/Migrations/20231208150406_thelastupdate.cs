using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SamShop.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class thelastupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RegisterTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Medals",
                columns: table => new
                {
                    MedalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedalType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    WagePercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medals", x => x.MedalId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alley = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExtraPart = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    PictureId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    Wallet = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                    table.ForeignKey(
                        name: "FK_Address_Admin",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId");
                    table.ForeignKey(
                        name: "Fk_AppUser_Admin",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AuctionOffers",
                columns: table => new
                {
                    OfferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AuctionId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    IsAccept = table.Column<bool>(type: "bit", nullable: false),
                    IsCanceled = table.Column<bool>(type: "bit", nullable: false),
                    OfferTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CancelTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionOffers", x => x.OfferId);
                });

            migrationBuilder.CreateTable(
                name: "Auctions",
                columns: table => new
                {
                    AuctionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SellerId = table.Column<int>(type: "int", nullable: false),
                    AuctionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TheLowestOffer = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CancelTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auctions", x => x.AuctionId);
                });

            migrationBuilder.CreateTable(
                name: "Booths",
                columns: table => new
                {
                    BoothId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellerId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    BoothName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booths", x => x.BoothId);
                    table.ForeignKey(
                        name: "Fk_Address_Booth",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BoothId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    AddTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "Fk_Booth_Product",
                        column: x => x.BoothId,
                        principalTable: "Booths",
                        principalColumn: "BoothId");
                    table.ForeignKey(
                        name: "Fk_Category_Product",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    PictureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.PictureId);
                    table.ForeignKey(
                        name: "Fk_Product_Picture",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Wallet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PictureId = table.Column<int>(type: "int", nullable: true),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "Fk_AppUser_Customer",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Fk_Picture_Customer",
                        column: x => x.PictureId,
                        principalTable: "Pictures",
                        principalColumn: "PictureId");
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    SellerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Wallet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MedalId = table.Column<int>(type: "int", nullable: false),
                    PictureId = table.Column<int>(type: "int", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.SellerId);
                    table.ForeignKey(
                        name: "Fk_Address_Seller",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId");
                    table.ForeignKey(
                        name: "Fk_AppUser_Seller",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Fk_Medal_Seller",
                        column: x => x.MedalId,
                        principalTable: "Medals",
                        principalColumn: "MedalId");
                    table.ForeignKey(
                        name: "Fk_Picture_Seller",
                        column: x => x.PictureId,
                        principalTable: "Pictures",
                        principalColumn: "PictureId");
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    IsCanceled = table.Column<bool>(type: "bit", nullable: false),
                    IsPayed = table.Column<bool>(type: "bit", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CancelTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                    table.ForeignKey(
                        name: "Fk_Customer_Cart",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CommentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "Fk_Customer_Comment",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_Product_Comment",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "Wages",
                columns: table => new
                {
                    WageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SellerId = table.Column<int>(type: "int", nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wages", x => x.WageId);
                    table.ForeignKey(
                        name: "Fk_Admin_Wage",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "AdminId");
                    table.ForeignKey(
                        name: "Fk_Product_Wage",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "Fk_Seller_Wage",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "SellerId");
                });

            migrationBuilder.CreateTable(
                name: "CartProducts",
                columns: table => new
                {
                    CartsCartId = table.Column<int>(type: "int", nullable: false),
                    ProductsProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProducts", x => new { x.CartsCartId, x.ProductsProductId });
                    table.ForeignKey(
                        name: "FK_CartProducts_Carts_CartsCartId",
                        column: x => x.CartsCartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProducts_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "Alley", "City", "CustomerId", "ExtraPart", "IsDeleted", "PostCode", "State", "Street" },
                values: new object[,]
                {
                    { 1, "alley 1", "City 1", null, "level 1", false, "1000", "State 1", "street 1" },
                    { 2, "alley 2", "City 2", null, "level 1", false, "2000", "State 2", "street 2" },
                    { 3, "alley 3", "City 3", null, "level 1", false, "3000", "State 3", "street 3" },
                    { 4, "alley 4", "City 4", null, "level 1", false, "4000", "State 4", "street 4" },
                    { 5, "alley 5", "City 5", null, "level 1", false, "5000", "State 5", "street 5" },
                    { 6, "alley 6", "City 6", null, "level 1", false, "6000", "State 6", "street 6" },
                    { 7, "alley 7", "City 7", null, "level 1", false, "7000", "State 7", "street 7" },
                    { 8, "alley 8", "City 8", null, "level 1", false, "8000", "State 8", "street 8" },
                    { 9, "alley 9", "City 9", null, "level 1", false, "9000", "State 9", "street 9" },
                    { 10, "alley 10", "City 10", null, "level 1", false, "10000", "State 10", "street 10" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discription", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Access to Everything", "Admin", "ADMIN" },
                    { 2, null, "Access to Products", "Customer", "CUSTOMER" },
                    { 3, null, "Access to Selling Things", "Seller", "SELLER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "ConcurrencyStamp", "DeleteTime", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegisterTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, null, "58f63477-c9d0-4daa-a9c7-d05752e98af4", null, "m3virus@mail.com", true, "Mohammadhasan", false, "Yazdani", false, null, null, "M3VIRUS", "AQAAAAIAAYagAAAAEF7gpUbqekfGoMBnXFvzreNEZAtGiixTmgDb29JsW++GFzkANZ43B8raK15ln5iCHw==", "0912345678", true, new DateTime(2023, 12, 8, 18, 34, 5, 169, DateTimeKind.Local).AddTicks(3212), "e6385674-8ac2-4734-9f9d-541433dac808", false, "M3Virus" },
                    { 2, 0, null, "27372f59-30c3-47bd-a6b3-d791120168ad", null, "Customer2@mail.com", true, "cust", false, "omer", false, null, null, "CUSTOMER1", "AQAAAAIAAYagAAAAEBQGCt8LToFMaHhtjfGqhUvHdnEZHz0mwVGYOIZM8nUrgGHypFT0l7D190RaOQZ2oQ==", "0912345678", true, new DateTime(2023, 12, 8, 18, 34, 5, 169, DateTimeKind.Local).AddTicks(3235), "45a29b63-d31c-48fa-9647-1cb90312c915", false, "customer1" },
                    { 3, 0, null, "ad606dae-160f-4e4c-b571-c7183159769b", null, "Customer2@mail.com", true, "cust", false, "omer", false, null, null, "CUSTOMER2", "AQAAAAIAAYagAAAAEIuFuf+lQLX2ADQkg9FkK6ssFeEw4H7Lb+1gRYkxRWzjrMf0OilK4pRcKbrvsBM9nw==", "0912345678", true, new DateTime(2023, 12, 8, 18, 34, 5, 169, DateTimeKind.Local).AddTicks(3241), "3f9431c3-b676-4167-a952-ef744c723fdd", false, "customer2" },
                    { 4, 0, null, "d436e7e1-34a5-4a63-aa83-cbe07db453b1", null, "Seller1@mail.com", true, "sel", false, "ler", false, null, null, "Seller1", "AQAAAAIAAYagAAAAEObFjBUENHscYzPiuu0GEXg2C4+oK0fIQFz8PDBljhsaHhrhW1XApo/EzTlVuY69lA==", "0912345678", true, new DateTime(2023, 12, 8, 18, 34, 5, 169, DateTimeKind.Local).AddTicks(3246), "d4649011-6605-44d7-ae8e-635217b14828", false, "Seller1" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "CreateTime", "DeleteTime", "IsAccepted", "IsDeleted" },
                values: new object[,]
                {
                    { 1, "category 1", new DateTime(2023, 12, 8, 18, 34, 5, 460, DateTimeKind.Local).AddTicks(7586), null, true, false },
                    { 2, "category 2", new DateTime(2023, 12, 8, 18, 34, 5, 460, DateTimeKind.Local).AddTicks(7591), null, true, false }
                });

            migrationBuilder.InsertData(
                table: "Medals",
                columns: new[] { "MedalId", "CreateTime", "DeleteTime", "IsDeleted", "MedalType", "WagePercentage" },
                values: new object[] { 1, new DateTime(2023, 12, 8, 18, 34, 5, 461, DateTimeKind.Local).AddTicks(2960), null, false, "Medal 1", 4m });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "AdminId", "AddressId", "AppUserId", "CreateTime", "DeleteTime", "IsDeleted", "PictureId", "Wallet" },
                values: new object[] { 1, 3, 1, new DateTime(2023, 12, 8, 18, 34, 5, 458, DateTimeKind.Local).AddTicks(58), null, false, null, 100m });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 4 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "AppUserId", "CreateTime", "DeleteTime", "IsDeleted", "PictureId", "Wallet" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2023, 12, 8, 18, 34, 5, 459, DateTimeKind.Local).AddTicks(3970), null, false, null, 10m },
                    { 2, 3, new DateTime(2023, 12, 8, 18, 34, 5, 459, DateTimeKind.Local).AddTicks(3976), null, false, null, 20m }
                });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "SellerId", "AddressId", "AppUserId", "CreateTime", "DeleteTime", "IsDeleted", "MedalId", "PictureId", "Wallet" },
                values: new object[] { 1, 5, 4, new DateTime(2023, 12, 8, 18, 34, 5, 462, DateTimeKind.Local).AddTicks(8172), null, false, 1, null, 100m });

            migrationBuilder.InsertData(
                table: "Booths",
                columns: new[] { "BoothId", "AddressId", "BoothName", "CreateTime", "DeleteTime", "IsDeleted", "SellerId" },
                values: new object[] { 1, 5, "booth 1", new DateTime(2023, 12, 8, 18, 34, 5, 459, DateTimeKind.Local).AddTicks(255), null, false, 1 });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "CartId", "CancelTime", "CreateTime", "CustomerId", "IsCanceled", "IsPayed", "TotalPrice" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 12, 8, 18, 34, 5, 460, DateTimeKind.Local).AddTicks(6788), 1, false, false, 0m },
                    { 2, null, new DateTime(2023, 12, 8, 18, 34, 5, 460, DateTimeKind.Local).AddTicks(6796), 2, false, false, 0m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "AddTime", "Amount", "BoothId", "CategoryId", "DeleteTime", "IsAccepted", "IsAvailable", "IsDeleted", "Price", "ProductName" },
                values: new object[] { 1, new DateTime(2023, 12, 8, 18, 34, 5, 461, DateTimeKind.Local).AddTicks(9907), 5, 1, 1, null, false, true, false, 6m, "Product 1" });

            migrationBuilder.InsertData(
                table: "Auctions",
                columns: new[] { "AuctionId", "AuctionTitle", "CancelTime", "EndTime", "IsAccepted", "IsActive", "ProductId", "SellerId", "StartTime", "TheLowestOffer" },
                values: new object[] { 1, "AuctionSample 1", null, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), false, false, 1, 1, new DateTime(2023, 12, 8, 18, 34, 5, 456, DateTimeKind.Local).AddTicks(9875), 10m });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "CommentDate", "CustomerId", "DeleteTime", "IsAccepted", "IsDeleted", "Message", "ProductId" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, true, false, "Message 1", 1 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, true, false, "Message 2", 1 }
                });

            migrationBuilder.InsertData(
                table: "Wages",
                columns: new[] { "WageId", "AdminId", "DeleteTime", "IsDeleted", "PayTime", "Price", "ProductId", "SellerId" },
                values: new object[] { 1, 1, null, false, new DateTime(2023, 12, 8, 18, 34, 5, 463, DateTimeKind.Local).AddTicks(4719), 4m, 1, 1 });

            migrationBuilder.InsertData(
                table: "AuctionOffers",
                columns: new[] { "OfferId", "AuctionId", "CancelTime", "CustomerId", "IsAccept", "IsCanceled", "OfferTime", "OfferValue" },
                values: new object[,]
                {
                    { 1, 1, null, 1, false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11m },
                    { 2, 1, null, 2, false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 22m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_AddressId",
                table: "Admins",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admins_AppUserId",
                table: "Admins",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admins_PictureId",
                table: "Admins",
                column: "PictureId",
                unique: true,
                filter: "[PictureId] IS NOT NULL");

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
                name: "IX_AuctionOffers_AuctionId",
                table: "AuctionOffers",
                column: "AuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionOffers_CustomerId",
                table: "AuctionOffers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_ProductId",
                table: "Auctions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_SellerId",
                table: "Auctions",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Booths_AddressId",
                table: "Booths",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booths_SellerId",
                table: "Booths",
                column: "SellerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartProducts_ProductsProductId",
                table: "CartProducts",
                column: "ProductsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CustomerId",
                table: "Carts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CustomerId",
                table: "Comments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductId",
                table: "Comments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AppUserId",
                table: "Customers",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PictureId",
                table: "Customers",
                column: "PictureId",
                unique: true,
                filter: "[PictureId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_ProductId",
                table: "Pictures",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BoothId",
                table: "Products",
                column: "BoothId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_AddressId",
                table: "Sellers",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_AppUserId",
                table: "Sellers",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_MedalId",
                table: "Sellers",
                column: "MedalId");

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_PictureId",
                table: "Sellers",
                column: "PictureId",
                unique: true,
                filter: "[PictureId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Wages_AdminId",
                table: "Wages",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Wages_ProductId",
                table: "Wages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Wages_SellerId",
                table: "Wages",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Customers_CustomerId",
                table: "Addresses",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "Fk_Picture_Admin",
                table: "Admins",
                column: "PictureId",
                principalTable: "Pictures",
                principalColumn: "PictureId");

            migrationBuilder.AddForeignKey(
                name: "Fk_Auction_AuctionOffer",
                table: "AuctionOffers",
                column: "AuctionId",
                principalTable: "Auctions",
                principalColumn: "AuctionId");

            migrationBuilder.AddForeignKey(
                name: "Fk_Customer_AuctionOffer",
                table: "AuctionOffers",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "Fk_Product_Auction",
                table: "Auctions",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "Fk_Seller_Auction",
                table: "Auctions",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "Fk_Seller_Booth",
                table: "Booths",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "SellerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Customers_CustomerId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "Fk_Address_Booth",
                table: "Booths");

            migrationBuilder.DropForeignKey(
                name: "Fk_Address_Seller",
                table: "Sellers");

            migrationBuilder.DropForeignKey(
                name: "Fk_AppUser_Seller",
                table: "Sellers");

            migrationBuilder.DropForeignKey(
                name: "Fk_Picture_Seller",
                table: "Sellers");

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
                name: "AuctionOffers");

            migrationBuilder.DropTable(
                name: "CartProducts");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Wages");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Auctions");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Booths");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Sellers");

            migrationBuilder.DropTable(
                name: "Medals");
        }
    }
}
