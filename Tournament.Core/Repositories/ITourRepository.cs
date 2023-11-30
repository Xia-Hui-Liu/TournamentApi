using Tournament.Core.Entities;

namespace Tournament.Core.Repositories
{
    public interface ITourRepository
    {
        Task<IEnumerable<Tour>> GetAllAsync(bool includeGames = false);
        Task<Tour> GetAsync(Guid id);

        Task<bool> AnyAsync(Guid id);
        void Add(Tour tour);
        void Update(Tour tour);
        void Remove(Tour tour);

        Task<bool> SaveChangesAsync();
    }
}
