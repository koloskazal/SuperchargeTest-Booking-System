using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics.CodeAnalysis;

namespace DbConnection.db.Supercharge.Context
{
    public class DbContextExtended : DbContext
    {
        private static readonly List<string> logList = new();
        public DbContextExtended([NotNull] DbContextOptions options) : base(options)
        {

        }

        public DbContextExtended()
        {

        }

        public static List<string> GetLog()
        {
            return logList;
        }

        public static void SetLastLog(string sql)
        {
            logList.Add(sql);
            if (logList.Count > 20)
            {
                try
                {
                    logList.RemoveAt(0);
                }
                catch (Exception)
                {

                }
            }
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            try
            {
                return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            }
            catch (Exception e)
            {
                //Place a breakpoint here and don't remove it. It helps to find db related errors.
                List<string> log = GetLog();
                WithdrawChanges();
                throw;
            }
        }

        private void WithdrawChanges()
        {
            List<EntityEntry> changedEntries = ChangeTracker.Entries()
                                .Where(x => x.State != EntityState.Unchanged).ToList();
            changedEntries.ForEach(entry =>
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            });
        }

        public override EntityEntry Remove(object entity)
        {
            try
            {
                return base.Remove(entity);
            }
            catch (Exception)
            {
                //Place a breakpoint here and don't remove it. It helps to find db related errors.
                List<string> log = GetLog();
                WithdrawChanges();
                throw;
            }
        }

        public override void RemoveRange(params object[] entities)
        {
            try
            {
                base.RemoveRange(entities);
            }
            catch (Exception)
            {
                //Place a breakpoint here and don't remove it. It helps to find db related errors.
                List<string> log = GetLog();
                WithdrawChanges();
                throw;
            }
        }
    }
}