using MediatR;

namespace Volkin.Musihqa.Management.Domain.UseCases.Handlers
{
    public interface IQueryHandler<in TQuery, TResponse>
        : IRequestHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
    }
}