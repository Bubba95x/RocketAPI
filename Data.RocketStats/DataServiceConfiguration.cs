using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Data.RocketStats
{
    public static class DataServiceConfiguration
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            string connStr = ConfigurationExtensions.GetConnectionString(configuration, "RocketStats");
            services.AddDbContext<RocketStatsDbContext>(options =>
                    options.UseSqlServer(connStr));
        }
    }
}
