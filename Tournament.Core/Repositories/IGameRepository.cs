
using Tournament.Core.Dto.GameDtos;
using Tournament.Core.Entities;

namespace Tournament.Core.Repositories
{
    public interface IGameRepository
    {

        Task<IEnumerable<Game>> GetAllAsync(Guid tourId);
        Task<Game> GetAsync(Guid id);

        Task<bool> AnyAsync(Guid id);
        void Add(Game game);
        void Update(Game game);
        void Remove(Game game);
    }
}
