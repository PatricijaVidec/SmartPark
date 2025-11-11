using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartPark.Migrations
{
    /// <inheritdoc />
    public partial class Administrator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "UserSM",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "UserSM",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "UserSM",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserSM",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AdministratorID",
                table: "UserSM",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "Reservation",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "Reservation",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "AdministratorID",
                table: "Reservation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdministratorID",
                table: "Parking Spot",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Parking Lot",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AdministratorID",
                table: "Parking Lot",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    AdministratorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminPassword = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.AdministratorID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSM_AdministratorID",
                table: "UserSM",
                column: "AdministratorID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_AdministratorID",
                table: "Reservation",
                column: "AdministratorID");

            migrationBuilder.CreateIndex(
                name: "IX_Parking Spot_AdministratorID",
                table: "Parking Spot",
                column: "AdministratorID");

            migrationBuilder.CreateIndex(
                name: "IX_Parking Lot_AdministratorID",
                table: "Parking Lot",
                column: "AdministratorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Parking Lot_Administrator_AdministratorID",
                table: "Parking Lot",
                column: "AdministratorID",
                principalTable: "Administrator",
                principalColumn: "AdministratorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Parking Spot_Administrator_AdministratorID",
                table: "Parking Spot",
                column: "AdministratorID",
                principalTable: "Administrator",
                principalColumn: "AdministratorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Administrator_AdministratorID",
                table: "Reservation",
                column: "AdministratorID",
                principalTable: "Administrator",
                principalColumn: "AdministratorID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSM_Administrator_AdministratorID",
                table: "UserSM",
                column: "AdministratorID",
                principalTable: "Administrator",
                principalColumn: "AdministratorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parking Lot_Administrator_AdministratorID",
                table: "Parking Lot");

            migrationBuilder.DropForeignKey(
                name: "FK_Parking Spot_Administrator_AdministratorID",
                table: "Parking Spot");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Administrator_AdministratorID",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSM_Administrator_AdministratorID",
                table: "UserSM");

            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropIndex(
                name: "IX_UserSM_AdministratorID",
                table: "UserSM");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_AdministratorID",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Parking Spot_AdministratorID",
                table: "Parking Spot");

            migrationBuilder.DropIndex(
                name: "IX_Parking Lot_AdministratorID",
                table: "Parking Lot");

            migrationBuilder.DropColumn(
                name: "AdministratorID",
                table: "UserSM");

            migrationBuilder.DropColumn(
                name: "AdministratorID",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "AdministratorID",
                table: "Parking Spot");

            migrationBuilder.DropColumn(
                name: "AdministratorID",
                table: "Parking Lot");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "UserSM",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "UserSM",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "UserSM",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserSM",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "Reservation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "Reservation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Parking Lot",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
