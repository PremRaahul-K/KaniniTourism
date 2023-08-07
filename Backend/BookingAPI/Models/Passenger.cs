using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace BookingAPI.Models
{
    public class Passenger
    {
        [Key]
        public int PassengerId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [RegularExpression(@"^[A-Za-z\s]*$", ErrorMessage = "Name should contain only letters and spaces.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [RegularExpression(@"^\d{1,3}$", ErrorMessage = "Age should be a valid number.")]
        public string? Age { get; set; }

        [RegularExpression(@"^(Male|Female|Other)$", ErrorMessage = "Gender should be 'Male', 'Female', or 'Other'.")]
        public string? Gender { get; set; }

        public int BookingId { get; set; }

        [ForeignKey("BookingId")]
        [JsonIgnore]
        public Booking? Booking { get; set; }
    }
}
