using Data.RocketStats.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Data.RocketStats.Repos
{
    public class PlayerMatchRepository : IPlayerMatchRepository
    {
        private readonly RocketStatsDbContext dbContext;

        public PlayerMatchRepository(RocketStatsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<PlayerMatchEntity> AddAsync(PlayerMatchEntity entity)
        {
            var response = await dbContext.PlayerMatch.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return response.Entity;
        }

        public async Task<PlayerMatchEntity> GetByUserIdAndMatchIdAsync(Guid userId, Guid matchId)
        {
            return await dbContext.PlayerMatch.FirstOrDefaultAsync(x => x.UserID == userId && x.MatchID == matchId);
        }
    }
}
