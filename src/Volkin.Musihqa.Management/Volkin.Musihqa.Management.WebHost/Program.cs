using Serilog;
using Volkin.Musihqa.Management.DataAccess.Data;
using Volkin.Musihqa.Management.WebHost.Common.Extensions;

namespace Volkin.Musihqa.Management.WebHost
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Log.Information("Creating host builder");
                IHostBuilder builder = CreateWebHostBuilder(args);

                Log.Information("Building host");
                IHost? app = builder.Build();

                using (IServiceScope scope = app.Services.CreateScope())
                {
                    scope.ServiceProvider.GetService<IDbInitializer>()?.InitializeDb();
                }

                Log.Information("Starting host");
                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host failure");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static IHostBuilder CreateWebHostBuilder(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                    });

            builder.ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddSerilog();
            });

            string? environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            IConfigurationRoot? configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{environment}.json", true)
                .Build();

            LoggingExtensions.ConfigureLogging(environment, configuration);

            return builder;
        }
    }
}