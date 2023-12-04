
using Tournament.Core.Dto.TourDtos;

namespace Tournament.Core.Services
{
   
    public interface ITourService
    {
        Task<IEnumerable<TourDto>> GetAllAsync(bool includeGames = false);
        Task<TourDto> GetAsync(Guid id);
    }

    
}
