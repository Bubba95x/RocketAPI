using API.RocketStats.StartUp;
using Azure.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
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
                    options.Connect(new Uri(settings["AppConfig:Url"]), creds)
                    .ConfigureKeyVault(kv =>
                    {
                        kv.SetCredential(creds);
                    }
                    ));
                }).UseStartup<Startup>());
    }
}
