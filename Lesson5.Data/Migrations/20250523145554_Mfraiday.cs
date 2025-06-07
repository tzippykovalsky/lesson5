using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lesson5.Data.Migrations
{
    /// <inheritdoc />
    public partial class Mfraiday : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Pilots_PilotId1",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_PilotId1",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "PilotId1",
                table: "Flights");

            migrationBuilder.AlterColumn<int>(
                name: "PilotId",
                table: "Flights",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_PilotId",
                table: "Flights",
                column: "PilotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Pilots_PilotId",
                table: "Flights",
                column: "PilotId",
                principalTable: "Pilots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Pilots_PilotId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_PilotId",
                table: "Flights");

            migrationBuilder.AlterColumn<string>(
                name: "PilotId",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PilotId1",
                table: "Flights",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flights_PilotId1",
                table: "Flights",
                column: "PilotId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Pilots_PilotId1",
                table: "Flights",
                column: "PilotId1",
                principalTable: "Pilots",
                principalColumn: "Id");
        }
    }
}
