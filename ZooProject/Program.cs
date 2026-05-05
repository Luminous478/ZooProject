using System;

class Program
{
    static void Main()
    {
        Zoo zoo = new Zoo();
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

            string choice = Console.ReadLine();

            // 1. Visa alla djur
            if (choice == "1")
            {
                var animals = zoo.GetAllAnimals();
                foreach (var animal in animals)
                {
                    Console.WriteLine(animal.GetInfo());
                }
            }

            // 2. Sök djur
            else if (choice == "2")
            {
                Console.WriteLine("\n--- SEARCH ---");
                Console.WriteLine("1. Species");
                Console.WriteLine("2. Diet");
                Console.WriteLine("3. Environment");
                Console.Write("Choose: ");

                string option = Console.ReadLine();

                if (option == "1")
                {
                    Console.Write("Enter species: ");
                    string value = Console.ReadLine();

                    var results = zoo.SearchBySpecies(value);

                    foreach (var a in results)
                        Console.WriteLine(a.GetInfo());
                }

                else if (option == "2")
                {
                    Console.WriteLine("0 = Herbivore");
                    Console.WriteLine("1 = Carnivore");
                    Console.WriteLine("2 = Omnivore");

                    int dietChoice = int.Parse(Console.ReadLine());
                    DietType diet = (DietType)dietChoice;

                    var results = zoo.SearchByDiet(diet);

                    foreach (var a in results)
                        Console.WriteLine(a.GetInfo());
                }

                else if (option == "3")
                {
                    Console.WriteLine("0 = Savanna");
                    Console.WriteLine("1 = Jungle");
                    Console.WriteLine("2 = Arctic");

                    int envChoice = int.Parse(Console.ReadLine());
                    EnvironmentType env = (EnvironmentType)envChoice;

                    var results = zoo.SearchByEnvironment(env);

                    foreach (var a in results)
                        Console.WriteLine(a.GetInfo());
                }
            }

            // 3. Mata djur
            else if (choice == "3")
            {
                Console.Write("Enter animal ID: ");
                int id = int.Parse(Console.ReadLine());

                var animal = zoo.GetAnimalById(id);

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

            // 4. Lägg till djur (MED ARV)
            else if (choice == "4")
            {
                Console.WriteLine("\n--- ADD ANIMAL ---");
                Console.WriteLine("1 = Mammal");
                Console.WriteLine("2 = Bird");
                Console.Write("Choose type: ");
                string type = Console.ReadLine();

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Species: ");
                string species = Console.ReadLine();

                Console.Write("Birth year: ");
                int year = int.Parse(Console.ReadLine());

                Console.WriteLine("Diet: 0=Herbivore, 1=Carnivore, 2=Omnivore");
                DietType diet = (DietType)int.Parse(Console.ReadLine());

                Console.WriteLine("Environment: 0=Savanna, 1=Jungle, 2=Arctic");
                EnvironmentType env = (EnvironmentType)int.Parse(Console.ReadLine());

                Console.Write("Life expectancy: ");
                int life = int.Parse(Console.ReadLine());

                Animal newAnimal;

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
                else
                {
                    Console.Write("Can fly (true/false): ");
                    bool canFly = bool.Parse(Console.ReadLine());

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
                Console.WriteLine("Animal added!");
            }

            // 5. Ta bort djur
            else if (choice == "5")
            {
                Console.Write("Enter ID: ");
                int id = int.Parse(Console.ReadLine());

                var animal = zoo.GetAnimalById(id);

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

            // 6. Avsluta
            else if (choice == "6")
            {
                Console.WriteLine("Saving animals...");
                SaveAnimals();
                Console.WriteLine("Exiting program.");
                break;
            }
        }
    }

    // Enkel "fake" save (för att matcha pseudokod)
    static void SaveAnimals()
    {
        Console.WriteLine("Animals saved (not really, just simulation).");
    }
}