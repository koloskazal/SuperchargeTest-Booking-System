using DbConnection.CustomExceptions;
using DbConnection.db.Supercharge.Domain.DbRepositories;
using DbConnection.db.Supercharge.Model;
using DbConnection.Resources;
using DbConnection.Singleton;
using DbConnection.Tools;
using DbConnection.Tools.ResourceTools;
using SuperchargeTestApi.db.Supercharge.Domain.DbServices;

namespace SuperchargeTestApi.db.Supercharge.Persistance.DbServices
{
    public class HotelService(IHotelRepository bookingRepository) : IHotelService
    {
        
    }
}
