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
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate
        {
            get
            {
                return StartDate.AddMonths(3);
            }
        }
        public ICollection<GameDto> Games { get; set; } = new List<GameDto>();

    }
}
