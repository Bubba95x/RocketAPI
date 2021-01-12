using API.RocketStats.AutoMapper;
using API.RocketStats.Security;
using Data.RocketStats;
using Data.RocketStats.Repos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.RocketStats.Services;

namespace API.RocketStats.StartUp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            new AutoMapperConfiguration().ConfigureServices(services);

            //services.RegisterLogin(Configuration);
            services.AddSwaggerGen();
            services.AddMvc();

            // Services
            services.AddScoped<IMatchService, MatchService>();
            services.AddScoped<IPlayerMatchStatisticService, PlayerMatchStatisticService>();
            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<IPlayerMatchService, PlayerMatchService>();

            // Repos
            services.AddScoped<IMatchRepository, MatchRepository>();
            services.AddScoped<IPlayerMatchStatisticsRepository, PlayerMatchStatisticRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IPlayerMatchRepository, PlayerMatchRepository>();

            // Auth
            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication("Bearer", options =>
                {
                    options.ApiName = "RocketAPI";
                    options.Authority = Configuration["OAuth:Domain"];
                });
            
            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();
            services.AddControllers();
            services.RegisterSecurityScopes(Configuration);
            
            DataServiceConfiguration.RegisterServices(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }            
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "RocketAPI API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseStaticFiles();
            app.UseDefaultFiles();
        }
    }
}
