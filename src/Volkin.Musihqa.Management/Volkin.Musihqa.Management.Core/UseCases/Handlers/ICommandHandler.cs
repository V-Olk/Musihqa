using MediatR;

namespace Volkin.Musihqa.Management.Domain.UseCases.Handlers
{
    public interface ICommandHandler<in TCommand, TResponse>
        : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
    {
    }
}