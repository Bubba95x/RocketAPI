using AutoMapper;
using Data.RocketStats.Entities;
using Data.RocketStats.Repos;
using Services.RocketStats.Models;
using System.Threading.Tasks;

namespace Services.RocketStats.Services
{
    public class PlayerMatchStatisticService : IPlayerMatchStatisticService
    {
        private readonly IMapper mapper;
        private readonly IPlayerMatchStatisticsRepository matchStatisticRepository;

        public PlayerMatchStatisticService(IMapper mapper, IPlayerMatchStatisticsRepository matchStatisticRepository)
        {
            this.mapper = mapper;
            this.matchStatisticRepository = matchStatisticRepository;
        }

        public async Task<PlayerMatchStatisticModel> AddAsync(PlayerMatchStatisticModel model)
        {
            var entity = mapper.Map<PlayerMatchStatisticEntity>(model);
            var response = await matchStatisticRepository.AddAsync(entity);
            return mapper.Map<PlayerMatchStatisticModel>(response);
        }
    }
}
