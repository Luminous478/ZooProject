using System;

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

    public Animal(int id, string name, string species,
        DateTime birthDate,
        DietType diet,
        EnvironmentType environment,
        int lifeExpectancy)
    {
        Id = id;
        Name = name;
        Species = species;
        BirthDate = birthDate;
        Diet = diet;
        Environment = environment;
        LifeExpectancy = lifeExpectancy;

        LastFed = DateTime.Now.AddHours(-10);
    }

    public virtual string GetInfo()
    {
        return $"ID: {Id}, Name: {Name}, Species: {Species}, Age: {GetAge(DateTime.Now)}";
    }

    public void Feed()
    {
        LastFed = DateTime.Now;
    }

    public bool NeedsFeeding(DateTime currentTime)
    {
        return (currentTime - LastFed).TotalHours > 8;
    }

    public bool IsAlive(DateTime currentDate)
    {
        return GetAge(currentDate) < LifeExpectancy;
    }

    public int GetAge(DateTime currentDate)
    {
        return currentDate.Year - BirthDate.Year;
    }
}