using DbConnection.db.Supercharge.Context;
using DbConnection.db.Supercharge.Domain.DbRepositories;
using DbConnection.db.Supercharge.Model;
using Microsoft.EntityFrameworkCore;

namespace DbConnection.db.Supercharge.Persistance.DbRepositories
{
    public class RoomRepository(SuperchargeContext context)
        : GenericRepository<SuperchargeContext, Room>(context), IRoomRepository
    {
        public Task<List<Room>> GetAvailableRoomsAsync(int hotelId, DateTime startDate, DateTime endDate)
        {
            Task<List<Room>> rooms = table
                    .Include(r => r.Bookings)
                    .Where(r => r.HotelId == hotelId)
                    .Where(r => r.Bookings.All(b => b.StartDate >= endDate || b.EndDate <= startDate))
                    .ToListAsync();
            return rooms;
        }

        public async Task<Room> GetIfAvailableAsync(int roomId,DateTime startDate, DateTime endDate)
        {
            Room room =await table
                    .Include(r => r.Bookings)
                    .Where(r => r.RoomId == roomId)
                    .Where(r => r.Bookings.All(b => b.StartDate >= endDate || b.EndDate <= startDate))
                    .FirstOrDefaultAsync();
            return room;
        }

    }
}
