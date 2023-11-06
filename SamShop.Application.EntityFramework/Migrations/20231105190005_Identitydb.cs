using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamShop.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Identitydb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionId",
                keyValue: 1,
                column: "StartTime",
                value: new DateTime(2023, 11, 5, 22, 30, 4, 887, DateTimeKind.Local).AddTicks(2564));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionId",
                keyValue: 1,
                column: "StartTime",
                value: new DateTime(2023, 11, 5, 22, 28, 8, 605, DateTimeKind.Local).AddTicks(2398));
        }
    }
}
