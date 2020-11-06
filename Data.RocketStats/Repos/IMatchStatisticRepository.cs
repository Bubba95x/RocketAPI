using Data.RocketStats.Entities;
using System.Threading.Tasks;

namespace Data.RocketStats.Repos
{
    public interface IMatchStatisticRepository
    {
        Task<MatchStatisticsEntity> AddAsync(MatchStatisticsEntity entity);
    }
}
