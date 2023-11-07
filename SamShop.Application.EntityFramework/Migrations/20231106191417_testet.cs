using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamShop.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class testet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionId",
                keyValue: 1,
                column: "StartTime",
                value: new DateTime(2023, 11, 6, 22, 44, 17, 108, DateTimeKind.Local).AddTicks(8070));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionId",
                keyValue: 1,
                column: "StartTime",
                value: new DateTime(2023, 11, 6, 22, 43, 15, 594, DateTimeKind.Local).AddTicks(7620));
        }
    }
}
