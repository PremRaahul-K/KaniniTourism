using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourismAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exclusions",
                columns: table => new
                {
                    ExclusionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exclusions", x => x.ExclusionId);
                });

            migrationBuilder.CreateTable(
                name: "Inclusions",
                columns: table => new
                {
                    InclusionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inclusions", x => x.InclusionId);
                });

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
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.TourId);
                });

            migrationBuilder.CreateTable(
                name: "TourDates",
                columns: table => new
                {
                    DateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TourId = table.Column<int>(type: "int", nullable: false),
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
                name: "TourExclusions",
                columns: table => new
                {
                    TourExclusionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    ExclusionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourExclusions", x => x.TourExclusionId);
                    table.ForeignKey(
                        name: "FK_TourExclusions_Exclusions_ExclusionId",
                        column: x => x.ExclusionId,
                        principalTable: "Exclusions",
                        principalColumn: "ExclusionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourExclusions_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "TourId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TourInclusions",
                columns: table => new
                {
                    TourInclusionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    InclusionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourInclusions", x => x.TourInclusionId);
                    table.ForeignKey(
                        name: "FK_TourInclusions_Inclusions_InclusionId",
                        column: x => x.InclusionId,
                        principalTable: "Inclusions",
                        principalColumn: "InclusionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourInclusions_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "TourId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TourDates_TourId",
                table: "TourDates",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_TourExclusions_ExclusionId",
                table: "TourExclusions",
                column: "ExclusionId");

            migrationBuilder.CreateIndex(
                name: "IX_TourExclusions_TourId",
                table: "TourExclusions",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_TourInclusions_InclusionId",
                table: "TourInclusions",
                column: "InclusionId");

            migrationBuilder.CreateIndex(
                name: "IX_TourInclusions_TourId",
                table: "TourInclusions",
                column: "TourId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TourDates");

            migrationBuilder.DropTable(
                name: "TourExclusions");

            migrationBuilder.DropTable(
                name: "TourInclusions");

            migrationBuilder.DropTable(
                name: "Exclusions");

            migrationBuilder.DropTable(
                name: "Inclusions");

            migrationBuilder.DropTable(
                name: "Tours");
        }
    }
}
