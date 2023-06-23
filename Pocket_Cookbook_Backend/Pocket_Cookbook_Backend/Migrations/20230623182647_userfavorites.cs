using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pocket_Cookbook_Backend.Migrations
{
    /// <inheritdoc />
    public partial class userfavorites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fulfillments",
                columns: table => new
                {
                    primary_key_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    curbside = table.Column<bool>(type: "bit", nullable: false),
                    delivery = table.Column<bool>(type: "bit", nullable: false),
                    inStore = table.Column<bool>(type: "bit", nullable: false),
                    shipToHome = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fulfillments", x => x.primary_key_id);
                });

            migrationBuilder.CreateTable(
                name: "inventory",
                columns: table => new
                {
                    primary_key_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stockLevel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory", x => x.primary_key_id);
                });

            migrationBuilder.CreateTable(
                name: "krogerProducts",
                columns: table => new
                {
                    primary_key_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_krogerProducts", x => x.primary_key_id);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    primary_key_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<int>(type: "int", nullable: false),
                    offset = table.Column<int>(type: "int", nullable: true),
                    number = table.Column<int>(type: "int", nullable: true),
                    totalResults = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.primary_key_id);
                });

            migrationBuilder.CreateTable(
                name: "prices",
                columns: table => new
                {
                    primary_key_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    regular = table.Column<float>(type: "real", nullable: false),
                    promo = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prices", x => x.primary_key_id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    primary_key_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<int>(type: "int", nullable: false),
                    vegetarian = table.Column<bool>(type: "bit", nullable: true),
                    vegan = table.Column<bool>(type: "bit", nullable: true),
                    glutenFree = table.Column<bool>(type: "bit", nullable: true),
                    dairyFree = table.Column<bool>(type: "bit", nullable: true),
                    veryHealthy = table.Column<bool>(type: "bit", nullable: true),
                    cheap = table.Column<bool>(type: "bit", nullable: true),
                    veryPopular = table.Column<bool>(type: "bit", nullable: true),
                    sustainable = table.Column<bool>(type: "bit", nullable: true),
                    lowFodmap = table.Column<bool>(type: "bit", nullable: true),
                    weightWatcherSmartPoints = table.Column<int>(type: "int", nullable: true),
                    gaps = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    preparationMinutes = table.Column<int>(type: "int", nullable: true),
                    cookingMinutes = table.Column<int>(type: "int", nullable: true),
                    aggregateLikes = table.Column<int>(type: "int", nullable: true),
                    healthScore = table.Column<int>(type: "int", nullable: true),
                    creditsText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sourceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pricePerServing = table.Column<float>(type: "real", nullable: true),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    readyInMinutes = table.Column<int>(type: "int", nullable: true),
                    servings = table.Column<int>(type: "int", nullable: true),
                    sourceUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imageType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    instructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spoonacularSourceUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.primary_key_id);
                });

            migrationBuilder.CreateTable(
                name: "tokenstorage",
                columns: table => new
                {
                    primary_key_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    token = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tokenstorage", x => x.primary_key_id);
                });

            migrationBuilder.CreateTable(
                name: "units_metric",
                columns: table => new
                {
                    primary_key_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<float>(type: "real", nullable: true),
                    unitShort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unitLong = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_units_metric", x => x.primary_key_id);
                });

            migrationBuilder.CreateTable(
                name: "units_us",
                columns: table => new
                {
                    primary_key_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<float>(type: "real", nullable: true),
                    unitShort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unitLong = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_units_us", x => x.primary_key_id);
                });

            migrationBuilder.CreateTable(
                name: "data",
                columns: table => new
                {
                    primary_key_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    upc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    countryOrigin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_data", x => x.primary_key_id);
                    table.ForeignKey(
                        name: "FK_data_krogerProducts_productFK",
                        column: x => x.productFK,
                        principalTable: "krogerProducts",
                        principalColumn: "primary_key_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "metas",
                columns: table => new
                {
                    primary_key_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_metas", x => x.primary_key_id);
                    table.ForeignKey(
                        name: "FK_metas_krogerProducts_productFK",
                        column: x => x.productFK,
                        principalTable: "krogerProducts",
                        principalColumn: "primary_key_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Queries",
                columns: table => new
                {
                    primary_key_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    query = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    time = table.Column<int>(type: "int", nullable: true),
                    mealFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Queries", x => x.primary_key_id);
                    table.ForeignKey(
                        name: "FK_Queries_Meals_mealFK",
                        column: x => x.mealFK,
                        principalTable: "Meals",
                        principalColumn: "primary_key_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    primary_key_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imageType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mealFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.primary_key_id);
                    table.ForeignKey(
                        name: "FK_Results_Meals_mealFK",
                        column: x => x.mealFK,
                        principalTable: "Meals",
                        principalColumn: "primary_key_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "analyzedinstructions",
                columns: table => new
                {
                    primary_key_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipeFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_analyzedinstructions", x => x.primary_key_id);
                    table.ForeignKey(
                        name: "FK_analyzedinstructions_Recipes_RecipeFK",
                        column: x => x.RecipeFK,
                        principalTable: "Recipes",
                        principalColumn: "primary_key_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "measures",
                columns: table => new
                {
                    primary_key_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<int>(type: "int", nullable: false),
                    usprimary_key_id = table.Column<int>(type: "int", nullable: true),
                    metricprimary_key_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_measures", x => x.primary_key_id);
                    table.ForeignKey(
                        name: "FK_measures_units_metric_metricprimary_key_id",
                        column: x => x.metricprimary_key_id,
                        principalTable: "units_metric",
                        principalColumn: "primary_key_id");
                    table.ForeignKey(
                        name: "FK_measures_units_us_usprimary_key_id",
                        column: x => x.usprimary_key_id,
                        principalTable: "units_us",
                        principalColumn: "primary_key_id");
                });

            migrationBuilder.CreateTable(
                name: "images",
                columns: table => new
                {
                    primary_key_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    perspective = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    featured = table.Column<bool>(type: "bit", nullable: false),
                    dataFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_images", x => x.primary_key_id);
                    table.ForeignKey(
                        name: "FK_images_data_dataFK",
                        column: x => x.dataFK,
                        principalTable: "data",
                        principalColumn: "primary_key_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    primary_key_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    inventoryprimary_key_id = table.Column<int>(type: "int", nullable: false),
                    favorite = table.Column<bool>(type: "bit", nullable: false),
                    fulfillmentprimary_key_id = table.Column<int>(type: "int", nullable: false),
                    priceprimary_key_id = table.Column<int>(type: "int", nullable: false),
                    size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    soldBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dataFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.primary_key_id);
                    table.ForeignKey(
                        name: "FK_items_data_dataFK",
                        column: x => x.dataFK,
                        principalTable: "data",
                        principalColumn: "primary_key_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_items_fulfillments_fulfillmentprimary_key_id",
                        column: x => x.fulfillmentprimary_key_id,
                        principalTable: "fulfillments",
                        principalColumn: "primary_key_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_items_inventory_inventoryprimary_key_id",
                        column: x => x.inventoryprimary_key_id,
                        principalTable: "inventory",
                        principalColumn: "primary_key_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_items_prices_priceprimary_key_id",
                        column: x => x.priceprimary_key_id,
                        principalTable: "prices",
                        principalColumn: "primary_key_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "paginations",
                columns: table => new
                {
                    primary_key_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    start = table.Column<int>(type: "int", nullable: false),
                    limit = table.Column<int>(type: "int", nullable: false),
                    total = table.Column<int>(type: "int", nullable: false),
                    metaFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paginations", x => x.primary_key_id);
                    table.ForeignKey(
                        name: "FK_paginations_metas_metaFK",
                        column: x => x.metaFK,
                        principalTable: "metas",
                        principalColumn: "primary_key_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "steps",
                columns: table => new
                {
                    primary_key_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<int>(type: "int", nullable: false),
                    number = table.Column<int>(type: "int", nullable: true),
                    step = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnalyzedInstructionprimary_key_id = table.Column<int>(type: "int", nullable: true),
                    AnalyzedInstructionFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_steps", x => x.primary_key_id);
                    table.ForeignKey(
                        name: "FK_steps_analyzedinstructions_AnalyzedInstructionprimary_key_id",
                        column: x => x.AnalyzedInstructionprimary_key_id,
                        principalTable: "analyzedinstructions",
                        principalColumn: "primary_key_id");
                });

            migrationBuilder.CreateTable(
                name: "extendedingredients",
                columns: table => new
                {
                    primary_key_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<int>(type: "int", nullable: false),
                    aisle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    consistency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nameClean = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    original = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    originalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    amount = table.Column<float>(type: "real", nullable: true),
                    unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    measuresprimary_key_id = table.Column<int>(type: "int", nullable: true),
                    RecipeFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_extendedingredients", x => x.primary_key_id);
                    table.ForeignKey(
                        name: "FK_extendedingredients_Recipes_RecipeFK",
                        column: x => x.RecipeFK,
                        principalTable: "Recipes",
                        principalColumn: "primary_key_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_extendedingredients_measures_measuresprimary_key_id",
                        column: x => x.measuresprimary_key_id,
                        principalTable: "measures",
                        principalColumn: "primary_key_id");
                });

            migrationBuilder.CreateTable(
                name: "sizes",
                columns: table => new
                {
                    primary_key_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imgFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sizes", x => x.primary_key_id);
                    table.ForeignKey(
                        name: "FK_sizes_images_imgFK",
                        column: x => x.imgFK,
                        principalTable: "images",
                        principalColumn: "primary_key_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "equipment",
                columns: table => new
                {
                    primary_key_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    localizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StepFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipment", x => x.primary_key_id);
                    table.ForeignKey(
                        name: "FK_equipment_steps_StepFK",
                        column: x => x.StepFK,
                        principalTable: "steps",
                        principalColumn: "primary_key_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ingredients",
                columns: table => new
                {
                    primary_key_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    localizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StepFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredients", x => x.primary_key_id);
                    table.ForeignKey(
                        name: "FK_ingredients_steps_StepFK",
                        column: x => x.StepFK,
                        principalTable: "steps",
                        principalColumn: "primary_key_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_analyzedinstructions_RecipeFK",
                table: "analyzedinstructions",
                column: "RecipeFK");

            migrationBuilder.CreateIndex(
                name: "IX_data_productFK",
                table: "data",
                column: "productFK");

            migrationBuilder.CreateIndex(
                name: "IX_equipment_StepFK",
                table: "equipment",
                column: "StepFK");

            migrationBuilder.CreateIndex(
                name: "IX_extendedingredients_measuresprimary_key_id",
                table: "extendedingredients",
                column: "measuresprimary_key_id");

            migrationBuilder.CreateIndex(
                name: "IX_extendedingredients_RecipeFK",
                table: "extendedingredients",
                column: "RecipeFK");

            migrationBuilder.CreateIndex(
                name: "IX_images_dataFK",
                table: "images",
                column: "dataFK");

            migrationBuilder.CreateIndex(
                name: "IX_ingredients_StepFK",
                table: "ingredients",
                column: "StepFK");

            migrationBuilder.CreateIndex(
                name: "IX_items_dataFK",
                table: "items",
                column: "dataFK");

            migrationBuilder.CreateIndex(
                name: "IX_items_fulfillmentprimary_key_id",
                table: "items",
                column: "fulfillmentprimary_key_id");

            migrationBuilder.CreateIndex(
                name: "IX_items_inventoryprimary_key_id",
                table: "items",
                column: "inventoryprimary_key_id");

            migrationBuilder.CreateIndex(
                name: "IX_items_priceprimary_key_id",
                table: "items",
                column: "priceprimary_key_id");

            migrationBuilder.CreateIndex(
                name: "IX_measures_metricprimary_key_id",
                table: "measures",
                column: "metricprimary_key_id");

            migrationBuilder.CreateIndex(
                name: "IX_measures_usprimary_key_id",
                table: "measures",
                column: "usprimary_key_id");

            migrationBuilder.CreateIndex(
                name: "IX_metas_productFK",
                table: "metas",
                column: "productFK",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_paginations_metaFK",
                table: "paginations",
                column: "metaFK",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Queries_mealFK",
                table: "Queries",
                column: "mealFK");

            migrationBuilder.CreateIndex(
                name: "IX_Results_mealFK",
                table: "Results",
                column: "mealFK");

            migrationBuilder.CreateIndex(
                name: "IX_sizes_imgFK",
                table: "sizes",
                column: "imgFK");

            migrationBuilder.CreateIndex(
                name: "IX_steps_AnalyzedInstructionprimary_key_id",
                table: "steps",
                column: "AnalyzedInstructionprimary_key_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "equipment");

            migrationBuilder.DropTable(
                name: "extendedingredients");

            migrationBuilder.DropTable(
                name: "ingredients");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "paginations");

            migrationBuilder.DropTable(
                name: "Queries");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "sizes");

            migrationBuilder.DropTable(
                name: "tokenstorage");

            migrationBuilder.DropTable(
                name: "measures");

            migrationBuilder.DropTable(
                name: "steps");

            migrationBuilder.DropTable(
                name: "fulfillments");

            migrationBuilder.DropTable(
                name: "inventory");

            migrationBuilder.DropTable(
                name: "prices");

            migrationBuilder.DropTable(
                name: "metas");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "images");

            migrationBuilder.DropTable(
                name: "units_metric");

            migrationBuilder.DropTable(
                name: "units_us");

            migrationBuilder.DropTable(
                name: "analyzedinstructions");

            migrationBuilder.DropTable(
                name: "data");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "krogerProducts");
        }
    }
}
