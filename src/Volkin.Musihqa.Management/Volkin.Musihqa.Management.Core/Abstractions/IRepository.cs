using Volkin.Musihqa.Management.Core.Domain;

namespace Volkin.Musihqa.Management.Core.Abstractions
{
    public interface IRepository<T>
        where T : BaseEntity
    {
        Task<T?> GetByIdAsync(Guid id);

        Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<Guid> ids);

        Task<IEnumerable<T>> GetAllAsync();

        Task AddAsync(T entity);

        Task UpdateAsync();

        Task DeleteAsync(T entity);
    }
}
