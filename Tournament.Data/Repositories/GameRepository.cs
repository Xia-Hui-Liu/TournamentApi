
using Bogus.DataSets;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Tournament.Core.Dto.GameDtos;
using Tournament.Core.Entities;
using Tournament.Core.Repositories;
using Tournament.Data.Data;

namespace Tournament.Data.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly TournamentApiContext _context;

        public GameRepository(TournamentApiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Game>> GetAllAsync(Guid tourId)
        {
            var tour = await _context.Tour
                .Include(t => t.Games)
                .ThenInclude(g = g => g.Games)
                .FirstOrDefaultAsync(t => t.Id == tourId);

            //if (tour is null)
            //{
            //    // Return an empty collection if the specified tour is not found
            //    return Enumerable.Empty<Game>();
            //}

            return tour.Games!;
        }





        public async Task<Game> GetAsync(Guid id)
        {

            var game = await _context.Game
                                     .Where(t => t.Id == id)
                                     .FirstOrDefaultAsync();
            return game!;
        }


        public Task<bool> AnyAsync(Guid id)
        {
            return _context.Game.AnyAsync(t => t.Id == id);
        }

        public void Add(Game game)
        {
          
          _context.Game.Add(game);
            
        }

        public void Update(Game game)
        {
            // Mark the entire entity as modified
            _context.Entry(game).State = EntityState.Modified;

            // Save the changes
            _context.SaveChanges();
        }

        public void Remove(Game game)
        {
            // Mark the entire entity as deleted
            _context.Entry(game).State = EntityState.Deleted;

            // Save the changes
            _context.SaveChanges();
        }

    }
}
