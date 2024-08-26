using System;
using System.Collections.Generic;

public class Sequence
{
    private readonly List<Action> _actions;

    public Sequence()
    {
        _actions = new List<Action>();
    }

    public void AddAction(Action action)
    {
        _actions.Add(action);
    }

    public void Execute()
    {
        foreach (var action in _actions)
        {
            action?.Invoke();
        }
    }
}

// Usage example:
public class Example
{
    static void Main(string[] args)
    {
        Sequence sequence = new Sequence();

        // Adding actions to the sequence
        sequence.AddAction(() => Console.WriteLine("Action 1: This is the first action."));
        sequence.AddAction(() => Console.WriteLine("Action 2: This is the second action."));
        sequence.AddAction(() => Console.WriteLine("Action 3: This is the third action."));

        // Execute all actions in sequence
        sequence.Execute();
    }
}
