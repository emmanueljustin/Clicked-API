using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClickedApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedRelationalDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Pricings_PricingId",
                table: "Services");

            migrationBuilder.AlterColumn<int>(
                name: "PricingId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Pricings_PricingId",
                table: "Services",
                column: "PricingId",
                principalTable: "Pricings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Pricings_PricingId",
                table: "Services");

            migrationBuilder.AlterColumn<int>(
                name: "PricingId",
                table: "Services",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Pricings_PricingId",
                table: "Services",
                column: "PricingId",
                principalTable: "Pricings",
                principalColumn: "Id");
        }
    }
}
