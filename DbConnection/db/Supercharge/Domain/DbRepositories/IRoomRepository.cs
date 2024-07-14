using DbConnection.db.Supercharge.Context;
using DbConnection.db.Supercharge.Model;

namespace DbConnection.db.Supercharge.Domain.DbRepositories
{
    public interface IRoomRepository
        : IGenericRepository<SuperchargeContext, Room>
    {
        Task<List<Room>> GetAvailableRoomsAsync(int hotelId, DateTime startDate, DateTime endDate);
        Task<Room> GetIfAvailableAsync(int roomId, DateTime startDate, DateTime endDate);
    }
}
