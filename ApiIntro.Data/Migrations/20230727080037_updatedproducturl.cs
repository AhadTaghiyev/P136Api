using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiIntro.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedproducturl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 27, 12, 0, 37, 170, DateTimeKind.Utc).AddTicks(3580),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 27, 10, 28, 28, 366, DateTimeKind.Utc).AddTicks(2150));

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 27, 12, 0, 37, 170, DateTimeKind.Utc).AddTicks(3370),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 27, 10, 28, 28, 366, DateTimeKind.Utc).AddTicks(1940));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 27, 10, 28, 28, 366, DateTimeKind.Utc).AddTicks(2150),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 27, 12, 0, 37, 170, DateTimeKind.Utc).AddTicks(3580));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 27, 10, 28, 28, 366, DateTimeKind.Utc).AddTicks(1940),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 27, 12, 0, 37, 170, DateTimeKind.Utc).AddTicks(3370));
        }
    }
}
