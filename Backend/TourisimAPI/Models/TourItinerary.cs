using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TourismAPI.Models
{
    public class TourItinerary
    {
        [Key]
        public int TourItineraryId { get; set; }
        public int TourId { get; set; }
        [ForeignKey("TourId")]
        [JsonIgnore]
        public Tour? Tour { get; set; }
        public string? Title { get; set; }
        public ICollection<Itinerary>? Itineraries { get; set; }
        public Accomidation? Accomidation { get; set; }
    }

}
