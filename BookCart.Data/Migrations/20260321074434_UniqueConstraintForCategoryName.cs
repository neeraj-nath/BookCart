using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookCart.Data.Migrations
{
    /// <inheritdoc />
    public partial class UniqueConstraintForCategoryName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "UQ_Categories_Name",
                schema: "books",
                table: "Categories",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ_Categories_Name",
                schema: "books",
                table: "Categories");
        }
    }
}
