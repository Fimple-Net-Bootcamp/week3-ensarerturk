using Microsoft.EntityFrameworkCore;
using PetFriendTrackingAPI.DBOperations;
using PetFriendTrackingAPI.DTO;
using PetFriendTrackingAPI.Entities;
using PetFriendTrackingAPI.Repositories.Contracts;

namespace PetFriendTrackingAPI.Repositories;

public class ActivityRepository : IActivityRepository
{
    private readonly PetDbContext _dbContext;

    public ActivityRepository(PetDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // GetAllAsync method retrieves all activities from the database.
    public async Task<IEnumerable<Activity>> GetAllAsync()
    {
        return await _dbContext.Activities.ToListAsync();
    }

    // GetByPetAnimalIdAsync method retrieves activities by pet animal Id from the database.
    public async Task<Activity> GetByPetAnimalIdAsync(int petAnimalId)
    {
        var petAnimal = await _dbContext.PetAnimals.FindAsync(petAnimalId);
    
        // Return the first activity associated with the pet animal.
        return petAnimal != null ? petAnimal.Activities.FirstOrDefault() : null;
    }

    // AddAsync method adds a new activity to the database.
    public async Task AddAsync(Activity activity)
    {
        _dbContext.Activities.Add(activity);
        await _dbContext.SaveChangesAsync();
    }
    
    // RemoveAsync method removes an activity by Id from the database.
    public async Task RemoveAsync(int activityId)
    {
        var activity = await _dbContext.Activities.FindAsync(activityId);
        if (activity != null)
        {
            _dbContext.Activities.Remove(activity);
            await _dbContext.SaveChangesAsync();
        }
        
        throw new BadHttpRequestException("Unable to delete activity.");
    }
}