using System;
internal class Program{
    private static void Main(){
    
        string firstName = Console.ReadLine()?.Trim() ?? "Rob";
        string lastName = Console.ReadLine()?.Trim() ?? "Greenberg";
        string birthPlace = Console.ReadLine()?.Trim() ?? "Belize";
        
        Console.WriteLine($"Hi, my name is {firstName} {lastName}, and I was born in {birthPlace}.");
        Console.WriteLine($"It is polite to write my name like this: {firstName.ToUpper()} {lastName.ToUpper()}.");
        Console.WriteLine($"My name is huge; it is {(firstName.Length + lastName.Length)} characters long!");
        Console.WriteLine();
        
        string country = Console.ReadLine()?.Trim() ?? "Georgia";
        string capital = Console.ReadLine()?.Trim() ?? "Paraquat";
        long gdp = long.Parse(Console.ReadLine() ?? "10000000000");
        
        string capitalShort = capital.StartsWith("Para") ? capital[4..] : capital;
        Console.WriteLine($"Many of my friends were born in the country of {country}. Its capital is {capital}, but people call it: {capitalShort}.");
        
        //Country Talk
        Console.Write($"My country is very wealthy, with a GDP of {gdp:C}.");
        Console.Write($"We have 100000 citizens, and each generates {gdp / 100000:C} of the GDP output.");
        Console.Write($" Each of us produces 30,000 widgets a year, for a total of {100000L * 30000L} widgets per year!");
        long worldPop = 7888000000;
        Console.WriteLine($" Many of the world's population of {worldPop} people will buy them!");
        Console.WriteLine();
        // Friend's details
        string friendName = Console.ReadLine();
        byte friendAge = byte.Parse(Console.ReadLine());
        int q1 = int.Parse(Console.ReadLine());
        int q2 = int.Parse(Console.ReadLine());
        int q3 = int.Parse(Console.ReadLine());
        int q4 = int.Parse(Console.ReadLine());
        long totalWidgets = (long)q1 + q2 + q3 + q4;
        Console.WriteLine($"Name: {friendName} Age: {friendAge} Q1: {q1} Q2: {q2} Q3: {q3} Q4: {q4} Total: {totalWidgets}");
        Console.WriteLine();
        
        // Second friend
        byte secondFriendAge = byte.Parse(Console.ReadLine());
        Console.WriteLine($"Here is another friend, and he is {secondFriendAge} years old. They are a total of {(friendAge + secondFriendAge)} years old.");
        Console.WriteLine();
        
        // String to number conversion
        string strNum1 = Console.ReadLine();
        string strNum2 = Console.ReadLine();
        
        if (int.TryParse(strNum1, out int num1))
            Console.WriteLine($"Is this string {strNum1} a number? {strNum1}");
        else
            Console.WriteLine("No, didn’t convert");
        
        if (int.TryParse(strNum2, out int num2))
            Console.WriteLine(num2);
        else
            Console.WriteLine($"Is this string {strNum2} a number? No, didn’t convert");
            Console.WriteLine();
        
        // Tuples
        var actor1 = "Actor 1: (James Earl Jones, 93, Star Wars)";
        var actor2 = "Actor 2: (William Shatner, 92, Star Trek)";
        var actor3 = "Actor 3: (Edward James Olmos, 76, Battlestar Galatica)";
        Console.WriteLine(actor1);
        Console.WriteLine(actor2);
        Console.WriteLine(actor3);
        Console.WriteLine();
        
        // Integer Tuples
        var tuple1 = (29, 6);
        var tuple2 = (23, 9);
        Console.WriteLine($"The sum and product of tuples 1: {tuple1} and 2: {tuple2} are {tuple1.Item1 + tuple2.Item1 + tuple1.Item2 + tuple2.Item2} and {tuple1.Item1 * tuple2.Item1 * tuple1.Item2 * tuple2.Item2}");
        Console.WriteLine();
        
        // Cat Breeds Array
        string[] catBreeds = { "Siamese", "British Shorthair", "Maine Coon", "Persian", "Ragdoll", "Sphynx", "Abyssinian", "American Shorthair", "Burmese" };
        Console.WriteLine($"My cats: {string.Join(", ", catBreeds)}");
        Console.WriteLine();
        Console.Write($"The 3rd through 5th cats: ");
        Console.WriteLine(string.Join(", ", catBreeds[2..5]));
    
    }
}
