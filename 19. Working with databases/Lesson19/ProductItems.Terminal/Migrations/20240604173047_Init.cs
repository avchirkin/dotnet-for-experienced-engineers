using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductItems.Terminal.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "varchar", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "properties",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "varchar", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_properties", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product_items",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_items", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_items_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "property_values",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_item_id = table.Column<Guid>(type: "uuid", nullable: false),
                    property_id = table.Column<Guid>(type: "uuid", nullable: false),
                    value = table.Column<string>(type: "varchar", maxLength: 3000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_property_values", x => x.Id);
                    table.ForeignKey(
                        name: "FK_property_values_product_items_product_item_id",
                        column: x => x.product_item_id,
                        principalTable: "product_items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_property_values_properties_property_id",
                        column: x => x.property_id,
                        principalTable: "properties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_items_category_id",
                table: "product_items",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_property_values_product_item_id",
                table: "property_values",
                column: "product_item_id");

            migrationBuilder.CreateIndex(
                name: "IX_property_values_property_id",
                table: "property_values",
                column: "property_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "property_values");

            migrationBuilder.DropTable(
                name: "product_items");

            migrationBuilder.DropTable(
                name: "properties");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
