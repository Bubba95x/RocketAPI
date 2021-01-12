using Services.RocketStats.Models;
using System;
using System.Threading.Tasks;

namespace Services.RocketStats.Services
{
    public interface IPlayerMatchService
    {
        Task<PlayerMatchModel> AddAsync(PlayerMatchModel model);
        Task<PlayerMatchModel> UpdateAsync(PlayerMatchModel model);
        Task<PlayerMatchModel> GetAsync(Guid ID);
        Task<PlayerMatchModel> GetByUserIdAndMatchIdAsync(Guid userId, Guid matchId);
    }
}
