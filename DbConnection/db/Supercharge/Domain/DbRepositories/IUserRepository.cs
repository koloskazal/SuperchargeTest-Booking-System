using DbConnection.db.Supercharge.Context;
using DbConnection.db.Supercharge.Model;

namespace DbConnection.db.Supercharge.Domain.DbRepositories
{
    public interface IUserRepository
        : IGenericRepository<SuperchargeContext, User>
    {
    }
}
