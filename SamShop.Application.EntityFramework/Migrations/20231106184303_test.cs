using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamShop.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Admin");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Seller",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Customer",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegisterTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Admin",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "AdminId",
                keyValue: 1,
                column: "AppUserId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "AdminId",
                keyValue: 2,
                column: "AppUserId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionId",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 11, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 6, 22, 13, 3, 8, DateTimeKind.Local).AddTicks(9493) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "AppUserId",
                value: "13");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "AppUserId",
                value: "14");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 3,
                column: "AppUserId",
                value: "15");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 4,
                column: "AppUserId",
                value: "16");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 5,
                column: "AppUserId",
                value: "17");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 6,
                column: "AppUserId",
                value: "18");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 7,
                column: "AppUserId",
                value: "19");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 8,
                column: "AppUserId",
                value: "20");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 9,
                column: "AppUserId",
                value: "21");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 10,
                column: "AppUserId",
                value: "22");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 11,
                column: "AppUserId",
                value: "23");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 12,
                column: "AppUserId",
                value: "24");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 13,
                column: "AppUserId",
                value: "25");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 14,
                column: "AppUserId",
                value: "26");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 15,
                column: "AppUserId",
                value: "27");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 16,
                column: "AppUserId",
                value: "28");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 17,
                column: "AppUserId",
                value: "29");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 18,
                column: "AppUserId",
                value: "30");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 19,
                column: "AppUserId",
                value: "31");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 20,
                column: "AppUserId",
                value: "32");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 21,
                column: "AppUserId",
                value: "33");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 22,
                column: "AppUserId",
                value: "34");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 23,
                column: "AppUserId",
                value: "35");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 24,
                column: "AppUserId",
                value: "36");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 25,
                column: "AppUserId",
                value: "37");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 26,
                column: "AppUserId",
                value: "38");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 27,
                column: "AppUserId",
                value: "39");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 28,
                column: "AppUserId",
                value: "40");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 29,
                column: "AppUserId",
                value: "41");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 30,
                column: "AppUserId",
                value: "42");

            migrationBuilder.UpdateData(
                table: "Seller",
                keyColumn: "SellerId",
                keyValue: 1,
                column: "AppUserId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "Seller",
                keyColumn: "SellerId",
                keyValue: 2,
                column: "AppUserId",
                value: "4");

            migrationBuilder.UpdateData(
                table: "Seller",
                keyColumn: "SellerId",
                keyValue: 3,
                column: "AppUserId",
                value: "5");

            migrationBuilder.UpdateData(
                table: "Seller",
                keyColumn: "SellerId",
                keyValue: 4,
                column: "AppUserId",
                value: "6");

            migrationBuilder.UpdateData(
                table: "Seller",
                keyColumn: "SellerId",
                keyValue: 5,
                column: "AppUserId",
                value: "7");

            migrationBuilder.UpdateData(
                table: "Seller",
                keyColumn: "SellerId",
                keyValue: 6,
                column: "AppUserId",
                value: "8");

            migrationBuilder.UpdateData(
                table: "Seller",
                keyColumn: "SellerId",
                keyValue: 7,
                column: "AppUserId",
                value: "9");

            migrationBuilder.UpdateData(
                table: "Seller",
                keyColumn: "SellerId",
                keyValue: 8,
                column: "AppUserId",
                value: "10");

            migrationBuilder.UpdateData(
                table: "Seller",
                keyColumn: "SellerId",
                keyValue: 9,
                column: "AppUserId",
                value: "11");

            migrationBuilder.UpdateData(
                table: "Seller",
                keyColumn: "SellerId",
                keyValue: 10,
                column: "AppUserId",
                value: "12");

            migrationBuilder.CreateIndex(
                name: "IX_Seller_AppUserId",
                table: "Seller",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_AppUserId",
                table: "Customer",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admin_AppUserId",
                table: "Admin",
                column: "AppUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_AspNetUsers_AppUserId",
                table: "Admin",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_AspNetUsers_AppUserId",
                table: "Customer",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seller_AspNetUsers_AppUserId",
                table: "Seller",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_AspNetUsers_AppUserId",
                table: "Admin");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_AspNetUsers_AppUserId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Seller_AspNetUsers_AppUserId",
                table: "Seller");

            migrationBuilder.DropIndex(
                name: "IX_Seller_AppUserId",
                table: "Seller");

            migrationBuilder.DropIndex(
                name: "IX_Customer_AppUserId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Admin_AppUserId",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RegisterTime",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Admin");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Seller",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Seller",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Seller",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Seller",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Seller",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customer",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Customer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Customer",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Admin",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Admin",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Admin",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "AdminId",
                keyValue: 1,
                columns: new[] { "Email", "IsDeleted", "Password", "Phone", "UserName" },
                values: new object[] { "StringSample 1@google.com", false, "StringSample 1", "StringSample 1", "StringSample 1" });

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "AdminId",
                keyValue: 2,
                columns: new[] { "Email", "IsDeleted", "Password", "Phone", "UserName" },
                values: new object[] { "StringSample 2@google.com", false, "StringSample 2", "StringSample 2", "StringSample 2" });

            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionId",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 5, 22, 30, 4, 887, DateTimeKind.Local).AddTicks(2564) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 1,
                columns: new[] { "Email", "IsDeleted", "PasswordHash", "Phone", "UserName" },
                values: new object[] { "CustomerSample 1", false, "CustomerSample 1", "CustomerSample 1", "CustomerSample 1" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 2,
                columns: new[] { "Email", "IsDeleted", "PasswordHash", "Phone", "UserName" },
                values: new object[] { "CustomerSample 2", false, "CustomerSample 2", "CustomerSample 2", "CustomerSample 2" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 3,
                columns: new[] { "Email", "IsDeleted", "PasswordHash", "Phone", "UserName" },
                values: new object[] { "CustomerSample 3", false, "CustomerSample 3", "CustomerSample 3", "CustomerSample 3" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 4,
                columns: new[] { "Email", "IsDeleted", "PasswordHash", "Phone", "UserName" },
                values: new object[] { "CustomerSample 4", false, "CustomerSample 4", "CustomerSample 4", "CustomerSample 4" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 5,
                columns: new[] { "Email", "IsDeleted", "PasswordHash", "Phone", "UserName" },
                values: new object[] { "CustomerSample 5", false, "CustomerSample 5", "CustomerSample 5", "CustomerSample 5" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 6,
                columns: new[] { "Email", "IsDeleted", "PasswordHash", "Phone", "UserName" },
                values: new object[] { "CustomerSample 6", false, "CustomerSample 6", "CustomerSample 6", "CustomerSample 6" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 7,
                columns: new[] { "Email", "IsDeleted", "PasswordHash", "Phone", "UserName" },
                values: new object[] { "CustomerSample 7", false, "CustomerSample 7", "CustomerSample 7", "CustomerSample 7" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 8,
                columns: new[] { "Email", "IsDeleted", "PasswordHash", "Phone", "UserName" },
                values: new object[] { "CustomerSample 8", false, "CustomerSample 8", "CustomerSample 8", "CustomerSample 8" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 9,
                columns: new[] { "Email", "IsDeleted", "PasswordHash", "Phone", "UserName" },
                values: new object[] { "CustomerSample 9", false, "CustomerSample 9", "CustomerSample 9", "CustomerSample 9" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 10,
                columns: new[] { "Email", "IsDeleted", "PasswordHash", "Phone", "UserName" },
                values: new object[] { "CustomerSample 10", false, "CustomerSample 10", "CustomerSample 10", "CustomerSample 10" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 11,
                columns: new[] { "Email", "IsDeleted", "PasswordHash", "Phone", "UserName" },
                values: new object[] { "CustomerSample 11", false, "CustomerSample 11", "CustomerSample 11", "CustomerSample 11" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 12,
                columns: new[] { "Email", "IsDeleted", "PasswordHash", "Phone", "UserName" },
                values: new object[] { "CustomerSample 12", false, "CustomerSample 12", "CustomerSample 12", "CustomerSample 12" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 13,
                columns: new[] { "Email", "IsDeleted", "PasswordHash", "Phone", "UserName" },
                values: new object[] { "CustomerSample 13", false, "CustomerSample 13", "CustomerSample 13", "CustomerSample 13" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 14,
                columns: new[] { "Email", "IsDeleted", "PasswordHash", "Phone", "UserName" },
                values: new object[] { "CustomerSample 14", false, "CustomerSample 14", "CustomerSample 14", "CustomerSample 14" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 15,
                columns: new[] { "Email", "IsDeleted", "PasswordHash", "Phone", "UserName" },
                values: new object[] { "CustomerSample 15", false, "CustomerSample 15", "CustomerSample 15", "CustomerSample 15" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 16,
                columns: new[] { "Email", "IsDeleted", "PasswordHash", "Phone", "UserName" },
                values: new object[] { "CustomerSample 16", false, "CustomerSample 16", "CustomerSample 16", "CustomerSample 16" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 17,
                columns: new[] { "Email", "IsDeleted", "PasswordHash", "Phone", "UserName" },
                values: new object[] { "CustomerSample 17", false, "CustomerSample 17", "CustomerSample 17", "CustomerSample 17" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 18,
                columns: new[] { "Email", "IsDeleted", "PasswordHash", "Phone", "UserName" },
                values: new object[] { "CustomerSample 18", false, "CustomerSample 18", "CustomerSample 18", "CustomerSample 18" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 19,
                columns: new[] { "Email", "IsDeleted", "PasswordHash", "Phone", "UserName" },
                values: new object[] { "CustomerSample 19", false, "CustomerSample 19", "CustomerSample 19", "CustomerSample 19" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 20,
                columns: new[] { "Email", "IsDeleted", "PasswordHash", "Phone", "UserName" },
                values: new object[] { "CustomerSample 20", false, "CustomerSample 20", "CustomerSample 20", "CustomerSample 20" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 21,
                columns: new[] { "Email", "IsDeleted", "PasswordHash", "Phone", "UserName" },
                values: new object[] { "CustomerSample 21", false, "CustomerSample 21", "CustomerSample 21", "CustomerSample 21" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 22,
                columns: new[] { "Email", "IsDeleted", "PasswordHash", "Phone", "UserName" },
                values: new object[] { "CustomerSample 22", false, "CustomerSample 22", "CustomerSample 22", "CustomerSample 22" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 23,
                columns: new[] { "Email", "IsDeleted", "PasswordHash", "Phone", "UserName" },
                values: new object[] { "CustomerSample 23", false, "CustomerSample 23", "CustomerSample 23", "CustomerSample 23" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 24,
                columns: new[] { "Email", "IsDeleted", "PasswordHash", "Phone", "UserName" },
                values: new object[] { "CustomerSample 24", false, "CustomerSample 24", "CustomerSample 24", "CustomerSample 24" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 25,
                columns: new[] { "Email", "IsDeleted", "PasswordHash", "Phone", "UserName" },
                values: new object[] { "CustomerSample 25", false, "CustomerSample 25", "CustomerSample 25", "CustomerSample 25" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 26,
                columns: new[] { "Email", "IsDeleted", "PasswordHash", "Phone", "UserName" },
                values: new object[] { "CustomerSample 26", false, "CustomerSample 26", "CustomerSample 26", "CustomerSample 26" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 27,
                columns: new[] { "Email", "IsDeleted", "PasswordHash", "Phone", "UserName" },
                values: new object[] { "CustomerSample 27", false, "CustomerSample 27", "CustomerSample 27", "CustomerSample 27" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 28,
                columns: new[] { "Email", "IsDeleted", "PasswordHash", "Phone", "UserName" },
                values: new object[] { "CustomerSample 28", false, "CustomerSample 28", "CustomerSample 28", "CustomerSample 28" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 29,
                columns: new[] { "Email", "IsDeleted", "PasswordHash", "Phone", "UserName" },
                values: new object[] { "CustomerSample 29", false, "CustomerSample 29", "CustomerSample 29", "CustomerSample 29" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 30,
                columns: new[] { "Email", "IsDeleted", "PasswordHash", "Phone", "UserName" },
                values: new object[] { "CustomerSample 30", false, "CustomerSample 30", "CustomerSample 30", "CustomerSample 30" });

            migrationBuilder.UpdateData(
                table: "Seller",
                keyColumn: "SellerId",
                keyValue: 1,
                columns: new[] { "Email", "IsDeleted", "Password", "Phone", "UserName" },
                values: new object[] { "SellerSample 1", false, "SellerSample 1", "SellerSample 1", "SellerSample 1" });

            migrationBuilder.UpdateData(
                table: "Seller",
                keyColumn: "SellerId",
                keyValue: 2,
                columns: new[] { "Email", "IsDeleted", "Password", "Phone", "UserName" },
                values: new object[] { "SellerSample 2", false, "SellerSample 2", "SellerSample 2", "SellerSample 2" });

            migrationBuilder.UpdateData(
                table: "Seller",
                keyColumn: "SellerId",
                keyValue: 3,
                columns: new[] { "Email", "IsDeleted", "Password", "Phone", "UserName" },
                values: new object[] { "SellerSample 3", false, "SellerSample 3", "SellerSample 3", "SellerSample 3" });

            migrationBuilder.UpdateData(
                table: "Seller",
                keyColumn: "SellerId",
                keyValue: 4,
                columns: new[] { "Email", "IsDeleted", "Password", "Phone", "UserName" },
                values: new object[] { "SellerSample 4", false, "SellerSample 4", "SellerSample 4", "SellerSample 4" });

            migrationBuilder.UpdateData(
                table: "Seller",
                keyColumn: "SellerId",
                keyValue: 5,
                columns: new[] { "Email", "IsDeleted", "Password", "Phone", "UserName" },
                values: new object[] { "SellerSample 5", false, "SellerSample 5", "SellerSample 5", "SellerSample 5" });

            migrationBuilder.UpdateData(
                table: "Seller",
                keyColumn: "SellerId",
                keyValue: 6,
                columns: new[] { "Email", "IsDeleted", "Password", "Phone", "UserName" },
                values: new object[] { "SellerSample 6", false, "SellerSample 6", "SellerSample 6", "SellerSample 6" });

            migrationBuilder.UpdateData(
                table: "Seller",
                keyColumn: "SellerId",
                keyValue: 7,
                columns: new[] { "Email", "IsDeleted", "Password", "Phone", "UserName" },
                values: new object[] { "SellerSample 7", false, "SellerSample 7", "SellerSample 7", "SellerSample 7" });

            migrationBuilder.UpdateData(
                table: "Seller",
                keyColumn: "SellerId",
                keyValue: 8,
                columns: new[] { "Email", "IsDeleted", "Password", "Phone", "UserName" },
                values: new object[] { "SellerSample 8", false, "SellerSample 8", "SellerSample 8", "SellerSample 8" });

            migrationBuilder.UpdateData(
                table: "Seller",
                keyColumn: "SellerId",
                keyValue: 9,
                columns: new[] { "Email", "IsDeleted", "Password", "Phone", "UserName" },
                values: new object[] { "SellerSample 9", false, "SellerSample 9", "SellerSample 9", "SellerSample 9" });

            migrationBuilder.UpdateData(
                table: "Seller",
                keyColumn: "SellerId",
                keyValue: 10,
                columns: new[] { "Email", "IsDeleted", "Password", "Phone", "UserName" },
                values: new object[] { "SellerSample 10", false, "SellerSample 10", "SellerSample 10", "SellerSample 10" });
        }
    }
}
