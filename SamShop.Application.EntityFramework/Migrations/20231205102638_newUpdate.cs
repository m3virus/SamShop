using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamShop.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class newUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsCanceled",
                table: "Auctions",
                newName: "IsActive");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Pictures",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 1,
                column: "CreateTime",
                value: new DateTime(2023, 12, 5, 13, 56, 37, 519, DateTimeKind.Local).AddTicks(4375));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterTime", "SecurityStamp" },
                values: new object[] { "73d26a15-42fe-4de6-8445-076a4076df2a", "AQAAAAIAAYagAAAAEM4CKA+z2hf03+FZKQVettXojWtg01O2hh0YegHJ0S6KRR3HbgVFLUQcbCFdsaOxZg==", new DateTime(2023, 12, 5, 13, 56, 37, 238, DateTimeKind.Local).AddTicks(1038), "b7408e2c-9058-4f1d-81f2-b44786f34f32" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterTime", "SecurityStamp" },
                values: new object[] { "edf3b33a-770c-4478-807f-630cd8440e51", "AQAAAAIAAYagAAAAEMGwY71/oUcezcM257lEjZHOwpIIyZ0194fL7NlAJWXqnwmThvjJiDWaSDEiIBA9vg==", new DateTime(2023, 12, 5, 13, 56, 37, 238, DateTimeKind.Local).AddTicks(1059), "cf30a19f-cecc-432e-b4c9-6410ffdfc0d1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterTime", "SecurityStamp" },
                values: new object[] { "e4e16330-c76d-40e7-9dac-9448c4bf842e", "AQAAAAIAAYagAAAAECyqJrI2bhKgTNEiKTp0EQNQbkrRGQZCAng7Uf23jZ5YDPxuTABRpZ7p0UYtVoCtdA==", new DateTime(2023, 12, 5, 13, 56, 37, 238, DateTimeKind.Local).AddTicks(1075), "56c84108-498f-45aa-b899-4b9337e219ba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterTime", "SecurityStamp" },
                values: new object[] { "492deed3-59a5-4831-8d31-70c481e7536a", "AQAAAAIAAYagAAAAECtG5hWm6u5eSGmGk3vsa0DgxkU5AgIGE87T5PqpYNITuzWaGhfsQA9h7fwON3PEQw==", new DateTime(2023, 12, 5, 13, 56, 37, 238, DateTimeKind.Local).AddTicks(1091), "e1b50e27-17e7-44b7-895f-22d6ea8228b8" });

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "AuctionId",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 12, 5, 13, 56, 37, 518, DateTimeKind.Local).AddTicks(9910) });

            migrationBuilder.UpdateData(
                table: "Booths",
                keyColumn: "BoothId",
                keyValue: 1,
                column: "CreateTime",
                value: new DateTime(2023, 12, 5, 13, 56, 37, 519, DateTimeKind.Local).AddTicks(9528));

            migrationBuilder.UpdateData(
                table: "Booths",
                keyColumn: "BoothId",
                keyValue: 2,
                column: "CreateTime",
                value: new DateTime(2023, 12, 5, 13, 56, 37, 519, DateTimeKind.Local).AddTicks(9534));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "CartId",
                keyValue: 1,
                column: "CreateTime",
                value: new DateTime(2023, 12, 5, 13, 56, 37, 520, DateTimeKind.Local).AddTicks(9342));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "CartId",
                keyValue: 2,
                column: "CreateTime",
                value: new DateTime(2023, 12, 5, 13, 56, 37, 520, DateTimeKind.Local).AddTicks(9347));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CreateTime",
                value: new DateTime(2023, 12, 5, 13, 56, 37, 521, DateTimeKind.Local).AddTicks(30));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CreateTime",
                value: new DateTime(2023, 12, 5, 13, 56, 37, 521, DateTimeKind.Local).AddTicks(48));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "CreateTime",
                value: new DateTime(2023, 12, 5, 13, 56, 37, 520, DateTimeKind.Local).AddTicks(2077));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "CreateTime",
                value: new DateTime(2023, 12, 5, 13, 56, 37, 520, DateTimeKind.Local).AddTicks(2086));

            migrationBuilder.UpdateData(
                table: "Medals",
                keyColumn: "MedalId",
                keyValue: 1,
                column: "CreateTime",
                value: new DateTime(2023, 12, 5, 13, 56, 37, 521, DateTimeKind.Local).AddTicks(3352));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "AddTime",
                value: new DateTime(2023, 12, 5, 13, 56, 37, 521, DateTimeKind.Local).AddTicks(7092));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "AddTime",
                value: new DateTime(2023, 12, 5, 13, 56, 37, 521, DateTimeKind.Local).AddTicks(7100));

            migrationBuilder.UpdateData(
                table: "Sellers",
                keyColumn: "SellerId",
                keyValue: 1,
                column: "CreateTime",
                value: new DateTime(2023, 12, 5, 13, 56, 37, 522, DateTimeKind.Local).AddTicks(3347));

            migrationBuilder.UpdateData(
                table: "Wages",
                keyColumn: "WageId",
                keyValue: 1,
                column: "PayTime",
                value: new DateTime(2023, 12, 5, 13, 56, 37, 522, DateTimeKind.Local).AddTicks(6802));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Auctions",
                newName: "IsCanceled");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Pictures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 1,
                column: "CreateTime",
                value: new DateTime(2023, 11, 25, 7, 52, 5, 521, DateTimeKind.Local).AddTicks(9727));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterTime", "SecurityStamp" },
                values: new object[] { "ef76bbd1-a0a5-49b1-bdba-9ef53942b162", "AQAAAAIAAYagAAAAEH6O6DvTk3Pi7TQmzwkG0aZ9DI1ngdBfCy1WE6RCylOBZkaOyPBV8yaXrJZzRN5rXw==", new DateTime(2023, 11, 25, 7, 52, 5, 165, DateTimeKind.Local).AddTicks(4350), "939ada09-2330-4cf4-84e0-a49ab6560f86" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterTime", "SecurityStamp" },
                values: new object[] { "0cf7bdf3-82d9-4c15-9ffa-1901dd756275", "AQAAAAIAAYagAAAAEIG4PODKRPFM9471xz2kPYW3+0zAMSuSOl7gULqozOWr0RTP94nCOYaGV/Naa0TNNQ==", new DateTime(2023, 11, 25, 7, 52, 5, 165, DateTimeKind.Local).AddTicks(4436), "de805afd-cdd2-4ffe-bcf3-5a33412af66a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterTime", "SecurityStamp" },
                values: new object[] { "9019492f-0f92-496e-9804-2f3651090839", "AQAAAAIAAYagAAAAEEz3uxtlLq3slKgDkfgL1KIrrCF55b83TkZu0FRyQQhq82aPNqjbeqIPQ9E2z0cccg==", new DateTime(2023, 11, 25, 7, 52, 5, 165, DateTimeKind.Local).AddTicks(4535), "90b0652f-9722-4dc2-9ee3-609b57595d4c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterTime", "SecurityStamp" },
                values: new object[] { "196c0c09-579f-4a8e-8b02-d3bef4ddce8b", "AQAAAAIAAYagAAAAEBMmfq2EMLkIzXxLZDnEiyfUCI9Iet2Jwf2v8OTZ5DcTgKXE/HDTdpdH+YyYjMoSmQ==", new DateTime(2023, 11, 25, 7, 52, 5, 165, DateTimeKind.Local).AddTicks(4729), "6fc36a9e-68ec-46b3-b6a5-9ab2ba3a3155" });

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "AuctionId",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 25, 7, 52, 5, 521, DateTimeKind.Local).AddTicks(2336) });

            migrationBuilder.UpdateData(
                table: "Booths",
                keyColumn: "BoothId",
                keyValue: 1,
                column: "CreateTime",
                value: new DateTime(2023, 11, 25, 7, 52, 5, 523, DateTimeKind.Local).AddTicks(4208));

            migrationBuilder.UpdateData(
                table: "Booths",
                keyColumn: "BoothId",
                keyValue: 2,
                column: "CreateTime",
                value: new DateTime(2023, 11, 25, 7, 52, 5, 523, DateTimeKind.Local).AddTicks(4221));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "CartId",
                keyValue: 1,
                column: "CreateTime",
                value: new DateTime(2023, 11, 25, 7, 52, 5, 524, DateTimeKind.Local).AddTicks(8666));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "CartId",
                keyValue: 2,
                column: "CreateTime",
                value: new DateTime(2023, 11, 25, 7, 52, 5, 524, DateTimeKind.Local).AddTicks(8679));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CreateTime",
                value: new DateTime(2023, 11, 25, 7, 52, 5, 525, DateTimeKind.Local).AddTicks(31));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CreateTime",
                value: new DateTime(2023, 11, 25, 7, 52, 5, 525, DateTimeKind.Local).AddTicks(68));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "CreateTime",
                value: new DateTime(2023, 11, 25, 7, 52, 5, 523, DateTimeKind.Local).AddTicks(9072));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "CreateTime",
                value: new DateTime(2023, 11, 25, 7, 52, 5, 523, DateTimeKind.Local).AddTicks(9089));

            migrationBuilder.UpdateData(
                table: "Medals",
                keyColumn: "MedalId",
                keyValue: 1,
                column: "CreateTime",
                value: new DateTime(2023, 11, 25, 7, 52, 5, 525, DateTimeKind.Local).AddTicks(4485));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "AddTime",
                value: new DateTime(2023, 11, 25, 7, 52, 5, 525, DateTimeKind.Local).AddTicks(8035));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "AddTime",
                value: new DateTime(2023, 11, 25, 7, 52, 5, 525, DateTimeKind.Local).AddTicks(8044));

            migrationBuilder.UpdateData(
                table: "Sellers",
                keyColumn: "SellerId",
                keyValue: 1,
                column: "CreateTime",
                value: new DateTime(2023, 11, 25, 7, 52, 5, 526, DateTimeKind.Local).AddTicks(3458));

            migrationBuilder.UpdateData(
                table: "Wages",
                keyColumn: "WageId",
                keyValue: 1,
                column: "PayTime",
                value: new DateTime(2023, 11, 25, 7, 52, 5, 526, DateTimeKind.Local).AddTicks(6663));
        }
    }
}
