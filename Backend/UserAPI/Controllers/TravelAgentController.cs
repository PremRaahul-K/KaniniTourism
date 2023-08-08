using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Interfaces;
using UserAPI.Models;
using UserAPI.Models.DTOs;

namespace UserAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TravelAgentController : ControllerBase
    {
        private readonly ITravelAgentRepo _travelAgentService;

        public TravelAgentController(ITravelAgentRepo travelAgentService)
        {
            _travelAgentService = travelAgentService;
        }
        [HttpPost]
        [ProducesResponseType(typeof(UserResponseDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserResponseDTO>> TravelAgentRegister(UserDTO userDTO)
        {
            var userResponseDTO = await _travelAgentService.RegisterTravelAgent(userDTO);
            if (userResponseDTO == null)
            {
                return BadRequest("Unable to register");
            }
            return Created("Home", userResponseDTO);
        }
        [HttpPost]
        [ProducesResponseType(typeof(ActionResult<TravelAgentDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TravelAgentDTO>> GetTravelAgent(int id)
        {
            var travelAgent = await _travelAgentService.GetTravelAgent(id);
            if (travelAgent == null)
            {
                return NotFound("No travel Agent are available at the moment");
            }
            return Ok(travelAgent);
        }
        [HttpGet]
        [ProducesResponseType(typeof(ActionResult<ICollection<TravelAgentDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<TravelAgentDTO>>> GetAllTravelAgents()
        {
            var travelAgents = await _travelAgentService.GetTravelAgents();
            if (travelAgents == null)
            {
                return NotFound("No travel Agents are available at the moment");
            }
            return Ok(travelAgents);
        }
        [HttpPut]
        [ProducesResponseType(typeof(ActionResult<TravelAgentDTO>), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TravelAgentDTO>> UpdateTravelAgent(TravelAgentUpdateDTO travelAgentUpdateDTO)
        {
            var travelAgent = await _travelAgentService.UpdateTravelAgent(travelAgentUpdateDTO);
            if (travelAgent != null)
            {
                return Ok(travelAgent);
            }
            return BadRequest("Unable to update travel agent details");
        }
        [HttpPut]
        [ProducesResponseType(typeof(ActionResult<TravelAgentDTO>), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TravelAgentDTO>> UpdateTravelAgentStatus(TravelAgentUpdateStatusDTO travelAgentUpdateStatusDTO)
        {
            var travelAgent = await _travelAgentService.UpdateTravelAgentStatus(travelAgentUpdateStatusDTO);
            if (travelAgent != null)
            {
                return Ok(travelAgent);
            }
            return BadRequest("Unable to update travel agent details");
        }
        [HttpDelete]
        [ProducesResponseType(typeof(ActionResult<TravelAgentDTO>), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TravelAgentDTO>> DeleteTravelAgent(int id)
        {
            var travelAgent = await _travelAgentService.DeleteTravelAgent(id);
            if (travelAgent != null)
            {
                return Ok(travelAgent);
            }
            return BadRequest("Unable to Delete travel agent details");
        }
    }
}
