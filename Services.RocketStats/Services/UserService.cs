using AutoMapper;
using Data.RocketStats.Entities;
using Data.RocketStats.Repos;
using Microsoft.Extensions.Configuration;
using Services.RocketStats.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.RocketStats.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly IUserRepository repository;
        private readonly IConfiguration config;

        public UserService(IMapper mapper, IUserRepository repository, IConfiguration config)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.config = config;
        }

        public async Task<UserModel> AddAsync(UserModel model)
        {
            var entity = mapper.Map<UserEntity>(model);
            var response = await repository.AddAsync(entity);
            return mapper.Map<UserModel>(response);
        }

        public async Task<UserModel> GetAsync(Guid ID)
        {
            var response = await repository.GetAsync(ID);
            return mapper.Map<UserModel>(response);
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            var response = await repository.GetAllAsync();
            return mapper.Map<List<UserModel>>(response);
        }
    }
}
