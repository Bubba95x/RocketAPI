using Data.RocketStats.Entities;
using System;
using System.Threading.Tasks;

namespace Data.RocketStats.Repos
{
    public interface IPlayerMatchRepository
    {
        Task<PlayerMatchEntity> AddAsync(PlayerMatchEntity entity);
        Task<PlayerMatchEntity> GetByUserIdAndMatchIdAsync(Guid userId, Guid matchId);
    }
}
