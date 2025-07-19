using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlourmillAPI.Migrations
{
    /// <inheritdoc />
    public partial class DeliveryBoyField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "DeliveryBoys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "DeliveryBoys");
        }
    }
}
