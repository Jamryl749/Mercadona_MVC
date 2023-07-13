using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mercadona.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemovedCategoryUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Categories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Categories",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Url",
                value: "fresh_produce");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Url",
                value: "meat_poultry");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Url",
                value: "seafood");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Url",
                value: "dairy_eggs");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Url",
                value: "snacks_confectionery");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "Url",
                value: "bakery");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "Url",
                value: "beverages");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "Url",
                value: "household_essential");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "Url",
                value: "personal_care");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "Url",
                value: "pharmacy");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "Url",
                value: "home_appliance");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "Url",
                value: "diy");
        }
    }
}
