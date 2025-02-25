using System;

class Program {
    static void Main() {
        CustomStack stack = new CustomStack(100); // Custom stack with max size 100
        int[] poppedElements = new int[100]; // Array to store popped elements
        int poppedCount = 0; // Track how many elements are popped

        bool processingStack = true;
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
                      //  stack.PrintStack();
                    } else {
                     continue;
                    }
                }
                else if (parts[0] == "pop") {
                    int poppedValue = stack.Pop();
                    if (poppedValue != -1) { // -1 means empty stack
                        poppedElements[poppedCount++] = poppedValue; // Store popped value in array
                        Console.WriteLine($"Popped: {poppedValue}" + "\n");
                       // stack.PrintStack();
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
                                Console.WriteLine($"Searching List for item {target}, found it at index {stackArray.Length -1 - i}" + "\n");
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

        // Print final stack state
        Console.Write("Stack after processing & Unsorted Array: ");
        int[] finalStack = stack.ToArray();
        for (int i = finalStack.Length - 1; i >= 0; i--) {
            Console.Write(finalStack[i] + " ");
        }
        Console.WriteLine("\n");

        Console.Write("Sorted Array: ");
        int[] finalStack2 = stack.ToArray();
        int stackArray2size = finalStack2.Length;
        BubbleSort(finalStack2, stackArray2size);
        for (int i = 0; i < finalStack2.Length; i++) {
            Console.Write(finalStack2[i] + " ");
        }
        Console.WriteLine("\n");
    }

    // Custom Stack Implementation using an Array
    class CustomStack {
        private int[] stackArray;
        private int top; // Index of the last element

        public CustomStack(int size) {
            stackArray = new int[size];
            top = -1; // Stack is initially empty
        }

        public void Push(int value) {
            if (top >= stackArray.Length - 1) {
                Console.WriteLine("Stack overflow! Cannot push.");
                return;
            }
            stackArray[++top] = value; // Increment top, then assign value
        }

        public int Pop() {
            if (top == -1) {
                Console.WriteLine("Stack is empty! Cannot pop." + "\n");
                return -1; // Indicate empty stack
            }
            return stackArray[top--]; // Return top value, then decrement top
        }

        public int[] ToArray() {
            int[] result = new int[top + 1]; // Create new array with valid elements
            for (int i = 0; i <= top; i++) {
                result[i] = stackArray[i];
            }
            return result;
        }

        public void PrintStack() {
            if (top == -1) {
                Console.WriteLine("Current Stack: Empty");
            } else {
                Console.Write("Current Stack: ");
                for (int i = 0; i <= top; i++) {
                    Console.Write(stackArray[i] + " ");
                }
                Console.WriteLine();
            }
        }
    }

    // Method to manually sort an array (Bubble Sort)
    static void BubbleSort(int[] arr, int size) {
        for (int i = 0; i < size - 1; i++) {
            for (int j = 0; j < size - i - 1; j++) {
                if (arr[j] > arr[j + 1]) {  // Swap if out of order
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
}