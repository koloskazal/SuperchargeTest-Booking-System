using DbConnection.CustomExceptions;
using DbConnection.Resources;
using Microsoft.AspNetCore.Mvc;
using SuperchargeTestApi.db.Supercharge.Domain.DbServices;

namespace SuperchargeTestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController(
        IRoomService roomService,
        ILogger<RoomController> logger) : ControllerBase
    {
        [HttpGet(Name = "GetRoom")]
        public async Task<IActionResult> Get([FromQuery(Name ="hotelid")] int hotelId)
        {
            List<RoomResource> resources = await roomService.GetAllRoomsAsync(hotelId);
            return Ok(resources);
        }

        [HttpGet("{roomId}")]
        public async Task<IActionResult> GetRoomById(string roomId)
        {
            RoomResource roomResource= await roomService.GetRoomResourceByIdAsync(roomId);
            if (roomResource == null)
            {
                return NotFound();
            }

            return Ok(roomResource);
        }

        [HttpGet("AvailableRooms")]
        public async Task<IActionResult> GetAvailableRooms([FromQuery] int hotelId, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            List<RoomResource> resources = await roomService.GetAvailableRoomsAsync(hotelId,startDate,endDate);
            return Ok(resources);
        }

    }
}
