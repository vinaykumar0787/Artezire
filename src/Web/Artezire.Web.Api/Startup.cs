using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Artezire.Data.Access;
using System.IdentityModel.Tokens.Jwt;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json.Serialization;
using Artezire.Data.Core;

namespace Artezire.Web.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {

            //var defaultPolicy = new AuthorizationPolicyBuilder()
            //    .RequireAuthenticatedUser()
            //    .RequireClaim("email")
            //    .Build();

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("apis", policyAdmin =>
            //    {
            //        policyAdmin.RequireClaim("role","user");
            //    });
            //});

            //services.AddMvc(setup =>
            //{
            //    setup.Filters.Add(new AuthorizeFilter(defaultPolicy));
            //}).AddJsonOptions(options =>
            //{
            //    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            //});

            //Configuration SIngleton
            services.AddSingleton<IConfiguration>(_ => { return Configuration; });

            //ConnectionString
            services.AddScoped<ArtezireDbContext>(_ => new ArtezireDbContext(Configuration.GetConnectionString("DefaultConnection")));


            //Dependency Injection
            services.AddTransient<IProductRepository, ProductRepository>();

            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddCors();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            IdentityServerAuthenticationOptions identityServerValidationOptions = new IdentityServerAuthenticationOptions
            {
                Authority = "https://localhost:44395/",
                AllowedScopes = new List<string> { "openid", "apis" },
                ApiSecret = "apisecret",
                ApiName = "apis",
                AutomaticAuthenticate = true,
                SupportedTokens = SupportedTokens.Both,
                // TokenRetriever = _tokenRetriever,
                // required if you want to return a 403 and not a 401 for forbidden responses
                AutomaticChallenge = true
            };

            app.UseIdentityServerAuthentication(identityServerValidationOptions);

            app.UseApplicationInsightsRequestTelemetry();

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseMvc();
        }
    }
}
