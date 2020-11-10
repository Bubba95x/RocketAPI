using Data.RocketStats.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.RocketStats.Repos
{
    public class UserRepository : IUserRepository
    {
        private readonly RocketStatsDbContext dbContext;

        public UserRepository(RocketStatsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<UserEntity> AddAsync(UserEntity entity)
        {
            var response = await dbContext.User.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return response.Entity;
        }

        public async Task<UserEntity> GetAsync(Guid ID)
        {
            return await dbContext.User.FirstAsync(x => x.ID == ID);
        }

        public async Task<IEnumerable<UserEntity>> GetAllAsync()
        {
            return await dbContext.User.ToListAsync();
        }
    }
}
