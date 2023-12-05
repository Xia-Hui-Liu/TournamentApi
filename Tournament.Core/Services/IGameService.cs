using Tournament.Core.Dto.GameDtos;
using Tournament.Core.Entities;

namespace Tournament.Core.Services
{
    public interface IGameService
    {
        Task<IEnumerable<GameDto>> GetAllAsync(Guid tourId);
        Task<GameDto> GetAsync(Guid id);
        Task<GameDto> UpdateAsync(Guid id, GameForUpdateDto dto);

        Task<GameDto> DeleteAsync(Guid id);
        Task<GameDto?> PostAsync(GameForCreationDto dto);
    }
}
