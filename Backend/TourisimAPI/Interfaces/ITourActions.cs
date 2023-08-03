using TourismAPI.Models;

namespace TourismAPI.Interfaces
{
    public interface ITourActions
    {
        public Task<Tour?> AddTour(Tour tour);
        public Task<Tour?> DeleteTour(int id);
        public Task<Tour?> GetTour(int id);
        public Task<List<Tour>?> GetAllTour();
        public Task<Tour?> UpdateTour(Tour tour);
    }
}
