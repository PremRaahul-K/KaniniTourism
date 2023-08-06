using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TourismAPI.Models
{
    public class TourDate
    {
        [Key]
        public int DateId { get; set; }
        public int TourId { get; set; }
        public int Capacity { get; set; }
        public int BookedCapacity { get; set; }
        public int NumberOfDays
        {
            get
            {
                TimeSpan time_difference = ReturnDate - DepartureDate;
                return time_difference.Days;
            }
        }
        [ForeignKey("TourId")]
        [JsonIgnore]
        public Tour? Tour { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
