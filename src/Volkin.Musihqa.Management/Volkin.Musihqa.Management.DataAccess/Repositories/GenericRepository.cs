using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Volkin.Musihqa.Management.DataAccess.Common;
using Volkin.Musihqa.Management.DataAccess.Common.Extensions;
using Volkin.Musihqa.Management.Domain.Abstractions;
using Volkin.Musihqa.Management.Domain.Models;

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
            => await DataContext.Set<T>().AddAsync(entity);

        public void Delete(T entity)
            => DataContext.Set<T>().Remove(entity);

        public Task<T?> GetByIdOrDefaultAsync(Guid id, params Expression<Func<T, object>>[] includes)
            => DataContext.Set<T>().IncludeMultiple(includes).FirstOrDefaultAsync(e => e.Id.Equals(id));

        public async Task<IReadOnlyCollection<T>> GetByIdsAsync(IEnumerable<Guid> ids)
            => await DataContext.Set<T>().Where(t => ids.Contains(t.Id)).ToArrayAsync();

    }


}


