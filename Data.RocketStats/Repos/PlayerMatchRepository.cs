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

        public async Task<PlayerMatchEntity> UpdateAsync(PlayerMatchEntity entity)
        {
            var existing = await dbContext.FindAsync<PlayerMatchEntity>(entity.ID); // Pass by reference
            if (existing is null)
            {
                return null;
            }

            dbContext.Entry(existing).CurrentValues.SetValues(entity);
            await dbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<PlayerMatchEntity> GetAsync(Guid ID)
        {
            return await dbContext.PlayerMatch.FirstOrDefaultAsync(x => x.ID == ID);
        }

        public async Task<PlayerMatchEntity> GetByRocketStatsIDAsync(Guid rocketStatsID)
        {
            return await dbContext.PlayerMatch.FirstOrDefaultAsync(x => x.RocketStatsID == rocketStatsID);
        }

        public async Task<PlayerMatchEntity> GetByUserIdAndMatchIdAsync(Guid userId, Guid matchId)
        {
            return await dbContext.PlayerMatch.FirstOrDefaultAsync(x => x.UserID == userId && x.MatchID == matchId);
        }
    }
}
