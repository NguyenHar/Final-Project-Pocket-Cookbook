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
        [ForeignKey("Meal")]
        public virtual Meal? meal { get; set; }
    }

}
