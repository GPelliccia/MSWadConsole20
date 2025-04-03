using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using MSWadConsole20.Contract;
using MSWadConsole20.Repository;
using MSWadConsole20.Repository.DataAccess;
using MSWadConsole20.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;

namespace MSWadConsole20
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            NLog.Extensions.Logging.ConfigSettingLayoutRenderer.DefaultConfiguration = Configuration;

            services.AddControllers();

            var connectionString = Configuration["DB_CONNECTION"];
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException("Missing DB_CONNECTION in configuration");

            // Registrazione ConfigurationDataAccess con la stringa di connessione da appsettings.json
            services.AddSingleton(sp => new ConfigurationDataAccess(connectionString));

            services.AddSingleton<IConfigurationRepository, ConfigurationRepository>();
            services.AddSingleton<IConfigurationService, ConfigurationService>();

            // Registrazione ReferentDataAccess con la stringa di connessione da appsettings.json
            services.AddSingleton(sp => new ReferentDataAccess(connectionString));

            services.AddSingleton<IReferentRepository, ReferentRepository>();
            services.AddSingleton<IReferentService, ReferentService>();

            services.AddHealthChecks();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MS01035 - MsWadConsole20",
                    Version = "v1",
                    Description = "Servizio di lettura applicazioni"
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MSWadConsole20"));
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/readiness", new HealthCheckOptions { Predicate = _ => true });
                endpoints.MapHealthChecks("/liveness", new HealthCheckOptions { Predicate = _ => true });
                endpoints.MapControllers();
            });
        }
    }
}
