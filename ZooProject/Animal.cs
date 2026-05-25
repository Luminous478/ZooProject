using System;

// Class for all animals in the program
class Animal
{
    
    public int Id { get; set; }

    public string Name { get; set; }

    
    public string Species { get; set; }

    
    public DateTime BirthDate { get; set; }

    
    public DietType Diet { get; set; }

    
    public EnvironmentType Environment { get; set; }

    
    public int LifeExpectancy { get; set; }

  
    public DateTime LastFed { get; set; }

    // Constructor used when creating a new animal
    public Animal(int id, string name, string species,
        DateTime birthDate,
        DietType diet,
        EnvironmentType environment,
        int lifeExpectancy)
    {
        // Save values into the object
        Id = id;
        Name = name;
        Species = species;
        BirthDate = birthDate;
        Diet = diet;
        Environment = environment;
        LifeExpectancy = lifeExpectancy;

        // Sets the animal as fed 10 hours ago
        LastFed = DateTime.Now.AddHours(-10);
    }

    // Returns information about the animal as text
    public virtual string GetInfo()
    {
        return $"ID: {Id}, Name: {Name}, Species: {Species}, Age: {GetAge(DateTime.Now)}";
    }

    // Updates the feeding time
    public void Feed()
    {
        LastFed = DateTime.Now;
    }

    // Checks if the animal needs food
    public bool NeedsFeeding(DateTime currentTime)
    {
        // Returns true if more than 8 hours have passed
        return (currentTime - LastFed).TotalHours > 8;
    }

    // Checks if the animal is still alive
    public bool IsAlive(DateTime currentDate)
    {
        // Returns true if the animal's age is less than life expectancy
        return GetAge(currentDate) < LifeExpectancy;
    }

    // Calculates the animal's age
    public int GetAge(DateTime currentDate)
    {
        return currentDate.Year - BirthDate.Year;
    }
}