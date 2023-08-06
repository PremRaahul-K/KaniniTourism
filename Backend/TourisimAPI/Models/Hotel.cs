using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TourismAPI.Models
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }
        public string? HotelName { get; set; }
        public string? Address  { get; set; }
        public int TourItineraryId { get; set; }
        [ForeignKey("TourItineraryId")]
        [JsonIgnore]
        public TourItinerary? TourItinerary { get; set; }
    }
}
