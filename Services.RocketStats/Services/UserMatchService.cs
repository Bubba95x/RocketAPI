using AutoMapper;
using Data.RocketStats.Entities;
using Data.RocketStats.Repos;
using Services.RocketStats.Models;
using System;
using System.Threading.Tasks;

namespace Services.RocketStats.Services
{
    public class UserMatchService : IUserMatchService
    {
        private readonly IMapper mapper;
        private readonly IUserMatchRepository userMatchRepository;

        public UserMatchService(IMapper mapper, IUserMatchRepository userMatchRepository)
        {
            this.mapper = mapper;
            this.userMatchRepository = userMatchRepository;
        }

        public async Task<UserMatchModel> AddAsync(UserMatchModel model)
        {
            var entity = mapper.Map<UserMatchEntity>(model);
            var response = await userMatchRepository.AddAsync(entity);
            return mapper.Map<UserMatchModel>(response);
        }

        public async Task<UserMatchModel> GetByUserIdAndMatchIdAsync(Guid userId, Guid matchId)
        {
            var response = await userMatchRepository.GetByUserIdAndMatchIdAsync(userId, matchId);
            return mapper.Map<UserMatchModel>(response);
        }
    }
}
