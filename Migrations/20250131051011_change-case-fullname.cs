using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopeeAPI.Migrations
{
    /// <inheritdoc />
    public partial class changecasefullname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Owners",
                newName: "Fullname");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fullname",
                table: "Owners",
                newName: "FullName");
        }
    }
}
