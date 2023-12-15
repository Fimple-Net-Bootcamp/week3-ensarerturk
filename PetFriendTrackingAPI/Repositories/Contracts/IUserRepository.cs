using PetFriendTrackingAPI.Entities;

namespace PetFriendTrackingAPI.Repositories.Contracts;

public interface IUserRepository
{
    // Asynchronously retrieves all users
    Task<IEnumerable<User>> GetAllAsync();
    // Asynchronously retrieves a user by Id
    Task<User> GetByIdAsync(int userId);
    // Asynchronously adds a new user
    Task AddAsync(User user);
    // Asynchronously removes a user by Id
    Task RemoveAsync(int userId);
}