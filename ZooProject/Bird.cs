using System;

class Bird : Animal
{
    public bool CanFly { get; set; }

    public Bird(int id, string name, string species,
        DateTime birthDate,
        DietType diet,
        EnvironmentType environment,
        int lifeExpectancy,
        bool canFly)

        : base(id, name, species, birthDate, diet, environment, lifeExpectancy)
    {
        CanFly = canFly;
    }

    public override string GetInfo()
    {
        return base.GetInfo() +
               (CanFly ? " (Bird, can fly)" : " (Bird, cannot fly)");
    }
}