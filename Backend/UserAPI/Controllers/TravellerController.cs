using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Numerics;
using UserAPI.Interfaces;
using UserAPI.Models.DTOs;

namespace UserAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TravellerController : ControllerBase
    {
        private readonly ITravellerRepo _travellerService;

        public TravellerController(ITravellerRepo travellerService)
        {
            _travellerService = travellerService;
        }
        [HttpPost]
        [ProducesResponseType(typeof(UserResponseDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserResponseDTO>> TravellerRegister(UserDTO userDTO)
        {
            var userResponseDTO = await _travellerService.RegisterTraveller(userDTO);
            if (userResponseDTO == null)
            {
                return BadRequest("Unable to register");
            }
            return Created("Home", userResponseDTO);
        }
        [HttpPost]
        [ProducesResponseType(typeof(ActionResult<TravellerDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TravellerDTO>> GetTraveller(int id)
        {
            var traveller = await _travellerService.GetTraveller(id);
            if (traveller == null)
            {
                return NotFound("No traveller are available at the moment");
            }
            return Ok(traveller);
        }
        [HttpGet]
        [ProducesResponseType(typeof(ActionResult<ICollection<TravellerDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<TravellerDTO>>> GetAllTravellers()
        {
            var travellers = await _travellerService.GetTravellers();
            if (travellers == null)
            {
                return NotFound("No traveller are available at the moment");
            }
            return Ok(travellers);
        }
        [HttpPut]
        [ProducesResponseType(typeof(ActionResult<TravellerDTO>), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TravellerDTO>> Update(TravellerUpdateDTO travellerUpdateDTO)
        {
            var traveller = await _travellerService.UpdateTraveller(travellerUpdateDTO);
            if (traveller != null)
            {
                return Ok(traveller);
            }
            return BadRequest("Unable to update traveller details");
        }
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ActionResult<TravellerDTO>), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TravellerDTO>> Delete(int id)
        {
            var traveller = await _travellerService.DeleteTraveller(id);
            if (traveller != null)
            {
                return Ok(traveller);
            }
            return BadRequest("Unable to Delete traveller details");
        }
    }
}
