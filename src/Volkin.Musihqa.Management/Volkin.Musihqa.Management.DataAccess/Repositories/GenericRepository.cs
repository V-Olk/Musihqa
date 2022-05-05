using Microsoft.EntityFrameworkCore;
using Volkin.Musihqa.Management.Core.Abstractions;
using Volkin.Musihqa.Management.Core.Domain;
using Volkin.Musihqa.Management.DataAccess.Common;

namespace Volkin.Musihqa.Management.DataAccess.Repositories
{
    public class GenericRepository<T>
        : IRepository<T>
        where T : BaseEntity
    {
        protected readonly DataContext DataContext;

        protected GenericRepository(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public async Task AddAsync(T entity)
        {
            await DataContext.Set<T>().AddAsync(entity).ConfigureAwait(false);
            await UpdateAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            DataContext.Set<T>().Remove(entity);
            await UpdateAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
            => await DataContext.Set<T>().ToListAsync().ConfigureAwait(false);

        public async Task<T?> GetByIdAsync(Guid id)
            => await DataContext.Set<T>().FirstOrDefaultAsync(e => e.Id.Equals(id)).ConfigureAwait(false);

        public async Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<Guid> ids)
            => await DataContext.Set<T>().Join(ids, t => t.Id, id => id, (t, id) => t).ToListAsync().ConfigureAwait(false);

        public async Task UpdateAsync()
            => await DataContext.SaveChangesAsync().ConfigureAwait(false);

    }

}
