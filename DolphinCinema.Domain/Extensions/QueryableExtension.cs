using DolphinCinema.Domain.Entities;
using System.Linq.Expressions;

namespace DolphinCinema.Domain.Extensions
{
    public static class QueryableExtension
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicate) where T : Entity
        {
            return condition ? query.Where(predicate) : query;
        }

        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, Func<T, bool> condition, Func<T, bool> predicate) where T : Entity
        {
            return query.Where(q => condition(q) ? predicate(q) : true);
        }
    }
}
