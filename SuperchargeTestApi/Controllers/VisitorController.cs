using DbConnection.CustomExceptions;
using DbConnection.Resources;
using Microsoft.AspNetCore.Mvc;
using SuperchargeTestApi.db.Supercharge.Domain.DbServices;

namespace SuperchargeTestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VisitorController(
        IUserService userService, 
        IVisitorService visitorService,
        ILogger<VisitorController> logger) : ControllerBase
    {

        [HttpGet(Name = "GetVisitor")]
        public async Task<IActionResult> Get()
        {
            List<VisitorResource> resources = await visitorService.GetAllVisitorsAsync();
            return Ok(resources);
        }

        [HttpGet("{visitorId}")]
        public async Task<IActionResult> GetVisitorById(string visitorId)
        {
            VisitorResource visitorResource = await visitorService.GetVisitorResourceByIdAsync(visitorId);
            if (visitorResource == null)
            {
                return NotFound();
            }

            return Ok(visitorResource);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVisitor([FromBody] VisitorResource createVisitorResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                VisitorResource userResource = await visitorService.AddVisitorAsync(createVisitorResource);
                return CreatedAtAction(nameof(GetVisitorById), new { visitorId = userResource.VisitorId }, userResource);
            }
            catch (EntityAlreadyExistsException e)
            {
                return Conflict(e.Message);
            }
            catch (Exception e)
            {
                logger.LogError(e, "An error occurred while creating a new visitor.");
                return Problem(e.Message);
            }
        }


        [HttpPut("{visitorId}")]
        public async Task<IActionResult> EditVisitor(string visitorId, [FromBody] UserResource updateUserResource)
        {
            if (!ModelState.IsValid || visitorId != updateUserResource.UserId.ToString())
            {
                return BadRequest(ModelState);
            }

            try
            {
                UserResource updatedUserResource = await userService.UpdateUserAsync(visitorId, updateUserResource);
                return Ok(updatedUserResource);
            }
            catch (InvalidOperationException e)
            {
                return Conflict(e.Message);
            }
            catch (EntityAlreadyExistsException e)
            {
                return Conflict(e.Message);
            }
            catch (Exception e)
            {
                logger.LogError(e, $"An error occurred while updating the visitor with ID {visitorId}.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the visitor.");
            }
        }
    }
}
