using Tournament.Core.Entities;

namespace Tournament.Core.Repositories
{
    public interface ITourRepository
    {
        Task<IEnumerable<Tour>> GetAllAsync();
        Task<Tour> GetAsync(int id);

        Task<bool> AnyAsync(int id);
        void Add(Tour tour);
        void Update(Tour tour);
        void Remove(Tour tour);
    }
}
