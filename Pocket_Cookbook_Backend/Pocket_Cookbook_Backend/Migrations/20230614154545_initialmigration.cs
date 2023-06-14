using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pocket_Cookbook_Backend.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    offset = table.Column<int>(type: "int", nullable: true),
                    number = table.Column<int>(type: "int", nullable: true),
                    totalResults = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Metric",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amount = table.Column<float>(type: "real", nullable: true),
                    unitShort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unitLong = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metric", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    table.PrimaryKey("PK_Recipes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Us",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amount = table.Column<float>(type: "real", nullable: true),
                    unitShort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unitLong = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Us", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Result",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imageType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Meal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.id);
                    table.ForeignKey(
                        name: "FK_Result_Meals_Meal",
                        column: x => x.Meal,
                        principalTable: "Meals",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Analyzedinstruction",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipeFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analyzedinstruction", x => x.id);
                    table.ForeignKey(
                        name: "FK_Analyzedinstruction_Recipes_RecipeFK",
                        column: x => x.RecipeFK,
                        principalTable: "Recipes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Measures",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usid = table.Column<int>(type: "int", nullable: true),
                    metricid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measures", x => x.id);
                    table.ForeignKey(
                        name: "FK_Measures_Metric_metricid",
                        column: x => x.metricid,
                        principalTable: "Metric",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Measures_Us_usid",
                        column: x => x.usid,
                        principalTable: "Us",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Step",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    number = table.Column<int>(type: "int", nullable: true),
                    step = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnalyzedInstructionid = table.Column<int>(type: "int", nullable: true),
                    AnalyzedInstructionFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Step", x => x.id);
                    table.ForeignKey(
                        name: "FK_Step_Analyzedinstruction_AnalyzedInstructionid",
                        column: x => x.AnalyzedInstructionid,
                        principalTable: "Analyzedinstruction",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Extendedingredient",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    aisle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    consistency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nameClean = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    original = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    originalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    amount = table.Column<float>(type: "real", nullable: true),
                    unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    measuresid = table.Column<int>(type: "int", nullable: true),
                    RecipeFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extendedingredient", x => x.id);
                    table.ForeignKey(
                        name: "FK_Extendedingredient_Measures_measuresid",
                        column: x => x.measuresid,
                        principalTable: "Measures",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Extendedingredient_Recipes_RecipeFK",
                        column: x => x.RecipeFK,
                        principalTable: "Recipes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    localizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StepFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.id);
                    table.ForeignKey(
                        name: "FK_Equipment_Step_StepFK",
                        column: x => x.StepFK,
                        principalTable: "Step",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    localizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StepFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.id);
                    table.ForeignKey(
                        name: "FK_Ingredient_Step_StepFK",
                        column: x => x.StepFK,
                        principalTable: "Step",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Analyzedinstruction_RecipeFK",
                table: "Analyzedinstruction",
                column: "RecipeFK");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_StepFK",
                table: "Equipment",
                column: "StepFK");

            migrationBuilder.CreateIndex(
                name: "IX_Extendedingredient_measuresid",
                table: "Extendedingredient",
                column: "measuresid");

            migrationBuilder.CreateIndex(
                name: "IX_Extendedingredient_RecipeFK",
                table: "Extendedingredient",
                column: "RecipeFK");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_StepFK",
                table: "Ingredient",
                column: "StepFK");

            migrationBuilder.CreateIndex(
                name: "IX_Measures_metricid",
                table: "Measures",
                column: "metricid");

            migrationBuilder.CreateIndex(
                name: "IX_Measures_usid",
                table: "Measures",
                column: "usid");

            migrationBuilder.CreateIndex(
                name: "IX_Result_Meal",
                table: "Result",
                column: "Meal");

            migrationBuilder.CreateIndex(
                name: "IX_Step_AnalyzedInstructionid",
                table: "Step",
                column: "AnalyzedInstructionid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Extendedingredient");

            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "Result");

            migrationBuilder.DropTable(
                name: "Measures");

            migrationBuilder.DropTable(
                name: "Step");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Metric");

            migrationBuilder.DropTable(
                name: "Us");

            migrationBuilder.DropTable(
                name: "Analyzedinstruction");

            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
