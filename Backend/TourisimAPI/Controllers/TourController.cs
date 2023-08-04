﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TourismAPI.Interfaces;
using TourismAPI.Models;

namespace TourismAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TourController : ControllerBase
    {
        private readonly ITourActions _tourService;

        public TourController(ITourActions tourService)
        {
            _tourService = tourService;
        }
        [HttpPost]
        [ProducesResponseType(typeof(Tour), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Tour>> AddTour(Tour tour)
        {
            var addedTour = await _tourService.AddTour(tour);
            if (addedTour == null)
            {
                return BadRequest("Unable to add tour");
            }
            return Created("Home", addedTour);
        }
        [HttpPost]
        [ProducesResponseType(typeof(ActionResult<Tour>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Tour>> GetTour(int id)
        {
            var tour = await _tourService.GetTour(id);
            if (tour == null)
            {
                return NotFound("No tour are available at the moment");
            }
            return Ok(tour);
        }
        [HttpGet]
        [ProducesResponseType(typeof(ActionResult<ICollection<Tour>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<Tour>>> GetAllTours()
        {
            var tours = await _tourService.GetAllTour();
            if (tours == null)
            {
                return NotFound("No tours are available at the moment");
            }
            return Ok(tours);
        }
        [HttpPut]
        [ProducesResponseType(typeof(ActionResult<Tour>), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Tour>> UpdateTour(Tour tour)
        {
            var updatedTour = await _tourService.UpdateTour(tour);
            if (updatedTour != null)
            {
                return Ok(updatedTour);
            }
            return BadRequest("Unable to update tour details");
        }

        [HttpDelete]
        [ProducesResponseType(typeof(ActionResult<Tour>), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Tour>> DeleteTour(int id)
        {
            var tour = await _tourService.DeleteTour(id);
            if (tour != null)
            {
                return Ok(tour);
            }
            return BadRequest("Unable to Delete tour details");
        }
    }
}