using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    public partial class UpdateRegionName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Regions_RegionsId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "RegionsId",
                table: "Customers",
                newName: "RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_RegionsId",
                table: "Customers",
                newName: "IX_Customers_RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Regions_RegionId",
                table: "Customers",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Regions_RegionId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "RegionId",
                table: "Customers",
                newName: "RegionsId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_RegionId",
                table: "Customers",
                newName: "IX_Customers_RegionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Regions_RegionsId",
                table: "Customers",
                column: "RegionsId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
