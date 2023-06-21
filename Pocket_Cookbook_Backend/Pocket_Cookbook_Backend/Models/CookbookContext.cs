using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace Pocket_Cookbook_Backend.Models
{
    public class CookbookContext : DbContext
    {
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Queries> Queries { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Extendedingredient> extendedingredients { get; set; }
        public DbSet<Analyzedinstruction> analyzedinstructions { get; set; }
        public DbSet<Measures> measures { get; set; }
        public DbSet<Us> units_us { get; set; } 
        public DbSet<Metric> units_metric { get; set; }
        public DbSet<Step> steps { get; set; }
        public DbSet<Ingredient> ingredients { get; set; }
        public DbSet<Equipment> equipment { get; set; }
        public DbSet<TokenStorage> tokenstorage { get; set; }
        public DbSet<KrogerProduct> krogerProducts { get; set; }


        public CookbookContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Cookbook;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }
    }
}
