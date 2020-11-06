using Data.RocketStats.Entities;
using System;
using System.Threading.Tasks;

namespace Data.RocketStats.Repos
{
    public interface IUserRepository
    {
        Task<UserEntity> AddAsync(UserEntity entity);
        Task<UserEntity> GetAsync(Guid ID);
    }
}
