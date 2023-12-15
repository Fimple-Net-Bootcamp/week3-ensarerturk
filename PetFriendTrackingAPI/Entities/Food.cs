namespace PetFriendTrackingAPI.Entities;

// The Food class represents a type of food that can be fed to pet animals.
public class Food
{
    // Unique identifier for the food item.
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public int Kalori { get; set; }
    public int Protein { get; set; }
    public int Oil { get; set; }
    public int Carbohydrate { get; set; }
    
    // Navigation property representing the relationship between Food and PetAnimalFood entities.
    public virtual List<PetAnimalFood> PetAnimalFoods { get; set; }
}