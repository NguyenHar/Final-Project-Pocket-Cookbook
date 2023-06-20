using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pocket_Cookbook_Backend.Models
{
    public class TokenStorage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int primary_key_id { get; set; }
        [MaxLength(10000)]
        public string token { get; set; }

        public DateTime dateTime { get; set; }

    }
}
