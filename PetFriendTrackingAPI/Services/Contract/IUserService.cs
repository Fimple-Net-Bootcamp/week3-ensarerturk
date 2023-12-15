using PetFriendTrackingAPI.DTO;

namespace PetFriendTrackingAPI.Services.Contract;

public interface IUserService
{
    // Asynchronously retrieves all users
    Task<IEnumerable<GetUserDTO>> GetAllAsync();
    // Asynchronously retrieves a user by Id
    Task<GetUserDTO> GetByIdAsync(int userId);
    // Asynchronously adds a new user
    Task AddAsync(PostUserDTO user);
    // Asynchronously removes a user by Id
    Task RemoveAsync(int userId);
}