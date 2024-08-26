using System;
using System.Collections.Generic;

/// <summary>
/// The DoOnce class ensures that specific tasks identified by unique keys are executed only once.
/// It provides two methods for executing tasks:
/// - Execute(string taskKey, Action action): Executes a void method (Action) once.
/// - Execute<T>(string taskKey, Func<T> function): Executes a method that returns a value (Func<T>) once,
///   returning the result on the first call and the default value for the type on subsequent calls.
/// Tasks are tracked using a HashSet to ensure efficient O(1) time complexity for both execution checks and additions.
/// </summary>
public class DoOnce
{
    private readonly HashSet<string> _executedTasks = new HashSet<string>();

    public void Execute(string taskKey, Action action)
    {
        if (_executedTasks.Contains(taskKey))
            return;

        action?.Invoke();
        _executedTasks.Add(taskKey);
    }

    public T Execute<T>(string taskKey, Func<T> function)
    {
        if (_executedTasks.Contains(taskKey))
            return default;

        T result = function();
        _executedTasks.Add(taskKey);
        return result;
    }
}

// Usage example:
public class Example
{
    static void Main(string[] args)
    {
        DoOnce doOnce = new DoOnce();

        // Task 1: Print a message (Action)
        doOnce.Execute("Print", () => Console.WriteLine("This will be printed once."));

        // Task 2: Perform a calculation and return the result (Func<int>)
        int result = doOnce.Execute("Calculate", () => 
        {
            int calculation = 2 + 2;
            Console.WriteLine($"Calculation result: {calculation}");
            return calculation;
        });

        // Task 3: Get a string value from a function (Func<string>)
        string value = doOnce.Execute("GetValue", () => 
        {
            string stringValue = "Hello, world!";
            Console.WriteLine($"String value: {stringValue}");
            return stringValue;
        });

        // Attempt to execute the same tasks again - these won't execute
        doOnce.Execute("Print", () => Console.WriteLine("This won't be printed."));
        int resultAgain = doOnce.Execute("Calculate", () => 3 + 3);
        string valueAgain = doOnce.Execute("GetValue", () => "This won't be returned.");

        Console.WriteLine($"Result again: {resultAgain}"); // Will print 0 (default int)
        Console.WriteLine($"Value again: {valueAgain}");  // Will print null (default string)
    }
}
