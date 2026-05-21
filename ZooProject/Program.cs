using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Zoo zoo = new Zoo();

        // load asved animals
        LoadAnimals(zoo);

        int idCounter = 1;

        while (true)
        {
            Console.WriteLine("\n--- ZOO SYSTEM ---");
            Console.WriteLine("1. Show all animals");
            Console.WriteLine("2. Search animals");
            Console.WriteLine("3. Feed an animal");
            Console.WriteLine("4. Add new animal");
            Console.WriteLine("5. Remove an animal");
            Console.WriteLine("6. Exit");

            Console.Write("Choose: ");
            string choice = Console.ReadLine();

            // SHOW ALL ANIMALS
            if (choice == "1")
            {
                var animals = zoo.GetAllAnimals();

                foreach (var animal in animals)
                {
                    Console.WriteLine(animal.GetInfo());
                }
            }

            // SEARCH ANIMALS
            else if (choice == "2")
            {
                Console.WriteLine("\n--- SEARCH ---");
                Console.WriteLine("1. Species");
                Console.WriteLine("2. Diet");
                Console.WriteLine("3. Environment");

                Console.Write("Choose: ");
                string option = Console.ReadLine();

                // SEARCH BY SPECIES
                if (option == "1")
                {
                    Console.Write("Enter species: ");
                    string value = Console.ReadLine();

                    var results = zoo.SearchBySpecies(value);

                    foreach (var animal in results)
                    {
                        Console.WriteLine(animal.GetInfo());
                    }
                }

                // SEARCH BY DIET
                else if (option == "2")
                {
                    Console.WriteLine("0 = Herbivore");
                    Console.WriteLine("1 = Carnivore");
                    Console.WriteLine("2 = Omnivore");

                    Console.Write("Choose diet: ");

                    int dietChoice = int.Parse(Console.ReadLine());

                    DietType diet = (DietType)dietChoice;

                    var results = zoo.SearchByDiet(diet);

                    foreach (var animal in results)
                    {
                        Console.WriteLine(animal.GetInfo());
                    }
                }

                // SEARCH BY ENVIRONMENT
                else if (option == "3")
                {
                    Console.WriteLine("0 = Savanna");
                    Console.WriteLine("1 = Jungle");
                    Console.WriteLine("2 = Arctic");

                    Console.Write("Choose environment: ");

                    int envChoice = int.Parse(Console.ReadLine());

                    EnvironmentType env = (EnvironmentType)envChoice;

                    var results = zoo.SearchByEnvironment(env);

                    foreach (var animal in results)
                    {
                        Console.WriteLine(animal.GetInfo());
                    }
                }
            }

            // FEED AN ANIMAL
            else if (choice == "3")
            {
                Console.Write("Enter animal ID: ");

                int id = int.Parse(Console.ReadLine());

                Animal animal = zoo.GetAnimalById(id);

                if (animal != null)
                {
                    if (animal.NeedsFeeding(DateTime.Now))
                    {
                        animal.Feed();

                        Console.WriteLine("Animal has been fed.");
                    }
                    else
                    {
                        Console.WriteLine("Animal does not need feeding yet.");
                    }
                }
                else
                {
                    Console.WriteLine("Animal not found.");
                }
            }

            // ADD NEW ANIMAL
            else if (choice == "4")
            {
                Console.WriteLine("\n--- ADD ANIMAL ---");

                Console.WriteLine("Choose animal class:");
                Console.WriteLine("1. Mammal (Lion, Elephant, Tiger)");
                Console.WriteLine("2. Bird (Eagle, Penguin, Owl)");

                Console.Write("Enter choice: ");

                string type = Console.ReadLine();

                Console.Write("Enter species (example: Lion): ");
                string species = Console.ReadLine();

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Birth year: ");
                int year = int.Parse(Console.ReadLine());

                Console.WriteLine("Diet:");
                Console.WriteLine("0 = Herbivore");
                Console.WriteLine("1 = Carnivore");
                Console.WriteLine("2 = Omnivore");

                DietType diet =
                    (DietType)int.Parse(Console.ReadLine());

                Console.WriteLine("Environment:");
                Console.WriteLine("0 = Savanna");
                Console.WriteLine("1 = Jungle");
                Console.WriteLine("2 = Arctic");

                EnvironmentType env =
                    (EnvironmentType)int.Parse(Console.ReadLine());

                Console.Write("Life expectancy: ");
                int life = int.Parse(Console.ReadLine());

                Animal newAnimal;

                // CREATE MAMMAL
                if (type == "1")
                {
                    newAnimal = new Mammal(
                        idCounter++,
                        name,
                        species,
                        new DateTime(year, 1, 1),
                        diet,
                        env,
                        life
                    );
                }

                // CREATE BIRD
                else
                {
                    Console.Write("Can fly (true/false): ");

                    bool canFly =
                        bool.Parse(Console.ReadLine());

                    newAnimal = new Bird(
                        idCounter++,
                        name,
                        species,
                        new DateTime(year, 1, 1),
                        diet,
                        env,
                        life,
                        canFly
                    );
                }

                zoo.AddAnimal(newAnimal);

                Console.WriteLine("Animal added.");
            }

            // REMOVE ANIMAL
            else if (choice == "5")
            {
                Console.Write("Enter ID: ");

                int id = int.Parse(Console.ReadLine());

                Animal animal = zoo.GetAnimalById(id);

                if (animal != null)
                {
                    zoo.RemoveAnimal(animal);

                    Console.WriteLine("Animal removed.");
                }
                else
                {
                    Console.WriteLine("Animal not found.");
                }
            }

            // EXIT
            else if (choice == "6")
            {
                Console.WriteLine("Saving animals...");

                SaveAnimals(zoo);

                Console.WriteLine("Exiting program.");

                break;
            }

            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
    }

    // SAVE TO JSON FILE
    static void SaveAnimals(Zoo zoo)
    {
        string json =
            JsonSerializer.Serialize(zoo.GetAllAnimals());

        File.WriteAllText("animals.json", json);

        Console.WriteLine("Animals saved.");
    }

    // LOAD FROM JSON FILE
    static void LoadAnimals(Zoo zoo)
    {
        if (File.Exists("animals.json"))
        {
            string json =
                File.ReadAllText("animals.json");

            List<Animal> animals =
                JsonSerializer.Deserialize<List<Animal>>(json);

            foreach (Animal animal in animals)
            {
                zoo.AddAnimal(animal);
            }

            Console.WriteLine("Animals loaded.");
        }
    }
}