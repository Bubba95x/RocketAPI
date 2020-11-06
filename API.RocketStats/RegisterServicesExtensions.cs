using API.RocketStats.Security;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace API.RocketStats
{
    public static class RegisterServicesExtensions
    {
        public static IServiceCollection RegisterSecurityScopes(this IServiceCollection services, IConfiguration configuration)
        {
            var authURI = configuration["Auth0:Domain"];
            services.AddAuthorization(options => 
            { 
                options.AddPolicy("read:stattypes", policy => policy.Requirements.Add(new HasScopeRequirement("read:stattypes", authURI)));
                
            });

            return services;
        }

        public static IServiceCollection RegisterLogin(this IServiceCollection services, IConfiguration configuration)
        {
            //services.ConfigureSameSiteNoneCookies();

            // Cookie configuration for HTTPS
            // services.Configure<CookiePolicyOptions>(options =>
            // {
            //    options.MinimumSameSitePolicy = SameSiteMode.None
            // });

            // Add authentication services
            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddOpenIdConnect("Auth0", options => {
            // Set the authority to your Auth0 domain
            options.Authority = $"https://{configuration["Auth0:Domain"]}";

            // Configure the Auth0 Client ID and Client Secret
            options.ClientId = "Qq54VXidBHIwbiFB5qpM8SUsIixwxKLB";
            options.ClientSecret = "q7u-SOW2Hf1TEd7egb0OaJS5cGRhhnWSwxymAIKL6gJWzuohx-mh3Kjqxl4VBhjd";

            // Set response type to code
            options.ResponseType = OpenIdConnectResponseType.Code;

            // Configure the scope
            options.Scope.Clear();
            options.Scope.Add("openid");

            // Set the callback path, so Auth0 will call back to http://localhost:3000/callback
            // Also ensure that you have added the URL as an Allowed Callback URL in your Auth0 dashboard
            options.CallbackPath = new PathString("/callback");

            // Configure the Claims Issuer to be Auth0
            options.ClaimsIssuer = "Auth0";
                });

                // Add framework services.
                services.AddControllersWithViews();
                return services;
            }
    }
}
