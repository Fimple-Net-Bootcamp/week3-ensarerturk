using Microsoft.EntityFrameworkCore;
using PetFriendTrackingAPI.DBOperations;
using PetFriendTrackingAPI.Entities;
using PetFriendTrackingAPI.Repositories.Contracts;

namespace PetFriendTrackingAPI.Repositories;

// This class implements the IHealthStatusRepository interface, providing functionality for health status repository operations.
public class HealthStatusRepository : IHealthStatusRepository
{
    private readonly PetDbContext _dbContext;

    public HealthStatusRepository(PetDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Retrieves health status information by its unique identifier asynchronously.
    public async Task<HealthStatus> GetByIdAsync(int healthStatusId)
    {
        var petAnimal = await _dbContext.PetAnimals.FindAsync(healthStatusId);
    
        if (petAnimal != null)
        {
            return petAnimal.HealthStatus.FirstOrDefault();
        }

        return null;
    }

    // Adds a new health status entry based on the provided data asynchronously.
    public async Task AddSAsync(HealthStatus healthStatus)
    {
        _dbContext.HealthStatus.Add(healthStatus);
        await _dbContext.SaveChangesAsync();
    }

    // Updates an existing health status entry for a given pet animal asynchronously.
    public async Task UpdateAsync(int petAnimalId, HealthStatus healthStatus)
    {
        var evcilHayvan = await _dbContext.PetAnimals.FindAsync(petAnimalId);
    
        if (evcilHayvan != null)
        {
            foreach (var durumu in evcilHayvan.HealthStatus)
            {
                durumu.Description = healthStatus.Description;
                durumu.Date = healthStatus.Date;
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}