using System.ComponentModel.DataAnnotations;

namespace TourismAPI.Models
{
    public class Tour
    {
        [Key]
        public int TourId { get; set; }
        public int TravelAgentId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? TourType { get; set; }
        public string? Price { get; set; }
        public string? FoodAccommodation { get; set; }
        public ICollection<TourDate>? TourDates { get; set; }
        public ICollection<TourItinerary>? TourItinerary  { get; set; }
        public ICollection<PickupLocation>? PickupLocation { get; set; }
    }
}
