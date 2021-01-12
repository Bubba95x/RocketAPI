using Data.RocketStats.Entities;
using System.Threading.Tasks;

namespace Data.RocketStats.Repos
{
    public class PlayerMatchStatisticRepository : IPlayerMatchStatisticsRepository
    {
        private readonly RocketStatsDbContext dbContext;

        public PlayerMatchStatisticRepository(RocketStatsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<PlayerMatchStatisticEntity> AddAsync(PlayerMatchStatisticEntity entity)
        {
            var response = await dbContext.PlayerMatchStatistic.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return response.Entity;
        }
    }
}
