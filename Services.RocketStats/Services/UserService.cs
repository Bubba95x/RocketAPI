using AutoMapper;
using Data.RocketStats.Entities;
using Data.RocketStats.Repos;
using Services.RocketStats.Models;
using System;
using System.Threading.Tasks;

namespace Services.RocketStats.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly IUserRepository repository;

        public UserService(IMapper mapper, IUserRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
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
    }
}
