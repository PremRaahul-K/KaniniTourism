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

        public async Task<BookingDTO?> UpdateCapacity(ValidateBookingDTO validateBooking)
        {
            try
            {
                var tour = await _tourRepo.Get(validateBooking.dateId);
                if (tour != null)
                {
                    var availableBookingSlots = tour.Capacity - tour.BookedCapacity;
                    if (availableBookingSlots > 0 && availableBookingSlots >= validateBooking.travellerCount)
                    {
                        tour.BookedCapacity = tour.BookedCapacity + validateBooking.travellerCount;
                        await _tourRepo.Update(tour);
                        return new BookingDTO { validationStatus = "Booking capacity Updated" };
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating booking capacity.");
            }
            return null;
        }

        public async Task<BookingDTO?> ValidateBooking(ValidateBookingDTO validateBooking)
        {
            try
            {
                var tours = await _tourRepo.GetAll();
                if (tours != null)
                {
                    var tour = tours.FirstOrDefault(t => t.DateId == validateBooking.dateId);
                    if (tour != null)
                    {
                        var availableBookingSlots = tour.Capacity - tour.BookedCapacity;
                        if (availableBookingSlots > 0 && availableBookingSlots >= validateBooking.travellerCount)
                        {
                            return new BookingDTO { validationStatus = "approved" };
                        }
                        return new BookingDTO { validationStatus = "not approved" };
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while validating booking.");
            }
            return null;
        }
    }
}
