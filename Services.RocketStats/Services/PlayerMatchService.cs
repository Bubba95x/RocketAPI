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
        private readonly IPlayerMatchRepository userMatchRepository;

        public PlayerMatchService(IMapper mapper, IPlayerMatchRepository userMatchRepository)
        {
            this.mapper = mapper;
            this.userMatchRepository = userMatchRepository;
        }

        public async Task<PlayerMatchModel> AddAsync(PlayerMatchModel model)
        {
            var entity = mapper.Map<PlayerMatchEntity>(model);
            var response = await userMatchRepository.AddAsync(entity);
            return mapper.Map<PlayerMatchModel>(response);
        }

        public async Task<PlayerMatchModel> GetByUserIdAndMatchIdAsync(Guid userId, Guid matchId)
        {
            var response = await userMatchRepository.GetByUserIdAndMatchIdAsync(userId, matchId);
            return mapper.Map<PlayerMatchModel>(response);
        }
    }
}
