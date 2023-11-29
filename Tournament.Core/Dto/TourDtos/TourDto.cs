using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.Core.Dto.GameDtos;
using Tournament.Core.Entities;

namespace Tournament.Core.Dto.TourDtos
{
    public class TourDto
    {

        public Guid Id { get; init; }
        public string? Title { get; init; }
        public DateTime StartDate { get; init; }
        public IEnumerable<GameDto> Games { get; init; }
        public DateTime EndDate { get; init; }

        public TourDto(string? title, DateTime startDate)
        {
            Title = title;
            StartDate = startDate;
            EndDate = startDate.AddMonths(3);
        }
    }
}
