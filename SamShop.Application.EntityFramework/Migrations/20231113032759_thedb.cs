using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SamShop.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class thedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    WagePercentage = table.Column<decimal>(type: "decimal(2,2)", precision: 2, nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medals", x => x.MedalId);
                });

            migrationBuilder.CreateTable(
                name: "Booths",
                columns: table => new
                {
                    BoothId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BoothId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(2,2)", precision: 2, nullable: false),
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
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.ForeignKey(
                        name: "Fk_Picture_Admin",
                        column: x => x.PictureId,
                        principalTable: "Pictures",
                        principalColumn: "PictureId");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Wallet = table.Column<decimal>(type: "decimal(2,2)", precision: 2, nullable: false),
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
                    Wallet = table.Column<decimal>(type: "decimal(2,2)", precision: 2, nullable: false),
                    BoothId = table.Column<int>(type: "int", nullable: false),
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
                        name: "Fk_Booth_Seller",
                        column: x => x.BoothId,
                        principalTable: "Booths",
                        principalColumn: "BoothId");
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
                name: "AddressCustomers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressCustomers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_AddressCustomer",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId");
                    table.ForeignKey(
                        name: "FK_Customer_AddressCustomer",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPrice = table.Column<decimal>(type: "decimal(2,2)", precision: 2, nullable: false),
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
                name: "Auctions",
                columns: table => new
                {
                    AuctionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SellerId = table.Column<int>(type: "int", nullable: false),
                    AuctionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TheLowestOffer = table.Column<decimal>(type: "decimal(2,2)", precision: 2, nullable: false),
                    IsCanceled = table.Column<bool>(type: "bit", nullable: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CancelTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auctions", x => x.AuctionId);
                    table.ForeignKey(
                        name: "Fk_Product_Auction",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "Fk_Seller_Auction",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "SellerId");
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
                    Price = table.Column<decimal>(type: "decimal(2,2)", precision: 2, nullable: false),
                    PayTime = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                name: "ProductCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCarts", x => x.Id);
                    table.ForeignKey(
                        name: "Fk_Cart_ProductCart",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId");
                    table.ForeignKey(
                        name: "Fk_Product_ProductCart",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "AuctionOffers",
                columns: table => new
                {
                    OfferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferValue = table.Column<decimal>(type: "decimal(2,2)", precision: 2, nullable: false),
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
                    table.ForeignKey(
                        name: "Fk_Auction_AuctionOffer",
                        column: x => x.AuctionId,
                        principalTable: "Auctions",
                        principalColumn: "AuctionId");
                    table.ForeignKey(
                        name: "Fk_Customer_AuctionOffer",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "Alley", "City", "ExtraPart", "IsDeleted", "PostCode", "State", "Street" },
                values: new object[,]
                {
                    { 1, "alley 1", "City 1", "level 1", false, "1000", "State 1", "street 1" },
                    { 2, "alley 2", "City 2", "level 1", false, "2000", "State 2", "street 2" },
                    { 3, "alley 3", "City 3", "level 1", false, "3000", "State 3", "street 3" },
                    { 4, "alley 4", "City 4", "level 1", false, "4000", "State 4", "street 4" },
                    { 5, "alley 5", "City 5", "level 1", false, "5000", "State 5", "street 5" },
                    { 6, "alley 6", "City 6", "level 1", false, "6000", "State 6", "street 6" },
                    { 7, "alley 7", "City 7", "level 1", false, "7000", "State 7", "street 7" },
                    { 8, "alley 8", "City 8", "level 1", false, "8000", "State 8", "street 8" },
                    { 9, "alley 9", "City 9", "level 1", false, "9000", "State 9", "street 9" },
                    { 10, "alley 10", "City 10", "level 1", false, "10000", "State 10", "street 10" },
                    { 11, "alley 11", "City 11", "level 1", false, "11000", "State 11", "street 11" },
                    { 12, "alley 12", "City 12", "level 1", false, "12000", "State 12", "street 12" },
                    { 13, "alley 13", "City 13", "level 1", false, "13000", "State 13", "street 13" },
                    { 14, "alley 14", "City 14", "level 1", false, "14000", "State 14", "street 14" },
                    { 15, "alley 15", "City 15", "level 1", false, "15000", "State 15", "street 15" },
                    { 16, "alley 16", "City 16", "level 1", false, "16000", "State 16", "street 16" },
                    { 17, "alley 17", "City 17", "level 1", false, "17000", "State 17", "street 17" },
                    { 18, "alley 18", "City 18", "level 1", false, "18000", "State 18", "street 18" },
                    { 19, "alley 19", "City 19", "level 1", false, "19000", "State 19", "street 19" },
                    { 20, "alley 20", "City 20", "level 1", false, "20000", "State 20", "street 20" },
                    { 21, "alley 21", "City 21", "level 1", false, "21000", "State 21", "street 21" },
                    { 22, "alley 22", "City 22", "level 1", false, "22000", "State 22", "street 22" },
                    { 23, "alley 23", "City 23", "level 1", false, "23000", "State 23", "street 23" },
                    { 24, "alley 24", "City 24", "level 1", false, "24000", "State 24", "street 24" },
                    { 25, "alley 25", "City 25", "level 1", false, "25000", "State 25", "street 25" },
                    { 26, "alley 26", "City 26", "level 1", false, "26000", "State 26", "street 26" },
                    { 27, "alley 27", "City 27", "level 1", false, "27000", "State 27", "street 27" },
                    { 28, "alley 28", "City 28", "level 1", false, "28000", "State 28", "street 28" },
                    { 29, "alley 29", "City 29", "level 1", false, "29000", "State 29", "street 29" },
                    { 30, "alley 30", "City 30", "level 1", false, "30000", "State 30", "street 30" },
                    { 31, "alley 31", "City 31", "level 1", false, "31000", "State 31", "street 31" },
                    { 32, "alley 32", "City 32", "level 1", false, "32000", "State 32", "street 32" },
                    { 33, "alley 33", "City 33", "level 1", false, "33000", "State 33", "street 33" },
                    { 34, "alley 34", "City 34", "level 1", false, "34000", "State 34", "street 34" },
                    { 35, "alley 35", "City 35", "level 1", false, "35000", "State 35", "street 35" },
                    { 36, "alley 36", "City 36", "level 1", false, "36000", "State 36", "street 36" },
                    { 37, "alley 37", "City 37", "level 1", false, "37000", "State 37", "street 37" },
                    { 38, "alley 38", "City 38", "level 1", false, "38000", "State 38", "street 38" },
                    { 39, "alley 39", "City 39", "level 1", false, "39000", "State 39", "street 39" },
                    { 40, "alley 40", "City 40", "level 1", false, "40000", "State 40", "street 40" },
                    { 41, "alley 41", "City 41", "level 1", false, "41000", "State 41", "street 41" },
                    { 42, "alley 42", "City 42", "level 1", false, "42000", "State 42", "street 42" },
                    { 43, "alley 43", "City 43", "level 1", false, "43000", "State 43", "street 43" },
                    { 44, "alley 44", "City 44", "level 1", false, "44000", "State 44", "street 44" },
                    { 45, "alley 45", "City 45", "level 1", false, "45000", "State 45", "street 45" },
                    { 46, "alley 46", "City 46", "level 1", false, "46000", "State 46", "street 46" },
                    { 47, "alley 47", "City 47", "level 1", false, "47000", "State 47", "street 47" },
                    { 48, "alley 48", "City 48", "level 1", false, "48000", "State 48", "street 48" },
                    { 49, "alley 49", "City 49", "level 1", false, "49000", "State 49", "street 49" },
                    { 50, "alley 50", "City 50", "level 1", false, "50000", "State 50", "street 50" },
                    { 51, "alley 51", "City 51", "level 1", false, "51000", "State 51", "street 51" },
                    { 52, "alley 52", "City 52", "level 1", false, "52000", "State 52", "street 52" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Discription", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "AppRole", "Access to Everything", "Admin", "ADMIN" },
                    { 2, null, "AppRole", "Access to Products", "Customer", "CUSTOMER" },
                    { 3, null, "AppRole", "Access to Selling Things", "Seller", "SELLER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "ConcurrencyStamp", "DeleteTime", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegisterTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, null, "b7e22f77-eda9-4a8f-9385-97440a3d2dd5", null, "m3virus@mail.com", true, "Mohammadhasan", false, "Yazdani", false, null, null, "M3VIRUS", "AQAAAAIAAYagAAAAEKA3h8GR7sZc+/6KGfTKoBvbZiGKEWENrUXnoUsLU6lY+uZNngF099wUDj6TkAlfpQ==", "0912345678", true, new DateTime(2023, 11, 13, 6, 57, 59, 194, DateTimeKind.Local).AddTicks(6189), "ada52434-8c0a-46b4-ad4f-6adc11d10126", false, "M3Virus" },
                    { 2, 0, null, "57c2412a-e220-4231-a928-bf2491d16e96", null, "Customer2@mail.com", true, "cust", false, "omer", false, null, null, "CUSTOMER1", "AQAAAAIAAYagAAAAECHKkjlGJ6zbUcvATZ48Lz0Amr3xG+QZq1V4o2suY9TGXs1NkCYV3fbZtyZ3qpJKHw==", "0912345678", true, new DateTime(2023, 11, 13, 6, 57, 59, 194, DateTimeKind.Local).AddTicks(6216), "7e7ef5cf-2de1-4bdd-93ec-1f48b1252796", false, "customer1" },
                    { 3, 0, null, "2865ebe4-3fc4-4640-8c25-0de333121f49", null, "Customer2@mail.com", true, "cust", false, "omer", false, null, null, "CUSTOMER2", "AQAAAAIAAYagAAAAEJlbWxnuuIiUXJ1KqAdS7W778i2iUImfjx8A+lbpbUrqxz/GV0Ov7BN5a4Z7cQLnnA==", "0912345678", true, new DateTime(2023, 11, 13, 6, 57, 59, 194, DateTimeKind.Local).AddTicks(6231), "08b6ac3e-ffe9-41a8-b3de-52357847c1e0", false, "customer2" },
                    { 4, 0, null, "673d09c7-7399-41d9-83c5-03eeec517448", null, "Seller1@mail.com", true, "sel", false, "ler", false, null, null, "Seller1", "AQAAAAIAAYagAAAAEOEI7iAxmyQALHUAwr53MOK7FJZnuOR5YcZ69zObM37p+igxpHLYlGx1hN8gbEHuEw==", "0912345678", true, new DateTime(2023, 11, 13, 6, 57, 59, 194, DateTimeKind.Local).AddTicks(6237), "b8aa1d5f-eb7e-483c-9fd0-974da6cc644f", false, "Seller1" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AddressCustomers_AddressId",
                table: "AddressCustomers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressCustomers_CustomerId",
                table: "AddressCustomers",
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
                name: "IX_Carts_CustomerId",
                table: "Carts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CustomerId",
                table: "Comments",
                column: "CustomerId",
                unique: true);

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
                name: "IX_ProductCarts_CartId",
                table: "ProductCarts",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCarts_ProductId",
                table: "ProductCarts",
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
                name: "IX_Sellers_BoothId",
                table: "Sellers",
                column: "BoothId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_MedalId",
                table: "Sellers",
                column: "MedalId",
                unique: true);

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
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wages_SellerId",
                table: "Wages",
                column: "SellerId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressCustomers");

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
                name: "Comments");

            migrationBuilder.DropTable(
                name: "ProductCarts");

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
                name: "Sellers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Medals");

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
                name: "Addresses");
        }
    }
}
