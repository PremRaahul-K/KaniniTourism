using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TourismAPI.Interfaces;
using TourismAPI.Models;
using TourismAPI.Models.Context;
#nullable disable

namespace TourismAPI.Services
{
    public class TourRepo : IRepo<int, Tour>
    {
        private readonly TourismContext _context;
        private readonly ILogger<TourRepo> _logger;

        public TourRepo(TourismContext context, ILogger<TourRepo> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Tour?> Add(Tour item)
        {
            try
            {
                await _context.Tours.AddAsync(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Tour?> Delete(Tour item)
        {
            try
            {
                var booking = await Get(item.TourId);
                if (booking != null)
                {
                    _context.Tours.Remove(booking);
                    await _context.SaveChangesAsync();
                    return booking;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Tour?> Get(int key)
        {
            try
            {
                if (_context != null && _context.Tours != null && _context.TourItineraries != null && _context.Itineraries != null && _context.Hotel != null)
                {
                    return await _context.Tours.Include(t => t.Highlight).Include(t => t.Inclusion).Include(t => t.Exclusion).Include(t => t.TourItinerary).ThenInclude(ti => ti.Itineraries).Include(t => t.TourItinerary).ThenInclude(ti => ti.Accommodation).Include(t => t.TourDates).Include(t => t.PickupLocation).FirstOrDefaultAsync(t => t.TourId == key);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<List<Tour>?> GetAll()
        {
            try
            {
                return await _context.Tours.Include(t => t.Highlight).Include(t => t.Inclusion).Include(t => t.Exclusion).Include(t => t.TourItinerary).ThenInclude(ti => ti.Itineraries).Include(t => t.TourItinerary).ThenInclude(ti => ti.Accommodation).Include(t => t.TourDates).Include(t => t.PickupLocation).ToListAsync();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Tour?> Update(Tour item)
        {
            try
            {
                _context.Tours.Update(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }
    }
}
