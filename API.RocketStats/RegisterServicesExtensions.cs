using API.RocketStats.Security;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.RocketStats
{
    public static class RegisterServicesExtensions
    {
        public static IServiceCollection RegisterSecurityScopes(this IServiceCollection services, IConfiguration configuration)
        {
            var authURI = configuration["OAuth:Domain"];
            services.AddAuthorization(options => 
            {
                options.AddPolicy("RocketAPI.Read", policy => policy.Requirements.Add(new HasScopeRequirement("RocketAPI.Read", authURI)));
                options.AddPolicy("RocketAPI.Write", policy => policy.Requirements.Add(new HasScopeRequirement("RocketAPI.Write", authURI)));
            });

            return services;
        }

        public static IServiceCollection RegisterLogin(this IServiceCollection services, IConfiguration configuration)
        {
            // Add authentication services
            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication("Bearer", options =>
                {
                    options.ApiName = "RocketAPI";
                    options.Authority = configuration["OAuth:Domain"];
                });

            // Add framework services.
            services.AddControllersWithViews();
            return services;
        }
    }
}
