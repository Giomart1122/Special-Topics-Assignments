using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        Zoo zoo = new Zoo();
        Queue<string> eventQueue = new Queue<string>();

        // Read events from file
        using (StreamReader reader = new StreamReader("AS4 input2.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                eventQueue.Enqueue(line);
            }
        }

        // Process events
        while (eventQueue.Count > 0)
        {
            string eventLine = eventQueue.Dequeue();
            zoo.ProcessEvent(eventLine);
        }
    }
}

// Base Animal Class
abstract class Animal
{
    public string Name { get; }
    public string Classification { get; }
    public string FavoriteFood { get; }
    public int Strength { get; }
    public int BirthDay { get; }
    public int DeathDay { get; private set; } = 0;

    public bool IsAlive => DeathDay == 0;

    protected Animal(string name, string classification, string favoriteFood, int strength, int birthDay)
    {
        Name = name;
        Classification = classification;
        FavoriteFood = favoriteFood;
        Strength = strength;
        BirthDay = birthDay;
    }

    public void Die(int currentDay)
    {
        DeathDay = currentDay;
    }

    public virtual void Feed()
    {
        Console.WriteLine($"{Name} is eating {FavoriteFood}.");
    }

    public override string ToString()
    {
        return $"{Name} ({Classification}) - Food: {FavoriteFood}, Strength: {Strength}, Birth: {BirthDay}, Death: {DeathDay}";
    }
}

// Derived Classes for Each Animal Type
class Monkey : Animal
{
    public Monkey(int birthDay) : base("Monkey", "Mammal", "Banana", 100, birthDay) { }
}

class Lion : Animal
{
    public Lion(int birthDay) : base("Lion", "Mammal", "Deer", 200, birthDay) { }
}

class Alligator : Animal
{
    public Alligator(int birthDay) : base("Alligator", "Reptile", "Snakes", 250, birthDay) { }
}

class Predator : Animal
{
    public Predator(int birthDay) : base("Predator", "Extraterrestrial", "Everything", 10000, birthDay) { }

    public override void Feed()
    {
        Console.WriteLine($"Predator is eating EVERYTHING!");
    }
}

// Zoo Class to Manage Animals and Events
class Zoo
{
    private List<Animal> animals = new List<Animal>();
    private int currentDay = 0;

    public void ProcessEvent(string eventLine)
    {
        string[] parts = eventLine.Split(' ');

        switch (parts[0])
        {
            case "Birth":
                Birth(parts[1]);
                break;
            case "Feeding":
                Feeding();
                break;
            case "Sunrise":
                Sunrise();
                break;
            case "Death":
                Death(parts[1]);
                break;
            case "Fight":
                Fight(parts[1], parts[2]);
                break;
            case "Plague":
                Plague(parts[1]);
                break;
            case "Report":
                Report();
                break;
        }
    }

    private void Birth(string animalType)
    {
        Animal newAnimal = animalType switch
        {
            "Monkey" => new Monkey(currentDay),
            "Lion" => new Lion(currentDay),
            "Alligator" => new Alligator(currentDay),
            "Predator" => new Predator(currentDay),
            _ => null
        };

        if (newAnimal != null)
        {
            animals.Add(newAnimal);
            Console.WriteLine($"{newAnimal.Name} has been born!");
        }
    }

    private void Feeding()
    {
        foreach (var animal in animals)
        {
            if (animal.IsAlive)
            {
                animal.Feed();
            }
        }
    }

    private void Sunrise()
    {
        Console.WriteLine("\nA new day has begun.");
        currentDay++;
    }

    private void Death(string animalType)
    {
        var animal = animals.Find(a => a.Name == animalType && a.IsAlive);
        if (animal != null)
        {
            animal.Die(currentDay);
            Console.WriteLine($"{animalType} has died.");
        }
    }

    private void Fight(string animal1Type, string animal2Type)
    {
        var animal1 = animals.Find(a => a.Name == animal1Type && a.IsAlive);
        var animal2 = animals.Find(a => a.Name == animal2Type && a.IsAlive);

        if (animal1 != null && animal2 != null)
        {
            if (animal1.Strength > animal2.Strength)
            {
                animal2.Die(currentDay);
                Console.WriteLine($"{animal1Type} fought {animal2Type} and won! {animal2Type} is dead.");
            }
            else
            {
                animal1.Die(currentDay);
                Console.WriteLine($"{animal2Type} fought {animal1Type} and won! {animal1Type} is dead.");
            }
        }
    }

    private void Plague(string classification)
    {
        Console.WriteLine($"Plague breaks out among {classification} animals!");
        foreach (var animal in animals)
        {
            if (animal.Classification == classification && animal.IsAlive)
            {
                animal.Die(currentDay);
                Console.WriteLine($"{animal.Name} has died from the plague.");
            }
        }
    }

    private void Report()
    {
        Console.WriteLine("Zoo Report:");
        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
        }
    }
}







//Read Input Data
//FileStream stream = new FileStream("C:\\Users\\Gio\\Documents\\GitHub\\Special-Topics-Assignments\\Assignment4Project\\AS4 input2.txt", FileMode.Open);

///StreamReader reader = new StreamReader(stream);
//string inputString;

///inputString = reader.ReadLine();
//Console.WriteLine(inputString);


