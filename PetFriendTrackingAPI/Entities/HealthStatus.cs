using System.ComponentModel.DataAnnotations.Schema;

namespace PetFriendTrackingAPI.Entities;

// The HealthStatus class represents the health status information for a pet animal.
public class HealthStatus
{
    public int Id { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    
    // Gets or sets the foreign key linking the health status entry to a specific pet animal.
    public int PetAnimalId { get; set; }
    
    // Gets or sets the navigation property representing the associated pet animal for this health status entry.
    [ForeignKey("PetAnimalId")]
    public virtual PetAnimal PetAnimal { get; set; }
}