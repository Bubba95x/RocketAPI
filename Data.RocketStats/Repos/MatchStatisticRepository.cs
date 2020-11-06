using Data.RocketStats.Entities;
using System.Threading.Tasks;

namespace Data.RocketStats.Repos
{
    public class MatchStatisticRepository : IMatchStatisticRepository
    {
        private readonly RocketStatsDbContext dbContext;

        public MatchStatisticRepository(RocketStatsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<MatchStatisticsEntity> AddAsync(MatchStatisticsEntity entity)
        {
            var response = await dbContext.MatchStatistics.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return response.Entity;
        }
    }
}
