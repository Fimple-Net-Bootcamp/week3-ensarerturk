using System.ComponentModel.DataAnnotations.Schema;

namespace PetFriendTrackingAPI.Entities;

// The PetAnimalFood class represents the association between a pet animal and the food it consumes in the system.
public class PetAnimalFood
{
    public int Id { get; set; }
    
    // Gets or sets the identifier of the pet animal associated with this food entry.
    public int PetAnimalId { get; set; }
    // Gets or sets the navigation property representing the pet animal associated with this food entry.

    [ForeignKey("PetAnimalId")]
    public virtual PetAnimal PetAnimal { get; set; }

    // Gets or sets the identifier of the food associated with this entry.
    public int FoodId { get; set; }
    // Gets or sets the navigation property representing the food associated with this entry.
    [ForeignKey("FoodId")]
    public virtual Food Food { get; set; }

    // Gets or sets the amount of food consumed by the pet animal.
    public int Amount { get; set; }
}