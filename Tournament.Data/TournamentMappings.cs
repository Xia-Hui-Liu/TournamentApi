using AutoMapper;
using Bogus.DataSets;
using Tournament.Core.Dto;
using Tournament.Core.Entities;

namespace Tournament.Data
{
    public class TournamentMappings : Profile
    {
        public TournamentMappings()
        {
            CreateMap<Tour, TourDto>()
            .ForMember(
            dest => dest.Title,
            from => from.MapFrom(
                 t => $"{t.Title} {t.StartDate.ToString("yyyy-MM-ddTHH:mm:ss")}"
           ));

            CreateMap<TourForCreationDto, Tour>();
            CreateMap<TourForUpdateDto, Tour>();
        }

    }
}
