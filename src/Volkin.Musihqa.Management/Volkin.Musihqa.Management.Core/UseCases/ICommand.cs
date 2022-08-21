using MediatR;

namespace Volkin.Musihqa.Management.Domain.UseCases
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}