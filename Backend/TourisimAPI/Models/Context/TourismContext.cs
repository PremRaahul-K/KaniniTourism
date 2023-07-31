using Microsoft.EntityFrameworkCore;

namespace TourismAPI.Models.Context
{
    public class TourismContext:DbContext
    {
        public TourismContext(DbContextOptions<TourismContext> options):base(options)
        {
            
        }
    }
}
