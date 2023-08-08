﻿using BookingAPI.Interfaces;
using BookingAPI.Models;
using BookingAPI.Models.DTOs;

namespace BookingAPI.Services
{
    public class ManageBookingService : IBookingRepo
    {
        private readonly IRepo<int, Booking> _bookingRepo;
        private readonly ILogger<ManageBookingService> _logger;

        public ManageBookingService(IRepo<int, Booking> bookingRepo, ILogger<ManageBookingService> logger)
        {
            _bookingRepo = bookingRepo;
            _logger = logger;
        }
        public async Task<Booking?> AddBooking(Booking booking)
        {
            try
            {
                await _bookingRepo.Add(booking);
                return booking;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Booking?> DeleteBooking(int id)
        {
            try
            {
                var booking = await GetBooking(id);
                if (booking != null)
                {
                    await _bookingRepo.Delete(booking);
                    return booking;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<List<Booking>?> GetAllBooking()
        {
            try
            {
                var bookings = await _bookingRepo.GetAll();
                if (bookings != null)
                {
                    return bookings;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Booking?> GetBooking(int id)
        {
            try
            {
                var booking = await _bookingRepo.Get(id);
                if (booking != null)
                {
                    return booking;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<ICollection<Booking>?> GetBookingWithUserId(UserIdDTO userIdDTO)
        {
            try
            {
                var bookings = await _bookingRepo.GetAll();
                if (bookings != null)
                {
                    return bookings.Where(b=>b.UserId==userIdDTO.UserId).ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Booking?> UpdateBooking(Booking booking)
        {
            try
            {
                var updatingBooking = await _bookingRepo.Get(booking.BookingId);
                if (updatingBooking != null)
                {
                    updatingBooking.BookingId = booking.BookingId;
                    updatingBooking.BookingDate = booking.BookingDate;
                    updatingBooking.BookingStatus = booking.BookingStatus;
                    updatingBooking.UserId = booking.UserId;
                    updatingBooking.TourId = booking.TourId;
                    updatingBooking.PhoneNumber = booking.PhoneNumber;
                    updatingBooking.ContactEmail = booking.ContactEmail;
                    updatingBooking.ContactName = booking.ContactName;
                    updatingBooking.TotalPrice = booking.TotalPrice;
                    updatingBooking.PickUpLocation = booking.PickUpLocation;
                    await _bookingRepo.Update(updatingBooking);
                    return booking;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Booking?> UpdateBookingStatus(BookingDTO bookingDTO)
        {
            try
            {
                var updatingBooking = await _bookingRepo.Get(bookingDTO.BookingId);
                if (updatingBooking != null)
                {
                    updatingBooking.BookingStatus = bookingDTO.BookingStatus;
                    var updatedBooking = await _bookingRepo.Update(updatingBooking);
                    return updatedBooking;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }
    }
}
