using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TourismAPI.Models
{
    public class Itinerary
    {
        [Key]
        public int ItineraryId { get; set; }
        public string? ActivityTitle { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public DateTime? EventTime { get; set; }
        public int TourItineraryId { get; set; }
        [ForeignKey("TourItineraryId")]
        [JsonIgnore]
        public TourItinerary? TourItinerary { get; set; }

    }
}
