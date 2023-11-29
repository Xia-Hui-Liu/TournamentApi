using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.Core.Entities;

namespace Tournament.Core.Dto
{
    public class TourDto
    {
        public Guid Id { get; init; }
        public string? Title { get; init; }
        public DateTime StartDate { get; init; }

        public ICollection<GameDto>? Games { get; init; } 
    }
}
