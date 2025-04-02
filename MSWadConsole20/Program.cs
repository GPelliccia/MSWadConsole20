
using NLog;
using NLog.Web;

namespace MSWadConsole20
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // 
            //  Loads appsetting.json and enables ${configsetting}
            // (${configsetting:name=ConnectionStrings.LogConnection}) => LoadConfigurationFromAppSettings
            var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                })
                .UseNLog();
    }
}
