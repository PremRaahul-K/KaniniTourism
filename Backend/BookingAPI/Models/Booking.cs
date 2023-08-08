using System.ComponentModel.DataAnnotations;

namespace BookingAPI.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        [Required(ErrorMessage = "TourId is required.")]
        public int TourId { get; set; }

        [Required(ErrorMessage = "UserId is required.")]
        public int UserId { get; set; }
        public DateTime BookingDate { get; set; }

        [StringLength(50, ErrorMessage = "BookingStatus cannot exceed 50 characters.")]
        public string? BookingStatus { get; set; }

        [RegularExpression(@"^[A-Za-z\s]*$", ErrorMessage = "ContactName should contain only letters and spaces.")]
        public string? ContactName { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format for ContactEmail.")]
        public string? ContactEmail { get; set; }

        [RegularExpression(@"^\d{10,15}$", ErrorMessage = "PhoneNumber should be between 10 to 15 digits.")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "TotalPrice should be a numeric value with up to 2 decimal places.")]
        public double? TotalPrice { get; set; }
        public ICollection<Passenger>? Passengers { get; set; }
    }
}
