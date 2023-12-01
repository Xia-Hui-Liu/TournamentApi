
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Tournament.Core.Repositories;
using Tournament.Data.Data;

namespace Tournament.Data.Repositories
{
    public class UoW : IUoW
    {
        public IGameRepository GameRepository { get; }
        public ITourRepository TourRepository { get; }

        private readonly TournamentApiContext _context;

        public UoW(
            IGameRepository gameRepository,
            ITourRepository tourRepository,
            TournamentApiContext context)
        {
            GameRepository = gameRepository;
            TourRepository = tourRepository;
            _context = context;
        }

        public async Task CompleteAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw;
            }
        }
    }
}
