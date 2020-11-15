using AutoMapper;
using Data.RocketStats.Entities;
using Data.RocketStats.Repos;
using Services.RocketStats.Models;
using System;
using System.Threading.Tasks;

namespace Services.RocketStats.Services
{
    public class MatchService : IMatchService
    {
        private readonly IMapper mapper;
        private readonly IMatchRepository matchRepository;

        public MatchService(IMapper mapper, IMatchRepository matchRepository)
        {
            this.mapper = mapper;
            this.matchRepository = matchRepository;
        }

        public async Task<MatchModel> AddAsync(MatchModel matchModel)
        {
            var matchEntity = mapper.Map<MatchEntity>(matchModel);
            var response = await matchRepository.AddAsync(matchEntity);
            return mapper.Map<MatchModel>(response);
        }

        public async Task<MatchModel> GetAsync(Guid ID)
        {
            var response = await matchRepository.GetAsync(ID);
            return mapper.Map<MatchModel>(response);
        }

        public async Task<MatchModel> GetByRocketStatsIDAsync(Guid ID)
        {
            var response = await matchRepository.GetByRocketStatsIDAsync(ID);
            return mapper.Map<MatchModel>(response);
        }
    }
}
