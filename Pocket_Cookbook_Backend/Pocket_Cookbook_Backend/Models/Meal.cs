using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pocket_Cookbook_Backend.Models
{
    // Object containing the entire api call
    public class Meal
    {
        [Key]
        public int primary_key_id { get; set; }
        public int id { get; set; }
        public virtual ICollection<Result>? results { get; set; } = new List<Result>();
        public int? offset { get; set; }
        public int? number { get; set; }
        public int? totalResults { get; set; }
    }

    // This is the actual Meal
    public class Result
    {
        [Key]
        public int primary_key_id { get; set; }
        public int id { get; set; }
        public string? title { get; set; }
        public string? image { get; set; }
        public string? imageType { get; set; }
        public virtual Meal? Meal { get; set; }
        [ForeignKey("Meal")]
        public int mealFK { get; set; }
    }

    // This stores user search results and corresponding meal PK id
    // Allows for re-use of already searched queries, preserving API calls
    public class Queries
    {
        [Key]
        public int primary_key_id { get; set; }
        public string? query { get; set; }
        public int? time { get; set; }
        public virtual Meal? Meal { get; set; }
        [ForeignKey("Meal")]
        public int mealFK { get; set; }

    }

}
