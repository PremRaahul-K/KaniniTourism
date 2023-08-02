using System.ComponentModel.DataAnnotations;

namespace TourismAPI.Models
{
    public class Exclusion
    {
        [Key]
        public int ExclusionId { get; set; }
        public string? Description { get; set; }
    }
}
