using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartPark.Migrations
{
    /// <inheritdoc />
    public partial class DisplayId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisplayId",
                table: "ParkingSpot",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayId",
                table: "ParkingSpot");
        }
    }
}
