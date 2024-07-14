using DbConnection.Resources;

namespace SuperchargeTestApi.db.Supercharge.Domain.DbServices
{
    public interface IVisitorService
    {
        Task<VisitorResource> AddVisitorAsync(VisitorResource createVisitorResource);
        Task<List<VisitorResource>> GetAllVisitorsAsync();
        Task<VisitorResource> GetVisitorResourceByIdAsync(string visitorId);
    }
}
