using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreRelations.Migrations
{
    /// <inheritdoc />
    public partial class IntialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirLines",
                columns: table => new
                {
                    AirLineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cont_Person = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirLines", x => x.AirLineId);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    RouteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Distance = table.Column<int>(type: "int", nullable: false),
                    Destination = table.Column<int>(type: "int", nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Classification = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.RouteId);
                });

            migrationBuilder.CreateTable(
                name: "AirCrafts",
                columns: table => new
                {
                    AirCraftId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    AirLineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirCrafts", x => x.AirCraftId);
                    table.ForeignKey(
                        name: "FK_AirCrafts_AirLines_AirLineId",
                        column: x => x.AirLineId,
                        principalTable: "AirLines",
                        principalColumn: "AirLineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BD_Year = table.Column<int>(type: "int", nullable: false),
                    BD_Month = table.Column<int>(type: "int", nullable: false),
                    BD_Day = table.Column<int>(type: "int", nullable: false),
                    AirLineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmpId);
                    table.ForeignKey(
                        name: "FK_Employees_AirLines_AirLineId",
                        column: x => x.AirLineId,
                        principalTable: "AirLines",
                        principalColumn: "AirLineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TranactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AirLineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TranactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_AirLines_AirLineId",
                        column: x => x.AirLineId,
                        principalTable: "AirLines",
                        principalColumn: "AirLineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Crews",
                columns: table => new
                {
                    CrewId = table.Column<int>(type: "int", nullable: false),
                    Maj_Pilot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Assis_Pilot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Host1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Host2 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crews", x => x.CrewId);
                    table.ForeignKey(
                        name: "FK_Crews_AirCrafts_CrewId",
                        column: x => x.CrewId,
                        principalTable: "AirCrafts",
                        principalColumn: "AirCraftId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RouteAircraft",
                columns: table => new
                {
                    AirCraftId = table.Column<int>(type: "int", nullable: false),
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    NumOfPassengers = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Arrival = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Departure = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteAircraft", x => new { x.AirCraftId, x.RouteId });
                    table.ForeignKey(
                        name: "FK_RouteAircraft_AirCrafts_AirCraftId",
                        column: x => x.AirCraftId,
                        principalTable: "AirCrafts",
                        principalColumn: "AirCraftId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RouteAircraft_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "RouteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AirCrafts_AirLineId",
                table: "AirCrafts",
                column: "AirLineId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AirLineId",
                table: "Employees",
                column: "AirLineId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteAircraft_RouteId",
                table: "RouteAircraft",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AirLineId",
                table: "Transactions",
                column: "AirLineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Crews");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "RouteAircraft");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "AirCrafts");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "AirLines");
        }
    }
}
