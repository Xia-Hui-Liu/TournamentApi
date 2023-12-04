
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

namespace Tournament.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToursController : ControllerBase
    {

        private readonly IUoW _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IServiceManager _serviceManager;

        // Constructor for ToursController, injecting IUoW and IMapper
        public ToursController(IUoW unitOfWork, IMapper mapper, IServiceManager serviceManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _serviceManager = serviceManager;
        }

        // GET: api/Tours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TourDto>>> GetTours(bool includeGames = false)
        {
            return Ok(await _serviceManager.TourService.GetAllAsync(includeGames));
            //// Retrieve tours from the repository based on the includeGames parameter
            //var dto = includeGames
            //    ? _mapper.Map<IEnumerable<TourDto>>(await _unitOfWork.TourRepository.GetAllAsync(includeGames: true))
            //    : _mapper.Map<IEnumerable<TourDto>>(await _unitOfWork.TourRepository.GetAllAsync());

            //// Return the mapped TourDto as Ok result
            //return Ok(dto);
        }


        // GET: api/Tours/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TourDto>> GetTour(Guid id)
        {
            // Retrieve the tour from the repository 
            Tour? tour = await _unitOfWork.TourRepository.GetAsync(id);

            // Check if the tour was not found
            if (tour == null)
            {
                return NotFound(); // Return 404 Not Found if the tour is not found
            }


            // Map the Tour entity to a TourDto and return it as Ok result
            return Ok(_mapper.Map<TourDto>(tour));
        }



        // PUT: api/Tours/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTour(Guid id, TourForUpdateDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            var existingTour = await _unitOfWork.TourRepository.GetAsync(id);
            
            if (existingTour == null) return NotFound();

            // Update the existing tour with values from the DTO
            _mapper.Map(dto, existingTour);

            // Save changes to db
            await _unitOfWork.CompleteAsync();

            return NoContent();
           
        }

        // POST: api/Tours
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tour>> PostTour(TourForCreationDto tour)
        {
            // Map the DTO to the actual entity type (Tour) using AutoMapper
            var tourEntity = _mapper.Map<Tour>(tour);

            // Add the new tour entity to the repository
            _unitOfWork.TourRepository.Add(tourEntity);
            // Save changes to persist the new entity to the database
            await _unitOfWork.CompleteAsync();

            // Return the created tour DTO with a 201 CreatedAtAction response
            var tourToReturn = _mapper.Map<TourDto>(tourEntity);
            return CreatedAtAction("GetTour", new { id = tourEntity.Id }, tourToReturn);
        }

        // DELETE: api/Tours/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTour(Guid id)
        {
            // retrieve the tour we want to delete by id
            var tour = await _unitOfWork.TourRepository.GetAsync(id);

            if (tour == null)
            {
                return NotFound();
            }
            // if exist remove it from the database
            _unitOfWork.TourRepository.Remove(tour);
            // save changes to the databas
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }


        // GET: api/Games/Exists/5
        [HttpGet("Exists/{id}")]
        public async Task<ActionResult<bool>> TourExists(Guid id)
        {
            var exists = await _unitOfWork.TourRepository.AnyAsync(id);
            return Ok(exists);
        }
    }
}
