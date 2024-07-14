using DbConnection.Resources;

namespace SuperchargeTestApi.db.Supercharge.Domain.DbServices
{
    public interface IRoomService
    {
        Task<List<RoomResource>> GetAllRoomsAsync(int hotelId);
        Task<List<RoomResource>> GetAvailableRoomsAsync(int hotelId, DateTime startDate, DateTime endDate);
        Task<RoomResource> GetRoomResourceByIdAsync(string roomId);
    }
}
