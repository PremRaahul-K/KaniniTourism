using UserAPI.Models.DTOs;

namespace UserAPI.Interfaces
{
    public interface IManageUser
    {
        public Task<UserResponseDTO?> Login(UserRequestDTO userRequestDTO);
    }
}
