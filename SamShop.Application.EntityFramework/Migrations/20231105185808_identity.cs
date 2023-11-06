using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SamShop.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class identity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Alley = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ExtraPart = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Medal",
                columns: table => new
                {
                    MedalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedalType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Wage = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medal", x => x.MedalId);
                });

            migrationBuilder.CreateTable(
                name: "Booth",
                columns: table => new
                {
                    BoothId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    BoothName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booth", x => x.BoothId);
                    table.ForeignKey(
                        name: "FK_Booth_Address",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BoothId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Booth",
                        column: x => x.BoothId,
                        principalTable: "Booth",
                        principalColumn: "BoothId");
                    table.ForeignKey(
                        name: "FK_Product_Category1",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    PictureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.PictureId);
                    table.ForeignKey(
                        name: "FK_Picture_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    PictureId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Wallet = table.Column<decimal>(type: "money", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminId);
                    table.ForeignKey(
                        name: "FK_Admin_Address",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId");
                    table.ForeignKey(
                        name: "FK_Admin_Picture1",
                        column: x => x.PictureId,
                        principalTable: "Picture",
                        principalColumn: "PictureId");
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIrstName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Wallet = table.Column<decimal>(type: "money", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureId = table.Column<int>(type: "int", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customer_Address",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId");
                    table.ForeignKey(
                        name: "FK_Customer_Picture1",
                        column: x => x.PictureId,
                        principalTable: "Picture",
                        principalColumn: "PictureId");
                });

            migrationBuilder.CreateTable(
                name: "Seller",
                columns: table => new
                {
                    SellerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Wallet = table.Column<decimal>(type: "money", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    BoothId = table.Column<int>(type: "int", nullable: false),
                    MedalId = table.Column<int>(type: "int", nullable: false),
                    PictureId = table.Column<int>(type: "int", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seller", x => x.SellerId);
                    table.ForeignKey(
                        name: "FK_Seller_Address",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId");
                    table.ForeignKey(
                        name: "FK_Seller_Booth",
                        column: x => x.BoothId,
                        principalTable: "Booth",
                        principalColumn: "BoothId");
                    table.ForeignKey(
                        name: "FK_Seller_Medal",
                        column: x => x.MedalId,
                        principalTable: "Medal",
                        principalColumn: "MedalId");
                    table.ForeignKey(
                        name: "FK_Seller_Picture1",
                        column: x => x.PictureId,
                        principalTable: "Picture",
                        principalColumn: "PictureId");
                });

            migrationBuilder.CreateTable(
                name: "AddressCustomer",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressCustomer", x => new { x.AddressId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_AddressCustomer_Address",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId");
                    table.ForeignKey(
                        name: "FK_AddressCustomer_Customer1",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPrice = table.Column<decimal>(type: "money", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    IsCanceled = table.Column<bool>(type: "bit", nullable: false),
                    IsPayed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Cart_Customer1",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId");
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
                    Message = table.Column<string>(type: "ntext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Customer",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_Comments_Product1",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "Auction",
                columns: table => new
                {
                    AuctionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    AuctionTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TheLowestOffer = table.Column<decimal>(type: "money", nullable: false),
                    IsCanceled = table.Column<bool>(type: "bit", nullable: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    SellerId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auction", x => x.AuctionId);
                    table.ForeignKey(
                        name: "FK_Auction_Product1",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_Auction_Seller",
                        column: x => x.SellerId,
                        principalTable: "Seller",
                        principalColumn: "SellerId");
                });

            migrationBuilder.CreateTable(
                name: "ProductCart",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCart", x => new { x.ProductId, x.CartId });
                    table.ForeignKey(
                        name: "FK_ProductCart_Cart",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "CartId");
                    table.ForeignKey(
                        name: "FK_ProductCart_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "AuctionOffer",
                columns: table => new
                {
                    OfferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferValue = table.Column<decimal>(type: "money", nullable: false),
                    AuctionId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    IsAccept = table.Column<bool>(type: "bit", nullable: false),
                    IsCanceled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionOffer", x => x.OfferId);
                    table.ForeignKey(
                        name: "FK_AuctionOffer_Auction",
                        column: x => x.AuctionId,
                        principalTable: "Auction",
                        principalColumn: "AuctionId");
                    table.ForeignKey(
                        name: "FK_AuctionOffer_Customer",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "AddressId", "Alley", "City", "ExtraPart", "PostCode", "State", "Street" },
                values: new object[,]
                {
                    { 1, "alley 1", "City 1", "level 1", "1000", "State 1", "street 1" },
                    { 2, "alley 2", "City 2", "level 1", "2000", "State 2", "street 2" },
                    { 3, "alley 3", "City 3", "level 1", "3000", "State 3", "street 3" },
                    { 4, "alley 4", "City 4", "level 1", "4000", "State 4", "street 4" },
                    { 5, "alley 5", "City 5", "level 1", "5000", "State 5", "street 5" },
                    { 6, "alley 6", "City 6", "level 1", "6000", "State 6", "street 6" },
                    { 7, "alley 7", "City 7", "level 1", "7000", "State 7", "street 7" },
                    { 8, "alley 8", "City 8", "level 1", "8000", "State 8", "street 8" },
                    { 9, "alley 9", "City 9", "level 1", "9000", "State 9", "street 9" },
                    { 10, "alley 10", "City 10", "level 1", "10000", "State 10", "street 10" },
                    { 11, "alley 11", "City 11", "level 1", "11000", "State 11", "street 11" },
                    { 12, "alley 12", "City 12", "level 1", "12000", "State 12", "street 12" },
                    { 13, "alley 13", "City 13", "level 1", "13000", "State 13", "street 13" },
                    { 14, "alley 14", "City 14", "level 1", "14000", "State 14", "street 14" },
                    { 15, "alley 15", "City 15", "level 1", "15000", "State 15", "street 15" },
                    { 16, "alley 16", "City 16", "level 1", "16000", "State 16", "street 16" },
                    { 17, "alley 17", "City 17", "level 1", "17000", "State 17", "street 17" },
                    { 18, "alley 18", "City 18", "level 1", "18000", "State 18", "street 18" },
                    { 19, "alley 19", "City 19", "level 1", "19000", "State 19", "street 19" },
                    { 20, "alley 20", "City 20", "level 1", "20000", "State 20", "street 20" },
                    { 21, "alley 21", "City 21", "level 1", "21000", "State 21", "street 21" },
                    { 22, "alley 22", "City 22", "level 1", "22000", "State 22", "street 22" },
                    { 23, "alley 23", "City 23", "level 1", "23000", "State 23", "street 23" },
                    { 24, "alley 24", "City 24", "level 1", "24000", "State 24", "street 24" },
                    { 25, "alley 25", "City 25", "level 1", "25000", "State 25", "street 25" },
                    { 26, "alley 26", "City 26", "level 1", "26000", "State 26", "street 26" },
                    { 27, "alley 27", "City 27", "level 1", "27000", "State 27", "street 27" },
                    { 28, "alley 28", "City 28", "level 1", "28000", "State 28", "street 28" },
                    { 29, "alley 29", "City 29", "level 1", "29000", "State 29", "street 29" },
                    { 30, "alley 30", "City 30", "level 1", "30000", "State 30", "street 30" },
                    { 31, "alley 31", "City 31", "level 1", "31000", "State 31", "street 31" },
                    { 32, "alley 32", "City 32", "level 1", "32000", "State 32", "street 32" },
                    { 33, "alley 33", "City 33", "level 1", "33000", "State 33", "street 33" },
                    { 34, "alley 34", "City 34", "level 1", "34000", "State 34", "street 34" },
                    { 35, "alley 35", "City 35", "level 1", "35000", "State 35", "street 35" },
                    { 36, "alley 36", "City 36", "level 1", "36000", "State 36", "street 36" },
                    { 37, "alley 37", "City 37", "level 1", "37000", "State 37", "street 37" },
                    { 38, "alley 38", "City 38", "level 1", "38000", "State 38", "street 38" },
                    { 39, "alley 39", "City 39", "level 1", "39000", "State 39", "street 39" },
                    { 40, "alley 40", "City 40", "level 1", "40000", "State 40", "street 40" },
                    { 41, "alley 41", "City 41", "level 1", "41000", "State 41", "street 41" },
                    { 42, "alley 42", "City 42", "level 1", "42000", "State 42", "street 42" },
                    { 43, "alley 43", "City 43", "level 1", "43000", "State 43", "street 43" },
                    { 44, "alley 44", "City 44", "level 1", "44000", "State 44", "street 44" },
                    { 45, "alley 45", "City 45", "level 1", "45000", "State 45", "street 45" },
                    { 46, "alley 46", "City 46", "level 1", "46000", "State 46", "street 46" },
                    { 47, "alley 47", "City 47", "level 1", "47000", "State 47", "street 47" },
                    { 48, "alley 48", "City 48", "level 1", "48000", "State 48", "street 48" },
                    { 49, "alley 49", "City 49", "level 1", "49000", "State 49", "street 49" },
                    { 50, "alley 50", "City 50", "level 1", "50000", "State 50", "street 50" },
                    { 51, "alley 51", "City 51", "level 1", "51000", "State 51", "street 51" },
                    { 52, "alley 52", "City 52", "level 1", "52000", "State 52", "street 52" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName", "IsAccepted", "IsDeleted" },
                values: new object[,]
                {
                    { 1, "category 1", true, false },
                    { 2, "category 2", true, false },
                    { 3, "category 3", true, false },
                    { 4, "category 4", true, false },
                    { 5, "category 5", true, false },
                    { 6, "category 6", true, false },
                    { 7, "category 7", true, false },
                    { 8, "category 8", true, false },
                    { 9, "category 9", true, false },
                    { 10, "category 10", true, false }
                });

            migrationBuilder.InsertData(
                table: "Medal",
                columns: new[] { "MedalId", "IsDeleted", "MedalType", "Wage" },
                values: new object[,]
                {
                    { 1, false, "Medal 1", 5m },
                    { 2, false, "Medal 2", 10m },
                    { 3, false, "Medal 3", 15m },
                    { 4, false, "Medal 4", 20m },
                    { 5, false, "Medal 5", 25m },
                    { 6, false, "Medal 6", 30m },
                    { 7, false, "Medal 7", 35m },
                    { 8, false, "Medal 8", 40m },
                    { 9, false, "Medal 9", 45m },
                    { 10, false, "Medal 10", 50m }
                });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "AdminId", "AddressId", "Email", "FirstName", "IsDeleted", "LastName", "Password", "Phone", "PictureId", "UserName", "Wallet" },
                values: new object[,]
                {
                    { 1, 1, "StringSample 1@google.com", "StringSample 1", false, "StringSample 1", "StringSample 1", "StringSample 1", null, "StringSample 1", 100m },
                    { 2, 2, "StringSample 2@google.com", "StringSample 2", false, "StringSample 2", "StringSample 2", "StringSample 2", null, "StringSample 2", 200m }
                });

            migrationBuilder.InsertData(
                table: "Booth",
                columns: new[] { "BoothId", "AddressId", "BoothName" },
                values: new object[,]
                {
                    { 1, 43, "booth 1" },
                    { 2, 44, "booth 2" },
                    { 3, 45, "booth 3" },
                    { 4, 46, "booth 4" },
                    { 5, 47, "booth 5" },
                    { 6, 48, "booth 6" },
                    { 7, 49, "booth 7" },
                    { 8, 50, "booth 8" },
                    { 9, 51, "booth 9" },
                    { 10, 52, "booth 10" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "AddressId", "Email", "FIrstName", "IsDeleted", "LastName", "PasswordHash", "Phone", "PictureId", "UserName", "Wallet" },
                values: new object[,]
                {
                    { 1, 13, "CustomerSample 1", "CustomerSample 1", false, "CustomerSample 1", "CustomerSample 1", "CustomerSample 1", null, "CustomerSample 1", 100m },
                    { 2, 14, "CustomerSample 2", "CustomerSample 2", false, "CustomerSample 2", "CustomerSample 2", "CustomerSample 2", null, "CustomerSample 2", 200m },
                    { 3, 15, "CustomerSample 3", "CustomerSample 3", false, "CustomerSample 3", "CustomerSample 3", "CustomerSample 3", null, "CustomerSample 3", 300m },
                    { 4, 16, "CustomerSample 4", "CustomerSample 4", false, "CustomerSample 4", "CustomerSample 4", "CustomerSample 4", null, "CustomerSample 4", 400m },
                    { 5, 17, "CustomerSample 5", "CustomerSample 5", false, "CustomerSample 5", "CustomerSample 5", "CustomerSample 5", null, "CustomerSample 5", 500m },
                    { 6, 18, "CustomerSample 6", "CustomerSample 6", false, "CustomerSample 6", "CustomerSample 6", "CustomerSample 6", null, "CustomerSample 6", 600m },
                    { 7, 19, "CustomerSample 7", "CustomerSample 7", false, "CustomerSample 7", "CustomerSample 7", "CustomerSample 7", null, "CustomerSample 7", 700m },
                    { 8, 20, "CustomerSample 8", "CustomerSample 8", false, "CustomerSample 8", "CustomerSample 8", "CustomerSample 8", null, "CustomerSample 8", 800m },
                    { 9, 21, "CustomerSample 9", "CustomerSample 9", false, "CustomerSample 9", "CustomerSample 9", "CustomerSample 9", null, "CustomerSample 9", 900m },
                    { 10, 22, "CustomerSample 10", "CustomerSample 10", false, "CustomerSample 10", "CustomerSample 10", "CustomerSample 10", null, "CustomerSample 10", 1000m },
                    { 11, 23, "CustomerSample 11", "CustomerSample 11", false, "CustomerSample 11", "CustomerSample 11", "CustomerSample 11", null, "CustomerSample 11", 1100m },
                    { 12, 24, "CustomerSample 12", "CustomerSample 12", false, "CustomerSample 12", "CustomerSample 12", "CustomerSample 12", null, "CustomerSample 12", 1200m },
                    { 13, 25, "CustomerSample 13", "CustomerSample 13", false, "CustomerSample 13", "CustomerSample 13", "CustomerSample 13", null, "CustomerSample 13", 1300m },
                    { 14, 26, "CustomerSample 14", "CustomerSample 14", false, "CustomerSample 14", "CustomerSample 14", "CustomerSample 14", null, "CustomerSample 14", 1400m },
                    { 15, 27, "CustomerSample 15", "CustomerSample 15", false, "CustomerSample 15", "CustomerSample 15", "CustomerSample 15", null, "CustomerSample 15", 1500m },
                    { 16, 28, "CustomerSample 16", "CustomerSample 16", false, "CustomerSample 16", "CustomerSample 16", "CustomerSample 16", null, "CustomerSample 16", 1600m },
                    { 17, 29, "CustomerSample 17", "CustomerSample 17", false, "CustomerSample 17", "CustomerSample 17", "CustomerSample 17", null, "CustomerSample 17", 1700m },
                    { 18, 30, "CustomerSample 18", "CustomerSample 18", false, "CustomerSample 18", "CustomerSample 18", "CustomerSample 18", null, "CustomerSample 18", 1800m },
                    { 19, 31, "CustomerSample 19", "CustomerSample 19", false, "CustomerSample 19", "CustomerSample 19", "CustomerSample 19", null, "CustomerSample 19", 1900m },
                    { 20, 32, "CustomerSample 20", "CustomerSample 20", false, "CustomerSample 20", "CustomerSample 20", "CustomerSample 20", null, "CustomerSample 20", 2000m },
                    { 21, 33, "CustomerSample 21", "CustomerSample 21", false, "CustomerSample 21", "CustomerSample 21", "CustomerSample 21", null, "CustomerSample 21", 2100m },
                    { 22, 34, "CustomerSample 22", "CustomerSample 22", false, "CustomerSample 22", "CustomerSample 22", "CustomerSample 22", null, "CustomerSample 22", 2200m },
                    { 23, 35, "CustomerSample 23", "CustomerSample 23", false, "CustomerSample 23", "CustomerSample 23", "CustomerSample 23", null, "CustomerSample 23", 2300m },
                    { 24, 36, "CustomerSample 24", "CustomerSample 24", false, "CustomerSample 24", "CustomerSample 24", "CustomerSample 24", null, "CustomerSample 24", 2400m },
                    { 25, 37, "CustomerSample 25", "CustomerSample 25", false, "CustomerSample 25", "CustomerSample 25", "CustomerSample 25", null, "CustomerSample 25", 2500m },
                    { 26, 38, "CustomerSample 26", "CustomerSample 26", false, "CustomerSample 26", "CustomerSample 26", "CustomerSample 26", null, "CustomerSample 26", 2600m },
                    { 27, 39, "CustomerSample 27", "CustomerSample 27", false, "CustomerSample 27", "CustomerSample 27", "CustomerSample 27", null, "CustomerSample 27", 2700m },
                    { 28, 40, "CustomerSample 28", "CustomerSample 28", false, "CustomerSample 28", "CustomerSample 28", "CustomerSample 28", null, "CustomerSample 28", 2800m },
                    { 29, 41, "CustomerSample 29", "CustomerSample 29", false, "CustomerSample 29", "CustomerSample 29", "CustomerSample 29", null, "CustomerSample 29", 2900m },
                    { 30, 42, "CustomerSample 30", "CustomerSample 30", false, "CustomerSample 30", "CustomerSample 30", "CustomerSample 30", null, "CustomerSample 30", 3000m }
                });

            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "CartId", "CustomerId", "IsCanceled", "IsPayed", "TotalPrice" },
                values: new object[,]
                {
                    { 1, 1, false, false, 0m },
                    { 2, 2, false, false, 0m },
                    { 3, 3, false, false, 0m },
                    { 4, 4, false, false, 0m },
                    { 5, 5, false, false, 0m },
                    { 6, 6, false, false, 0m },
                    { 7, 7, false, false, 0m },
                    { 8, 8, false, false, 0m },
                    { 9, 9, false, false, 0m },
                    { 10, 10, false, false, 0m }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Amount", "BoothId", "CategoryId", "IsAccepted", "IsAvailable", "IsDeleted", "Price", "ProductName" },
                values: new object[,]
                {
                    { 1, 5, 1, 1, true, true, false, 6m, "Product 1" },
                    { 2, 5, 2, 2, true, true, false, 12m, "Product 2" },
                    { 3, 5, 3, 3, true, true, false, 18m, "Product 3" },
                    { 4, 5, 4, 4, true, true, false, 24m, "Product 4" },
                    { 5, 5, 5, 5, true, true, false, 30m, "Product 5" },
                    { 6, 5, 6, 6, true, true, false, 36m, "Product 6" },
                    { 7, 5, 7, 7, true, true, false, 42m, "Product 7" },
                    { 8, 5, 8, 8, true, true, false, 48m, "Product 8" },
                    { 9, 5, 9, 9, true, true, false, 54m, "Product 9" },
                    { 10, 5, 10, 10, true, true, false, 60m, "Product 10" }
                });

            migrationBuilder.InsertData(
                table: "Seller",
                columns: new[] { "SellerId", "AddressId", "BoothId", "Email", "FirstName", "IsDeleted", "LastName", "MedalId", "Password", "Phone", "PictureId", "UserName", "Wallet" },
                values: new object[,]
                {
                    { 1, 3, 1, "SellerSample 1", "SellerSample 1", false, "SellerSample 1", 1, "SellerSample 1", "SellerSample 1", null, "SellerSample 1", 100m },
                    { 2, 4, 2, "SellerSample 2", "SellerSample 2", false, "SellerSample 2", 1, "SellerSample 2", "SellerSample 2", null, "SellerSample 2", 200m },
                    { 3, 5, 3, "SellerSample 3", "SellerSample 3", false, "SellerSample 3", 1, "SellerSample 3", "SellerSample 3", null, "SellerSample 3", 300m },
                    { 4, 6, 4, "SellerSample 4", "SellerSample 4", false, "SellerSample 4", 1, "SellerSample 4", "SellerSample 4", null, "SellerSample 4", 400m },
                    { 5, 7, 5, "SellerSample 5", "SellerSample 5", false, "SellerSample 5", 1, "SellerSample 5", "SellerSample 5", null, "SellerSample 5", 500m },
                    { 6, 8, 6, "SellerSample 6", "SellerSample 6", false, "SellerSample 6", 1, "SellerSample 6", "SellerSample 6", null, "SellerSample 6", 600m },
                    { 7, 9, 7, "SellerSample 7", "SellerSample 7", false, "SellerSample 7", 1, "SellerSample 7", "SellerSample 7", null, "SellerSample 7", 700m },
                    { 8, 10, 8, "SellerSample 8", "SellerSample 8", false, "SellerSample 8", 1, "SellerSample 8", "SellerSample 8", null, "SellerSample 8", 800m },
                    { 9, 11, 9, "SellerSample 9", "SellerSample 9", false, "SellerSample 9", 1, "SellerSample 9", "SellerSample 9", null, "SellerSample 9", 900m },
                    { 10, 12, 10, "SellerSample 10", "SellerSample 10", false, "SellerSample 10", 1, "SellerSample 10", "SellerSample 10", null, "SellerSample 10", 1000m }
                });

            migrationBuilder.InsertData(
                table: "Auction",
                columns: new[] { "AuctionId", "AuctionTitle", "EndTime", "IsAccepted", "IsCanceled", "ProductId", "SellerId", "StartTime", "TheLowestOffer" },
                values: new object[] { 1, "AuctionSample 1", new DateTime(2023, 11, 5, 0, 0, 0, 0, DateTimeKind.Local), false, false, 1, 1, new DateTime(2023, 11, 5, 22, 28, 8, 605, DateTimeKind.Local).AddTicks(2398), 10m });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "CustomerId", "IsAccepted", "Message", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, true, "Message 1", 1 },
                    { 2, 2, true, "Message 2", 1 },
                    { 3, 3, true, "Message 3", 1 },
                    { 4, 4, true, "Message 4", 1 },
                    { 5, 5, true, "Message 5", 1 },
                    { 6, 6, true, "Message 6", 1 },
                    { 7, 7, true, "Message 7", 1 },
                    { 8, 8, true, "Message 8", 1 },
                    { 9, 9, true, "Message 9", 1 },
                    { 10, 10, true, "Message 10", 1 }
                });

            migrationBuilder.InsertData(
                table: "Picture",
                columns: new[] { "PictureId", "IsDeleted", "ProductId", "URL" },
                values: new object[,]
                {
                    { 1, false, 1, "Url 1" },
                    { 2, false, 2, "Url 2" },
                    { 3, false, 3, "Url 3" },
                    { 4, false, 4, "Url 4" },
                    { 5, false, 5, "Url 5" },
                    { 6, false, 6, "Url 6" },
                    { 7, false, 7, "Url 7" },
                    { 8, false, 8, "Url 8" },
                    { 9, false, 9, "Url 9" },
                    { 10, false, 10, "Url 10" }
                });

            migrationBuilder.InsertData(
                table: "AuctionOffer",
                columns: new[] { "OfferId", "AuctionId", "CustomerId", "IsAccept", "IsCanceled", "OfferValue" },
                values: new object[,]
                {
                    { 1, 1, 1, false, false, 11m },
                    { 2, 1, 2, false, false, 22m },
                    { 3, 1, 3, false, false, 33m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressCustomer_CustomerId",
                table: "AddressCustomer",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_AddressId",
                table: "Admin",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_PictureId",
                table: "Admin",
                column: "PictureId");

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
                name: "IX_Auction_ProductId",
                table: "Auction",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Auction_SellerId",
                table: "Auction",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionOffer_AuctionId",
                table: "AuctionOffer",
                column: "AuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionOffer_CustomerId",
                table: "AuctionOffer",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Booth_AddressId",
                table: "Booth",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_CustomerId",
                table: "Cart",
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
                name: "IX_Customer_AddressId",
                table: "Customer",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_PictureId",
                table: "Customer",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Picture_ProductId",
                table: "Picture",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BoothId",
                table: "Product",
                column: "BoothId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCart_CartId",
                table: "ProductCart",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Seller_AddressId",
                table: "Seller",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Seller_BoothId",
                table: "Seller",
                column: "BoothId");

            migrationBuilder.CreateIndex(
                name: "IX_Seller_MedalId",
                table: "Seller",
                column: "MedalId");

            migrationBuilder.CreateIndex(
                name: "IX_Seller_PictureId",
                table: "Seller",
                column: "PictureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressCustomer");

            migrationBuilder.DropTable(
                name: "Admin");

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
                name: "AuctionOffer");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "ProductCart");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Auction");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Seller");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Medal");

            migrationBuilder.DropTable(
                name: "Picture");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Booth");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
