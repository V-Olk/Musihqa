using System.Linq.Expressions;
using Volkin.Musihqa.Management.Domain.Models;

namespace Volkin.Musihqa.Management.Domain.Abstractions
{
    public interface IRepository<T>
        where T : BaseEntity
    {
        Task<T?> GetByIdOrDefaultAsync(Guid id, CancellationToken cancellationToken, params Expression<Func<T, object>>[] includes);

        Task<IReadOnlyCollection<T>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken);

        Task AddAsync(T entity, CancellationToken cancellationToken);

        void Delete(T entity);
    }
}
