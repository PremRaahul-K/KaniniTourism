using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TourismAPI.Models
{
    public class Highlight
    {
        [Key]
        public int HighlightId { get; set; }
        public int TourId { get; set; }
        [ForeignKey("TourId")]
        [JsonIgnore]
        public Tour? Tour { get; set; }
        public string? HighlightDetails{ get; set; }
    }
}
