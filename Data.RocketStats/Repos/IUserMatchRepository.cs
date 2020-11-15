using Data.RocketStats.Entities;
using System;
using System.Threading.Tasks;

namespace Data.RocketStats.Repos
{
    public interface IUserMatchRepository
    {
        Task<UserMatchEntity> AddAsync(UserMatchEntity entity);
        Task<UserMatchEntity> GetByUserIdAndMatchIdAsync(Guid userId, Guid matchId);
    }
}
