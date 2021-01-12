using Data.RocketStats.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.RocketStats.Repos
{
    public interface IPlayerRepository
    {
        Task<PlayerEntity> AddAsync(PlayerEntity entity);
        Task<PlayerEntity> UpdateAsync(PlayerEntity entity);
        Task<PlayerEntity> GetAsync(Guid ID);
        Task<IEnumerable<PlayerEntity>> GetAllAsync();
    }
}
