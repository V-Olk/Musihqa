using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Volkin.Musihqa.Management.DataAccess.Common.Extensions
{
    public static class EntityExtensions
    {
        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes)
            where T : class
        {
            if (includes.Length == 0)
                return query;

            query = includes.Aggregate(query,
                (current, include) => current.Include(include));

            return query;
        }
    }
}