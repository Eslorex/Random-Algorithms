using System;

public class Select<T>
{
    private readonly T[] _options;

    public Select(params T[] options)
    {
        _options = options;
    }

    public T Choose(int index)
    {
        if (index >= 0 && index < _options.Length)
        {
            return _options[index];
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }
    }
}

// Usage example:
public class Example
{
    static void Main(string[] args)
    {
        // Example with integers
        Select<int> intSelect = new Select<int>(10, 20, 30, 40);

        int selectedValue = intSelect.Choose(2);  // Choose the third option (index 2)
        Console.WriteLine($"Selected Value: {selectedValue}");  // Outputs: Selected Value: 30

        // Example with strings
        Select<string> stringSelect = new Select<string>("Option A", "Option B", "Option C");

        string selectedString = stringSelect.Choose(0);  // Choose the first option (index 0)
        Console.WriteLine($"Selected String: {selectedString}");  // Outputs: Selected String: Option A
    }
}
