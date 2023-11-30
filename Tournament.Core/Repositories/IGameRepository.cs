using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.Core.Entities;

namespace Tournament.Core.Repositories
{
    public interface IGameRepository
    {

        Task<IEnumerable<Game>> GetAllAsync();
        Task<Game> GetAsync(Guid id);

        Task<bool> AnyAsync(Guid id);
        void Add(Game game);
        void Update(Game game);
        void Remove(Game game);
    }
}
