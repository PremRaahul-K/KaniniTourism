using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TourismAPI.Models
{
    public class Inclusion
    {
        [Key]
        public int InclusionId { get; set; }
        public int TourId { get; set; }
        [ForeignKey("TourId")]
        [JsonIgnore]
        public Tour? Tour { get; set; }
        public string? InclusionDetails { get; set; }
    }
}
