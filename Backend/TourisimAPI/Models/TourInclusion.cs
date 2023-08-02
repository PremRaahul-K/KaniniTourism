using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TourismAPI.Models
{
    public class TourInclusion
    {
        public int TourInclusionId { get; set; }
        public int TourId { get; set; }
        [ForeignKey("TourId")]
        [JsonIgnore]
        public Tour? Tour { get; set; }
        public int InclusionId { get; set; }
        [ForeignKey("InclusionId")]
        [JsonIgnore]
        public Inclusion? Inclusion { get; set; }
    }
}
