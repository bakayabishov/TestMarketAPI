using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddManagersToShops : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "shops",
                keyColumn: "id",
                keyValue: 1,
                column: "manager_id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "shops",
                keyColumn: "id",
                keyValue: 2,
                column: "manager_id",
                value: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "shops",
                keyColumn: "id",
                keyValue: 1,
                column: "manager_id",
                value: 0);

            migrationBuilder.UpdateData(
                table: "shops",
                keyColumn: "id",
                keyValue: 2,
                column: "manager_id",
                value: 0);
        }
    }
}
