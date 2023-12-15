using Microsoft.AspNetCore.Mvc;
using PetFriendTrackingAPI.DTO;
using PetFriendTrackingAPI.Services.Contract;

namespace PetFriendTrackingAPI.Controllers;

[Route("api/v1/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    
    // Constructor with dependency injection
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    // Get all users
    [HttpGet("users/")]
    public async Task<ActionResult<IEnumerable<GetUserDTO>>> GetAll()
    {
        try
        {
            // Retrieve all users from the service
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }
        catch (Exception ex)
        {
            // Handle exceptions and return a bad request response
            return BadRequest(ex.Message);
        }
    }
    
    // Get user by Id
    [HttpGet("users/{userId}")]
    public async Task<ActionResult<GetUserDTO>> GetById(int userId)
    {
        try
        {
            // Retrieve user by Id from the service
            var user = await _userService.GetByIdAsync(userId);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    // Create a new user
    [HttpPost("users/")]
    public async Task<ActionResult> Post([FromBody] PostUserDTO user)
    {
        try
        {
            // Add a new user using the service
            await _userService.AddAsync(user);
            return CreatedAtAction(nameof(GetById), new { userId = user.Name }, user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    // Delete user by Id
    [HttpDelete("users/{userId}")]
    public async Task<ActionResult> Delete(int userId)
    {
        try
        {
            // Remove user by Id using the service
            await _userService.RemoveAsync(userId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}