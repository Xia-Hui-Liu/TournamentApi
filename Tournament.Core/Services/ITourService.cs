

using Tournament.Core.Dto.TourDtos;

namespace Tournament.Core.Services
{
    public interface ITourService
    {
        Task<IEnumerable<TourDto>> GetAsync(bool includeGames = false);
    }
}
