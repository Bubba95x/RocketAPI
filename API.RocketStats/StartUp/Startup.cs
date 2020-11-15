using API.RocketStats.AutoMapper;
using Data.RocketStats;
using Data.RocketStats.Repos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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

            services.RegisterLogin(Configuration);
            services.AddSwaggerGen();
            services.AddMvc();

            // Services
            services.AddScoped<IMatchService, MatchService>();
            services.AddScoped<IRTConversionService, RTConversionService>();
            services.AddScoped<IMatchStatisticService, MatchStatisticService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserMatchService, UserMatchService>();

            // Repos
            services.AddScoped<IMatchRepository, MatchRepository>();
            services.AddScoped<IMatchStatisticRepository, MatchStatisticRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserMatchRepository, UserMatchRepository>();

            // 1. Add Authentication Services
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = Configuration["Auth0:Domain"];
                options.Audience = Configuration["Auth0:Audience"];
            });
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
            app.UseStaticFiles();
            app.UseDefaultFiles();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            //SwaggerConfiguration.ConfigureSwagger(app, "Rocket API");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "RocketAPI API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
