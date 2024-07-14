using DbConnection.CustomExceptions;
using DbConnection.Resources;
using Microsoft.AspNetCore.Mvc;
using SuperchargeTestApi.db.Supercharge.Domain.DbServices;

namespace SuperchargeTestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController(IUserService userService, ILogger<UserController> logger) : ControllerBase
    {

        [HttpGet(Name = "GetUser")]
        public async Task<IActionResult> Get()
        {
            List<UserResource> resources = await userService.GetAllUsersAsync();
            return Ok(resources);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(string userId)
        {
            UserResource userResource = await userService.GetUserResourceByIdAsync(userId);
            if (userResource == null)
            {
                return NotFound();
            }

            return Ok(userResource);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserResource createUserResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                UserResource userResource = await userService.AddUserAsync(createUserResource);
                return CreatedAtAction(nameof(GetUserById), new { userId = userResource.UserId }, userResource);
            }
            catch (EntityAlreadyExistsException e)
            {
                return Conflict(e.Message);
            }
            catch (Exception e)
            {
                logger.LogError(e, "An error occurred while creating a new user.");
                return Problem(e.Message);
            }
        }


        [HttpPut("{userId}")]
        public async Task<IActionResult> EditUser(string userId, [FromBody] UserResource updateUserResource)
        {
            if (!ModelState.IsValid || userId != updateUserResource.UserId.ToString())
            {
                return BadRequest(ModelState);
            }

            try
            {
                UserResource updatedUserResource = await userService.UpdateUserAsync(userId, updateUserResource);
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
                logger.LogError(e, "An error occurred while updating the user with ID {UserId}.", userId);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the user.");
            }
        }
    }
}
