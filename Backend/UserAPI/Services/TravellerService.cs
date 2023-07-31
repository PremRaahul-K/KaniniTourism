using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using UserAPI.Interfaces;
using UserAPI.Models;
using UserAPI.Models.DTOs;

namespace UserAPI.Services
{
    public class TravellerService:ITravellerRepo
    {
        private readonly IRepo<int, User> _user;
        private readonly ITokenGenerate _tokenService;

        public TravellerService(IRepo<int, User> user, ITokenGenerate tokenService)
        {
            _user = user;
            _tokenService = tokenService;
        }

        public async Task<TravellerDTO?> DeleteTraveller(int travellerId)
        {
            var user = await _user.Get(travellerId);
            if (user != null && user.Role == "Traveller" && user.UserDetail != null && user.Email != null && user.UserDetail.Traveller != null)
            {
                var deletedUser = await _user.Delete(user);
                if (deletedUser != null)
                {
                    return new TravellerDTO(user.UserDetail,user.Email);
                }
            }
            return null;
        }

        public async Task<TravellerDTO?> GetTraveller(int travellerId)
        {
            var user = await _user.Get(travellerId);
            if (user != null && user.Role == "Traveller" && user.UserDetail!=null && user.Email!=null && user.UserDetail.Traveller!=null)
            {
                return new TravellerDTO(user.UserDetail,user.Email);
            }
            return null;
        }

        public async Task<ICollection<TravellerDTO>?> GetTravellers()
        {
            var users = await _user.GetAll();
            if (users != null)
            {
                return users.Where(u=>u.Role== "Traveller" && u.UserDetail!=null).Select(u=>new TravellerDTO(u.UserDetail,u.Email)).ToList();
            }
            return null;
        }

        public async Task<UserResponseDTO?> RegisterTraveller(UserDTO user)
        {
            UserResponseDTO? responseUser = null;
            var hmac = new HMACSHA512();
            if (user.PasswordClear != null)
            {
                if (user != null)
                {
                    user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.PasswordClear));
                    user.PasswordKey = hmac.Key;
                    user.Role = "Traveller";
                }
                var addedTraveller = await _user.Add(user);
                if (addedTraveller != null)
                {
                    responseUser = new UserResponseDTO
                    {
                        Id = addedTraveller.Id,
                        Role = addedTraveller.Role,
                        Email = addedTraveller.Email,
                        Token = await _tokenService.GenerateToken(addedTraveller)
                    };
                    return responseUser;
                }
            }
            return null;
        }

        public async Task<TravellerDTO?> UpdateTraveller(TravellerUpdateDTO travellerDTO)
        {
            var user = await _user.Get(travellerDTO.UserId);
            if (user != null && user.UserDetail!=null && user.UserDetail.Traveller!=null) 
            {
                user.UserDetail.FirstName = travellerDTO.FirstName;
                user.UserDetail.LastName  = travellerDTO.LastName;
                user.UserDetail.PhoneNumber = travellerDTO.PhoneNumber;
                user.UserDetail.DateOfBirth = travellerDTO.DateOfBirth;
                user.UserDetail.Address = travellerDTO.Address;
                user.UserDetail.Gender = travellerDTO.Gender;
                user.UserDetail.Nationality = travellerDTO.Nationality;
                await _user.Update(user);
                return new TravellerDTO(user.UserDetail,user.Email);
            }
            return null;
        }
    }
}
