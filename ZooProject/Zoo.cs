using System.Collections.Generic; 
using System.Linq; 

// Class that manages all animals in the zoo
class Zoo
{
    // List that stores all animals
    private List<Animal> animals = new List<Animal>();

    // Adds a new animal to the list
    public void AddAnimal(Animal animal)
    {
        animals.Add(animal);
    }

    // Removes an animal from the list
    public void RemoveAnimal(Animal animal)
    {
        animals.Remove(animal);
    }

    // Returns all animals in the zoo
    public List<Animal> GetAllAnimals()
    {
        return animals;
    }

    // Searches animals by species
    public List<Animal> SearchBySpecies(string species)
    {
        return animals
            .Where(a => a.Species.ToLower() == species.ToLower())
            .ToList();
    }

    // Searches animals by diet type
    public List<Animal> SearchByDiet(DietType diet)
    {
        return animals
            .Where(a => a.Diet == diet)
            .ToList();
    }

    // Searches animals by environment
    public List<Animal> SearchByEnvironment(EnvironmentType env)
    {
        return animals
            .Where(a => a.Environment == env)
            .ToList();
    }

    // Finds an animal by its id
    public Animal GetAnimalById(int id)
    {
        return animals.FirstOrDefault(a => a.Id == id);
    }
}