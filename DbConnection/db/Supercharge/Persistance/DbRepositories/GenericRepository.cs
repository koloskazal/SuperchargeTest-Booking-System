using DbConnection.db.Supercharge.Context;
using DbConnection.db.Supercharge.Domain.DbRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DbConnection.db.Supercharge.Persistance.DbRepositories
{
    public class GenericRepository<TContext, T> : IGenericRepository<TContext, T> where TContext : DbContextExtended where T : class
    {
        protected readonly TContext context;
        protected readonly DbSet<T> table = null;

        public GenericRepository(TContext context)
        {
            context.Database.SetCommandTimeout(300);
            table = context.Set<T>();
            this.context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await table.FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            List<T> result = await table.ToListAsync();
            return result;
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return table.FirstOrDefaultAsync(predicate);
        }

        public Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = table.Where(predicate);
            query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            string sql = query.ToQueryString();
            return query.FirstOrDefaultAsync();
        }

        public Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate)
        {
            return table.Where(predicate).ToListAsync();
        }

        public Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = table.Where(predicate);
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).ToListAsync();
        }

        public async Task<T> InsertAsync(T entity, bool saveChanges = true)
        {
            try
            {
                await table.AddAsync(entity);
                if (saveChanges)
                {
                    int _ = await context.SaveChangesAsync();
                }
                return entity;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<int> InsertRangeAsync(List<T> entityList)
        {
            await table.AddRangeAsync(entityList);
            int _ = await context.SaveChangesAsync();
            return entityList.Count;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            table.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            int _ = await context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            table.Remove(entity);
            int _ = await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            T entity = await table.FindAsync(id);
            table.Remove(entity);
            int _ = await context.SaveChangesAsync();
            return true;
        }

        public async Task<int> DeleteRangeAsync(IEnumerable<T> entries)
        {
            table.RemoveRange(entries);
            int _ = await context.SaveChangesAsync();
            return entries.Count();
        }

        public async Task<int> DeleteRangeAsync(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entries = table.Where(predicate);
            int count = await DeleteRangeAsync(entries);
            return entries.Count();
        }

        public async Task<bool> SaveChangesAsync()
        {
            int _ = await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await table.FindAsync(id) != null;
        }

        public Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            return table.AnyAsync(predicate);
        }


    }
}

