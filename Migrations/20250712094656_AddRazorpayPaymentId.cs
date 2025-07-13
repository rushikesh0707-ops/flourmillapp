using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlourmillAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddRazorpayPaymentId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RazorpayPaymentId",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RazorpayPaymentId",
                table: "Payments");
        }
    }
}
