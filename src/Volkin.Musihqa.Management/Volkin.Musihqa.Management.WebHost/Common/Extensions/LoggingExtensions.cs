using System.Reflection;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;

namespace Volkin.Musihqa.Management.WebHost.Common.Extensions
{
    public static class LoggingExtensions
    {
        public static void ConfigureLogging(string? environment, IConfigurationRoot configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                .MinimumLevel.Override("System", LogEventLevel.Error)

                .Enrich.FromLogContext()
                .Enrich.WithEnvironmentName()
                .Enrich.WithMachineName()
                
                .WriteTo.Console()
                .WriteTo.Debug()
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(configuration["ElasticSearch:Url"]))
                {
                    AutoRegisterTemplate = true,
                    AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6,
                    IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name!.ToLower().Replace(".", "-")}" +
                                  $"-{environment?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}"
                })
                
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }
    }
}
