using Volkin.Musihqa.Management.WebHost.Common.CustomExceptionMiddleware;

namespace Volkin.Musihqa.Management.WebHost.Common.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
