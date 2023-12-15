using System.ComponentModel.DataAnnotations.Schema;

namespace PetFriendTrackingAPI.Entities;

// The Activity class represents an activity associated with a pet animal in the system.
public class Activity
{
    // The unique identifier for the activity.
    public int Id { get; set; }
    public string Type { get; set; }
    public DateTime StartDate { get; set; } = DateTime.UtcNow;
    public DateTime EndDate { get; set; } = DateTime.UtcNow;
    
    // The foreign key referencing the associated pet animal's Id.
    public int PetAnimalId { get; set; }
    
    // The navigation property representing the associated pet animal.
    [ForeignKey("PetAnimalId")]
    public virtual PetAnimal PetAnimal { get; set; }
}