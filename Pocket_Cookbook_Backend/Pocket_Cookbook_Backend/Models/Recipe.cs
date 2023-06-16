using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pocket_Cookbook_Backend.Models
{
    public class Recipe
    {
        [Key]
        public int primary_key_id { get; set; }
        public int id { get; set; }
        public bool? vegetarian { get; set; }
        public bool? vegan { get; set; }
        public bool? glutenFree { get; set; }
        public bool? dairyFree { get; set; }
        public bool? veryHealthy { get; set; }
        public bool? cheap { get; set; }
        public bool? veryPopular { get; set; }
        public bool? sustainable { get; set; }
        public bool? lowFodmap { get; set; }
        public int? weightWatcherSmartPoints { get; set; }
        public string? gaps { get; set; }
        public int? preparationMinutes { get; set; }
        public int? cookingMinutes { get; set; }
        public int? aggregateLikes { get; set; }
        public int? healthScore { get; set; }
        public string? creditsText { get; set; }
        public string? sourceName { get; set; }
        public float? pricePerServing { get; set; }
        public string? title { get; set; }
        public int? readyInMinutes { get; set; }
        public int? servings { get; set; }
        public string? sourceUrl { get; set; }
        public string? image { get; set; }
        public string? imageType { get; set; }
        public string? summary { get; set; }
        //public object[]? cuisines { get; set; }
        //public string[]? dishTypes { get; set; }
        //public string[]? diets { get; set; }
        //public object[]? occasions { get; set; }
        //public Winepairing? winePairing { get; set; }
        public string? instructions { get; set; }
        public virtual ICollection<Extendedingredient>? extendedIngredients { get; set; } = new List<Extendedingredient>();
        public virtual ICollection<Analyzedinstruction>? analyzedInstructions { get; set; } = new List<Analyzedinstruction>();
        //public object? originalId { get; set; }
        public string? spoonacularSourceUrl { get; set; }
    }

    //public class Winepairing
    //{
    //    public object[]? pairedWines { get; set; }
    //    public string? pairingText { get; set; }
    //    public object[]? productMatches { get; set; }
    //}

    public class Extendedingredient
    {
        [Key]
        public int primary_key_id { get; set; }
        public int id { get; set; }
        public string? aisle { get; set; }
        public string? image { get; set; }
        public string? consistency { get; set; }
        public string? name { get; set; }
        public string? nameClean { get; set; }
        public string? original { get; set; }
        public string? originalName { get; set; }
        public float? amount { get; set; }
        public string? unit { get; set; }
        //public string[]? meta { get; set; }
        public Measures? measures { get; set; }
        public virtual Recipe? Recipe { get; set; }
        [ForeignKey("Recipe")]
        public int RecipeFK { get; set; }
    }
    public class Analyzedinstruction
    {
        [Key]
        public int primary_key_id { get; set; }
        public int id { get; set; }
        public string? name { get; set; }
        public virtual ICollection<Step>? steps { get; set; } = new List<Step>();
        public virtual Recipe? Recipe { get; set; }
        [ForeignKey("Recipe")]
        public int RecipeFK { get; set; }
    }
    public class Step
    {
        [Key]
        public int primary_key_id { get; set; }
        public int id { get; set; }
        public int? number { get; set; }
        public string? step { get; set; }
        public virtual ICollection<Ingredient>? ingredients { get; set; } = new List<Ingredient>();
        public virtual ICollection<Equipment>? equipment { get; set; } = new List<Equipment>();
        public virtual Analyzedinstruction? AnalyzedInstruction { get; set; }
        [ForeignKey("Analyzedinstruction")]
        public int AnalyzedInstructionFK { get; set; }
    }

    public class Measures
    {
        [Key]
        public int primary_key_id { get; set; }
        public int id { get; set; }    
        public Us? us { get; set; }
        public Metric? metric { get; set; }
    }

    public class Us
    {
        [Key]
        public int primary_key_id { get; set; }
        public int id { get; set; }
        public float? amount { get; set; }
        public string? unitShort { get; set; }
        public string? unitLong { get; set; }
    }

    public class Metric
    {
        [Key]
        public int primary_key_id { get; set; }
        public int id { get; set; }
        public float? amount { get; set; }
        public string? unitShort { get; set; }
        public string? unitLong { get; set; }
    }



    public class Ingredient
    {
        [Key]
        public int primary_key_id { get; set; }
        public int id { get; set; }
        public string? name { get; set; }
        public string? localizedName { get; set; }
        public string? image { get; set; }
        public virtual Step? Step { get; set; }
        [ForeignKey("Step")]
        public int StepFK { get; set; }
    }

    public class Equipment
    {
        [Key]
        public int primary_key_id { get; set; }
        public int id { get; set; }
        public string? name { get; set; }
        public string? localizedName { get; set; }
        public string? image { get; set; }
        public virtual Step? Step { get; set; }
        [ForeignKey("Step")]
        public int StepFK { get; set; }
    }

}
