using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament.Core.Dto.TourDtos
{
    public class TourForCreationDto
    {
        public string? Title { get; set; }
        public DateTime StartDate { get; set; }
        public ICollection<GameForCreationDto>? Games { get; set; }
    }
}
