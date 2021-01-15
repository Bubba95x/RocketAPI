using API.RocketStats.AutoMapper;
using System;
using Xunit;

namespace API.RocketStats.UnitTests
{
    public class AutoMapperUnitTests
    {
        [Fact]
        public void AutoMapperTest_AllMappings_ConfigurationIsValid()
        {
            var autoMapperConfig = new AutoMapperConfiguration();
            var mapperConfiguration = autoMapperConfig.MapperConfiguration;

            mapperConfiguration.AssertConfigurationIsValid();
        }        
    }
}
