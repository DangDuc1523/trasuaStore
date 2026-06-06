using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TraSuaMoc.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Emoji = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    IsHot = table.Column<bool>(type: "boolean", nullable: false),
                    IsNew = table.Column<bool>(type: "boolean", nullable: false),
                    IsHidden = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TableNumber = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Total = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AdminUsers",
                columns: new[] { "Id", "PasswordHash", "Username" },
                values: new object[] { 1, "$2a$11$qDWjgkj8Ru0Ks1AQ4cdaZu/5zwZ3ntGdUp8tODjo2KkuSkP4qNCD.", "admin" });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Category", "CreatedAt", "Description", "Emoji", "IsHidden", "IsHot", "IsNew", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "trasua", new DateTime(2026, 6, 6, 7, 47, 35, 951, DateTimeKind.Utc).AddTicks(9427), "Trà oolong thơm, sữa tươi béo ngậy", "🧋", false, true, false, "Trà Sữa Oolong", 35000m },
                    { 2, "trasua", new DateTime(2026, 6, 6, 7, 47, 35, 951, DateTimeKind.Utc).AddTicks(9435), "Matcha Nhật nguyên chất hoà cùng sữa tươi", "🍵", false, false, true, "Trà Sữa Matcha", 38000m },
                    { 3, "trasua", new DateTime(2026, 6, 6, 7, 47, 35, 951, DateTimeKind.Utc).AddTicks(9437), "Dâu tây tươi xay nhuyễn, sữa tươi, trân châu đỏ", "🍓", false, false, false, "Trà Sữa Dâu", 37000m },
                    { 4, "trasua", new DateTime(2026, 6, 6, 7, 47, 35, 951, DateTimeKind.Utc).AddTicks(9437), "Khoai môn tím thuần chất, vị bùi ngọt đặc trưng", "💜", false, true, false, "Trà Sữa Taro", 38000m },
                    { 5, "cafe", new DateTime(2026, 6, 6, 7, 47, 35, 951, DateTimeKind.Utc).AddTicks(9438), "Cà phê phin truyền thống, sữa đặc ngọt thơm", "☕", false, false, false, "Cà Phê Sữa Đá", 28000m },
                    { 6, "cafe", new DateTime(2026, 6, 6, 7, 47, 35, 951, DateTimeKind.Utc).AddTicks(9439), "Cà phê nhẹ, nhiều sữa, thích hợp buổi chiều", "🥛", false, false, false, "Bạc Xỉu", 28000m },
                    { 7, "cafe", new DateTime(2026, 6, 6, 7, 47, 35, 951, DateTimeKind.Utc).AddTicks(9440), "Ủ lạnh 12 giờ, hương thơm đậm đà, không đắng", "🧊", false, true, false, "Cold Brew", 35000m },
                    { 8, "sinh-to", new DateTime(2026, 6, 6, 7, 47, 35, 951, DateTimeKind.Utc).AddTicks(9441), "Bơ chín 100%, thêm sữa đặc và đá xay mịn", "🥑", false, false, false, "Sinh Tố Bơ", 40000m },
                    { 9, "sinh-to", new DateTime(2026, 6, 6, 7, 47, 35, 951, DateTimeKind.Utc).AddTicks(9442), "Xoài cát Hoà Lộc ngọt lịm, đá xay mát lạnh", "🥭", false, false, true, "Sinh Tố Xoài", 38000m },
                    { 10, "nuoc-ep", new DateTime(2026, 6, 6, 7, 47, 35, 951, DateTimeKind.Utc).AddTicks(9442), "Cam vắt tươi mỗi ngày, vitamin C dồi dào", "🍊", false, false, false, "Nước Ép Cam", 32000m },
                    { 11, "nuoc-ep", new DateTime(2026, 6, 6, 7, 47, 35, 951, DateTimeKind.Utc).AddTicks(9443), "Dưa hấu mùa hè tươi ngọt, mát lạnh sảng khoái", "🍉", false, false, false, "Nước Ép Dưa Hấu", 30000m },
                    { 12, "tra", new DateTime(2026, 6, 6, 7, 47, 35, 951, DateTimeKind.Utc).AddTicks(9444), "Kết hợp đào, cam và sả, vị chua ngọt dịu mát", "🍑", false, true, false, "Trà Đào Cam Sả", 33000m },
                    { 13, "tra", new DateTime(2026, 6, 6, 7, 47, 35, 951, DateTimeKind.Utc).AddTicks(9445), "Chanh dây nhiệt đới chua nhẹ, thơm mát", "🟡", false, false, false, "Trà Chanh Leo", 30000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminUsers");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
