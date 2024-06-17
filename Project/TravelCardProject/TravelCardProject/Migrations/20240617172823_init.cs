using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelCardProject.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    balance = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "coefficients",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "varchar", maxLength: 250, nullable: false),
                    value = table.Column<double>(type: "decimal", nullable: false),
                    duration_minutes = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coefficients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "passengers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "varchar", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passengers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tariffs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "varchar", maxLength: 250, nullable: false),
                    duration = table.Column<int>(type: "int", nullable: true),
                    underground_trip_price = table.Column<decimal>(type: "decimal", nullable: false),
                    ground_trip_price = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tariffs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "terminals",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    transport_type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_terminals", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "travel_cards",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    number = table.Column<string>(type: "varchar", maxLength: 12, nullable: false),
                    activation_date = table.Column<DateTime>(type: "timestamp", nullable: false),
                    expiration_date = table.Column<DateTime>(type: "timestamp", nullable: true),
                    status = table.Column<int>(type: "int", nullable: false),
                    high_coefficient_expiration = table.Column<DateTime>(type: "timestamp", nullable: true),
                    AccountId = table.Column<Guid>(type: "uuid", nullable: false),
                    TariffId = table.Column<Guid>(type: "uuid", nullable: false),
                    PassengerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_travel_cards", x => x.id);
                    table.ForeignKey(
                        name: "FK_travel_cards_accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_travel_cards_passengers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "passengers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_travel_cards_tariffs_TariffId",
                        column: x => x.TariffId,
                        principalTable: "tariffs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trips_info",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    trip_date = table.Column<DateTime>(type: "timestamp", nullable: false),
                    TerminalId = table.Column<Guid>(type: "uuid", nullable: false),
                    TravelCardId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trips_info", x => x.id);
                    table.ForeignKey(
                        name: "FK_trips_info_terminals_TerminalId",
                        column: x => x.TerminalId,
                        principalTable: "terminals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_trips_info_travel_cards_TravelCardId",
                        column: x => x.TravelCardId,
                        principalTable: "travel_cards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_travel_cards_AccountId",
                table: "travel_cards",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_travel_cards_PassengerId",
                table: "travel_cards",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_travel_cards_TariffId",
                table: "travel_cards",
                column: "TariffId");

            migrationBuilder.CreateIndex(
                name: "IX_trips_info_TerminalId",
                table: "trips_info",
                column: "TerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_trips_info_TravelCardId",
                table: "trips_info",
                column: "TravelCardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "coefficients");

            migrationBuilder.DropTable(
                name: "trips_info");

            migrationBuilder.DropTable(
                name: "terminals");

            migrationBuilder.DropTable(
                name: "travel_cards");

            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "passengers");

            migrationBuilder.DropTable(
                name: "tariffs");
        }
    }
}
