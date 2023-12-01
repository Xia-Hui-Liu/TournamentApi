
using Tournament.Core.Dto.GameDtos;

namespace Tournament.Core.Dto.TourDtos
{
    public class TourForCreationDto
    {
        public string? Title { get; set; }
        public DateTime StartDate { get; set; }

        public TourForCreationDto()
        {
            StartDate = DateTime.MinValue;
        }

    }
}
