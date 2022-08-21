using MediatR;

namespace Volkin.Musihqa.Management.Domain.UseCases
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}