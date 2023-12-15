using PetFriendTrackingAPI.Entities;

namespace PetFriendTrackingAPI.Repositories.Contracts;

// This interface defines the contract for the repository responsible for managing food-related database operations.
public interface IFoodRepository
{
    // Retrieves all available food items from the database.
    Task<IEnumerable<Food>> GetAllAsync();
    // Retrieves a specific food item by its unique identifier.
    Task<Food> GetnByIdAsync(int foodId);
    // Adds a new food item to the database.
    Task AddAsync(Food besin);
    // Feeds a pet animal with a specific food item.
    Task GiveFoodAsync(int petAnimalId, string foodName);
    // Updates the information of an existing food item in the database.
    Task UpdateAsync(Food food);
    // Removes a specific food item from the database by its unique identifier.
    Task RemoveAsync(int foodId);
}