using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraSuaMoc.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddImageToMenuItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "MenuItems",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$iReuE2Ldi8ZAz0vGSSn89etfj4aHQVBfgPDpWTJ7dbhH4dFepOqN6");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Image" },
                values: new object[] { new DateTime(2026, 6, 6, 12, 29, 43, 394, DateTimeKind.Utc).AddTicks(8795), null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Image" },
                values: new object[] { new DateTime(2026, 6, 6, 12, 29, 43, 394, DateTimeKind.Utc).AddTicks(8803), null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Image" },
                values: new object[] { new DateTime(2026, 6, 6, 12, 29, 43, 394, DateTimeKind.Utc).AddTicks(8804), null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Image" },
                values: new object[] { new DateTime(2026, 6, 6, 12, 29, 43, 394, DateTimeKind.Utc).AddTicks(8805), null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Image" },
                values: new object[] { new DateTime(2026, 6, 6, 12, 29, 43, 394, DateTimeKind.Utc).AddTicks(8805), null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Image" },
                values: new object[] { new DateTime(2026, 6, 6, 12, 29, 43, 394, DateTimeKind.Utc).AddTicks(8806), null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Image" },
                values: new object[] { new DateTime(2026, 6, 6, 12, 29, 43, 394, DateTimeKind.Utc).AddTicks(8807), null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Image" },
                values: new object[] { new DateTime(2026, 6, 6, 12, 29, 43, 394, DateTimeKind.Utc).AddTicks(8808), null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Image" },
                values: new object[] { new DateTime(2026, 6, 6, 12, 29, 43, 394, DateTimeKind.Utc).AddTicks(8809), null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Image" },
                values: new object[] { new DateTime(2026, 6, 6, 12, 29, 43, 394, DateTimeKind.Utc).AddTicks(8810), null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "Image" },
                values: new object[] { new DateTime(2026, 6, 6, 12, 29, 43, 394, DateTimeKind.Utc).AddTicks(8811), null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "Image" },
                values: new object[] { new DateTime(2026, 6, 6, 12, 29, 43, 394, DateTimeKind.Utc).AddTicks(8811), null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "Image" },
                values: new object[] { new DateTime(2026, 6, 6, 12, 29, 43, 394, DateTimeKind.Utc).AddTicks(8812), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "MenuItems");

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$tuAuoqRF5fx.h.RseKOtfOPl6dNHnL6ED2Sbtuet9O0ORdUT5MltO");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 6, 7, 51, 58, 193, DateTimeKind.Utc).AddTicks(7577));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 6, 7, 51, 58, 193, DateTimeKind.Utc).AddTicks(7585));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 6, 7, 51, 58, 193, DateTimeKind.Utc).AddTicks(7586));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 6, 7, 51, 58, 193, DateTimeKind.Utc).AddTicks(7589));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 6, 7, 51, 58, 193, DateTimeKind.Utc).AddTicks(7590));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 6, 7, 51, 58, 193, DateTimeKind.Utc).AddTicks(7591));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 6, 7, 51, 58, 193, DateTimeKind.Utc).AddTicks(7591));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 6, 7, 51, 58, 193, DateTimeKind.Utc).AddTicks(7592));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 6, 7, 51, 58, 193, DateTimeKind.Utc).AddTicks(7593));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 6, 7, 51, 58, 193, DateTimeKind.Utc).AddTicks(7594));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 6, 7, 51, 58, 193, DateTimeKind.Utc).AddTicks(7595));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 6, 7, 51, 58, 193, DateTimeKind.Utc).AddTicks(7596));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 6, 7, 51, 58, 193, DateTimeKind.Utc).AddTicks(7597));
        }
    }
}
