using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopManagement.Infrastructure.Efcore.Migrations
{
    public partial class linkslide : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsRemovwd",
                table: "ShopSlider",
                newName: "IsRemoved");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "ShopSlider",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "ShopSlider");

            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "ShopSlider",
                newName: "IsRemovwd");
        }
    }
}
