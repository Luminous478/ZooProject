using System.Collections.Generic;
using System.Linq;

class Zoo
{
    private List<Animal> animals = new List<Animal>();

    public void AddAnimal(Animal animal)
    {
        animals.Add(animal);
    }

    public void RemoveAnimal(Animal animal)
    {
        animals.Remove(animal);
    }

    public List<Animal> GetAllAnimals()
    {
        return animals;
    }

    public List<Animal> SearchBySpecies(string species)
    {
        return animals
            .Where(a => a.Species.ToLower() == species.ToLower())
            .ToList();
    }

    public List<Animal> SearchByDiet(DietType diet)
    {
        return animals
            .Where(a => a.Diet == diet)
            .ToList();
    }

    public List<Animal> SearchByEnvironment(EnvironmentType env)
    {
        return animals
            .Where(a => a.Environment == env)
            .ToList();
    }

    public Animal GetAnimalById(int id)
    {
        return animals.FirstOrDefault(a => a.Id == id);
    }
}