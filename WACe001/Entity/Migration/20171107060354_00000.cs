using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace WACe001.Entity.Migration
{
	public partial class _00000 : Microsoft.EntityFrameworkCore.Migrations.Migration
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
				name: "Trip",
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
					table.PrimaryKey("PK_Trip", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Stop",
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
					table.PrimaryKey("PK_Stop", x => x.Id);
					table.ForeignKey(
						name: "FK_Stop_Trip_TripId",
						column: x => x.TripId,
						principalTable: "Trip",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Stop_Coordinate_CoordinateLatitude_CoordinateLongitude",
						columns: x => new { x.CoordinateLatitude, x.CoordinateLongitude },
						principalTable: "Coordinate",
						principalColumns: new[] { "Latitude", "Longitude" },
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Stop_TripId",
				table: "Stop",
				column: "TripId");

			migrationBuilder.CreateIndex(
				name: "IX_Stop_CoordinateLatitude_CoordinateLongitude",
				table: "Stop",
				columns: new[] { "CoordinateLatitude", "CoordinateLongitude" });
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Stop");

			migrationBuilder.DropTable(
				name: "Trip");

			migrationBuilder.DropTable(
				name: "Coordinate");
		}
	}
}
