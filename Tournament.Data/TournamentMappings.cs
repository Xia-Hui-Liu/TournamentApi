using AutoMapper;
using Bogus.DataSets;
using Tournament.Core.Dto.TourDtos;
using Tournament.Core.Entities;

namespace Tournament.Data
{
    public class TournamentMappings : Profile
    {
        public TournamentMappings()
        {
            CreateMap<Tour, TourDto>();
            CreateMap<Tour, TourWithoutGameDto>();
        
        }

    }
}
