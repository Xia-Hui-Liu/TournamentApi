using AutoMapper;
using Tournament.Core.Dto.GameDtos;
using Tournament.Core.Dto.TourDtos;
using Tournament.Core.Entities;

namespace Tournament.Data
{
    public class GameMapping : Profile
    {
        public GameMapping()
        {
            CreateMap<Game, GameDto>().ReverseMap();
            CreateMap<GameForUpdateDto, Game>();
            CreateMap<GameForCreationDto, Game>();

        }
       
        
    }
}
