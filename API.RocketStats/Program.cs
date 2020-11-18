using API.RocketStats.StartUp;
using Azure.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using Microsoft.Extensions.Hosting;
using System;

namespace API.RocketStats
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                webBuilder.ConfigureAppConfiguration(config => {
                    var creds = new DefaultAzureCredential();
                    var settings = config.Build();
                    config.AddAzureAppConfiguration(options =>
                    options.Connect(new Uri(settings["AppConfig:Endpoint"]), creds)
                    .ConfigureKeyVault(x => x.SetCredential(creds))
                    .Select(KeyFilter.Any, settings["Environment"]));
                }).UseStartup<Startup>());
    }
}
