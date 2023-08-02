using System.ComponentModel.DataAnnotations;

namespace TourismAPI.Models
{
    public class PickupDropLocation
    {
        [Key]
        public int PickupDropLocationId { get; set; }
        public string? PickupDropLocationName { get; set; }
    }
}
