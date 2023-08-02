using System.ComponentModel.DataAnnotations;

namespace TourismAPI.Models
{
    public class Inclusion
    {
        [Key]
        public int InclusionId { get; set; }
        public string? Description { get; set; }
    }
}
