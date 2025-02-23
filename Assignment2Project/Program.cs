using System;
using System.Collections.Generic;

class Program {
    static void Main() {
        Stack<int> stack = new Stack<int>();
        bool processingStack = true;  // Tracks whether we are in the stack or find section
        int[] stackArray;

        string? line;
        while ((line = Console.ReadLine()) != null) {
            string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0) continue; // Ignore empty lines

            if (line == "(stack end)") {
                processingStack = false;
                //Console.WriteLine(string.Join("  ", stackArray) + "\n");
                continue;
            }
            if (line == "(find end)") {
               // Console.WriteLine("Find operations finished.");
                continue;
            }   

            if (processingStack) {
                if (parts[0] == "push") {
                    if (parts.Length == 2 && int.TryParse(parts[1], out int num)) {
                        stack.Push(num);
                        Console.WriteLine($"Pushed: {num}" + "\n");
                    } else {
                       // Console.WriteLine($"Invalid push operation: '{line}'");
                       continue;
                    }   
                } 
                else if (parts[0] == "pop") {
                    if (stack.Count > 0) {
                        Console.WriteLine($"Popped: {stack.Pop()}" + "\n");

                    } else {
                        Console.WriteLine("Stack is empty! Cannot pop." + "\n");
                    }
                }
            } 
            else { // Processing find commands
            int loop = 0;
            stackArray = stack.ToArray(); // Convert stack to array
                if (parts[0] == "find") {
                    if (parts.Length == 2 && int.TryParse(parts[1], out int target)) {
                        bool found = false;
                        // Stack stores elements in reverse order, so index is reversed
                        for (int i = 0; i < stackArray.Length; i++) {
                            if (stackArray[i] == target) {
                                Console.WriteLine($"Searching List for item {target}, found it at index {i}" + "\n");
                                found = true;
                            }
                        }

                        if (!found) {
                            Console.WriteLine($"{target} not found");
                        }
                    } else {
                        continue;
                    }
                }
            }
        }
        //Console.WriteLine("Unsorted Array: ");
    }
}
