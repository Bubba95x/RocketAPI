using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

namespace API.RocketStats.StartUp
{
    public static class SwaggerConfiguration
    {
        public static void ConfigureSwagger(IApplicationBuilder app, string api)
        {
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                // app.ApplicationServices
                //foreach (var description in provider.ApiVersionDescriptions)
                //{
                //    options.SwaggerEndpoint(
                //        $"/swagger/{description.GroupName}/swagger.json",
                //        $"{api} {description.GroupName.ToUpperInvariant()}");
                //}

                options.OAuthClientId("Qq54VXidBHIwbiFB5qpM8SUsIixwxKLB");
                options.OAuthAppName("Swagger Client");
            });
        }

        public static void SwaggerSetup(this IServiceCollection services, IConfiguration configuration)
        {
            var authURI = configuration["Auth0:Domain"];
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        Implicit = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri(authURI),
                            //Scopes = new Dictionary<string, string>
                            //{
                            //    { "pattersonuniversalid", "Access to the Patterson Active Directory" },
                            //    { "pat.platform.api", "Access to Platform endpoints" }
                            //},
                        }
                    }
                });

                options.OperationFilter<SecurityRequirementsOperationFilter>();

                //using (var serviceProvider = services.BuildServiceProvider())
                //{
                //    var provider = serviceProvider.GetRequiredService<IApiVersionDescriptionProvider>();

                //    // add a swagger document for each discovered API version
                //    // note: you might choose to skip or document deprecated API versions differently
                //    foreach (var description in provider.ApiVersionDescriptions)
                //    {
                //        options.SwaggerDoc(description.GroupName, new OpenApiInfo()
                //        {
                //            Title = "Rocket League API",
                //            Version = description.ApiVersion.ToString()
                //        });
                //    }
                //}
            });
        }
    }
}
