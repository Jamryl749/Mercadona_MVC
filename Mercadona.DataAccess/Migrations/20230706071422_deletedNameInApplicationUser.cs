using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mercadona.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class deletedNameInApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Name",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);
        }
    }
}
