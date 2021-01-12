using AutoMapper;
using Data.RocketStats.Entities;
using Data.RocketStats.Repos;
using Services.RocketStats.Models;
using System;
using System.Threading.Tasks;

namespace Services.RocketStats.Services
{
    public class PlayerMatchService : IPlayerMatchService
    {
        private readonly IMapper mapper;
        private readonly IPlayerMatchRepository playerMatchRepository;

        public PlayerMatchService(IMapper mapper, IPlayerMatchRepository userMatchRepository)
        {
            this.mapper = mapper;
            this.playerMatchRepository = userMatchRepository;
        }

        public async Task<PlayerMatchModel> AddAsync(PlayerMatchModel model)
        {
            var entity = mapper.Map<PlayerMatchEntity>(model);
            var response = await playerMatchRepository.AddAsync(entity);
            return mapper.Map<PlayerMatchModel>(response);
        }

        public async Task<PlayerMatchModel> UpdateAsync(PlayerMatchModel model)
        {
            var entity = mapper.Map<PlayerMatchEntity>(model);
            var response = await playerMatchRepository.UpdateAsync(entity);
            return mapper.Map<PlayerMatchModel>(response);
        }

        public async Task<PlayerMatchModel> GetAsync(Guid ID)
        {
            var response = await playerMatchRepository.GetAsync(ID);
            return mapper.Map<PlayerMatchModel>(response);
        }

        public async Task<PlayerMatchModel> GetByUserIdAndMatchIdAsync(Guid userId, Guid matchId)
        {
            var response = await playerMatchRepository.GetByUserIdAndMatchIdAsync(userId, matchId);
            return mapper.Map<PlayerMatchModel>(response);
        }
    }
}
