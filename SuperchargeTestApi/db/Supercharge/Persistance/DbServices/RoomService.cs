using DbConnection.CustomExceptions;
using DbConnection.db.Supercharge.Domain.DbRepositories;
using DbConnection.db.Supercharge.Model;
using DbConnection.db.Supercharge.Persistance.DbRepositories;
using DbConnection.Resources;
using DbConnection.Singleton;
using DbConnection.Tools;
using DbConnection.Tools.ResourceTools;
using SuperchargeTestApi.db.Supercharge.Domain.DbServices;

namespace SuperchargeTestApi.db.Supercharge.Persistance.DbServices
{
    public class RoomService(IRoomRepository roomRepository) : IRoomService
    {
        public async Task<List<RoomResource>> GetAllRoomsAsync(int hotelId)
        {
            try
            {
                List<Room> roomList= await roomRepository.GetListAsync(u => u.HotelId==hotelId,
                                                                        u => u.Bookings);

                List<RoomResource> roomResourceList = MapperStorage.Mapper.Map<List<RoomResource>>(roomList);
                return roomResourceList;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<RoomResource> GetRoomResourceByIdAsync(string roomId)
        {
            try
            {
                int roomIdInt = IntTools.GetId(roomId, "RoomId is incorrect.");
                Room room = await roomRepository.GetFirstOrDefaultAsync(r => r.RoomId == roomIdInt,
                                                                        r => r.Bookings);
                RoomResource roomresource = MapperStorage.Mapper.Map<RoomResource>(room);
                return roomresource;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<List<RoomResource>> GetAvailableRoomsAsync(int hotelId, DateTime startDate, DateTime endDate)
        {
            try
            {
                List<Room> roomList = await roomRepository.GetAvailableRoomsAsync(hotelId, startDate, endDate);

                List<RoomResource> roomResourceList = MapperStorage.Mapper.Map<List<RoomResource>>(roomList);
                return roomResourceList;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
