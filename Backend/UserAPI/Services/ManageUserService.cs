using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using UserAPI.Interfaces;
using UserAPI.Models;
using UserAPI.Models.DTOs;

namespace UserAPI.Services
{
    public class ManageUserService : IManageUser
    {
        private readonly IRepo<int, User> _userRepo;
        private readonly ITokenGenerate _tokenService;

        public ManageUserService(IRepo<int,User> userRepo,ITokenGenerate tokenService)
        {
            _userRepo = userRepo;   
            _tokenService = tokenService;
        }
        public async Task<UserResponseDTO?> Login(UserRequestDTO userRequestDTO)
        {
            var users = await _userRepo.GetAll();
            if (users!=null)
            {
                var user = users.FirstOrDefault(u => u.Email == userRequestDTO.Email);
                if (user != null && userRequestDTO.Password != null && user.PasswordHash != null && user.PasswordKey != null)
                {
                    var hmac = new HMACSHA512(user.PasswordKey);
                    var userpass = hmac.ComputeHash(Encoding.UTF8.GetBytes(userRequestDTO.Password));
                    for (int i = 0; i < userpass.Length; i++)
                    {
                        if (userpass[i] != user.PasswordHash[i])
                            return null;
                    }
                    UserResponseDTO returnUser = new UserResponseDTO();
                    returnUser.Email = user.Email;
                    returnUser.Role = user.Role;
                    returnUser.Id = user.Id;
                    if (user.Role != "travelagent")
                    {
                        returnUser.Token = await _tokenService.GenerateToken(user);
                        return returnUser;
                    }
                    if (user.Role?.ToLower() == "travelagent" && user.UserDetail != null && user.UserDetail.TravelAgent != null && user.UserDetail.TravelAgent.Status == "Not Approved")
                    {
                        return returnUser;
                    }
                    returnUser.Token = await _tokenService.GenerateToken(user);
                    return returnUser;
                }
            }
            return null;
        }
    }
}
