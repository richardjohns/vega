using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using vega.Persistence;

namespace vega
{
    public class Startup
    {
        private readonly IHostingEnvironment _currentEnvironment;
        // In terminal start application with ASPNETCORE_ENVIRONMENT=Development dotnet run
        // Start Docker MySQL instance with - 
        // Open MacSQLPro to monitor db
        // Check containers running with docker ps.
        // Start docker container with - 
        // sudo docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=MyComplexPassword!234' -p 1433:1433 -d microsoft/mssql-server-linux
        // Then apply migrations including seeding data using - 
        // dotnet ef database update SeedDatabase (or name of latest migration file)

        // Log container activity with docker ps -a
        // Stop docker containers with doccker stop (container ID)

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            _currentEnvironment = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<VegaDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            // Add framework services (ie for dependency injection)
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // loggerFactort.AddConsole(Configuration.GetSection....)
            // loggerFactory.AddDebug();

            // if (env.IsDevelopment())

            if (_currentEnvironment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
