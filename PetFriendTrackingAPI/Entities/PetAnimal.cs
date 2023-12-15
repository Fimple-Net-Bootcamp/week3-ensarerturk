using System.ComponentModel.DataAnnotations.Schema;

namespace PetFriendTrackingAPI.Entities;

// The PetAnimal class represents a pet animal entity in the system.
public class PetAnimal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public DateTime BirthDate { get; set; } = DateTime.UtcNow;
    
    // Gets or sets the user identifier associated with the pet animal.
    public int UserId { get; set; }
    
    // Gets or sets the User navigation property representing the owner of the pet animal.
    [ForeignKey("UserId")]
    public virtual User User { get; set; }
    
    // Gets or sets the list of health statuses associated with the pet animal.
    public virtual List<HealthStatus> HealthStatus { get; set; }
    // Gets or sets the list of activities associated with the pet animal.
    public virtual List<Activity> Activities { get; set; }
    // Gets or sets the list of pet animal foods associated with the pet animal.
    public virtual List<PetAnimalFood> PetAnimalFoods { get; set; }
}