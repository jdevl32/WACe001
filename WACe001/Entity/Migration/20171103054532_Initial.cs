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
                "Coordinate",
                table => new
                {
                    Latitude = table.Column<double>("float", nullable: false),
                    Longitude = table.Column<double>("float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinate", x => new { x.Latitude, x.Longitude });
                });

            migrationBuilder.CreateTable(
                "Trips",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateTimestamp = table.Column<DateTime>("datetime2", nullable: false),
                    Name = table.Column<string>("nvarchar(max)", nullable: true),
                    UserName = table.Column<string>("nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                });

            migrationBuilder.CreateTable(
                "Stops",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Arrival = table.Column<DateTime>("datetime2", nullable: false),
                    CoordinateLatitude = table.Column<double>("float", nullable: true),
                    CoordinateLongitude = table.Column<double>("float", nullable: true),
                    Name = table.Column<string>("nvarchar(max)", nullable: true),
                    Order = table.Column<int>("int", nullable: false),
                    TripId = table.Column<int>("int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stops", x => x.Id);
                    table.ForeignKey(
                        "FK_Stops_Trips_TripId",
                        x => x.TripId,
                        "Trips",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Stops_Coordinate_CoordinateLatitude_CoordinateLongitude",
                        x => new { x.CoordinateLatitude, x.CoordinateLongitude },
                        "Coordinate",
                        new[] { "Latitude", "Longitude" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_Stops_TripId",
                "Stops",
                "TripId");

            migrationBuilder.CreateIndex(
                "IX_Stops_CoordinateLatitude_CoordinateLongitude",
                "Stops",
                new[] { "CoordinateLatitude", "CoordinateLongitude" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Stops");

            migrationBuilder.DropTable(
                "Trips");

            migrationBuilder.DropTable(
                "Coordinate");
        }

    }
	
}
