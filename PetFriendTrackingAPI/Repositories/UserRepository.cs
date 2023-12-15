using Microsoft.EntityFrameworkCore;
using PetFriendTrackingAPI.DBOperations;
using PetFriendTrackingAPI.Entities;
using PetFriendTrackingAPI.Repositories.Contracts;

namespace PetFriendTrackingAPI.Repositories;

public class UserRepository : IUserRepository
{
    private readonly PetDbContext _dbContext;

    // Constructor with dependency injection
    public UserRepository(PetDbContext dbContext)
    {
        // Initializes the database context dependency
        _dbContext = dbContext;
    }
    
    // Asynchronously retrieves all users
    public async Task<IEnumerable<User>> GetAllAsync()
    {
        // Retrieves all users from the database
        return await _dbContext.Users.ToListAsync();
    }

    // Asynchronously retrieves a user by Id
    public async Task<User> GetByIdAsync(int userId)
    {
        // Retrieves a user by Id from the database
        return await _dbContext.Users.FindAsync(userId);
    }

    // Asynchronously adds a new user
    public async Task AddAsync(User user)
    {
        // Adds a new user to the database
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
    }

    // Asynchronously removes a user by Id
    public async Task RemoveAsync(int userId)
    {
        // Retrieves and removes a user by Id from the database
        var kullanici = await _dbContext.Users.FindAsync(userId);
        if (kullanici != null)
        {
            _dbContext.Users.Remove(kullanici);
            await _dbContext.SaveChangesAsync();
        }
        
        // Throws an exception if the user could not be deleted
        throw new BadHttpRequestException("User could not be deleted.");
    }
}