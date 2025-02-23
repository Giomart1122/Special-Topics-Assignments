using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    static void Main() {
        Stack<int> stack = new Stack<int>();
        bool processingStack = true;  // Tracks whether we are in the stack or find section

        string? line;
        while ((line = Console.ReadLine()) != null) {
            string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0) continue; // Ignore empty lines

            if (line == "(stack end)") {
                processingStack = false;
                continue; // Stop processing stack commands
            }

            if (parts[0] == "push") {
                if (parts.Length == 2 && int.TryParse(parts[1], out int num)) {
                    stack.Push(num);
                    Console.WriteLine($"Pushed {num}\n");
                } else {
                   // Console.WriteLine($"Invalid push operation: '{line}'\n");
                   continue;
                }
            } 
            else if (parts[0] == "pop") {
                if (stack.Count > 0) {
                    Console.WriteLine($"Popped {stack.Pop()}\n");
                } else {
                    Console.WriteLine("Stack is empty! Cannot pop.\n");
                }
            }
        }

        // Display stack contents after processing
        int[] stackArray = stack.ToArray();
        Console.Write("\nStack after processing:  ");
        Console.WriteLine(string.Join("   ", stackArray) + "\n");

        // Process find operations
        while ((line = Console.ReadLine()) != null) {
            string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (line == "(find end)") {
                continue; // Stop processing find commands
            }

            if (parts[0] == "find") {
                if (parts.Length == 2 && int.TryParse(parts[1], out int target)) {
                    Console.Write($"Searching list for item {target}, ");
                    int index = Array.IndexOf(stackArray, target);
                    if (index != -1) {
                        Console.WriteLine($"found it in array position {index}.\n");
                    } else {
                        Console.WriteLine("did not find it in the array.\n");
                    }
                } else {
                    Console.WriteLine($"Invalid find operation: '{line}'\n");
                }
            }
        }

        // Print unsorted and sorted arrays
        Console.Write("Unsorted Array: ");
        Console.WriteLine(string.Join("   ", stackArray) + "\n");

        Array.Sort(stackArray);
        Console.Write("Sorted Array:  ");
        Console.WriteLine(string.Join("   ", stackArray) + "\n");
    }
}