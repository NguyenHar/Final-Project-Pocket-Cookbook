using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pocket_Cookbook_Backend.Migrations
{
    /// <inheritdoc />
    public partial class querymigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Queries_mealFK",
                table: "Queries",
                column: "mealFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Queries");
        }
    }
}
