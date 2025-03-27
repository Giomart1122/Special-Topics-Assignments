using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create buildings
        List<Building> buildings = new List<Building>
        {
            new SingleFamilyHome("123 Main St"),
            new Warehouse("789 Industrial Rd"),
            new TownHome("456 Elm St"),
        //  new Office("4205 Main St"),     --Assignment doesnt ask for this building, but it works!
        //  new Factory("098 New St")       --Assignment doesnt ask for this building  but it works!
        };

        Console.WriteLine("Built a new single family home!");
        Console.WriteLine("Built a new warehouse!");
        Console.WriteLine("Bult a new Townhome!");

        // Turn on AC for all buildings
        foreach (var building in buildings)
        {
            building.TurnOnAC();
        }

        // Fire breakout simulation
        foreach (var building in buildings)
        {
            building.FireBreakout();
        }

        // Print building details
        foreach (var building in buildings)
        {
            Console.WriteLine(building);
        }
    }
}

// Base class
abstract class Building
{
    public string Address { get; }
    public string Color { get; protected set; }
    public int Doors { get; protected set; }
    public int Toilets { get; protected set; }
    public bool HasAC { get; protected set; }

    protected Building(string address)
    {
        Address = address;
    }

    public virtual void TurnOnAC()
    {
        if (HasAC)
            Console.WriteLine($"{GetType().Name} at {Address}: AC is now ON.");
        else
            Console.WriteLine($"{GetType().Name} at {Address} has no AC.");
    }

    public virtual void FireBreakout()
    {
        Console.WriteLine($"🔥 Fire at {GetType().Name} ({Address})! No automatic sprinkler system.");
    }

    public override string ToString()
    {
        return $"{GetType().Name} - Address: {Address}, Color: {Color}, Doors: {Doors}, Toilets: {Toilets}, AC: {HasAC}";
    }
}

// Residential Base Class
abstract class ResidentialBuilding : Building
{
    public bool HasSprinklers { get; } = true; // Only residential buildings have sprinklers

    protected ResidentialBuilding(string address) : base(address) { }

    public override void FireBreakout()
    {
        Console.WriteLine($"🔥 Fire at {GetType().Name} ({Address})! Sprinklers activated.");
    }
}

// Commercial Base Class
abstract class CommercialBuilding : Building
{
    protected CommercialBuilding(string address) : base(address) 
    {
        Color = "Grey";
    }

    public override void FireBreakout()
    {
        Console.WriteLine($"🔥 Fire at {GetType().Name} ({Address})! No sprinklers available. Building likely burned down.");
    }
}

// Specific Building Classes
class SingleFamilyHome : ResidentialBuilding
{
    public SingleFamilyHome(string address) : base(address)
    {
        Color = "Blue";
        Doors = 2;
        Toilets = 1;
        HasAC = true;
       // HasSprinklers = true;   --Redudant 
    }
}

class TownHome : ResidentialBuilding
{
    public TownHome(string address) : base(address)
    {
        Color = "Red";
        Doors = 1;
        Toilets = 4;
        HasAC = true;
      //  HasSprinklers = true;  --Redundant
    }
}

class Warehouse : CommercialBuilding
{
    public Warehouse(string address) : base(address)
    {
        Doors = 4;
        Toilets = 0;
        HasAC = false;
    }
}

class Office : CommercialBuilding
{
    public Office(string address) : base(address)
    {
        Doors = 4;
        Toilets = 0;
        HasAC = true;
    }
}

class Factory : CommercialBuilding
{
    public Factory(string address): base(address)
    {
        Doors = 6;
        Toilets= 2;
        HasAC = true;
    }
}