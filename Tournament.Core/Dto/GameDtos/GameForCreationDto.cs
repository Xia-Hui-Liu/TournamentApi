using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament.Core.Dto.GameDtos
{
    public class GameForCreationDto
    {
        public string? Title { get; set; }
        public DateTime Time { get; set; }
    }
}
