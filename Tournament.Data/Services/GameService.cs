﻿using AutoMapper;
using Tournament.Core.Dto.GameDtos;
using Tournament.Core.Dto.TourDtos;
using Tournament.Core.Entities;
using Tournament.Core.Repositories;
using Tournament.Core.Services;

namespace Tournament.Data.Services
{
    public class GameService : IGameService
    {
        private readonly IUoW _unitOfWork;
        private readonly IMapper _mapper;

        public GameService(IUoW unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<IEnumerable<GameDto>> GetAllAsync(Guid tourId)
        {
            var games = await _unitOfWork.GameRepository.GetAllAsync(tourId);
            var dtos = _mapper.Map<IEnumerable<GameDto>>(games);
            return dtos;
        }


        public async Task<GameDto> GetAsync(Guid id)
        {
            var game = await _unitOfWork.GameRepository.GetAsync(id);

            var dtos = _mapper.Map<GameDto>(game);

            return dtos;
        }


        public async Task<GameDto> UpdateAsync(Guid id, GameForUpdateDto dto)
        {
            var game = _mapper.Map<Game>(dto);
            _unitOfWork.GameRepository.Update(game);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<GameDto>(game);
        }

        public async Task<GameDto?> PostAsync(GameForCreationDto dto)
        {
            var game = _mapper.Map<Game>(dto);
            _unitOfWork.GameRepository.Add(game);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<GameDto>(game);
        }

        public async Task<GameDto> DeleteAsync(Guid id)
        {
            var existGame = await _unitOfWork.GameRepository.GetAsync(id);

            return _mapper.Map<GameDto>(existGame);

        }
    }
}
