using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TourismAPI.Models
{
    public class TourDates
    {
        [Key]
        public int DateId { get; set; }
        public int TourId { get; set; }
        [ForeignKey("TourId")]
        [JsonIgnore]
        public Tour? Tour { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
