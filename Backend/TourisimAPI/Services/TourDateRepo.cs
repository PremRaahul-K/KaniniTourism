using TourismAPI.Models.Context;
using TourismAPI.Models;
using TourismAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TourismAPI.Services
{
    public class TourDateRepo:IRepo<int,TourDate>
    {
        private readonly TourismContext _context;
        private readonly ILogger<TourDateRepo> _logger;

        public TourDateRepo(TourismContext context, ILogger<TourDateRepo> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<TourDate?> Add(TourDate item)
        {
            try
            {
                await _context.TourDates.AddAsync(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<TourDate?> Delete(TourDate item)
        {
            try
            {
                var date = await Get(item.DateId);
                if (date != null)
                {
                    _context.TourDates.Remove(date);
                    await _context.SaveChangesAsync();
                    return date;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<TourDate?> Get(int key)
        {
            try
            {
                if (_context != null && _context.TourDates != null)
                {
                    return await _context.TourDates.FirstOrDefaultAsync(t => t.DateId == key);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<List<TourDate>?> GetAll()
        {
            try
            {
                if (_context != null && _context.TourDates != null)
                {
                    return await _context.TourDates.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<TourDate?> Update(TourDate item)
        {
            try
            {
                _context.TourDates.Update(item);
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
