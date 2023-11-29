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


        public async Task<IEnumerable<Tour>> GetAllAsync()
        {

            return await _context.Tour.Include(t => t.Games).ToListAsync();

        }


        public async Task<Tour> GetAsync(int id)
        {
            var tour = await _context.Tour
                                     .Include(t => t.Games)
                                     .Where(t =>  t.Id == id)
                                     .FirstOrDefaultAsync();

            return tour!;
        }


        public Task<bool> AnyAsync(int id)
        {
            return _context.Tour.AnyAsync(t => t.Id == id);
        }

        public void Add(Tour tour)
        {
            _context.Tour.Add(tour);
            _context.SaveChanges();
        }

        public void Update(Tour tour)
        {
            // Mark the entire entity as modified
            _context.Entry(tour).State = EntityState.Modified;

            // Save the changes
            _context.SaveChanges();
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

