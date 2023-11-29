﻿
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tournament.Data.Data;
using Tournament.Core.Entities;
using Tournament.Core.Repositories;
using Bogus.DataSets;

namespace Tournament.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToursController : ControllerBase
    {
       
        private readonly IUoW _unitOfWork;
        public ToursController(IUoW unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Tours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tour>>> GetTour()
        {
            var tours = await _unitOfWork.TourRepository.GetAllAsync();


            return Ok(tours);
        }

        // GET: api/Tours/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tour>> GetTour(int id)
        {
            var tour = await _unitOfWork.TourRepository.GetAsync(id);

            if (tour == null)
            {
                return NotFound();
            }

            return Ok(tour);
        }


        // PUT: api/Tours/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTour(int id, Tour tour)
        {
            if (id != tour.Id)
            {
                return BadRequest();
            }

            _unitOfWork.TourRepository.Update(tour);

            return NoContent();
        }

        // POST: api/Tours
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tour>> PostTour(Tour tour)
        {
            _unitOfWork.TourRepository.Add(tour);
           
            return CreatedAtAction("GetTour", new { id = tour.Id }, tour);
        }

        // DELETE: api/Tours/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTour(int id)
        {
            var tour = await _unitOfWork.TourRepository.GetAsync(id);

            if (tour == null)
            {
                return NotFound();
            }

            _unitOfWork.TourRepository.Remove(tour);

            return NoContent();
        }


        // GET: api/Games/Exists/5
        [HttpGet("Exists/{id}")]
        public async Task<ActionResult<bool>> TourExists(int id)
        {
            var exists = await _unitOfWork.TourRepository.AnyAsync(id);
            return Ok(exists);
        }
    }
}