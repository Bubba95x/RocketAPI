using AutoMapper;
using Data.RocketStats.Entities;
using Data.RocketStats.Repos;
using Services.RocketStats.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.RocketStats.Services
{
    public class MatchStatisticService : IMatchStatisticService
    {
        private readonly IMapper mapper;
        private readonly IMatchStatisticRepository matchStatisticRepository;

        public MatchStatisticService(IMapper mapper, IMatchStatisticRepository matchStatisticRepository)
        {
            this.mapper = mapper;
            this.matchStatisticRepository = matchStatisticRepository;
        }

        public async Task<MatchStatisticsModel> AddAsync(MatchStatisticsModel model)
        {
            var entity = mapper.Map<MatchStatisticsEntity>(model);
            var response = await matchStatisticRepository.AddAsync(entity);
            return mapper.Map<MatchStatisticsModel>(response);
        }
    }
}
