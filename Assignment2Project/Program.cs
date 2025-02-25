using System;
using System.Collections.Generic;

class Program {
    static void Main() {
        Stack<int> stack = new Stack<int>();
        List<int> poppedElements = new List<int>(); // Stores popped elements
        bool processingStack = true;  // Tracks whether we are in the stack or find section

        string? line;
        while ((line = Console.ReadLine()) != null) {
            string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0) continue; // Ignore empty lines

            if (line == "(stack end)") {
                processingStack = false;
                continue;
            }
            if (line == "(find end)") {
                continue;
            }   

            if (processingStack) {
                if (parts[0] == "push") {
                    if (parts.Length == 2 && int.TryParse(parts[1], out int num)) {
                        stack.Push(num);
                        Console.WriteLine($"Pushed: {num}" + "\n");
                    } else {
                        continue;
                    }   
                } 
                else if (parts[0] == "pop") {
                    if (stack.Count > 0) {
                        int poppedValue = stack.Pop();
                        poppedElements.Add(poppedValue); // Store in the list
                        Console.WriteLine($"Popped: {poppedValue}" + "\n");
                    } else {
                        Console.WriteLine("Stack is empty! Cannot pop."+"\n");
                    }
                }
            } 
            else { // Processing find commands
                int[] stackArray = stack.ToArray(); // Convert stack to array
                if (parts[0] == "find") {
                    if (parts.Length == 2 && int.TryParse(parts[1], out int target)) {
                        bool found = false;
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

        // Convert list to array and print its contents
        int[] poppedArray = poppedElements.ToArray();
        Console.WriteLine("\nPopped Elements: " + string.Join(" ", poppedArray) + "\n");
        Console.WriteLine("Stack after processing: " + string.Join(" ", stack.ToArray()) + "\n");
        int[] stackedArray = stack.ToArray();
        Console.WriteLine("Unsorted Array: " + string.Join(" ", stackedArray) + "\n");
        Array.Sort(stackedArray);
        Console.WriteLine("Sorted Array: " + string.Join(" ", stackedArray) + "\n");
    }
}
