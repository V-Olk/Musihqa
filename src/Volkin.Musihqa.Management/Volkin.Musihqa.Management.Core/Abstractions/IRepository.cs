using System.Linq.Expressions;
using Volkin.Musihqa.Management.Core.Domain;

namespace Volkin.Musihqa.Management.Core.Abstractions
{
    public interface IRepository<T>
        where T : BaseEntity
    {
        Task<T?> GetByIdOrDefaultAsync(Guid id, params Expression<Func<T, object>>[] includes);

        Task<IReadOnlyCollection<T>> GetByIdsAsync(IEnumerable<Guid> ids);

        Task AddAsync(T entity);

        void Delete(T entity);
    }
}
