using Data.RocketStats.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Data.RocketStats.Repos
{
    public class UserMatchRepository : IUserMatchRepository
    {
        private readonly RocketStatsDbContext dbContext;

        public UserMatchRepository(RocketStatsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<UserMatchEntity> AddAsync(UserMatchEntity entity)
        {
            var response = await dbContext.UserMatch.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return response.Entity;
        }

        public async Task<UserMatchEntity> GetByUserIdAndMatchIdAsync(Guid userId, Guid matchId)
        {
            return await dbContext.UserMatch.FirstOrDefaultAsync(x => x.UserID == userId && x.MatchID == matchId);
        }
    }
}
