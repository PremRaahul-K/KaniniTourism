using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UserAPI.Models
{
    public class Traveller
    {
        [Key]
        public int TravellerId { get; set; }
        [ForeignKey("TravellerId")]
        [JsonIgnore]
        public UserDetail? UserDetail { get; set; }
    }
}
