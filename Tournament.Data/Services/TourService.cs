using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tournament.Core.Dto.TourDtos;
using Tournament.Core.Entities;
using Tournament.Core.Repositories;
using Tournament.Core.Services;

namespace Tournament.Data.Services
{
  
    public class TourService : ITourService
    { 
        private readonly IUoW _unitOfWork;
        private readonly IMapper _mapper;   

        public TourService(IUoW unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            
        }


        public async Task<IEnumerable<TourDto>> GetAllAsync(bool includeGames = false)
        {
            var tours = await _unitOfWork.TourRepository.GetAllAsync(includeGames);
            var dtos = _mapper.Map<IEnumerable<TourDto>>(tours);
            return dtos;
        }




        public async Task<TourDto> GetAsync(Guid id)
        {
            var tour = await _unitOfWork.TourRepository.GetAsync(id);

            var dtos = _mapper.Map<TourDto>(tour);

                
            return dtos;
        }

     


        //public Task<bool> AnyAsync(Guid id)
        //{
        //    return _context.Tour.AnyAsync(t => t.Id == id);
        //}

        //public void Add(Tour tour)
        //{
        //   var tourToAdd = _unitOfWork.TourRepository.Add(tour)
        //    //_context.SaveChanges();
        //}


        //public void Remove(Tour tour)
        //{
        //    // Mark the entire entity as deleted
        //    _context.Entry(tour).State = EntityState.Deleted;

        //    // Save the changes
        //    _context.SaveChanges();
        //}
    }
}
