using DbConnection.db.Supercharge.Context;
using DbConnection.db.Supercharge.Domain.DbRepositories;
using DbConnection.db.Supercharge.Model;

namespace DbConnection.db.Supercharge.Persistance.DbRepositories
{
    public class VisitorRepository(SuperchargeContext context)
        : GenericRepository<SuperchargeContext, Visitor>(context), IVisitorRepository
    {

    }
}
