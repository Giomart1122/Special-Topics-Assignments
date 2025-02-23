using System;
using System.Collections.Generic;

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
                Console.WriteLine("Stack processing finished.\n");
                continue;
            }
            if (line == "(find end)") {
                Console.WriteLine("Find operations finished.");
                break;
            }

            if (processingStack) {
                if (parts[0] == "push") {
                    if (parts.Length == 2 && int.TryParse(parts[1], out int num)) {
                        stack.Push(num);
                        Console.WriteLine($"Pushed: {num}");
                    } else {
                        Console.WriteLine($"Invalid push operation: '{line}'");
                    }
                } 
                else if (parts[0] == "pop") {
                    if (stack.Count > 0) {
                        Console.WriteLine($"Popped: {stack.Pop()}");
                    } else {
                        Console.WriteLine("Stack is empty! Cannot pop.");
                    }
                }
            } 
            else { // Processing find commands
                if (parts[0] == "find") {
                    if (parts.Length == 2 && int.TryParse(parts[1], out int target)) {
                        int[] stackArray = stack.ToArray(); // Convert stack to array
                        bool found = false;

                        // Stack stores elements in reverse order, so index is reversed
                        for (int i = 0; i < stackArray.Length; i++) {
                            if (stackArray[i] == target) {
                                Console.WriteLine($"Found {target} at index {i}");
                                found = true;
                            }
                        }

                        if (!found) {
                            Console.WriteLine($"{target} not found");
                        }
                    } else {
                        Console.WriteLine($"Invalid find operation: '{line}'");
                    }
                }
            }
        }
    }
}
