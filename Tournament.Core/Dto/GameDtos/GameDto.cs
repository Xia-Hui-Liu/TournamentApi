namespace Tournament.Core.Dto.GameDtos
{
    public class GameDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public DateTime Time { get; set; }
    }
}
