using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartPark.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parking Lot",
                columns: table => new
                {
                    ParkingLotID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parking Lot", x => x.ParkingLotID);
                });

            migrationBuilder.CreateTable(
                name: "UserSM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parking Spot",
                columns: table => new
                {
                    ParkingSpotID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParkingLotID = table.Column<int>(type: "int", nullable: false),
                    IsOccupied = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parking Spot", x => x.ParkingSpotID);
                    table.ForeignKey(
                        name: "FK_Parking Spot_Parking Lot_ParkingLotID",
                        column: x => x.ParkingLotID,
                        principalTable: "Parking Lot",
                        principalColumn: "ParkingLotID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    ReservationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserSMId = table.Column<int>(type: "int", nullable: false),
                    ParkingSpotID = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.ReservationID);
                    table.ForeignKey(
                        name: "FK_Reservation_Parking Spot_ParkingSpotID",
                        column: x => x.ParkingSpotID,
                        principalTable: "Parking Spot",
                        principalColumn: "ParkingSpotID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_UserSM_UserSMId",
                        column: x => x.UserSMId,
                        principalTable: "UserSM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parking Spot_ParkingLotID",
                table: "Parking Spot",
                column: "ParkingLotID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ParkingSpotID",
                table: "Reservation",
                column: "ParkingSpotID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_UserSMId",
                table: "Reservation",
                column: "UserSMId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Parking Spot");

            migrationBuilder.DropTable(
                name: "UserSM");

            migrationBuilder.DropTable(
                name: "Parking Lot");
        }
    }
}
