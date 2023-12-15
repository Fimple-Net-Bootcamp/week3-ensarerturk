using Microsoft.EntityFrameworkCore;
using PetFriendTrackingAPI.Entities;

namespace PetFriendTrackingAPI.DBOperations;

// The PetDbContext class represents the database context for the Pet Friend Tracking system.
public class PetDbContext : DbContext
{
    // Initializes a new instance of the PetDbContext class with the specified options.
    public PetDbContext(DbContextOptions options) : base(options)
    {
    }

    // Configures the context to use lazy loading proxies for related entities.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }
    
    // Gets or sets the DbSet for the User entities in the database.
    public DbSet<User> Users { get; set; }

    // Gets or sets the DbSet for the PetAnimal entities in the database.
    public DbSet<PetAnimal> PetAnimals { get; set; }

    // Gets or sets the DbSet for the HealthStatus entities in the database.
    public DbSet<HealthStatus> HealthStatus { get; set; }

    // Gets or sets the DbSet for the Activity entities in the database.
    public DbSet<Activity> Activities { get; set; }

    // Gets or sets the DbSet for the Food entities in the database.
    public DbSet<Food> Foods { get; set; }

    // Gets or sets the DbSet for the PetAnimalFood entities in the database.
    public DbSet<PetAnimalFood> PetAnimalFoods { get; set; }
}