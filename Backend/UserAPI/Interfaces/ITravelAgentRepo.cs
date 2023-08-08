using UserAPI.Models;
using UserAPI.Models.DTOs;

namespace UserAPI.Interfaces
{
    public interface ITravelAgentRepo
    {
        public Task<UserResponseDTO?> RegisterTravelAgent(UserDTO user);
        public Task<TravelAgentDTO?> GetTravelAgent(int travelAgentId);
        public Task<ICollection<TravelAgentDTO>?> GetTravelAgents();
        public Task<TravelAgentDTO?> UpdateTravelAgent(TravelAgentUpdateDTO  travelAgentUpdateDTO);
        public Task<TravelAgentDTO?> UpdateTravelAgentStatus(Models.DTOs.TravelAgentUpdateStatusDTO travelAgentDTO);
        public Task<TravelAgentDTO?> DeleteTravelAgent(int travelAgentId);
    }
}
