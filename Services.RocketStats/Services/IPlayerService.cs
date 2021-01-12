using Services.RocketStats.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.RocketStats.Services
{
    public interface IPlayerService
    {
        Task<PlayerModel> AddAsync(PlayerModel model);
        Task<PlayerModel> UpdateAsync(PlayerModel model);
        Task<PlayerModel> GetAsync(Guid ID);
        Task<IEnumerable<PlayerModel>> GetAllAsync();
    }
}
