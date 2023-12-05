using Tournament.Core.Dto.GameDtos;

namespace Tournament.Core.Services
{
    public interface IGameService
    {
        Task<IEnumerable<GameDto>> GetAllAsync();
        Task<GameDto> GetAsync(Guid id);
        Task<GameDto> UpdateAsync(Guid id, GameForUpdateDto dto);

        Task<GameDto> DeleteAsync(Guid id);
        Task<GameDto> PostAsync(Guid id, GameForCreationDto dto);
    }
}
