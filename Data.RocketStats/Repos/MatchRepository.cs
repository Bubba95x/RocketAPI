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

        public async Task<MatchEntity> AddAsync(MatchEntity matchModel)
        {
            var entity = await dbContext.Match.AddAsync(matchModel);
            await dbContext.SaveChangesAsync();
            return entity.Entity;
        }

        public async Task<MatchEntity> GetAsync(Guid ID)
        {
            return await dbContext.Match.FirstAsync(x => x.ID == ID);
        }
    }
}
