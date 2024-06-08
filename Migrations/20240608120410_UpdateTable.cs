using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DD_FootwearAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_CustomerID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_CustomerID",
                table: "Orders",
                column: "CustomerID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
