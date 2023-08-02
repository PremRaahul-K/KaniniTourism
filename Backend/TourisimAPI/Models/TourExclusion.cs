using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TourismAPI.Models
{
    public class TourExclusion
    {
        [Key]
        public int TourExclusionId { get; set; }
        public int TourId { get; set; }
        [ForeignKey("TourId")]
        [JsonIgnore]
        public Tour? Tour { get; set; }
        public int ExclusionId { get; set; }
        [ForeignKey("ExclusionId")]
        [JsonIgnore]
        public Exclusion? Exclusion { get; set; }
    }
}
