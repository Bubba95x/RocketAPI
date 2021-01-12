using Microsoft.EntityFrameworkCore;
using Data.RocketStats.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Azure.Services.AppAuthentication;

namespace Data.RocketStats
{
    public class RocketStatsDbContext : DbContext
    {
        public RocketStatsDbContext(DbContextOptions<RocketStatsDbContext> options, IConfiguration configuration) : base(options)
        {
            if(configuration["Environment"] != "local")
            {
                var conn = (Microsoft.Data.SqlClient.SqlConnection)Database.GetDbConnection();
                conn.AccessToken = (new AzureServiceTokenProvider()).GetAccessTokenAsync("https://database.windows.net/").Result;
            }
        }

        public DbSet<MatchEntity> Match { get; set; }        
        public DbSet<PlayerEntity> Player { get; set; }        
        public DbSet<PlayerMatchEntity> PlayerMatch { get; set; }
        public DbSet<PlayerMatchStatisticEntity> PlayerMatchStatistic { get; set; }
        public DbSet<PlayerStatisticsEntity> PlayerStatistic { get; set; }
    }
}
