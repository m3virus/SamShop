using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamShop.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class teset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionId",
                keyValue: 1,
                column: "StartTime",
                value: new DateTime(2023, 11, 6, 22, 43, 15, 594, DateTimeKind.Local).AddTicks(7620));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "AspNetRoles");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionId",
                keyValue: 1,
                column: "StartTime",
                value: new DateTime(2023, 11, 6, 22, 13, 3, 8, DateTimeKind.Local).AddTicks(9493));
        }
    }
}
