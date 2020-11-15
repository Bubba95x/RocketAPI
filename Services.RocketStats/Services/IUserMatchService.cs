using Services.RocketStats.Models;
using System;
using System.Threading.Tasks;

namespace Services.RocketStats.Services
{
    public interface IUserMatchService
    {
        Task<UserMatchModel> AddAsync(UserMatchModel model);
        Task<UserMatchModel> GetByUserIdAndMatchIdAsync(Guid userId, Guid matchId);
    }
}
