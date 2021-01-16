using Microsoft.EntityFrameworkCore;
using Data.RocketStats.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Azure.Services.AppAuthentication;
using System.Threading.Tasks;
using System.Threading;
using System;

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

        public override int SaveChanges()
        {
            throw new NotImplementedException();
            //return base.SaveChanges();
        }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var UTCNow = DateTime.UtcNow;
            foreach(var entity in ChangeTracker.Entries<BaseEntity>())
            {
                // Adds
                if(entity.State == EntityState.Added)
                {
                    entity.Entity.DateCreatedUTC = UTCNow;
                    entity.Entity.DateModifiedUTC = UTCNow;
                }

                // Updates
                if(entity.State == EntityState.Modified)
                {
                    entity.Entity.DateModifiedUTC = UTCNow;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
