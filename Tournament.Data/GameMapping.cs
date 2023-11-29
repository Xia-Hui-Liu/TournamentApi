using AutoMapper;
using Tournament.Core.Dto;
using Tournament.Core.Entities;

namespace Tournament.Data
{
    public class GameMapping : Profile
    {
        public GameMapping()
        {
            CreateMap<Game, GameDto>()
           .ForMember(
           dest => dest.Title,
           from => from.MapFrom(g => g.Title));
        }
       
        
    }
}
