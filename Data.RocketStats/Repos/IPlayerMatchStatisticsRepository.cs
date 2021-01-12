using Data.RocketStats.Entities;
using System.Threading.Tasks;

namespace Data.RocketStats.Repos
{
    public interface IPlayerMatchStatisticsRepository
    {
        Task<PlayerMatchStatisticEntity> AddAsync(PlayerMatchStatisticEntity entity);
    }
}
