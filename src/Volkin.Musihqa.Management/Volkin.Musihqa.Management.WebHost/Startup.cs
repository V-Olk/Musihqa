using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Volkin.Musihqa.Management.Application.Common;
using Volkin.Musihqa.Management.DataAccess.Common;
using Volkin.Musihqa.Management.WebHost.Common.Extensions;

namespace Volkin.Musihqa.Management.WebHost
{
    public class Startup
    {
        private readonly IConfiguration _сonfiguration;

        public Startup(IConfiguration configuration)
        {
            _сonfiguration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataAccess();
            services.AddApplication();

            string? connectionString = _сonfiguration.GetConnectionString("ManagementDatabase");
            services.AddDbContext<DataContext>(x =>
            {
                x.UseNpgsql(connectionString);
            });

            services.AddControllers(x => x.SuppressAsyncSuffixInActionNames = true);
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(options =>
            {
                // Set the comments path for the Swagger JSON and UI
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.EnvironmentName is "Docker")
            {
                app.UseSwagger(options =>
                {
                    options.SerializeAsV2 = true;
                });

                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Musihqa v1"));
            }

            app.ConfigureCustomExceptionMiddleware();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
