using TourismAPI.Models.DTOs;
using TourismAPI.Models;

namespace TourismAPI.Interfaces
{
    public interface ITourDateActions
    {
        public Task<BookingDTO?> ValidateBooking(ValidateBookingDTO validateBooking);
        public Task<BookingDTO?> UpdateCapacity(ValidateBookingDTO validateBooking);

    }
}
