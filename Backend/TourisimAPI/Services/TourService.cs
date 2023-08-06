using TourismAPI.Interfaces;
using TourismAPI.Models;

namespace TourismAPI.Services
{
    public class TourService : ITourActions
    {
        private readonly IRepo<int, Tour> _tourRepo;
        private readonly ILogger<TourService> _logger;

        public TourService(IRepo<int, Tour> tourRepo, ILogger<TourService> logger)
        {
            _tourRepo = tourRepo;
            _logger = logger;
        }
        public async Task<Tour?> AddTour(Tour tour)
        {
            try
            {
                await _tourRepo.Add(tour);
                return tour;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Tour?> DeleteTour(int id)
        {
            try
            {
                var tour = await GetTour(id);
                if (tour != null)
                {
                    await _tourRepo.Delete(tour);
                    return tour;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<List<Tour>?> GetAllTour()
        {
            try
            {
                var tours = await _tourRepo.GetAll();
                if (tours != null)
                {
                    return tours;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Tour?> GetTour(int id)
        {
            try
            {
                var tour = await _tourRepo.Get(id);
                if (tour != null)
                {
                    return tour;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Tour?> UpdateTour(Tour tour)
        {
            try
            {
                var updatingTour = await _tourRepo.Get(tour.TourId);
                if (updatingTour != null)
                {
                    updatingTour.TourId = tour.TourId;
                    updatingTour.TravelAgentId = tour.TravelAgentId;
                    updatingTour.Name = tour.Name;
                    updatingTour.Description = tour.Description;
                    updatingTour.TourType = tour.TourType;
                    updatingTour.Price = tour.Price;
                    updatingTour.Price = tour.Price;
                    updatingTour.FoodAccommodation = tour.FoodAccommodation;
                    updatingTour.PickupLocation = tour.PickupLocation;
                    updatingTour.TourDates = tour.TourDates;
                    updatingTour.TourItinerary = tour.TourItinerary;
                    updatingTour.Highlight = tour.Highlight;
                    updatingTour.Inclusion = tour.Inclusion;
                    updatingTour.Exclusion = tour.Exclusion;    
                    return tour;
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
