using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mercadona.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SendCategoryTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "Fresh Produce", "fresh_produce" },
                    { 2, "Meat and Poultry", "meat_poultry" },
                    { 3, "Seafood", "seafood" },
                    { 4, "Dairy and Eggs", "dairy_eggs" },
                    { 5, "Snacks and Confectionery", "snacks_confectionery" },
                    { 6, "Bakery", "bakery" },
                    { 7, "Beverages", "beverages" },
                    { 8, "Household Essential", "household_essential" },
                    { 9, "Personal Care", "personal_care" },
                    { 10, "Pharmacy", "pharmacy" },
                    { 11, "Home Appliance", "home_appliance" },
                    { 12, "DIY", "diy" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
