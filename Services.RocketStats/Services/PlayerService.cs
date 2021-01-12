using AutoMapper;
using Data.RocketStats.Entities;
using Data.RocketStats.Repos;
using Microsoft.Extensions.Configuration;
using Services.RocketStats.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.RocketStats.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IMapper mapper;
        private readonly IPlayerRepository playerRepo;
        private readonly IConfiguration config;

        public PlayerService(IMapper mapper, IPlayerRepository repository, IConfiguration config)
        {
            this.mapper = mapper;
            this.playerRepo = repository;
            this.config = config;
        }

        public async Task<PlayerModel> AddAsync(PlayerModel model)
        {
            var entity = mapper.Map<PlayerEntity>(model);
            var response = await playerRepo.AddAsync(entity);
            return mapper.Map<PlayerModel>(response);
        }

        public async Task<PlayerModel> UpdateAsync(PlayerModel model)
        {
            var entity = mapper.Map<PlayerEntity>(model);
            var response = await playerRepo.UpdateAsync(entity);
            return mapper.Map<PlayerModel>(response);
        }

        public async Task<PlayerModel> GetAsync(Guid ID)
        {
            var response = await playerRepo.GetAsync(ID);
            return mapper.Map<PlayerModel>(response);
        }

        public async Task<IEnumerable<PlayerModel>> GetAllAsync()
        {
            var response = await playerRepo.GetAllAsync();
            return mapper.Map<List<PlayerModel>>(response);
        }
    }
}
