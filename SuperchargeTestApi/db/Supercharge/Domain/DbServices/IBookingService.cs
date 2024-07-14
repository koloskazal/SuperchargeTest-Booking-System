using DbConnection.Resources;
using SuperchargeTestApi.Communication;

namespace SuperchargeTestApi.db.Supercharge.Domain.DbServices
{
    public interface IBookingService
    {
        Task<BookingResult> BookRoomAsync(BookingRequest bookingRequest);
        Task<BookingResult> CancelBookingAsync(int bookingId);
    }
}
