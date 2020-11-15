using Data.RocketStats.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Data.RocketStats.Repos
{
    public class MatchRepository : IMatchRepository
    {
        private readonly RocketStatsDbContext dbContext;

        public MatchRepository(RocketStatsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<MatchEntity> AddAsync(MatchEntity entity)
        {
            var response = await dbContext.Match.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return response.Entity;
        }

        public async Task<MatchEntity> GetAsync(Guid ID)
        {
            return await dbContext.Match.FirstOrDefaultAsync(x => x.ID == ID);
        }

        public async Task<MatchEntity> GetByRocketStatsIDAsync(Guid ID)
        {
            return await dbContext.Match.FirstOrDefaultAsync(x => x.RocketStatsID == ID);
        }
    }
}
