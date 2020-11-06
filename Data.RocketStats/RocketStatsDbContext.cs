using Microsoft.EntityFrameworkCore;
using Data.RocketStats.Entities;

namespace Data.RocketStats
{
    public class RocketStatsDbContext : DbContext
    {
        public RocketStatsDbContext(DbContextOptions<RocketStatsDbContext> options) : base(options)
        {

        }

        public DbSet<MatchEntity> Match { get; set; }
        public DbSet<MatchStatisticsEntity> MatchStatistics { get; set; }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<UserStatisticsEntity> UserStatistics { get; set; }
        public DbSet<UserMatchEntity> UserMatch { get; set; }
    }
}
