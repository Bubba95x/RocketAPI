using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace API.RocketStats.AutoMapper
{
	public class AutoMapperConfiguration
	{
		public MapperConfiguration MapperConfiguration { get; private set; }

		public AutoMapperConfiguration()
		{
			MapperConfiguration = new MapperConfiguration(config =>
			{
				config.AddProfile(new ProfileSetup());
			});
		}

		public void ConfigureServices(IServiceCollection services)
		{
			IMapper mapper = MapperConfiguration.CreateMapper();
			services.AddSingleton(mapper);
		}
	}
}
