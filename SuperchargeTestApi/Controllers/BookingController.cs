using DbConnection.CustomExceptions;
using DbConnection.Resources;
using Microsoft.AspNetCore.Mvc;
using SuperchargeTestApi.Communication;
using SuperchargeTestApi.db.Supercharge.Domain.DbServices;

namespace SuperchargeTestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController(
        IBookingService bookingService,
        ILogger<BookingController> logger) : ControllerBase
    {

        [HttpPost("BookRoom")]
        public async Task<IActionResult> BookRoom([FromBody] BookingRequest bookingRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                BookingResult bookingResult = await bookingService.BookRoomAsync(bookingRequest);
                if (!bookingResult.Successfull )
                {
                    return NotFound($"Unable to book the room. Please check the details and try again. ({bookingResult.ErrorDescription})");
                }

                return Ok(bookingResult);
            }
            catch (EntityAlreadyExistsException e)
            {
                return Conflict(e.Message);
            }
            catch (Exception e)
            {
                logger.LogError(e, "An error occurred while booking a room.");
                return Problem(e.Message);
            }
        }

        [HttpDelete("CancelBooking/{bookingId}")]
        public async Task<IActionResult> CancelBooking(int bookingId)
        {
            if (bookingId <= 0)
            {
                return BadRequest("Invalid booking ID.");
            }

            try
            {
                BookingResult cancellationResult = await bookingService.CancelBookingAsync(bookingId);
                if (!cancellationResult.Successfull)
                {
                    return NotFound($"Unable to cancel the booking. Please check the booking ID and try again. ({cancellationResult.ErrorDescription})");
                }

                return Ok(cancellationResult);
            }
            catch (Exception e)
            {
                logger.LogError(e, "An error occurred while canceling the booking.");
                return Problem(e.Message);
            }
        }
    }
}
