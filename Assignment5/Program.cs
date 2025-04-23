using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static Random rnd = new Random();
    static int questionCount = 4;

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Write("Press 'P' to Play or 'E' to Exit: ");
            char choice = Char.ToLower(Console.ReadKey(true).KeyChar);
            Console.WriteLine();

            if (choice == 'e') break;
            if (choice == 'p') StartGame();
        }
    }

    static void StartGame()
    {
        for (int i = 0; i < questionCount; i++)
        {
            int a = rnd.Next(1, 11);
            int b = rnd.Next(1, 11);
            int correctAnswer = a * b;

            Console.WriteLine($"\nQuestion {i + 1}: What is {a} * {b}?");
            DateTime questionStart = DateTime.Now;

            // Set up opponent threads
            List<(string Name, int Answer, DateTime Time)> opponentResults = new List<(string, int, DateTime)>();
            Thread t1 = new Thread(() => Opponent("Thread 1", correctAnswer, opponentResults));
            Thread t2 = new Thread(() => Opponent("Thread 2", correctAnswer, opponentResults));
            t1.Start();
            t2.Start();

            // Get user's input char-by-char
            string userInput = "";
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter) break;
                if (char.IsDigit(key.KeyChar)) userInput += key.KeyChar;
            }

            DateTime userTime = DateTime.Now;
            int userAnswer = int.TryParse(userInput, out int parsed) ? parsed : 0;

            // Wait for bots to finish
            t1.Join();
            t2.Join();

            // Display opponent answers
            foreach (var result in opponentResults)
            {
                Console.WriteLine($"{result.Name} answered {result.Answer} at {result.Time:HH:mm:ss.fff}");
            }

            Console.WriteLine($"You answered {userAnswer} at {userTime:HH:mm:ss.fff}");

            // Determine result
            bool userCorrect = userAnswer == correctAnswer;
            var fastest = GetFastest(userTime, opponentResults);
            TimeSpan diff = (userTime - fastest.Time).Duration();

            Console.WriteLine(userCorrect
                ? fastest.Name == "You"
                    ? $"Correct! You were the fastest by {userTime} ms." //orignal was diff.totalMilliseconds but didnt work.
                    : $"Correct! But {fastest.Name} was faster by {diff.TotalMilliseconds} ms."
                : fastest.Name == "You"
                    ? $"Incorrect. You were fast, but wrong."
                    : $"Incorrect and {fastest.Name} was faster by {fastest.Time} ms.");
        }

        Console.WriteLine("\nPress Enter to return to menu...");
        Console.ReadLine();
    }

    static void Opponent(string name, int answer, List<(string, int, DateTime)> results)
    {
        int delay = rnd.Next(1800, 3001);
        Thread.Sleep(delay);
        DateTime time = DateTime.Now;
        lock (results)
        {
            results.Add((name, answer, time));
        }
    }

   static (string Name, DateTime Time) GetFastest(DateTime userTime, List<(string Name, int Answer, DateTime Time)> results)
{
    var fastest = (Name: "You", Time: userTime);
    foreach (var result in results)
    {
        if (result.Time < fastest.Time)
            fastest = (result.Name, result.Time);
    }
    return fastest;
}
}