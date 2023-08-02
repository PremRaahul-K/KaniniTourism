namespace TourismAPI.Models
{
    public class Tour
    {
        public int TourId { get; set; }
        public int TravelAgentId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? TourType { get; set; }
        public string? Price { get; set; }
        public ICollection<TourDate>? TourDates { get; set; }
        public ICollection<TourInclusion>? TourInclusions { get; set; }
        public ICollection<TourExclusion>? TourExclusions { get; set; }
        public ICollection<TourItinerary>? TourItinerary  { get; set; }
        public ICollection<PickupDropLocation>? PickupLocation { get; set; }
    }
}
