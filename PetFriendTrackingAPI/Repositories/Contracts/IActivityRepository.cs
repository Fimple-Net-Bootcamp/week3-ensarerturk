using PetFriendTrackingAPI.Entities;

namespace PetFriendTrackingAPI.Repositories.Contracts;

// IActivityRepository interface defines the contract for activity-related database operations.
public interface IActivityRepository
{
    // Get all activities from the database asynchronously.
    Task<IEnumerable<Activity>> GetAllAsync();
    // Get activities by pet animal Id from the database asynchronously.
    Task<Activity> GetByPetAnimalIdAsync(int petAnimalId);
    // Add a new activity to the database asynchronously.
    Task AddAsync(Activity activity);
    // Remove an activity by Id from the database asynchronously.
    Task RemoveAsync(int activityId);
}