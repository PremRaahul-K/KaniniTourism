using System.Security.Cryptography;
using System.Text;
using UserAPI.Interfaces;
using UserAPI.Models;
using UserAPI.Models.DTOs;

namespace UserAPI.Services
{
    public class TravelAgentService : ITravelAgentRepo
    {
        private readonly IRepo<int, User> _user;
        private readonly ITokenGenerate _tokenService;

        public TravelAgentService(IRepo<int, User> user, ITokenGenerate tokenService)
        {
            _user = user;
            _tokenService = tokenService;
        }
        public async Task<TravelAgentDTO?> DeleteTravelAgent(int travelAgentId)
        {
            var user = await _user.Get(travelAgentId);
            if (user != null && user.Role == "TravelAgent" && user.UserDetail != null && user.Email != null && user.UserDetail.TravelAgent != null)
            {
                var deletedUser = await _user.Delete(user);
                if (deletedUser != null)
                {
                    return new TravelAgentDTO(user.UserDetail, user.Email);
                }
            }
            return null;
        }

        public async Task<TravelAgentDTO?> GetTravelAgent(int travelAgentId)
        {
            var user = await _user.Get(travelAgentId);
            if (user != null && user.Role == "TravelAgent" && user.UserDetail != null && user.Email != null && user.UserDetail.TravelAgent != null)
            {
                return new TravelAgentDTO(user.UserDetail, user.Email);
            }
            return null;
        }

        public async Task<ICollection<TravelAgentDTO>?> GetTravelAgents()
        {
            var users = await _user.GetAll();
            if (users != null)
            {
                return users.Where(u => u.Role == "TravelAgent" && u.UserDetail != null).Select(u => new TravelAgentDTO(u.UserDetail, u.Email)).ToList();
            }
            return null;
        }

        public async Task<UserResponseDTO?> RegisterTravelAgent(UserDTO user)
        {
            UserResponseDTO? responseUser = null;
            var hmac = new HMACSHA512();
            if (user.PasswordClear != null)
            {
                if (user != null  && user.UserDetail!=null && user.UserDetail.TravelAgent!=null)
                {
                    user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.PasswordClear));
                    user.PasswordKey = hmac.Key;
                    user.Role = "TravelAgent";
                    user.UserDetail.TravelAgent.Status = "Not Approved";
                }
                var addedTravelAgent = await _user.Add(user);
                if (addedTravelAgent != null)
                {
                    responseUser = new UserResponseDTO
                    {
                        Id = addedTravelAgent.Id,
                        Role = addedTravelAgent.Role,
                        Email = addedTravelAgent.Email,
                    };
                    return responseUser;
                }
            }
            return null;
        }

        public async Task<TravelAgentDTO?> UpdateTravelAgent(TravelAgentUpdateDTO travelAgentUpdateDTO)
        {
            var user = await _user.Get(travelAgentUpdateDTO.UserId);
            if (user != null && user.UserDetail != null && user.UserDetail.TravelAgent != null)
            {
                user.UserDetail.FirstName = travelAgentUpdateDTO.FirstName;
                user.UserDetail.LastName = travelAgentUpdateDTO.LastName;
                user.UserDetail.PhoneNumber = travelAgentUpdateDTO.PhoneNumber;
                user.UserDetail.DateOfBirth = travelAgentUpdateDTO.DateOfBirth;
                user.UserDetail.Address = travelAgentUpdateDTO.Address;
                user.UserDetail.Gender = travelAgentUpdateDTO.Gender;
                user.UserDetail.Nationality = travelAgentUpdateDTO.Nationality;
                user.UserDetail.TravelAgent.AgencyName = travelAgentUpdateDTO.AgencyName;
                user.UserDetail.TravelAgent.Status = travelAgentUpdateDTO.Status;
                await _user.Update(user);
                return new TravelAgentDTO(user.UserDetail, user.Email);
            }
            return null;
        }

        public async Task<TravelAgentDTO?> UpdateTravelAgentStatus(Models.DTOs.TravelAgentUpdateStatusDTO travelAgentDTO)
        {
            var user = await _user.Get(travelAgentDTO.UserId);
            if (user != null && user.UserDetail != null && user.UserDetail.TravelAgent != null)
            {
                user.UserDetail.TravelAgent.Status = travelAgentDTO.Status;
                await _user.Update( user );
                return new TravelAgentDTO(user.UserDetail, user.Email);
            }
            return null;
        }
    }
}
