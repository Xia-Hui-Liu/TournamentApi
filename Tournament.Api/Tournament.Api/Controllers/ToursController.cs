
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tournament.Data.Data;
using Tournament.Core.Entities;
using Tournament.Core.Repositories;
using Bogus.DataSets;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using NuGet.Protocol;
using Tournament.Core.Dto.TourDtos;
using Tournament.Core.Services;
using Tournament.Data.Services;
using Humanizer;

namespace Tournament.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToursController : ControllerBase
    {

        private readonly IServiceManager _serviceManager;

        // Constructor for ToursController, injecting IUoW and IMapper
        public ToursController(IServiceManager serviceManager)
        {

            _serviceManager = serviceManager;
        }

        // GET: api/Tours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TourDto>>> GetTours(bool includeGames = false)
        {
            return Ok(await _serviceManager.TourService.GetAllAsync(includeGames));
        }


        // GET: api/Tours/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TourDto>> GetTour(Guid id)
        {
            return Ok(await _serviceManager.TourService.GetAsync(id));
        }



        // PUT: api/Tours/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTour(Guid id, TourForUpdateDto dto)
        {
            if (id != dto.Id) return BadRequest(); 
            await _serviceManager.TourService.UpdateAsync(id, dto);
            return NoContent();

        }

        // POST: api/Tours
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tour>> PostTour(TourForCreationDto dto)
        {
            var tourToReturn = await _serviceManager.TourService.PostAsync(dto);
            return CreatedAtAction(nameof(GetTour), new { id = tourToReturn.Id }, tourToReturn);
        }

        // DELETE: api/Tours/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTour(Guid id)
        {
            // retrieve the tour we want to delete by id
            await _serviceManager.TourService.DeleteAsync(id);

            return NoContent();
        }


    }
}
