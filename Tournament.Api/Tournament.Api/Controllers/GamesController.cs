
using AutoMapper;
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

        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameDto>>> GetGamesAsync()
        {
            return Ok(await _serviceManager.GameService.GetAllAsync());
        }



        // GET: api/Games/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameDto>> GetGameAsync(Guid id)
        {
            // retrieve the game by id
            var game = await _unitOfWork.GameRepository.GetAsync(id);

            if (game == null)
            {
                return NotFound();
            }
            
            var gameDto = _mapper.Map<GameDto>(game);

            return Ok(gameDto);// return a 200 OK response with the retrieved game
        }

        // PUT: api/Games/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame(Guid id, GameForUpdateDto gameDto)
        {
            if (id != gameDto.Id)
            {
                return BadRequest();
            }
            // get the existing game from db
            var existingGame = await _unitOfWork.GameRepository.GetAsync(id);

            if (existingGame == null) return NotFound();

            // Update the existing tour with values from the DTO
            _mapper.Map(gameDto, existingGame);

            // Save changes to db
            await _unitOfWork.CompleteAsync();


            return NoContent();
        }

        // POST: api/Games
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GameDto>> PostGame(Guid tourId, GameDto game)
        {
            // Check if the specified tour exists
            if (!await _unitOfWork.TourRepository.AnyAsync(tourId))
            {
                // If the tour does not exist, return a 404 Not Found response
                return NotFound();
            }

            // Map the GameDto to a Game entity using AutoMapper
            var finalGame = _mapper.Map<Game>(game);

            // Add the game to the repository, associating it with the specified tour
            _unitOfWork.GameRepository.Add(tourId, finalGame);

            // Save changes to the database
            await _unitOfWork.CompleteAsync();

            // Map the final Game entity back to a GameDto for the response
            var createGameToReturn = _mapper.Map<GameDto>(finalGame);

            // Return a 201 Created response with the URL of the newly created game
            return CreatedAtRoute("GetGame",
                new
                {
                    tourId,
                    gameId = createGameToReturn.Id
                }, createGameToReturn
            );
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
