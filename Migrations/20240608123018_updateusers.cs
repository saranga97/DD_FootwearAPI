using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DD_FootwearAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateusers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreOrders_Users_CustomerID",
                table: "PreOrders");

            migrationBuilder.DropIndex(
                name: "IX_PreOrders_CustomerID",
                table: "PreOrders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PreOrders_CustomerID",
                table: "PreOrders",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_PreOrders_Users_CustomerID",
                table: "PreOrders",
                column: "CustomerID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
