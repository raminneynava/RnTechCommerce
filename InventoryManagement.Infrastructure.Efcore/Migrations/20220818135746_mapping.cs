using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement.Infrastructure.Efcore.Migrations
{
    public partial class mapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryOperation_Inventory_InventoryId",
                table: "InventoryOperation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryOperation",
                table: "InventoryOperation");

            migrationBuilder.RenameTable(
                name: "InventoryOperation",
                newName: "InventoryOperations");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryOperation_InventoryId",
                table: "InventoryOperations",
                newName: "IX_InventoryOperations_InventoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "InventoryOperations",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryOperations",
                table: "InventoryOperations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryOperations_Inventory_InventoryId",
                table: "InventoryOperations",
                column: "InventoryId",
                principalTable: "Inventory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryOperations_Inventory_InventoryId",
                table: "InventoryOperations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryOperations",
                table: "InventoryOperations");

            migrationBuilder.RenameTable(
                name: "InventoryOperations",
                newName: "InventoryOperation");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryOperations_InventoryId",
                table: "InventoryOperation",
                newName: "IX_InventoryOperation_InventoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "InventoryOperation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryOperation",
                table: "InventoryOperation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryOperation_Inventory_InventoryId",
                table: "InventoryOperation",
                column: "InventoryId",
                principalTable: "Inventory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
