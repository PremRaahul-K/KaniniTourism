using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace TourismAPI.Models.Context
{
    public class TourismContext:DbContext
    {
        public TourismContext(DbContextOptions<TourismContext> options):base(options)
        {
            
        }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourDate> TourDates { get; set; }
        public DbSet<TourItinerary> TourItineraries { get; set; }
        public DbSet<Itinerary> Itineraries { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<PickupLocation> PickupLocations { get; set; }
        public DbSet<Highlight>  Highlights{ get; set; }
        public DbSet<Inclusion> Inclusions { get; set; }
        public DbSet<Exclusion> Exclusions { get; set; }

    }
}
