using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourismAPI.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accommodations");

            migrationBuilder.AddColumn<int>(
                name: "BookedCapacity",
                table: "TourDates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TourItineraryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.HotelId);
                    table.ForeignKey(
                        name: "FK_Hotel_TourItineraries_TourItineraryId",
                        column: x => x.TourItineraryId,
                        principalTable: "TourItineraries",
                        principalColumn: "TourItineraryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_TourItineraryId",
                table: "Hotel",
                column: "TourItineraryId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropColumn(
                name: "BookedCapacity",
                table: "TourDates");

            migrationBuilder.CreateTable(
                name: "Accommodations",
                columns: table => new
                {
                    AccommodationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TourItineraryId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotelName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_TourItineraryId",
                table: "Accommodations",
                column: "TourItineraryId",
                unique: true);
        }
    }
}
