using Data.RocketStats.Entities;
using System;
using System.Threading.Tasks;

namespace Data.RocketStats.Repos
{
    public interface IMatchRepository
    {
        Task<MatchEntity> AddAsync(MatchEntity matchModel);
        Task<MatchEntity> GetAsync(Guid ID);
    }
}
