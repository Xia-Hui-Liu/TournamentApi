using Bogus.DataSets;
using Microsoft.EntityFrameworkCore;

using Tournament.Core.Entities;
using Tournament.Core.Repositories;
using Tournament.Data.Data;


namespace Tournament.Data.Repositories
{
    public class TourRepository : ITourRepository
    {

        private readonly TournamentApiContext _context;

        public TourRepository(TournamentApiContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Tour>> GetAllAsync(bool includeGames = false)
        {
            return includeGames? await _context.Tour
                                .Include(t => t.Games)
                                .ToListAsync()
                                :await _context.Tour .ToListAsync();
        }


        public async Task<Tour> GetAsync(Guid id)
        {
            var tour = await _context.Tour
                               .Where(t => t.Id == id)
                               .FirstOrDefaultAsync();

            return tour!;
        }


        public Task<bool> AnyAsync(Guid id)
        {
            return _context.Tour.AnyAsync(t => t.Id == id);
        }

        public void Add(Tour tour)
        {
            _context.Tour.Add(tour);
        }

        public void Update (Tour tour)
        {
            _context.Tour.Update(tour);
        }

        public void Remove(Tour tour)
        {
            // Mark the entire entity as deleted
            _context.Entry(tour).State = EntityState.Deleted;

            // Save the changes
            _context.SaveChanges();
        }

    }
}

