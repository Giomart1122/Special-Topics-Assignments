using System;

class Program
{
    static void Main()
    {
        string firstName = Console.ReadLine()?.Trim() ?? "";
        string lastName = Console.ReadLine()?.Trim() ?? "";
        string birthPlace = Console.ReadLine()?.Trim() ?? "";
        
        Console.WriteLine($"Hi, my name is {firstName} {lastName}, and I was born in {birthPlace}.");
        Console.WriteLine($"It is polite to write my name like this: {firstName.ToUpper()} {lastName.ToUpper()}.");
        Console.WriteLine($"My name is huge; it is {(firstName.Length + lastName.Length)} characters long!");
        
        string country = Console.ReadLine()?.Trim() ?? "";
        string capital = Console.ReadLine()?.Trim() ?? "";
        if (!decimal.TryParse(Console.ReadLine(), out decimal gdp)) gdp = 0;
        
        string capitalShort = capital.StartsWith("Para") ? capital[4..] : capital;
        Console.WriteLine($"Many of my friends were born in the country of {country}. Its capital is {capital}, but people call it: {capitalShort}.");
        
        Console.WriteLine($"My country is very wealthy, with a GDP of {gdp:C}.");
        
        Console.WriteLine($"My country is very wealthy, with a GDP of {gdp:C}.");
        Console.WriteLine($"We have 100000 citizens, and each generates {gdp / 100000:C} of the GDP output.");
        Console.WriteLine($"Each of us produces 30,000 widgets a year, for a total of {100000L * 30000L} widgets per year!");
        
        // Population of the world
        long worldPopulation = 8000000000; // Example value
        //Console.WriteLine($"Many of the world’s population of {worldPopulation} people will buy them!");
        
        // Friend's details
        string friendName = Console.ReadLine();
        byte friendAge = byte.Parse(Console.ReadLine());
        int q1 = int.Parse(Console.ReadLine());
        int q2 = int.Parse(Console.ReadLine());
        int q3 = int.Parse(Console.ReadLine());
        int q4 = int.Parse(Console.ReadLine());
        long totalWidgets = (long)q1 + q2 + q3 + q4;
        Console.WriteLine($"Name: {friendName} Age: {friendAge} Q1: {q1} Q2: {q2} Q3: {q3} Q4: {q4}. Total: {totalWidgets}");
        
        // Second friend
        byte secondFriendAge = byte.Parse(Console.ReadLine());
        Console.WriteLine($"Here is another friend, and he is {secondFriendAge} years old. They are a total of {(friendAge + secondFriendAge)} years old.");
        
        // String to number conversion
        string strNum1 = Console.ReadLine();
        string strNum2 = Console.ReadLine();
        
        if (int.TryParse(strNum1, out int num1))
            Console.WriteLine(num1);
        else
            Console.WriteLine("No, didn’t convert");
        
        if (int.TryParse(strNum2, out int num2))
            Console.WriteLine(num2);
        else
            Console.WriteLine("No, didn’t convert");
        
        // Tuples
        var actor1 = ("Leonardo DiCaprio", 49, "Inception");
        var actor2 = ("Emma Watson", 34, "Harry Potter");
        var actor3 = ("Chris Evans", 43, "Captain America");
        Console.WriteLine(actor1);
        Console.WriteLine(actor2);
        Console.WriteLine(actor3);
        
        // Integer Tuples
        var tuple1 = (4, 7);
        var tuple2 = (10, 5);
        Console.WriteLine($"Tuple1: {tuple1}, Tuple2: {tuple2}");
        Console.WriteLine($"Sum: ({tuple1.Item1 + tuple2.Item1}, {tuple1.Item2 + tuple2.Item2})");
        Console.WriteLine($"Product: ({tuple1.Item1 * tuple2.Item1}, {tuple1.Item2 * tuple2.Item2})");
        
        // Cat Breeds Array
        string[] catBreeds = { "Persian", "Maine Coon", "Siamese", "Bengal", "Sphynx", "British Shorthair", "Abyssinian", "Scottish Fold", "Ragdoll" };
        Console.WriteLine(string.Join(", ", catBreeds));
        Console.WriteLine(string.Join(", ", catBreeds[2..5]));
    }
}
