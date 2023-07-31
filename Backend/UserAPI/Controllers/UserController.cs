using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Interfaces;
using UserAPI.Models.DTOs;
using UserAPI.Services;

namespace UserAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("ReactCors")]
    public class UserController : ControllerBase
    {
        private readonly IManageUser _userService;

        public UserController(IManageUser userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [ProducesResponseType(typeof(UserResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserResponseDTO>> Login(UserRequestDTO userDTO)
        {
            var userResponseDTO = await _userService.Login(userDTO);
            if (userResponseDTO == null)
            {
                return BadRequest("invalid username or password");
            }
            return Ok(userResponseDTO);
        }
    }
}
