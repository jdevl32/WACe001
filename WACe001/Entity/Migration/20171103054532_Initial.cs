using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace WACe001.Entity.Migration
{

	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// Fully-qualified (Migration) base class required (to avoid collision with project namespace).
	/// </remarks>
	public partial class Initial : Microsoft.EntityFrameworkCore.Migrations.Migration
	{

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coordinate",
                columns: table => new
                {
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinate", x => new { x.Latitude, x.Longitude });
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Arrival = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CoordinateLatitude = table.Column<double>(type: "float", nullable: true),
                    CoordinateLongitude = table.Column<double>(type: "float", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    TripId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stops_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stops_Coordinate_CoordinateLatitude_CoordinateLongitude",
                        columns: x => new { x.CoordinateLatitude, x.CoordinateLongitude },
                        principalTable: "Coordinate",
                        principalColumns: new[] { "Latitude", "Longitude" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stops_TripId",
                table: "Stops",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_Stops_CoordinateLatitude_CoordinateLongitude",
                table: "Stops",
                columns: new[] { "CoordinateLatitude", "CoordinateLongitude" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stops");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Coordinate");
        }

    }
	
}
