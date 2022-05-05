using System.Text.Json;

namespace Volkin.Musihqa.Management.WebHost.Common.CustomExceptionMiddleware
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = default!;
        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
