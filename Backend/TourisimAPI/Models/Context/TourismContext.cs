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
        public DbSet<TourInclusion> TourInclusions { get; set; }
        public DbSet<TourExclusion> TourExclusions { get; set; }
        public DbSet<TourDate> TourDates { get; set; }
        public DbSet<Exclusion> Exclusions { get; set; }
        public DbSet<Inclusion> Inclusions { get; set; }
        public DbSet<TourItinerary> TourItineraries { get; set; }
        public DbSet<Itinerary> Itineraries { get; set; }
        public DbSet<Accomidation> Accomidations { get; set; }
        public DbSet<PickupDropLocation> PickupDropLocations { get; set; }

    }
}
