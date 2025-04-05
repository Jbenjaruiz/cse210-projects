// Activity.cs
using System;
using System.Collections.Generic;
using System.Threading;

// Base class for all mindfulness activities
public abstract class Activity
{
    // Member variables accessible by derived classes
    protected string _name;
    protected string _description;
    protected int _duration; // Duration in seconds

    // List of spinner characters for animation
    private readonly List<string> _spinnerChars = new List<string> { "|", "/", "-", "\\" };

    // Constructor (parameterless, name/description set in derived classes)
    public Activity()
    {
        // Initialize with default values, will be overwritten by derived classes
        _name = "Unnamed Activity";
        _description = "No description provided.";
        _duration = 0; // Default duration
    }

    // Displays the starting message, description, and prompts for duration
    public void DisplayStartingMessage()
    {
        Console.Clear(); // Clear console for a fresh start
        Console.WriteLine($"Welcome to the {_name}");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        // Prompt user for duration
        Console.Write("How long, in seconds, would you like for your session? ");
        while (!int.TryParse(Console.ReadLine(), out _duration) || _duration <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive number of seconds.");
            Console.Write("How long, in seconds, would you like for your session? ");
        }

        Console.Clear(); // Clear console after getting duration
        Console.WriteLine("Get ready...");
        ShowSpinner(5); // Pause for 5 seconds with spinner
    }

    // Displays the common ending message
    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3); // Pause for 3 seconds

        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(5); // Pause for 5 seconds before finishing
        Console.Clear(); // Clear console before returning to menu
    }

    // Displays a spinner animation for a specified duration
    public void ShowSpinner(int seconds)
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        int spinnerIndex = 0;

        while (DateTime.Now < endTime)
        {
            string s = _spinnerChars[spinnerIndex];
            Console.Write(s);
            Thread.Sleep(200); // Pause for 0.2 seconds
            Console.Write("\b \b"); // Erase the previous character

            spinnerIndex++;
            if (spinnerIndex >= _spinnerChars.Count)
            {
                spinnerIndex = 0;
            }
        }
        Console.Write(" "); // Clear the final spinner character spot
    }

    // Displays a countdown timer for a specified duration
    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i}");
            Thread.Sleep(1000); // Pause for 1 second
            // Overwrite the number (adjust backspaces based on number of digits)
            string backspaces = new string('\b', i.ToString().Length);
            string spaces = new string(' ', i.ToString().Length);
            Console.Write($"{backspaces}{spaces}{backspaces}");
        }
         Console.Write(" "); // Clear the final countdown spot (optional)
    }

    // Abstract method to be implemented by each specific activity
    public abstract void RunActivity();

    // Public method to run the entire activity flow
    public void Run()
    {
        DisplayStartingMessage();
        RunActivity(); // Call the specific implementation
        DisplayEndingMessage();
    }
}