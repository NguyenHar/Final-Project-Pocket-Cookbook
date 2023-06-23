using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pocket_Cookbook_Backend.Models
{
    public class UserFavorites
    {
        [Key]
        public int primary_key_id { get; set; }
        public string googleId { get; set; }
        public virtual Result? Result { get; set; }
        [ForeignKey("Result")]
        public int resultFK { get; set; }
    }
}
