using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourismAPI.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    TourId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TravelAgentId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TourType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfDays = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodAccommodation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.TourId);
                });

            migrationBuilder.CreateTable(
                name: "Exclusions",
                columns: table => new
                {
                    ExclusionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    ExclusionDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exclusions", x => x.ExclusionId);
                    table.ForeignKey(
                        name: "FK_Exclusions_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "TourId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Highlights",
                columns: table => new
                {
                    HighlightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    HighlightDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Highlights", x => x.HighlightId);
                    table.ForeignKey(
                        name: "FK_Highlights_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "TourId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inclusions",
                columns: table => new
                {
                    InclusionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    InclusionDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inclusions", x => x.InclusionId);
                    table.ForeignKey(
                        name: "FK_Inclusions_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "TourId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PickupLocations",
                columns: table => new
                {
                    PickupLocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PickupLocationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PickupTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TourId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PickupLocations", x => x.PickupLocationId);
                    table.ForeignKey(
                        name: "FK_PickupLocations_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "TourId");
                });

            migrationBuilder.CreateTable(
                name: "TourDates",
                columns: table => new
                {
                    DateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourDates", x => x.DateId);
                    table.ForeignKey(
                        name: "FK_TourDates_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "TourId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TourItineraries",
                columns: table => new
                {
                    TourItineraryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourItineraries", x => x.TourItineraryId);
                    table.ForeignKey(
                        name: "FK_TourItineraries_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "TourId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accommodations",
                columns: table => new
                {
                    AccommodationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TourItineraryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accommodations", x => x.AccommodationId);
                    table.ForeignKey(
                        name: "FK_Accommodations_TourItineraries_TourItineraryId",
                        column: x => x.TourItineraryId,
                        principalTable: "TourItineraries",
                        principalColumn: "TourItineraryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Itineraries",
                columns: table => new
                {
                    ItineraryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivityDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TourItineraryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itineraries", x => x.ItineraryId);
                    table.ForeignKey(
                        name: "FK_Itineraries_TourItineraries_TourItineraryId",
                        column: x => x.TourItineraryId,
                        principalTable: "TourItineraries",
                        principalColumn: "TourItineraryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_TourItineraryId",
                table: "Accommodations",
                column: "TourItineraryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exclusions_TourId",
                table: "Exclusions",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_Highlights_TourId",
                table: "Highlights",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_Inclusions_TourId",
                table: "Inclusions",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_Itineraries_TourItineraryId",
                table: "Itineraries",
                column: "TourItineraryId");

            migrationBuilder.CreateIndex(
                name: "IX_PickupLocations_TourId",
                table: "PickupLocations",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_TourDates_TourId",
                table: "TourDates",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_TourItineraries_TourId",
                table: "TourItineraries",
                column: "TourId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accommodations");

            migrationBuilder.DropTable(
                name: "Exclusions");

            migrationBuilder.DropTable(
                name: "Highlights");

            migrationBuilder.DropTable(
                name: "Inclusions");

            migrationBuilder.DropTable(
                name: "Itineraries");

            migrationBuilder.DropTable(
                name: "PickupLocations");

            migrationBuilder.DropTable(
                name: "TourDates");

            migrationBuilder.DropTable(
                name: "TourItineraries");

            migrationBuilder.DropTable(
                name: "Tours");
        }
    }
}
