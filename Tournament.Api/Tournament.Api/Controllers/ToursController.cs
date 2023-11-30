
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

namespace Tournament.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToursController : ControllerBase
    {
       
        private readonly IUoW _unitOfWork;
        private readonly IMapper _mapper;
        public ToursController(IUoW unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Tours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TourDto>>> GetTours(bool includeGames = false)
        {
            //var tour = await _unitOfWork.TourRepository.GetAllAsync();
            //var tourDtos = _mapper.Map<IEnumerable<TourWithoutGameDto>>(tour);

            //return Ok(tourDtos);
            var dto = includeGames ? _mapper.Map<IEnumerable<TourDto>>(await _unitOfWork.TourRepository.GetAllAsync(includeGames = true)) 
                                   : _mapper.Map<IEnumerable<TourDto>>(await _unitOfWork.TourRepository.GetAllAsync());
            return Ok(dto);
        }

        // GET: api/Tours/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TourDto>> GetTour(int id)
        {
            var tour = await _unitOfWork.TourRepository.GetAsync(id);
         
            if (tour == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TourDto>(tour));
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
        public async Task<ActionResult<TourForCreationDto>> PostTour(TourForCreationDto tour)
        {
            //if (TourExists() == false)
            //{
            //    return NotFound();
            //}

            var tourDtos = _mapper.Map<Tour>(tour);
            
            _unitOfWork.TourRepository.Add(tourDtos);

            return CreatedAtAction("GetTour", new { id = tourDtos.Id }, tourDtos);
        }

        // DELETE: api/Tours/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTour(int id, bool includeGames)
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
