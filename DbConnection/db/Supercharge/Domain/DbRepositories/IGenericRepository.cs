using DbConnection.db.Supercharge.Context;
using System.Linq.Expressions;

namespace DbConnection.db.Supercharge.Domain.DbRepositories
{
    public interface IGenericRepository<TContext, T> where TContext : DbContextExtended where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        Task<bool> ExistsAsync(int id);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
        Task<T> InsertAsync(T entity, bool saveChanges = true);
        Task<int> InsertRangeAsync(List<T> logMessages);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<bool> DeleteByIdAsync(int id);
        Task<bool> SaveChangesAsync();
        Task<int> DeleteRangeAsync(Expression<Func<T, bool>> predicate);
        Task<int> DeleteRangeAsync(IEnumerable<T> entries);
    }
}
