using Services.RocketStats.Models;
using System;
using System.Threading.Tasks;

namespace Services.RocketStats.Services
{
    public interface IMatchService
    {
        Task<MatchModel> AddAsync(MatchModel matchModel);
        Task<MatchModel> GetAsync(Guid ID);
    }
}
