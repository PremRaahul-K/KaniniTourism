using UserAPI.Models;
using UserAPI.Models.DTOs;

namespace UserAPI.Interfaces
{
    public interface ITravellerRepo
    {
        public Task<UserResponseDTO?> RegisterTraveller(UserDTO user);
        public Task<TravellerDTO?> GetTraveller(int travellerId);
        public Task<ICollection<TravellerDTO>?> GetTravellers();
        public Task<TravellerDTO?> UpdateTraveller(TravellerUpdateDTO travellerDTO);
        public Task<TravellerDTO?> DeleteTraveller(int travellerId);
    }
}
