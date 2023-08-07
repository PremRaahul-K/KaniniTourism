using TourismAPI.Interfaces;
using TourismAPI.Models;
using TourismAPI.Models.DTOs;

namespace TourismAPI.Services
{
    public class TourDateService : ITourDateActions
    {
        private readonly IRepo<int, TourDate> _tourRepo;
        private readonly ILogger<TourDateService> _logger;

        public TourDateService(IRepo<int, TourDate> dateRepo, ILogger<TourDateService> logger)
        {
            _tourRepo = dateRepo;
            _logger = logger;
        }
        public async Task<BookingDTO?> ValidateBooking(ValidateBookingDTO validateBooking)
        {
            var tours = await _tourRepo.GetAll();
            if (tours != null)
            {
                var tour = tours.FirstOrDefault(t=>t.DateId==validateBooking.dateId);
                if (tour != null)
                {
                    var availableBookingSlots = tour.Capacity - tour.BookedCapacity;
                    if (availableBookingSlots > 0 && availableBookingSlots>=validateBooking.travellerCount)
                    {
                        return new BookingDTO { validationStatus = "approved" };
                    }
                    return new BookingDTO { validationStatus = "not approved" };
                }
            }
            return null;   
        }
    }
}
