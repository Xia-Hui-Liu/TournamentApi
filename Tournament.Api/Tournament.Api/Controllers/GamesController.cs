
using AutoMapper;
using Humanizer;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Tournament.Core.Dto.GameDtos;
using Tournament.Core.Entities;
using Tournament.Core.Repositories;
using Tournament.Core.Services;

namespace Tournament.Api.Controllers
{
    [Route("api/tours/{tourId:guid}/games")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IUoW _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IServiceManager _serviceManager;
        public GamesController(IUoW unitOfWork, IMapper mapper, IServiceManager serviceManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _serviceManager = serviceManager;
        }

        // GET: api/games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameDto>>> GetGamesAsync(Guid id)
        {
            return Ok(await _serviceManager.GameService.GetAllAsync(id));
        }



        // GET: api/Games/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameDto>> GetGameAsync(Guid id)
        {
            return Ok(await _serviceManager.GameService.GetAsync(id));
        }

        // PUT: api/Games/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame(Guid id, GameForUpdateDto gameDto)
        {

            if (id != gameDto.Id) return BadRequest();
            await _serviceManager.GameService.UpdateAsync(id, gameDto);
            return NoContent();
        }

        // POST: api/Games
        [HttpPost]
        public async Task<ActionResult<GameDto>> PostGame(GameForCreationDto game)
        {
            var createdGame = await _serviceManager.GameService.PostAsync(game);

            return CreatedAtAction(nameof(GetGameAsync), new { id = createdGame.Id }, createdGame);
        }


        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(Guid id)
        {
            // Retrieve the game with the specified ID from the repository
            var game = await _unitOfWork.GameRepository.GetAsync(id);

            // Check if the game exists
            if (game == null)
            {
                // If the game does not exist, return a 404 Not Found response
                return NotFound();
            }

            // Remove the game from the repository
            _unitOfWork.GameRepository.Remove(game);

            // Save changes to the database
            await _unitOfWork.CompleteAsync();

            // Return a 204 No Content response indicating successful deletion
            return NoContent();
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchGame(Guid id,  JsonPatchDocument<GameDto> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest();
            }

            var game = await _unitOfWork.GameRepository.GetAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            var gameDto = _mapper.Map<GameDto>(game);

            // Apply the patch document to the game DTO
            patchDocument.ApplyTo(gameDto, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Map the updated game DTO back to the entity
            _mapper.Map(gameDto, game);

            // Save changes to the database
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }


    }
}
