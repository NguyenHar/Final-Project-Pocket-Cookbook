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
        public DbSet<Meta> metas { get; set; }
        public DbSet<Pagination> paginations { get; set; }
        public DbSet<Datum> data { get; set; }
        public DbSet<Image> images { get; set; }
        public DbSet<Size> sizes { get; set; }
        public DbSet<Item> items { get; set; }
        public DbSet<Inventory> inventory { get; set; }
        public DbSet<Fulfillment> fulfillments { get; set; }
        public DbSet<Price> prices { get; set; }


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
