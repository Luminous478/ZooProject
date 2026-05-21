using System;

class Mammal : Animal
{
    public Mammal(int id, string name, string species,
        DateTime birthDate,
        DietType diet,
        EnvironmentType environment,
        int lifeExpectancy)

        : base(id, name, species, birthDate, diet, environment, lifeExpectancy)
    {
    }

    public override string GetInfo()
    {
        return base.GetInfo() + " (Mammal)";
    }
}