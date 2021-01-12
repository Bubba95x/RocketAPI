using Data.RocketStats.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.RocketStats.Repos
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly RocketStatsDbContext dbContext;

        public PlayerRepository(RocketStatsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<PlayerEntity> AddAsync(PlayerEntity entity)
        {
            var response = await dbContext.Player.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return response.Entity;
        }

        public async Task<PlayerEntity> UpdateAsync(PlayerEntity entity)
        {
            var existing = await dbContext.FindAsync<PlayerEntity>(entity.ID); // Pass by reference
            if(existing is null)
            {
                return null;
            }

            dbContext.Entry(existing).CurrentValues.SetValues(entity);
            await dbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<PlayerEntity> GetAsync(Guid ID)
        {
            return await dbContext.Player.FirstAsync(x => x.ID == ID);
        }

        public async Task<IEnumerable<PlayerEntity>> GetAllAsync()
        {
            return await dbContext.Player.ToListAsync();
        }
    }
}
