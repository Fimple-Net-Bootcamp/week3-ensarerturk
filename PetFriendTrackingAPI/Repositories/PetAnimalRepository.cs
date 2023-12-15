using Microsoft.EntityFrameworkCore;
using PetFriendTrackingAPI.DBOperations;
using PetFriendTrackingAPI.Entities;
using PetFriendTrackingAPI.Repositories.Contracts;

namespace PetFriendTrackingAPI.Repositories;

// PetAnimalRepository class implements the IPetAnimalRepository interface.
public class PetAnimalRepository : IPetAnimalRepository
{
    private readonly PetDbContext _dbContext;

    // Constructor to inject the database context dependency.
    public PetAnimalRepository(PetDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    // Get all pet animals asynchronously.
    public async Task<IEnumerable<PetAnimal>> GetAllAsync()
    {
        // Return all pet animals from the database.
        return await _dbContext.PetAnimals.ToListAsync();
    }

    // Get a specific pet animal by its identifier asynchronously.
    public async Task<PetAnimal> GetByIdAsync(int petAnimalId)
    {
        // Return the pet animal with the specified identifier from the database.
        return await _dbContext.PetAnimals.FindAsync(petAnimalId);
    }

    // Add a new pet animal asynchronously.
    public async Task AddAsync(PetAnimal petAnimal)
    {
        // Add the new pet animal to the database and save changes.
        _dbContext.PetAnimals.Add(petAnimal);
        await _dbContext.SaveChangesAsync();
    }

    // Update an existing pet animal asynchronously.
    public async Task UpdateAsync(int petAnimalId, PetAnimal petAnimal)
    {
        // Find the existing pet animal in the database.
        var findAnimal = await _dbContext.PetAnimals.FindAsync(petAnimalId);

        // If the pet animal is found, update its properties and save changes.
        if (findAnimal != null)
        {
            findAnimal.Name = petAnimal.Name;
            findAnimal.Type = petAnimal.Type;
            findAnimal.BirthDate = petAnimal.BirthDate;
            findAnimal.UserId = petAnimal.UserId;
            await _dbContext.SaveChangesAsync();
        }
    }

    // Remove a pet animal by its identifier asynchronously.
    public async Task RemoveAsync(int petAnimalId)
    {
        // Find the pet animal in the database by its identifier.
        var evcilHayvan = await _dbContext.PetAnimals.FindAsync(petAnimalId);
        
        // If the pet animal is found, remove it from the database and save changes.
        if (evcilHayvan != null)
        {
            _dbContext.PetAnimals.Remove(evcilHayvan);
            await _dbContext.SaveChangesAsync();
            return;
        }
        
        // If the pet animal is not found, throw an exception indicating the failure.
        throw new BadHttpRequestException("The pet could not be deleted.");
    }
}