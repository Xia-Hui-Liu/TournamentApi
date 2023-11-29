
namespace Tournament.Core.Dto
{
    public class GameDto
    {
        public Guid Id { get; init; }
        public string? Title { get; init; }
        public DateTime Time { get; init; }
    }
}
