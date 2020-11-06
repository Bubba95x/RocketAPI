using Data.RocketStats.Entities;
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
    }
}
