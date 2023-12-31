﻿using System.ComponentModel.DataAnnotations;

namespace TourismAPI.Models
{
    public class PickupLocation
    {
        [Key]
        public int PickupLocationId { get; set; }
        public string? PickupLocationName { get; set; }
        public string? PickupTime { get; set; }
    }
}
