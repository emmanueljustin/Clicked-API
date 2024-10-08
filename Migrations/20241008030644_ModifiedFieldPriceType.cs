using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClickedApi.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedFieldPriceType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Pricings",
                type: "double",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Pricings",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");
        }
    }
}
