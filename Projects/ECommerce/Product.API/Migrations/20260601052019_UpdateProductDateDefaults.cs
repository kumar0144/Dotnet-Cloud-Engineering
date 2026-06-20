using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductDateDefaults : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 6, 1, 5, 2, 18, 235, DateTimeKind.Utc).AddTicks(1815));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 6, 1, 5, 2, 18, 234, DateTimeKind.Utc).AddTicks(4917));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2026, 6, 1, 5, 2, 18, 235, DateTimeKind.Utc).AddTicks(1815),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 6, 1, 5, 2, 18, 234, DateTimeKind.Utc).AddTicks(4917),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETUTCDATE()");
        }
    }
}
