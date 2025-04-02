using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using MSWadConsole20.Contract;
using MSWadConsole20.Repository.DataAccess;
using MSWadConsole20.Repository;
using MSWadConsole20.Services;
using Microsoft.EntityFrameworkCore;

namespace MSWadConsole20
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
            NLog.Extensions.Logging.ConfigSettingLayoutRenderer.DefaultConfiguration = Configuration;

            services.AddControllers();

            if (string.IsNullOrWhiteSpace(Configuration["DB_CONNECTION"]))
                throw new InvalidOperationException("Missing Default Connection String");
           
            services.AddPooledDbContextFactory<ConfigurationDataAccess>(o => { o.UseSqlServer(Configuration["DB_CONNECTION"]); });

            
            services.AddSingleton<IConfigurationRepository, ConfigurationRepository>();
            services.AddSingleton<IConfigurationService, ConfigurationService>();
            
            services.AddHealthChecks();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MS01035 - MsWadCommonService",
                    Version = "v1",
                    Description = "Servizio di lettura applicazioni"
                });
                //// Set the comments path for the Swagger JSON and UI.
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MS00914 - PushEvent"));
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
