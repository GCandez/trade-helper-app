using System;
using System.Text.Json;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using tradehelperapi.Factories;

namespace tradehelperapi
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
            var MYSQL_CONNECTION_STRING = "Server=localhost;Database=gametradehelper;User=root;";

            services.AddControllers();

            services.AddTransient<ProblemDetailsFactory, CustomProblemDetailsFactory>();

            services.AddOpenApiDocument();
            services.AddDbContextPool<DatabaseContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseMySql(MYSQL_CONNECTION_STRING, mysqlOptions => mysqlOptions.ServerVersion(new Version(10, 5, 2), ServerType.MariaDb));
            });

            services.AddHealthChecks()
                    .AddDbContextCheck<DatabaseContext>();


            services.AddHealthChecksUI(setup =>
            {
                setup.AddHealthCheckEndpoint("API", "/api/health");
            })
                    .AddMySqlStorage(MYSQL_CONNECTION_STRING);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseOpenApi(); // serve OpenAPI/Swagger documents
            app.UseSwaggerUi3(); // serve Swagger UI
            app.UseReDoc(); // serve ReDoc UI

            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/api/health", new HealthCheckOptions
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
                endpoints.MapHealthChecksUI(options => options.UIPath = "/health");
            });
        }
    }
}
