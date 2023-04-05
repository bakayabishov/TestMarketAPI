using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MarketApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TablesCreatingWithSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "shops",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    manager_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shops", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_products_shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "shops",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "shops",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "shops",
                columns: new[] { "id", "manager_id", "name" },
                values: new object[,]
                {
                    { 1, 0, "На диване" },
                    { 2, 0, "Строительный" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "name", "price", "quantity", "ShopId" },
                values: new object[,]
                {
                    { 1, "кольцо", 45.4m, 4, 1 },
                    { 2, "ожерелье", 78.6m, 2, 1 },
                    { 3, "серьги", 4m, 2, 1 },
                    { 4, "браслет", 4m, 1, 1 },
                    { 5, "платье", 800.1m, 4, 1 },
                    { 6, "туфли", 452.4m, 5, 1 },
                    { 7, "шляпа", 12.3m, 7, 1 },
                    { 8, "чулки", 12.4m, 45, 1 },
                    { 9, "топор", 89.8m, 100, 2 },
                    { 10, "молоток", 99.9m, 150, 2 },
                    { 11, "гвозди", 1.5m, 10000, 2 },
                    { 12, "изолента", 15.7m, 150, 2 },
                    { 13, "лопата", 45.5m, 16, 2 },
                    { 14, "грабли", 54.4m, 16, 2 },
                    { 15, "вилы", 65.4m, 35, 2 },
                    { 16, "газонакосилка", 455.5m, 5, 2 },
                    { 17, "серп", 55.9m, 10, 2 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "name", "password", "Role", "ShopId" },
                values: new object[,]
                {
                    { 1, "Администратор", "Admin", "administrator", 1 },
                    { 2, "Менеджер", "Manager", "manager", 1 },
                    { 3, "Продавец", "Seller", "seller", 1 },
                    { 4, "Администратор", "Admin", "administrator", 2 },
                    { 5, "Менеджер", "Manager", "manager", 2 },
                    { 6, "Продавец", "Seller", "seller", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_ShopId",
                table: "products",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_users_ShopId",
                table: "users",
                column: "ShopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "shops");
        }
    }
}
