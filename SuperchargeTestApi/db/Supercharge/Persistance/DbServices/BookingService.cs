using DbConnection.db.Supercharge.Domain.DbRepositories;
using DbConnection.db.Supercharge.Model;
using SuperchargeTestApi.Communication;
using SuperchargeTestApi.db.Supercharge.Domain.DbServices;

namespace SuperchargeTestApi.db.Supercharge.Persistance.DbServices
{
    public class BookingService(
        IBookingRepository bookingRepository,
        IRoomRepository roomRepository,
        IVisitorRepository visitorRepository

        ) : IBookingService
    {
        public async Task<BookingResult> BookRoomAsync(BookingRequest bookingRequest)
        {
            try
            {
                bool roomExists = await roomRepository.ExistsAsync(r => r.RoomId == bookingRequest.RoomId);
                if (!roomExists)
                {
                    return new BookingResult
                    {
                        Successfull = false,
                        ErrorDescription = "Room does not exist.",
                        BookingId = null
                    };
                }
                bool visitorExists = await visitorRepository.ExistsAsync(v => v.VisitorId == bookingRequest.VisitorId);
                if (!visitorExists)
                {
                    return new BookingResult
                    {
                        Successfull = false,
                        ErrorDescription = "Visitor does not exist.",
                        BookingId = null
                    };
                }
                Room room = await roomRepository.GetIfAvailableAsync(bookingRequest.RoomId, bookingRequest.StartDate, bookingRequest.EndDate);
                if (room == null)
                {
                    return new BookingResult
                    {
                        Successfull = false,
                        ErrorDescription = "Room is not available for the selected dates."
                    };
                }
                Booking booking = new()
                {
                    RoomId = bookingRequest.RoomId,
                    VisitorId = bookingRequest.VisitorId,
                    StartDate = bookingRequest.StartDate,
                    EndDate = bookingRequest.EndDate
                };

                Booking _ = await bookingRepository.InsertAsync(booking);
                return new BookingResult
                {
                    Successfull = true,
                    BookingId = booking.BookingId
                };
            }
            catch (Exception e)
            {
                //Todo: logging
                return new BookingResult
                {
                    Successfull = false,
                    ErrorDescription = "Unknow error. "
                };
            }

        }

        public async Task<BookingResult> CancelBookingAsync(int bookingId)
        {
            try
            {
                Booking booking = await bookingRepository.GetByIdAsync(bookingId);
                if (booking == null)
                {
                    return new BookingResult
                    {
                        Successfull = false,
                        ErrorDescription = "Booking does not exist."
                    };
                }
                bool deleted = await bookingRepository.DeleteAsync(booking);
                if (!deleted)
                {
                    return new BookingResult
                    {
                        Successfull = false,
                        ErrorDescription = "Unable to cancel the booking."
                    };
                }

                return new BookingResult
                {
                    Successfull = true
                };
            }
            catch (Exception)
            {
                return new BookingResult
                {
                    Successfull = false,
                    ErrorDescription = "Unable to cancel the booking."
                };
            }
        }
    }
}

